using Eclipseworks.Entity;
using Eclipseworks.Model;

namespace Eclipseworks.Service
{
    public class RelatoriosService : IRelatoriosService
    {
        private readonly ApplicationDbContext _db;
        public RelatoriosService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<long> RelatorioMediaTarefasConcluidasUltimoMes(int idUsuario)
        {
           if (ValidarFuncaoUsuario(idUsuario))
           {
                //número médio de tarefas concluídas por usuário nos últimos 30 dias
                var tarefas = _db.Tarefas.Where(t => t.Status == "concluida" && t.DataInclusao > DateTime.Now.AddDays(-30));

                var totalUsuariosComTarefasConcluidas = tarefas
                .Select(x => new
                {
                    Usuario = x.IdUsuario
                }
                ).Distinct().Count();

                var mediaTarefasConcluidasUltimoMes = tarefas.Count() / totalUsuariosComTarefasConcluidas;

                return mediaTarefasConcluidasUltimoMes;
            }

            return -1;

          
        }

        public async Task<List<Relatorio>> RelatorioTarefasConcluidasUltimoMesPorUsuario(int idUsuario)
        {
            if (ValidarFuncaoUsuario(idUsuario))
            {
                //número médio de tarefas concluídas por usuário nos últimos 30 dias
                var tarefasTotais = _db.Tarefas.Where(t => t.Status == "concluida" && t.DataInclusao > DateTime.Now.AddDays(-30))
                 .GroupBy(e => e.IdUsuario)
                    .Select(group => new Relatorio
                    {
                        IdUsuario = group.Key,
                        QuantidadaTarefasConcluidas = group.Count()
                    })
                    .ToList();

                //get name usuario
                var resultadoFinal = tarefasTotais
                .GroupJoin(_db.Usuarios,
                    p => p.IdUsuario,
                    u => u.Id,
                    (relatorio, usuario) => new { relatorio, usuario })
                .SelectMany(
                    g => g.usuario.DefaultIfEmpty(),
                    (a, e) => new Relatorio()
                    {
                        NomeUsuario = a.usuario.FirstOrDefault().Nome,
                        IdUsuario = a.usuario.FirstOrDefault().Id,
                        QuantidadaTarefasConcluidas = a.relatorio.QuantidadaTarefasConcluidas

                    }).ToList();

                return resultadoFinal;
            }

            return null;
        }
        private bool ValidarFuncaoUsuario(int idUsuario)
        {
            var usuario = _db.Usuarios.Where(u => u.Id == idUsuario).FirstOrDefault();

            if (usuario.Funcao == "gerente")
            {
                return true;
            }

            return false;

        }
    }
}

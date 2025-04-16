using Eclipseworks.Entity;
using Eclipseworks.Model;
using Microsoft.EntityFrameworkCore;

namespace Eclipseworks.Service
{
    public class ProjetosService : IProjetosService
    {
        private readonly ApplicationDbContext _db;
        public ProjetosService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Projeto>> GetAllProjetos()
        {
            return await _db.Projetos.ToListAsync();
        }

        public async Task<Projeto?> AddProjeto(Projeto obj)
        {
            var addProjeto = new Projeto()
            {
                IdUsuario = obj.IdUsuario,
                NomeProjeto = obj.NomeProjeto
            };

            _db.Projetos.Add(addProjeto);
            var result = await _db.SaveChangesAsync();
            return result >= 0 ? addProjeto : null;
        }

        public async Task<int> DeleteProjetoByID(int idProjeto)
        {
            var valido = await ValidaProjetoTemTarefaAtiva(idProjeto);

            if (valido)
            {
                var projetos = await _db.Projetos.FirstOrDefaultAsync(index => index.Id == idProjeto);
                if (projetos != null)
                {
                    _db.Projetos.Remove(projetos);
                    var result = await _db.SaveChangesAsync();
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return -1;
            }
        }
        private async Task<bool> ValidaProjetoTemTarefaAtiva(int idProjeto)
        {
            var totalTarefaAtivaProjeto = _db.Tarefas.Where(t => t.IdProjeto == idProjeto && t.Status != "concluida").Count();

            if (totalTarefaAtivaProjeto > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}

using Eclipseworks.Entity;
using Eclipseworks.Model;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Security.Cryptography;

namespace Eclipseworks.Service
{
    public class TarefasService : ITarefasService
    {
        private readonly ApplicationDbContext _db;
        public TarefasService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Tarefa>> GetAllTarefas()
        {
            return await _db.Tarefas.ToListAsync();
        }

        public async Task<int> AddTarefa(Tarefa obj)
        {

            var valido = await ValidaLimiteTarefasPorProjeto(obj.IdProjeto);

            if (valido)
            {
                var addTarefa = new Tarefa()
                {
                    IdProjeto = obj.IdProjeto,
                    IdUsuario = obj.IdUsuario,
                    Titulo = obj.Titulo,
                    Descricao = obj.Descricao,
                    DataVencimento = obj.DataVencimento,
                    DataInclusao = DateTime.Now,
                    Status = obj.Status,
                    Prioridade = obj.Prioridade,
                    Comentarios = obj.Comentarios
                };

                _db.Tarefas.Add(addTarefa);

                var addProjetoTarefas = new ProjetoTarefas()
                {
                    IdProjeto = obj.IdProjeto,
                    IdTarefa = addTarefa.Id
                };

                _db.ProjetoTarefas.Add(addProjetoTarefas);

                var result = await _db.SaveChangesAsync();
                return result >= 0 ? addTarefa.Id : 0;
            }
            else
            {
                return -1;
            }
        }

        public async Task<Tarefa?> UpdateTarefa(int id, Tarefa tarefaAlterada)
        {
            var tarefaOriginal = await _db.Tarefas.FirstOrDefaultAsync(index => index.Id == id);

            var alteracoes = await GetAlteraçoes(tarefaOriginal, tarefaAlterada);

            if (tarefaOriginal != null)
            {
                tarefaOriginal.IdProjeto = tarefaAlterada.IdProjeto;
                tarefaOriginal.IdUsuario = tarefaAlterada.IdUsuario;
                tarefaOriginal.Titulo = tarefaAlterada.Titulo;
                tarefaOriginal.Descricao = tarefaAlterada.Descricao;
                tarefaOriginal.DataVencimento = tarefaAlterada.DataVencimento;
                tarefaOriginal.Status = tarefaAlterada.Status;
                tarefaOriginal.Prioridade = tarefaAlterada.Prioridade;
                tarefaOriginal.Comentarios = tarefaAlterada.Comentarios;

                var idUsuario = await GetIdUsuario(tarefaOriginal.IdProjeto);

                var historico = new Historico()
                {
                    IdTarefa = tarefaOriginal.Id,
                    IdUsuario = idUsuario,
                    Alteracao = alteracoes,
                    DataAlteracao = DateTime.Now
                };

                _db.Historicos.Add(historico);

                var result = await _db.SaveChangesAsync();

                return result >= 0 ? tarefaOriginal : null;
            }
            return null;
        }

        public async Task<bool> DeleteTarefaByID(int idProjeto)
        {
            var Tarefas = await _db.Tarefas.FirstOrDefaultAsync(index => index.Id == idProjeto);
            if (Tarefas != null)
            {
                _db.Tarefas.Remove(Tarefas);
                var result = await _db.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }
        private async Task<int> GetIdUsuario(int idProjeto)
        {
            return _db.Projetos.Where(p => p.Id == idProjeto).FirstOrDefault().IdUsuario;
        }

        private async Task<string> GetAlteraçoes(Tarefa original, Tarefa alterada)
        {
            var diferencas = "";

            if (original.Titulo != alterada.Titulo)
            {
                diferencas = $"Titulo alterado de {original.Titulo} para {alterada.Titulo}. ";
            }
            if (original.Descricao != alterada.Descricao)
            {
                diferencas += $"Descricao alterado de {original.Descricao} para {alterada.Descricao}. ";
            }
            if (original.Status != alterada.Status)
            {
                diferencas += $"Status alterado de {original.Status} para {alterada.Status}. ";
            }
            if (original.Comentarios != alterada.Comentarios)
            {
                diferencas += $"Comentarios alterado de {original.Comentarios} para {alterada.Comentarios}. ";
            }

            return diferencas;
        }

        private async Task<bool> ValidaLimiteTarefasPorProjeto(int idProjeto)
        {
            var totalTarefasProjeto = _db.Tarefas.Where(t => t.IdProjeto == idProjeto).Count();

            if (totalTarefasProjeto < 20)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

    }
}

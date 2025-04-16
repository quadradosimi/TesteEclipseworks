using Eclipseworks.Model;

namespace Eclipseworks.Service
{
    public interface ITarefasService
    {
        Task<List<Tarefa>> GetAllTarefas();
        Task<int> AddTarefa(Tarefa obj);
        Task<Tarefa?> UpdateTarefa(int id, Tarefa obj);
        Task<bool> DeleteTarefaByID(int id);
    }
}

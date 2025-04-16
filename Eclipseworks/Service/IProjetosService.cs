using Eclipseworks.Model;

namespace Eclipseworks.Service
{
    public interface IProjetosService
    {
        Task<List<Projeto>> GetAllProjetos();
        Task<Projeto?> AddProjeto(Projeto obj);
        Task<int> DeleteProjetoByID(int id);
    }
}

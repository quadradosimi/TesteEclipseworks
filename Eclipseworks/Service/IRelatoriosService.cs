using Eclipseworks.Model;

namespace Eclipseworks.Service
{
    public interface IRelatoriosService
    {
        Task<List<Relatorio>> RelatorioTarefasConcluidasUltimoMesPorUsuario(int idUsuario);
        Task<long> RelatorioMediaTarefasConcluidasUltimoMes(int idUsuario);
    }
}

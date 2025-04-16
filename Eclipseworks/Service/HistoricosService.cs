using Eclipseworks.Entity;
using Eclipseworks.Model;

namespace Eclipseworks.Service
{
    public class HistoricosService : IHistoricosService
    {
        private readonly ApplicationDbContext _db;
        public HistoricosService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddHistorico(Historico obj)
        {
            var addHistoricos = new Historico()
            {
                IdTarefa = obj.IdTarefa,
                IdUsuario = obj.IdUsuario,
                Alteracao = obj.Alteracao,
                DataAlteracao = obj.DataAlteracao
            };

            _db.Historicos.Add(addHistoricos);
            var result = await _db.SaveChangesAsync();
        }       
    }
}

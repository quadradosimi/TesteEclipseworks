namespace Eclipseworks.Model
{
    public class Historico
    {
        public int Id { get; set; }
        public int IdTarefa { get; set; }
        public int IdUsuario { get; set; }
        public string Alteracao { get; set; }
        public DateTime DataAlteracao { get; set; }

    }
}

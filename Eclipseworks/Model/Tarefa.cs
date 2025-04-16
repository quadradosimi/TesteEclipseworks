namespace Eclipseworks.Model
{
    public class Tarefa
    {
        public int Id { get; set; }
        public int IdProjeto { get; set; }
        public int IdUsuario{ get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataInclusao { get; set; }
        public string Status { get; set; }// (pendente, em andamento, concluída).
        public string Prioridade { get; set; }// (baixa, média, alta)
        public string Comentarios { get; set; }

    }
}

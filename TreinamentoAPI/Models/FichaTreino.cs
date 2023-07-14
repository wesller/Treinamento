namespace TreinamentoAPI.Models
{
    public class FichaTreino
    {
        public int Id { get; set; }

        public DivisaoTreino Divisao { get; set; }
        
        public string Name { get; set; }
        
        public string? Descricao { get; set;}

        public int TempoDescanco { get; set;}

        public List<Serie> Exercicios { get; set; }
    }
}

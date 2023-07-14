namespace TreinamentoAPI.Models
{
    public class Serie
    {
        public int Id { get; set; }

        public char DivisaoTreino { get; set; }
        
        public Exercicio Exercicio { get; set; }

        public int Minimo { get; set; }

        public int Maximo { get; set; }

        public int Carga { get; set; }
    }
}

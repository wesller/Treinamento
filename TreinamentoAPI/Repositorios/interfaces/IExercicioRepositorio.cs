using TreinamentoAPI.Models;

namespace TreinamentoAPI.Repositorios.interfaces
{
    public interface IExercicioRepositorio
    {
        Task<List<Exercicio>> BuscarTodosUsuarios();
        
        Task<Exercicio> BuscarPorId(int id);

        Task<Exercicio> Adicionar(Exercicio exercicio);

        Task<Exercicio> Atualizar(Exercicio exercicio, int id);

        Task<bool> Apagar(int id);
    }
}

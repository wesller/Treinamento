using Microsoft.EntityFrameworkCore;
using TreinamentoAPI.Data;
using TreinamentoAPI.Models;
using TreinamentoAPI.Repositorios.interfaces;

namespace TreinamentoAPI.Repositorios
{
    public class ExercicioRepositorio : IExercicioRepositorio
    {
        private readonly TreinamentoAPIDBContext _dbContext;

        public ExercicioRepositorio(TreinamentoAPIDBContext context)
        {
            _dbContext = context;
        }

        public async Task<Exercicio> BuscarPorId(int id)
        {
            return await _dbContext.Exercicios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Exercicio>> BuscarTodosUsuarios()
        {
            return await _dbContext.Exercicios.ToListAsync();
        }

        public async Task<Exercicio> Adicionar(Exercicio exercicio)
        {
            await _dbContext.Exercicios.AddAsync(exercicio);
            await _dbContext.SaveChangesAsync();
            return exercicio;
        }

        public async Task<bool> Apagar(int id)
        {
            Exercicio exercicioPorId = await BuscarPorId(id);

            if (exercicioPorId == null)
            {
                throw new Exception($"Exercicio para o ID {id} não foi encontrado no banco de dados");
            }

            _dbContext.Exercicios.Remove(exercicioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Exercicio> Atualizar(Exercicio exercicio, int id)
        {
            Exercicio exercicioPorId = await BuscarPorId(id);

            if (exercicioPorId == null)
            {
                throw new Exception($"Exercicio para o ID {id} não foi encontrado no banco de dados");
            }

            exercicioPorId.Nome = exercicio.Nome;
            exercicioPorId.Descricao = exercicio.Descricao;
            exercicioPorId.link = exercicio.link;

            _dbContext.Exercicios.Update(exercicioPorId);
            await _dbContext.SaveChangesAsync();

            return exercicioPorId;
        }

       
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TreinamentoAPI.Models;
using TreinamentoAPI.Repositorios.interfaces;

namespace TreinamentoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercicioController : ControllerBase
    {
        private readonly IExercicioRepositorio _exercicioRepositorio;

        public ExercicioController(IExercicioRepositorio exercicioRepositorio)
        {
            _exercicioRepositorio = exercicioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Exercicio>>> BuscarTodosExercicios()
        {
            List<Exercicio> exercicios = await _exercicioRepositorio.BuscarTodosUsuarios();
            return Ok(exercicios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Exercicio>>> BuscarPorId(int id)
        {
            Exercicio exercicio = await _exercicioRepositorio.BuscarPorId(id);
            return Ok(exercicio);
        }

        [HttpPost]
        public async Task<ActionResult<Exercicio>> Cadastrar([FromBody]Exercicio exercicio)
        {
            await _exercicioRepositorio.Adicionar(exercicio);
            return Ok(exercicio);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Exercicio>> Atualizar([FromBody] Exercicio exercicio, int id)
        {
            exercicio.Id = id;
            await _exercicioRepositorio.Atualizar(exercicio, id);
            return Ok(exercicio);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Exercicio>> Apagar(int id)
        {
            bool apagado = await _exercicioRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}

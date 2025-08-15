using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using API_PetShop.Context;
using API_PetShop.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API_PetShop.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CachorroController : ControllerBase
    {

        private readonly PetShopContext _context;

        public CachorroController(PetShopContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Criar(Cachorro cachorro)
        {
            _context.Add(cachorro);
            _context.SaveChanges();

            return Ok(cachorro);
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            var cachorros = _context.Cachorros;
            return Ok(cachorros);
        }

        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            var cachorro = _context.Cachorros.Where(x => x.Nome.Contains(nome));
            return Ok(cachorro);
        }

        [HttpGet("ObterPorPorte")]
        public IActionResult ObterPorPorte(EnumPorte porte)
        {

            var cachorro = _context.Cachorros.Where(x => x.Porte == porte);

            return Ok(cachorro);
        }

        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var cachorro = _context.Cachorros.Where(x => x.DataDoBanho.Date == data.Date);
            if (!cachorro.Any())
                return NotFound();
                
            return Ok(cachorro);
        }

        [HttpPut]
        public IActionResult Atualizar(int id, Cachorro cachorro)
        {
            var cachorroAtualizado = _context.Cachorros.Find(id);
            if (cachorroAtualizado == null)
                return NotFound();

            cachorroAtualizado.Nome = cachorro.Nome;
            cachorroAtualizado.Raca = cachorro.Raca;
            cachorroAtualizado.Porte = cachorro.Porte;
            cachorroAtualizado.ValorBanho = cachorro.ValorBanho;
            cachorroAtualizado.DataDoBanho = cachorro.DataDoBanho;

            _context.Cachorros.Update(cachorroAtualizado);
            _context.SaveChanges();

            return Ok(cachorroAtualizado);

        }

        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            var cachorroDeletar = _context.Cachorros.Find(id);
            if (cachorroDeletar == null)
                return NotFound();

            _context.Cachorros.Remove(cachorroDeletar);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

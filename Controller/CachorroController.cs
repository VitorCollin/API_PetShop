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
            return Ok(cachorro);
        }
    }
}

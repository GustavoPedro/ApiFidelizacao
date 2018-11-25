using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFidelizacao1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiFidelizacao1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartaoController : ControllerBase
    {
        private readonly fidelizacaoContext _context;
        public CartaoController(fidelizacaoContext context)
        {
            _context = context;
        }
        // Seleciona todos os clientes
        [HttpGet]
        public ActionResult<List<Cartao>> GetCartoes()
        {
         return null;
        }
        // GET seleciona todos clientes por cpf
        [HttpGet("{id}", Name="GetCartao")]
        public ActionResult<List<Cartao>> GetCartoesPorId(int id)
        {
            return  _context.Cartao
            .Where(cod => cod.NumeroCartao == id).ToList();            
            
        }

        // POST api/values
        // [HttpPost]
        // public IActionResult Post([FromBody] Cliente cliente)
        // {
        //     _context.Cliente.Add(cliente);
        //     _context.SaveChanges();
        //     //Retorna o id inserido
        //     return CreatedAtRoute("GetClientes", new {
        //         cliente.Cpf                
        //     }, cliente);
        // }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

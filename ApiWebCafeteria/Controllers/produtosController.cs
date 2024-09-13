﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiWebCafeteria.Data;
using ApiWebCafeteria.Models;

namespace ApiWebCafeteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class produtosController : ControllerBase
    {
        private readonly DBContext _context;

        public produtosController(DBContext context)
        {
            _context = context;
        }

        // GET: api/produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<produto>>> Getproduto()
        {
          if (_context.produto == null)
          {
              return NotFound();
          }
            return await _context.produto.ToListAsync();
        }

        // GET: api/produtos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<produto>> Getproduto(int id)
        {
          if (_context.produto == null)
          {
              return NotFound();
          }
            var produto = await _context.produto.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        // PUT: api/produtos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putproduto(int id, produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!produtoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/produtos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<produto>> Postproduto(produto produto)
        {
          if (_context.produto == null)
          {
              return Problem("Entity set 'DBContext.produto'  is null.");
          }
            _context.produto.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getproduto", new { id = produto.Id }, produto);
        }

        // DELETE: api/produtos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteproduto(int id)
        {
            if (_context.produto == null)
            {
                return NotFound();
            }
            var produto = await _context.produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.produto.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool produtoExists(int id)
        {
            return (_context.produto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

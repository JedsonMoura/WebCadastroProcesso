using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebCadastroProcessos.Data;
using WebCadastroProcessos.Dto;
using WebCadastroProcessos.Models;

namespace WebCadastroProcessos.Controllers
{
    public class ProcessoController : Controller
    {
        private readonly Contexto _context;

        public ProcessoController(Contexto context)
        {
            _context = context;
        }

        public IActionResult Index(string npu, DateTime? dataCadastro, string uf, int page = 1)
        {
            int pageSize = 10;
            var processos = _context.Processo.AsQueryable();

            if (!string.IsNullOrEmpty(npu))
            {
                processos = processos.Where(p => p.Npu.Contains(npu));
            }

            if (dataCadastro.HasValue)
            {
                processos = processos.Where(p => p.DataCadastro.Date == dataCadastro.Value.Date);
            }

            if (!string.IsNullOrEmpty(uf))
            {
                processos = processos.Where(p => p.Uf == uf);
            }

            var totalCount = processos.Count();
            var totalPages = totalCount > 0 ? (int)Math.Ceiling(totalCount / (double)pageSize) : 0;

            var processosPage = processos.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentNpu = npu;
            ViewBag.CurrentDataCadastro = dataCadastro?.ToString("yyyy-MM-dd");
            ViewBag.CurrentUf = uf;
            ViewBag.Uf = this.buscarUf();

            return View(processosPage);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Processo == null)
            {
                return NotFound();
            }

            var processo = await _context.Processo
                .FirstOrDefaultAsync(m => m.Id == id);

            if (processo == null)
            {
                return NotFound();
            }

            processo.DataVisualizacao = DateTime.Now;

            _context.Update(processo);
            await _context.SaveChangesAsync();

            return View(processo);
        }

        public IActionResult Create()
        {
            ViewBag.Uf = this.buscarUf();
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processo = await _context.Processo.FindAsync(id);
            if (processo == null)
            {
                return NotFound();
            }
            var ufList = new List<SelectListItem>();
            foreach (var uf in buscarUf())
            {
                ufList.Add(new SelectListItem
                {
                    Value = uf,
                    Text = uf,
                    Selected = uf == processo.Uf
                });
            }
            ViewBag.Uf = ufList;
            var municipios = await GetMunicipios(processo.Uf);
            ViewBag.Municipios = municipios.Select(municipio => new SelectListItem
            {
                Value = municipio.Nome,
                Text = municipio.Nome,
                Selected = municipio.Nome == processo.Municipio
            }).ToList();

            return View(processo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Npu,Uf,Municipio")] Processo processo)
        {
            if (ModelState.IsValid)
            {
                processo.DataCadastro = DateTime.Now;
                _context.Add(processo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(processo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Npu,Uf,Municipio")] Processo processo)
        {
            if (id != processo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    processo.DataCadastro = DateTime.Now; // O Correto é possui outro campo "DataAtualizacao", Porém não esta definido no escopo.
                    _context.Update(processo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessoExists(processo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(processo);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Processo == null)
            {
                return NotFound();
            }

            var processo = await _context.Processo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (processo == null)
            {
                return NotFound();
            }

            return View(processo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Processo == null)
            {
                return Problem("Entity set 'Contexto.Processo' is null.");
            }
            var processo = await _context.Processo.FindAsync(id);
            if (processo != null)
            {
                _context.Processo.Remove(processo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcessoExists(int id)
        {
            return (_context.Processo?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet]
        public async Task<List<MunicipioDTO>> GetMunicipios(string uf)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{uf}/distritos");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var municipios = JsonConvert.DeserializeObject<List<MunicipioDTO>>(content);
                return municipios;
            }

            return new List<MunicipioDTO>(); 
        }

        public List<string> buscarUf()
        {
            return new List<string>
            {
                "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO",
                "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE","PI",
                "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO"
            };
        }

    }
}

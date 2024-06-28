using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ClientePainel.Models;
using ClientePainel.Data;

namespace ClientePainel.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<ClientesController> clientes = Cliente.GetClientes(_context);
            return View(clientes);
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.AddCliente(_context);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public IActionResult Edit(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.UpdateCliente(_context);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public IActionResult Delete(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(in id)
        {
            Cliente.DeleteCliente(id, _context);
            return RedirectToAction("Index");
        }

    }

}
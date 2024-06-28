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
    }
}
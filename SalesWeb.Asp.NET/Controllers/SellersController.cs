using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWeb.Asp.NET.Models;
using SalesWeb.Asp.NET.Models.ViewModels;
using SalesWeb.Asp.NET.Services;

namespace SalesWeb.Asp.NET.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            //passando a lista de vendedores
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//Evita ataques maliciosos

        //passa os dados do vendedor para o metodo Insert depois atualiza a pagina
        public IActionResult Create(Seller seller)
        {            
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index)); // atualiza a pagina pra index
        }
    }
}
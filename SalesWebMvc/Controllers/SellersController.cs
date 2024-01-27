﻿using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        //Por padrão já é um get
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        //Por padrão,uma chamada normal é um get
        //Quando for uma ação diferente, deve ser indicada através das annotations
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            bool sucess = _sellerService.Insert(seller);
            //Redireciona à tela principal de Sellers
            return RedirectToAction(nameof(Index));
        }
    }
}
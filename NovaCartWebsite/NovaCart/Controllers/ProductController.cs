using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovaCart.Data;
using NovaCart.Models;
using System.Collections.Generic;

namespace NovaCart.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Details(
            string name,
            string image,
            string price,
            string description)
        {
            ViewBag.Name = name;
            ViewBag.Image = image;
            ViewBag.Price = price;
            ViewBag.Description = description;

            return View();
        }


    }


    }

using ProcessoSeletivo.Models.Domain.Entities;
using ProcessoSeletivo.Models.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProcessoSeletivo.Controllers
{
    public class ProductController : Controller
    {
        private ICategoryRepository _CategoryRepository;
        private IProductRepository _ProductRepository;

        public ProductController()
        {
            this._CategoryRepository = new CategoryRepository();
            this._ProductRepository = new ProductRepository();
        }

        public ActionResult Create()
        {
            ViewData["Categories"] = _CategoryRepository.FindAll();
            return View();
        }
      
        [HttpPost]
        public ActionResult Create(Product product, int[] categories)
        {
            product.Categories = _CategoryRepository.FindAllByIds(categories);
            _ProductRepository.Save(product);
            return RedirectToAction("Index", "Category");
        }
       
    }
}

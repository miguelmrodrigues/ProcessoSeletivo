using ProcessoSeletivo.Models.Domain.Entities;
using ProcessoSeletivo.Models.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProcessoSeletivo.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository _CategoryRepository;
        private IProductRepository _ProductRepository;

        public CategoryController()
        {
            this._CategoryRepository = new CategoryRepository();
            this._ProductRepository = new ProductRepository();
        }

        public ActionResult Index()
        {
            ViewData["Products"] = _ProductRepository.FindAll();
            ViewData["Categories"] = _CategoryRepository.FindAll();
            return View();
        }

        public ActionResult View(int id)
        {
            Category _Category = _CategoryRepository.FindById(id);
            ViewData["Categories"] = _CategoryRepository.FindAll();

            if (_Category.ParentCategory != null)
            {
                ViewData["Products"] = _Category.Products;
            }
            else
            {
                ViewData["Products"] = this.GetChildProducts(_Category);
            }

            return View("index");
        }
        
        public ActionResult Create()
        {
            ViewData["Categories"] = _CategoryRepository.FindAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category, int category_id)
        {
            try
            {
                category.ParentCategory = _CategoryRepository.FindById(category_id);
                _CategoryRepository.Save(category);
                return RedirectToAction("Index", "Category");
            }
            catch
            {
                return View();
            }
        }

        public List<Product> GetChildProducts(Category _Category)
        {
            List<Product> products = _Category.Products == null ? new List<Product>() : _Category.Products.ToList();

            if (_Category.ChildCategories != null)
            {
                foreach (Category item in _Category.ChildCategories)
                {
                    List<Product> subproducts = this.GetChildProducts(item);
                    products.AddRange(subproducts);
                }
            }
            return products.Distinct().ToList();
        }
	}
}

/*
           IList<Category> childCategories = new List<Category>();

           Category childCategory1 = new Category();
           childCategory1.Name = "Child 1";
           childCategories.Add(childCategory1);

           Category childCategory2 = new Category();
           childCategory2.Name = "Child 2";
           childCategories.Add(childCategory2);

           Category mainCategory = new Category();
           mainCategory.Name = "Main";
           mainCategory.ChildCategories = childCategories;

           using (ISession session = NHibernateSession.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   session.Save(mainCategory);
                   transaction.Commit();
               }
           }
           */
/*
CategoryRepository _CategoryRepository = new CategoryRepository();
ProductRepository _ProductRepository = new ProductRepository();

Category category1 = _CategoryRepository.FindById(6);                        
Category category2 = _CategoryRepository.FindById(7);            
            
Product product1 = new Product();
product1.Categories = new List<Category>();
product1.Name = "Camiseta Child 1";
product1.Categories.Add(category1);

Product product2 = new Product();
product2.Categories = new List<Category>();
product2.Name = "Camiseta Child 2";
product2.Categories.Add(category2);

_ProductRepository.Save(product1);
_ProductRepository.Save(product2);
*/
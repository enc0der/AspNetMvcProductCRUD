using AspNetMvcCRUD.Context;
using AspNetMvcCRUD.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;
//Nuh
namespace AspNetMvcCRUD.Controllers
{
    public class ProductController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


            Product model = db.Products.FirstOrDefault(m=>m.Id==id);
            if (model == null)
                return HttpNotFound();

            return View(model);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product model)
        {
            try
            {
               
                if(ModelState.IsValid)
                {
                    db.Products.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(model);
               
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Product model = db.Products.FirstOrDefault(m=>m.Id==id);

            if (model == null)
                return HttpNotFound();


            return View(model);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product model)
        {
            try
            {
                // TODO: Add update logic here

                if(ModelState.IsValid)
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");

                }
                return View(model);

            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Product model = db.Products.Find(id);
            if (model == null)
                return HttpNotFound();

            return View(model);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id,Product proc)
        {
            Product model = new Product();
            try
            {
                if(ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                     model = db.Products.Find(id);
                    if (model == null)
                        return HttpNotFound();

                    db.Products.Remove(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch
            {
                return View();
            }
        }
    }
}

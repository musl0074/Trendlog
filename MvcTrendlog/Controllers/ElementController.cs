using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MvcTrendlog.Controllers
{
    
    public class ElementController : Controller
    {
        // GET: Element
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult DropDowns()
        {
            return View();
        }

        // GET: Element/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Element/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Element/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Element/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Element/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Element/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Element/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control_Inmuebles.Controllers.MyPages
{
    public class RegistrosController : Controller
    {
        // GET: RegistrosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RegistrosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistrosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistrosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistrosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistrosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistrosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistrosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eagle.Web.Areas.Message.Controllers
{
    public class LetterController : Controller
    {
        // GET: Message/Letter
        public ActionResult Index()
        {
            return View();
        }

        // GET: Message/Letter/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Message/Letter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Message/Letter/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Message/Letter/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Message/Letter/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Message/Letter/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Message/Letter/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

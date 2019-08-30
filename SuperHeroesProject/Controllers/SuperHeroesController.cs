using SuperHeroesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeroesProject.Controllers
{
    public class SuperHeroesController : Controller
    {
        ApplicationDbContext context;

        public SuperHeroesController()
        {
            context = new ApplicationDbContext();
        }

        // GET: SuperHeroes
        public ActionResult Index()
        {
            return View(context.SuperHeroes.ToList());
        }

        // GET: SuperHeroes/Details/5
        public ActionResult Details(int id)
        {
            var selectHero = context.SuperHeroes.Find(id);
            return View(selectHero);
        }

        // GET: SuperHeroes/Create
        public ActionResult Create()
        {
            SuperHero superHero = new SuperHero();
            return View(superHero);
        }

        // POST: SuperHeroes/Create
        [HttpPost]
        public ActionResult Create(SuperHero superHero)
        {
            try
            {
                // TODO: Add insert logic here
                context.SuperHeroes.Add(superHero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroes/Edit/5
        public ActionResult Edit(int id)
        {
            var selectHero = context.SuperHeroes.Find(id);
            return View(selectHero);
        }

        // POST: SuperHeroes/Edit/5
        [HttpPost]
        public ActionResult Edit(SuperHero selectHero)
        {
            try
            {
                // TODO: Add update logic here
               if (ModelState.IsValid)
                {
                    context.Entry(selectHero).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroes/Delete/5
        public ActionResult Delete(int id)
        {
            var selectHero = context.SuperHeroes.Find(id);
            return View(selectHero);
        }

        // POST: SuperHeroes/Delete/5
        [HttpPost]
        public ActionResult Delete(SuperHero selectHero)
        {
            try
            {
                // TODO: Add delete logic here
                var deleteHero = context.SuperHeroes.Where(s => s.ID == selectHero.ID).SingleOrDefault();
                context.SuperHeroes.Remove(deleteHero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

using AVPPruebaDarwin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AVPPruebaDarwin.Controllers
{
    public class EmpleadosController : Controller
    {
        private AVPPruebaDarwinEntities db;

        public EmpleadosController()
        {
            this.db = new AVPPruebaDarwinEntities();
        }

        public ActionResult Index()
        {
            ViewBag.Empleados = db.Empleados.ToList();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Empleados empleado)
        {
            if (!String.IsNullOrEmpty(empleado.Nombre) && !String.IsNullOrEmpty(empleado.Apellido)
                && !String.IsNullOrEmpty(empleado.UserName) && !String.IsNullOrEmpty(empleado.Password))
            {
                db.Empleados.Add(empleado);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Empleados");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Empleado = db.Empleados.FirstOrDefault(x => x.Id == id);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Empleados empleado)
        {
            if (!String.IsNullOrEmpty(empleado.Nombre) && !String.IsNullOrEmpty(empleado.Apellido)
                && !String.IsNullOrEmpty(empleado.UserName) && !String.IsNullOrEmpty(empleado.Password))
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Empleados");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var empleado = db.Empleados.FirstOrDefault(x => x.Id == id);

            if (empleado == null)
                return RedirectToAction("Index", "Empleados");

            db.Empleados.Remove(empleado);
            db.SaveChanges();
            return RedirectToAction("Index", "Empleados");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Empleados empleado)
        {
            var empleados = db.Empleados.ToList();

            if (empleados.Count > 0)
            {
                foreach (var model in empleados)
                {
                    if (empleado.UserName == model.UserName && empleado.Password == model.Password)
                    {
                        return RedirectToAction("Welcome", "Empleados", model);
                    }
                }
            }

            return RedirectToAction("Login", "Empleados");
        }

        [HttpGet]
        public ActionResult Welcome(Empleados empleado)
        {
            ViewBag.Empleado = empleado;
            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using VeterinariaRepasoParcial.Models;
using VeterinariaRepasoParcial.Datos;

namespace VeterinariaRepasoParcial.Controllers
{
    public class MascotaController : Controller
    {
        public BibliotecaDatos _BD = new BibliotecaDatos();
        public IActionResult Index()
        {
            return View(_BD.ListarMascotas(0));
            //return View(_BD.ListarMascotas());    
        }
        public IActionResult Create()
        {
            ViewBag.Especies = _BD.ListarEspecies();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Mascota mascota)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                ViewBag.Error = _BD.CrearMascota(mascota); //ViewBag para pasar info del controlador a la vista
                if (ViewBag.Error != "")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("index");
                }
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Details(int id)
        {
            return View(_BD.ListarMascotas(id).FirstOrDefault());
        }

        public IActionResult Edit(int id)
        {
            return View(_BD.ListarMascotas(id).FirstOrDefault());
        }
        [HttpPost]
        public IActionResult Edit(Mascota mascota)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                ViewBag.Error = _BD.EditarMascota(mascota);
                if (ViewBag.Error != "")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("index");
                }
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            return View(_BD.ListarMascotas(id).FirstOrDefault());
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (_BD.ListarMascotas(id).Any())
                {
                    ViewBag.Error = _BD.BorrarMascota(id);
                    if (ViewBag.Error != "")
                    {
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("index");
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return View();
            }

        }
    }
}

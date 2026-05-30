using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using negocio;
using dominio;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CatalogoDiscos_MVC.Controllers
{
    public class DiscoController : Controller
    {
        // GET: DiscoController
        public ActionResult Index()
        {
            DiscoNegocio negocio = new DiscoNegocio();
            return View(negocio.listar());
        }

        // GET: DiscoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DiscoController/Create
        public ActionResult Create()
        {
            EstiloNegocio estiloNegocio = new EstiloNegocio();
            TipoEdicionNegocio tipoNegocio = new TipoEdicionNegocio();

            ViewBag.Estilo = new SelectList(estiloNegocio.listar(), "Id", "Descripcion");
            ViewBag.TipoEdicion = new SelectList(tipoNegocio.listar(), "Id", "Descripcion");
            return View();
        }

        // POST: DiscoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Disco disco)
        {
            try
            {
                DiscoNegocio negocio = new DiscoNegocio();
                negocio.agregar(disco);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DiscoController/Edit/5
        public ActionResult Edit(int id)
        {
            DiscoNegocio discoNegocio = new DiscoNegocio();
            EstiloNegocio estiloNegocio = new EstiloNegocio();
            TipoEdicionNegocio edicionNegocio = new TipoEdicionNegocio();

            var disco = discoNegocio.listar().Find(d => d.Id == id);
            var generos = estiloNegocio.listar();
            var formatos = edicionNegocio.listar();

            ViewBag.Generos = new SelectList(generos, "Id", "Descripcion", disco.Estilo.Id);
            ViewBag.Formatos = new SelectList(formatos, "Id", "Descripcion", disco.TipoEdicion.Id);



            return View(disco);
        }

        // POST: DiscoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Disco disco)
        {
            try
            {
                DiscoNegocio discoNegocio = new DiscoNegocio();
                discoNegocio.modificar(disco);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DiscoController/Delete/5
        public ActionResult Delete(int id)
        {
            DiscoNegocio negocio = new DiscoNegocio();
            var disco = negocio.listar().Find(d => d.Id == id);
            return View(disco);
        }

        // POST: DiscoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                DiscoNegocio discoNeg = new DiscoNegocio();
                discoNeg.eliminar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

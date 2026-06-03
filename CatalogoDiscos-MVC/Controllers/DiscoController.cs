using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using negocio;
using dominio;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CatalogoDiscos_MVC.Controllers
{
    public class DiscoController : Controller
    {
        private DiscoNegocio _negocio;
        private EstiloNegocio _estiloNegocio;
        private TipoEdicionNegocio _tipoEdicionNegocio;

        public DiscoController(DiscoNegocio negocio, EstiloNegocio estiloNegocio, TipoEdicionNegocio tipoEdicionNegocio)
        {
            _negocio = negocio;
            _estiloNegocio = estiloNegocio;
            _tipoEdicionNegocio = tipoEdicionNegocio;
        }

        // GET: DiscoController
        public ActionResult Index(string filtro)
        {
            var discos = _negocio.listar();

            if (!string.IsNullOrEmpty(filtro))
            {
                discos = discos.FindAll(d => d.Titulo.ToUpper().Contains(filtro.ToUpper()));
            }
            ViewBag.filtro = filtro;

            return View(discos);
        }

        // GET: DiscoController/Details/5
        public ActionResult Details(int id)
        {


            var disco = _negocio.listar().Find(d => d.Id == id);

            return View(disco);
        }

        // GET: DiscoController/Create
        public ActionResult Create()
        {
            ViewBag.Estilo = new SelectList(_estiloNegocio.listar(), "Id", "Descripcion");
            ViewBag.TipoEdicion = new SelectList(_tipoEdicionNegocio.listar(), "Id", "Descripcion");
            return View();
        }

        // POST: DiscoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Disco disco)
        {
            try
            {
                _negocio.agregar(disco);
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

            var disco = _negocio.listar().Find(d => d.Id == id);
            var generos = _estiloNegocio.listar();
            var formatos = _tipoEdicionNegocio.listar();

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
                _negocio.modificar(disco);
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
            var disco = _negocio.listar().Find(d => d.Id == id);
            return View(disco);
        }

        // POST: DiscoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _negocio.eliminar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

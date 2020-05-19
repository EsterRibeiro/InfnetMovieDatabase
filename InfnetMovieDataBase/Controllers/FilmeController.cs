using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfnetMovieDataBase.Domain;
using InfnetMovieDataBase.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfnetMovieDataBase.Controllers
{
    public class FilmeController : Controller
    {
        FilmeRepository repository = new FilmeRepository();

        // GET: Filme
        public ActionResult Index()
        {
            var filmes = repository.ListarFilmes();

            return View(filmes);
        }

        // GET: Filme/Details/5
        public ActionResult Details(int id)
        {
            var filme = repository.DetalharFilme(id);

            if (filme == null)
            {
                return StatusCode(404);
            }

            return View(filme);
        }

        // GET: Filme/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filme/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] Filme filme)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.CriarFilme(filme);
                    return RedirectToAction("Index");
                }
                return View(filme);
            }
            catch
            {
                return View(filme);
            }
        }

        // GET: Filme/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Filme/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Filme filme)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    repository.AtualizarFilme
                    (
                        //sobescrevendo o objeto filme 
                        new Filme
                        {
                            Id = filme.Id,
                            Titulo = filme.Titulo,
                            TituloOriginal = filme.TituloOriginal,
                            Ano = filme.Ano,
                            Duracao = filme.Duracao
                        }
                       
                    );

                    return RedirectToAction(nameof(Index));
                }
                else
                    //return View("Index");
                // TODO: Add update logic here
                
                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Filme/Delete/5
        public ActionResult Delete(int id)
        {
            var filme = new Filme();

            repository.DetalharFilme(id);
            return View(filme);
        }

        // POST: Filme/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [Bind]Filme filme)
        {
            try
            {
                if(ModelState.IsValid)
                    repository.ExcluirFilme(filme.Id);
                else
                    return RedirectToAction(nameof(Index));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
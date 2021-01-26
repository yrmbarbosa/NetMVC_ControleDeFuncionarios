using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using App_ControleDeFuncionarios.Models;

namespace App_ControleDeFuncionarios.Controllers
{

    public class FuncionariosController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        [Route("listar-funcionarios")]
        public async Task<ActionResult> Index()
        {
            return View(await db.Funcionarios.ToListAsync());
        }

        [HttpGet]
        [Route("funcionario-detalhe/{id:int}")]
        public async Task<ActionResult> Details(int id)
        {            
            var funcionario = await db.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        [HttpGet]
        [Route("novo-funcionario")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("novo-funcionario")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Matricula,Nome,Sobrenome,Email,Ativo,DataAdmissao,DataDemissao")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Funcionarios.Add(funcionario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(funcionario);
        }

        [HttpGet]
        [Route("editar-funcionario/{id:int}")]
        public async Task<ActionResult> Edit(int id)
        {          
            var funcionario = await db.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        [HttpPost]
        [Route("editar-funcionario/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Matricula,Nome,Sobrenome,Email,Ativo,DataAdmissao,DataDemissao")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        [HttpGet]
        [Route("excluir-funcionario/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {           
            var funcionario = await db.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        [HttpPost]
        [Route("excluir-funcionario/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await db.Funcionarios.FindAsync(id);
            db.Funcionarios.Remove(funcionario);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

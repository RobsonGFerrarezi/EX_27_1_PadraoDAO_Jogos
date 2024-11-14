using EX_27_1_PadraoDAO_Jogos.DAO;
using EX_27_1_PadraoDAO_Jogos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace EX_27_1_PadraoDAO_Jogos.Controllers
{
    public class JogoController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                JogoDAO dao = new JogoDAO();
                return View("Index", dao.Listagem());
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.Message));
            }
        }

        public IActionResult NovoJogo()
        {
            try
            {
                JogoViewModel jogo = new JogoViewModel();
                jogo.Id = (new JogoDAO()).ProximoId();
                jogo.DataAquisicao = DateTime.Now;
                ViewBag.Operacao = "I";
                PreparaComboCategorias();

                return View("Form", jogo);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.Message));
            }
        }

        private void PreparaComboCategorias()
        {
            CategoriaDAO dao = new CategoriaDAO();
            var lista = dao.Lista();

            List<SelectListItem> listaRetorno = new List<SelectListItem>();
            foreach (var categoria in lista)
            {
                listaRetorno.Add(new SelectListItem(categoria.Descricao, categoria.Id.ToString()));
            }

            ViewBag.Categoria = listaRetorno;
        }

        private void ValidaDados(string operacao, JogoViewModel jogo)
        {
            ModelState.Clear();

            JogoDAO dao = new JogoDAO();
            if (operacao == "I" && dao.Consulta(jogo.Id) != null)
                ModelState.AddModelError("Id", "Código já em uso, tente outro código...");
            if (operacao == "A" && dao.Consulta(jogo.Id) == null)
                ModelState.AddModelError("Id", "Código não existe, só é possível alterar Ids existentes!");
            if (jogo.Id <= 0)
                ModelState.AddModelError("Id", "Código não existe, digite um Id válido!");

            if (string.IsNullOrEmpty(jogo.Descricao))
                ModelState.AddModelError("Descricao", "Valor obrigatório, digite uma descrição!");
            if (jogo.Valor < 0)
                ModelState.AddModelError("Valor", "Valor inválido, o valor não pode ser menor que 0!");
            if (jogo.DataAquisicao > DateTime.Now || jogo.DataAquisicao < new DateTime(1900, 1, 1))
                ModelState.AddModelError("DataAquisicao", "Data inválida! Digite uma entre 01/01/1900 e hoje!");
            if (jogo.CategoriaID <= 0)
                ModelState.AddModelError("CategoriaId", "CategoriaID inválida, o número tem que ser maior que 0!");
        }

        public IActionResult Salvar(JogoViewModel jogo, string Operacao)
        {
            try
            {
                ValidaDados(Operacao, jogo);

                if (ModelState.IsValid)
                {
                    JogoDAO dao = new JogoDAO();
                    if (Operacao == "I")
                        dao.Insert(jogo);
                    else
                        dao.Update(jogo);
                    return RedirectToAction("Index");
                }
                else
                {
                    PreparaComboCategorias();
                    ViewBag.Operacao = Operacao;
                    return View("Form", jogo);
                }
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.Message));
            }
        }

        public IActionResult Editar(int id)
        {
            try
            {
                ViewBag.Operacao = "A";
                JogoDAO dao = new JogoDAO();
                PreparaComboCategorias();

                return View("Form", dao.Consulta(id));
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.Message));
            }
        }
        public IActionResult Delete(int id)
        {
            try
            {
                JogoDAO dao = new JogoDAO();
                dao.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.Message));
            }
        }
    }
}

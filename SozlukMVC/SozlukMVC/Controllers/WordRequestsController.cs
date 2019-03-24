using BLL;
using Entity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SozlukMVC.Controllers
{
    public class WordRequestsController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();
        public ActionResult Index(int? sil)
        {
            if (sil.HasValue)
            {
                _uw.WordRequests.Delete(sil.Value);
                _uw.Complete();
            }

            var list = _uw.WordRequests.GetAll();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            //<option>
            ViewBag.Langs = _uw.Languages.GetAll()
                .Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View();
        }

        [HttpPost]
        public ActionResult Create(WordRequest r)
        {
            if (ModelState.IsValid)
            {
                string uid = User.Identity.GetUserId();
                var user = _uw.db.Users.Find(uid);
                r.Person = user;
                _uw.WordRequests.Add(r);
                _uw.Complete();
                return RedirectToAction("Index");
            }
            ViewBag.Langs = _uw.Languages.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
            return View(r);
        }
    }
}
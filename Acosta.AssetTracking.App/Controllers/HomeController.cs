using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acosta.AssetTracking.App.Models;
using Acosta.AssetTracking.BLL;
using Acosta.AssetTracking.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Acosta.AssetTracking.App.Controllers
{
    public class HomeController : Controller
    {
        // Home - View List
        public IActionResult Index()
        {
            List<SelectListItem> items = AssetTypeManager.GetAll().
                Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();

            items.Insert(0, new SelectListItem { Text = "All Types", Value = "0" });

            ViewBag.AssetTypeId = items;

            return View();
        }
        public IActionResult GetAssetsByType(int id)
        {
            return ViewComponent("AssetsByType", id);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            var asset = AssetManager.Find(id);
            return View(asset);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            var assetTypes = AssetTypeManager.GetAsKeyValuePairs();
            var list = new SelectList(assetTypes, "Id", "Name");
            ViewBag.AssetTypeId = list;

            return View();
        }

        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Asset asset)
        {
            try
            {
                AssetManager.Add(asset);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var asset = AssetManager.Find(id);

            var assetTypes = AssetTypeManager.GetAsKeyValuePairs();
            var list = new SelectList(assetTypes, "Id", "Name");
            ViewBag.AssetTypeId = list;

            return View(asset);
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Asset asset)
        {
            try
            {
                AssetManager.Update(asset);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}

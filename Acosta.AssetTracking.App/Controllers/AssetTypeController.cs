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
    public class AssetTypeController : Controller
    {
        // GET: AssetType
        public ActionResult Index()
        {
            var assetTypes = AssetTypeManager.GetAll().
            Select(assetType => new AssetTypeViewModel
            {
                Id = assetType.Id,
                Name = assetType.Name,
            }).ToList();

            return View(assetTypes);

        }

        // GET: AssetType/Details/5
        public ActionResult Details(int id)
        {
            var assetType = AssetTypeManager.Find(id);
            return View(assetType);
        }

        // GET: AssetType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssetType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssetType assetType)
        {
            try
            {
                AssetTypeManager.Add(assetType);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssetType/Edit/5
        public ActionResult Edit(int id)
        {
            var assetType = AssetTypeManager.Find(id);

            var assetTypes = AssetTypeManager.GetAsKeyValuePairs();
            var list = new SelectList(assetTypes, "Id", "Name");
            ViewBag.AssetTypeId = list;

            return View(assetType);
        }

        // POST: AssetType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AssetType assetType)
        {
            try
            {
                AssetTypeManager.Update(assetType);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



    }
}
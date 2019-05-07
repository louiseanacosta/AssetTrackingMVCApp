using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acosta.AssetTracking.App.Models;
using Acosta.AssetTracking.BLL;
using Acosta.AssetTracking.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Acosta.AssetTracking.App.ViewComponents
{
    public class AssetsByTypeViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            List<Asset> assets = null;

            if (id == 0)
            {
                assets = AssetManager.GetAll();
            }
            else
            {
                assets = AssetManager.GetAllByType(id);
            }


            var items = assets.
                Select(a => new AssetsViewModel
                {
                    TagNumber = a.TagNumber,
                    AssetType = a.AssetType.Name,
                    Description = a.Description,
                    SerialNumber = a.SerialNumber
                }).ToList();

            return View(items);
        }

    }
}

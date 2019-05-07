using Acosta.AssetTracking.Data;
using Acosta.AssetTracking.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Acosta.AssetTracking.BLL
{
    public class AssetManager
    {
        public static IList GetasValuePairs()
        {
            var context = new AssetContext();
            var assets = context.Assets.Select(asset => new
            {
                asset.Id,
                asset.TagNumber
            }).ToList();
            return assets;
        }

        public static List<Asset> GetAll()
        {
            var context = new AssetContext();
            var assets = context.Assets.
                Include(asset => asset.AssetType).
                ToList();
            return assets;
        }

        public static List<Asset> GetAllByType(int assetTypeId)
        {
            var context = new AssetContext();
            var assets =
                context.Assets.
                Include(asset => asset.AssetType).
                Where(t => t.AssetTypeId == assetTypeId).ToList();
            return assets;
        }


        public static Asset Find(int id)
        {
            var context = new AssetContext();
            var asset = context.Assets.
                Include(a => a.AssetType).
                SingleOrDefault(a => a.Id == id);
            return asset;
        }

        public static void Add(Asset asset)
        {
            var context = new AssetContext();
            context.Assets.Add(asset);
            context.SaveChanges();
        }

        public static void Update(Asset asset)
        {
            var context = new AssetContext();
            var upAsset = context.Assets.SingleOrDefault(a => a.Id == asset.Id);
            upAsset.Id = asset.Id;
            upAsset.TagNumber = asset.TagNumber;
            upAsset.AssetTypeId = asset.AssetTypeId;
            upAsset.Manufacturer = asset.Manufacturer;
            upAsset.Model = asset.Model;
            upAsset.Description = asset.Description;
            upAsset.SerialNumber = asset.SerialNumber;
            context.SaveChanges();
        }
    }
}

using Acosta.AssetTracking.Data;
using Acosta.AssetTracking.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Acosta.AssetTracking.BLL
{
    public class AssetTypeManager
    {
        public static IList GetAsKeyValuePairs()
        {
            var context = new AssetContext();
            var types = context.AssetTypes.Select(type => new
            {
                type.Id,
                type.Name
            }).ToList();
            return types;
        }

        public static List<AssetType> GetAll()
        {
            var context = new AssetContext();
            var types = context.AssetTypes.ToList();
            return types;
        }

        public static AssetType Find(int id)
        {
            var context = new AssetContext();
            var types = context.AssetTypes.Find(id);
            return types;
        }

        public static void Add(AssetType assetType)
        {
            var context = new AssetContext();
            context.AssetTypes.Add(assetType);
            context.SaveChanges();
        }

        public static void Update(AssetType assetType)
        {
            var context = new AssetContext();
            var upAssetType = context.AssetTypes.SingleOrDefault(a => a.Id == assetType.Id);
            upAssetType.Id = assetType.Id;
            upAssetType.Name = assetType.Name;

            context.SaveChanges();
        }
    }
}

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Acosta.AssetTracking.Domain
{
    public class Asset
    {
        public int Id { get; set; }
        [Required, DisplayName("Tag Number")]
        public string TagNumber { get; set; }
        [Required, DisplayName("Asset Type")]
        public int AssetTypeId { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        [Required]
        public string Description { get; set; }
        [Required, DisplayName("Serial Number")]
        public string SerialNumber { get; set; }
        // navigation property
        public AssetType AssetType { get; set; }
    }
}

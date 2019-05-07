using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acosta.AssetTracking.Domain
{
    public class AssetType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<Asset> Assets { get; set; }
    }
}

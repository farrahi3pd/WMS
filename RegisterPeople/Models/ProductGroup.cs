using System.ComponentModel.DataAnnotations;

namespace RegisterPeople.Models
{
    public class ProductGroup
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ParentGroup { get; set; }
        public string ProductGroupCode { get; set; }
        public object Products { get; internal set; }  // for InventoryReportController
    }
}

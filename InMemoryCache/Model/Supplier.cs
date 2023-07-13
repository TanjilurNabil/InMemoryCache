using System.ComponentModel.DataAnnotations;

namespace InMemoryCache.Model
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierNameBN { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public bool IsImporter { get; set; }
    }
}

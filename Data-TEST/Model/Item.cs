using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace Data_TEST.Model
{
    [Table("Items")]
    public class Item
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int? WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; } // questo ci occorre per avere l'intero oggetto Warehouse


    }
}
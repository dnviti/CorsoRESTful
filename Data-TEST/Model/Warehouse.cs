using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Data_TEST.Model
{
    [Table("Warehouses")]
    public class Warehouse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Slots { get; set; }

        public IList<Item> Items { get; set; }
    }
}
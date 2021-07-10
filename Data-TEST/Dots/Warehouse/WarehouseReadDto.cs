using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data_TEST.Model;

namespace Data_TEST
{
    public class WarehouseReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Slots { get; set; }
        public IList<Item> Items { get; set; }
    }
}
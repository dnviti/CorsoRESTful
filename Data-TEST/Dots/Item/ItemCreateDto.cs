using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data_TEST.Model;

namespace Data_TEST
{
    public class ItemCreateDto
    {
        [Required]
        public string Name { get; set; }
        public int WarehouseId { get; set; }
    }
}
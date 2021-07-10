using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data_TEST.Model;

namespace Data_TEST
{
    public class ItemUpdateDto
    {
        // è 1 a 1 con il json che passo, quindi non ci va l'Id perché non lo voglio modificare
        public string Name { get; set; }
        public int WarehouseId { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Dtos.ShopDtos
{
    public class ShopUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
}

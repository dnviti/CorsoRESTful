﻿namespace Data.Dtos.ShopDtos
{
    public record ShopUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
}

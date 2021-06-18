using System;

namespace Data.Dtos.ShopDtos
{
    public class ShopCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public int Role { get; set; }
    }
}

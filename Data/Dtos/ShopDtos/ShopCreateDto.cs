using System;

namespace Data.Dtos.ShopDtos
{
    public class ShopReadDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public int Role { get; set; }
    }
}

using Data.Model;
using System;
using System.Collections.Generic;

namespace Data.Dtos.ShopDtos
{
    public class ShopCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int Role { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}

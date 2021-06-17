using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
    [Table("ShopsMovies")]
    public class ShopMovie
    {
        [Required]
        public long ShopId { get; set; }
        [Required]
        public Shop Shop { get; set; }
        [Required]
        public long MovieId { get; set; }
        [Required]
        public Movie Movie { get; set; }
    }
}

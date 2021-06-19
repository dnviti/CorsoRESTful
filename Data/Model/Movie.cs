using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
    [Table("Movies")]
    public class Movie
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double? Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public int? AuthorId { get; set; }
        public Author Author { get; set; }

        public IList<Shop> Shops { get; set; }
        public IList<Actor> Actors { get; set; }
    }
}

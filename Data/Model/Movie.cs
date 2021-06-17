using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
    public class Movie
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Rating { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime CreateOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public long AuthorId { get; set; }
        public Author Author { get; set; }

        public ICollection<Shop> Shops { get; set; }
        public ICollection<Actor> Actors { get; set; }
    }
}

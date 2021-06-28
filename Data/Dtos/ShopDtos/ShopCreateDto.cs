namespace Data.Dtos.ShopDtos
{
    public record ShopReadDto
    {
        public int Id { get; set; }


        [Required]
        public string Name { get; set; }
    }
}

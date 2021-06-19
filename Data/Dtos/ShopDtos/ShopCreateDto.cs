namespace Data.Dtos.ShopDtos
{
    public class ShopReadDto
    {
        public int Id { get; set; }


        [Required]
        public string Name { get; set; }
    }
}

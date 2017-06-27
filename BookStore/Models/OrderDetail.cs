namespace BookStore.Models
{
    public class OrderDetail
    {
  //nice
       public int Id { get; set; }

        public Book Books { get; set; }

        public int BookId { get; set; }

        public decimal Price { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public Order Orders { get; set; }

        public int OrderId { get; set; }

    }
}
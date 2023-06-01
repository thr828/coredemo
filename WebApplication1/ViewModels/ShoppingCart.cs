namespace WebApplication1.ViewModels
{
    public class ShoppingCart
    {
        public int Gid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int  BuyNum { get; set; }

        public int IsDelete { get; set; }


    }
}

namespace APIAlamoDrifter.Models.Pedidos
{
    public class ItemDTO
    {
        public string sku{ get; set; }
        public int product_id { get; set; }
        public int variation_id { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }

        public int? id { get; set; }

    }
}
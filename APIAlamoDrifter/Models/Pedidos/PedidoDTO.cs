namespace APIAlamoDrifter.Models.Pedidos
{
    public class PedidoDTO
    {
        public int id { get; set; }
        public DateTime date_created { get; set; }

        public PedidoBillingDTO billing { get; set; }
        public string? company { get; set; }
        public string? codempSoftland { get; set; }

        //public List<MetaDataDTO> meta_data { get; set; } 
        public ICollection<ItemDTO> line_items { get; set; }
    }
}

namespace APIAlamoAnclaflex.Models.Pedidos
{
    public class PedidoDTO
    {
        public decimal? MSNroPedCte { get; set; }
        public decimal? MSDocExterno { get; set; }
        public string? MSLetraComprobante { get; set; }
        public string? MSCtroEmisor { get; set; }
        public decimal? MSNroComprobante { get; set; }

        public decimal? MSNroAplica { get; set; }
        public string? MSDomAlt { get; set; }
        public string? MSCliCod { get; set; }
        public string? MSCategoria { get; set; }
        public string? ValNomDestino { get; set; }
        public string? ValNomDstLargo { get; set; }
        public string? ValDirDestino { get; set; }
        public string? ValCodAlternativo { get; set; }
        public string? ValCodDestinoERP { get; set; }
        public decimal? ValCuit { get; set; }
        public string? ValCodigoPostal { get; set; }
        public decimal? ValLocalidad { get; set; }
        public string? ValPcia { get; set; }
        public string? ValPais { get; set; }
        public string? MSNroViaje { get; set; }
        public decimal? ViajesCodigo { get; set; }
        public string? MSFechaEmision { get; set; }
        public string? MSFechaPreparacion { get; set; }
        public string? MSUsuarioPreparacion { get; set; }
        public string? MSFechaRemision { get; set; }
        public string? MSUsuarioRemison { get; set; }
        public string? MSFechaDespacho { get; set; }
        public string? MSUsuarioDespacho { get; set; }
        public string? MSFechaViajeSalida { get; set; }
        public string? MSHoraViajeSalida { get; set; }
        public string? MSUsuarioViajeSalida { get; set; }
        public string? MSFechaGrabacion { get; set; }
        public string? MSArtFechaVtoERP { get; set; }
        public string? MSCompExternoERP { get; set; }
        public string? MSOrdenCompraERP { get; set; }
        public string? MSAlmacenOrigenERP { get; set; }
        public string? MSAlmacenDestinoERP { get; set; }
        public string? MSCtroOrigenERP { get; set; }
        public string? MSCtroDestinoERP { get; set; }
        public string? MSCodExternoERP1 { get; set; }
        public string? MSCodExternoERP2 { get; set; }
        public string? MSCodExternoERP3 { get; set; }
        public string? MSCodAuxiliarERP1 { get; set; }
        public string? MSCodAuxiliarERP2 { get; set; }
        public string? AsgTOrdenCodigo { get; set; }
        public string? AsgLocalCodigo { get; set; }
        public ICollection<ItemDTO> detalle { get; set; }
    }
}

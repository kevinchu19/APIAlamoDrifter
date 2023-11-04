namespace APIAlamoAnclaflex.Models.Recepciones
{
    public class RecepcionDTO
    {
        public decimal? MSNroPedCte { get; set; }
        public decimal? MSDocExterno { get; set; }
        public string? MSLetraComprobante { get; set; }
        public string? MSCtroEmisor { get; set; }
        public decimal? MSNroComprobante { get; set; }
        public string? RecCabTipoDocumento { get; set; }
        public string? RecCabNoRecepcion { get; set; }
        public string? RecCabComentario { get; set; }
        public decimal? RecCabCondicion { get; set; }
        public DateTime? MSFechaEmision { get; set; }
        public DateTime? MSFechaGrabacion { get; set; }
        public DateTime? RecCabFechaRemito { get; set; }
        public DateTime? RecCabFhRecepcion { get; set; }
        public DateTime? RecCabFechaFinalizada { get; set; }
        public DateTime? RecCabFhFGuardada { get; set; }
        public string? RecCabDock { get; set; }
        public decimal? RecCabCantTotalDeContenedores { get; set; }
        public decimal? RecCabAnulada { get; set; }
        public DateTime? RecCabAnuladaFecha { get; set; }
        public string? RecCabAnuladaUsuario { get; set; }
        public decimal? MSSucursal { get; set; }
        public decimal? MSEmpresa { get; set; }
        public string? MSTipoAplica { get; set; }
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
        public string? RecCabNroViaje { get; set; }
        public DateTime? MSArtFechaVtoERP { get; set; }
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
        public ICollection<ItemRecepcionDTO> detalle { get; set; }
    }
}

namespace APIAlamoAnclaflex.Models.Pedidos
{
    public class ItemDTO
    {
        public decimal? MSSucursal { get; set; }
        public decimal? MSEmpresa { get; set; }
        public string? MSTipoAplica { get; set; }
        public decimal? MSNroAplica { get; set; }
        public decimal? MSOrdenArticulo { get; set; }
        public string? MSArticulo { get; set; }
        public string? ArtDsc { get; set; }
        public string? GrpAbr { get; set; }
        public decimal? MSCantidad { get; set; }
        public string? MSArtUnLogica { get; set; }
        public string? MSArtLote { get; set; }
        public string? MSArtFechaVto { get; set; }
        public string? MSArtNroSerie { get; set; }
        public string? MSTempSalida { get; set; }
        public decimal? MSCodMotivo { get; set; }
        public string? MSCodMotivoMtsDsc { get; set; }
        public string? MSCodMotivoMtsTipo { get; set; }
        public decimal? MSCodMotivoAnterior { get; set; }
        public string? MSCodMotivoAnteriorMtsDsc { get; set; }
        public string? MSCodMotivoAnteriorMtsTipo { get; set; }
        public string? MSObservacion { get; set; }
        public decimal? PesoTeoKg { get; set; }
        public decimal? VolumenTeoM3 { get; set; }
        public decimal? LitrosTeo { get; set; }
        public decimal? ValorTeo { get; set; }
        public string? MSContenedor { get; set; }
        public decimal? MSTotalContenedores { get; set; }
        public string? Lincod { get; set; }
        public string? LinDsc { get; set; }
        public string? SLinCod { get; set; }
        public string? SLinDsc { get; set; }
        public decimal? Marca { get; set; }
        public string? MarcaDescripcion { get; set; }
        public decimal? ArtGpoPicking { get; set; }
        public string? GrupoPickingDsc { get; set; }
        public decimal? ArtNomencladorCot { get; set; }


    }
}
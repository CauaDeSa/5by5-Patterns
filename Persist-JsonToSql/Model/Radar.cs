using System.Data;
using Newtonsoft.Json;

namespace Model
{
    public class Radar : IRadar
    {
        public static readonly string Initialize = "spInitializeRadar";
        public static readonly string Insert = "spInsertRadar";
        public static readonly string RetrieveAll = "spRetrieveAll";

        public int? Id { get; set; }

        [JsonProperty("concessionaria")]
        public string? Concessionaria { get; set; }

        [JsonProperty("ano_do_pnv_snv")]
        public int Ano_do_pnv_snv { get; set; }

        [JsonProperty("tipo_de_radar")]
        public string? Tipo_de_radar { get; set; }

        [JsonProperty("rodovia")]
        public string? Rodovia { get; set; }

        [JsonProperty("uf")]
        public string? Uf { get; set; }

        [JsonProperty("km_m")]
        public string Km_m { get; set; }

        [JsonProperty("municipio")]
        public string? Municipio { get; set; }

        [JsonProperty("tipo_pista")]
        public string? Tipo_de_pista { get; set; }

        [JsonProperty("sentido")]
        public string? Sentido { get; set; }

        [JsonProperty("situacao")]
        public string? Situacao { get; set; }

        [JsonProperty("data_da_inativacao")]
        public DataTable Data_da_inativacao { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("velocidade_leve")]
        public int Velocidade_leve { get; set; }

        public override string ToString()
        {
            return $"Concessionaria: {Concessionaria}\n" +
                   $"Ano do PNV/SNV: {Ano_do_pnv_snv}\n" +
                   $"Tipo de radar: {Tipo_de_radar}\n" +
                   $"Rodovia: {Rodovia}\n" +
                   $"UF: {Uf}\n" +
                   $"KM: {Km_m}\n" +
                   $"Municipio: {Municipio}\n" +
                   $"Tipo de pista: {Tipo_de_pista}\n" +
                   $"Sentido: {Sentido}\n" +
                   $"Situacao: {Situacao}\n" +
                   $"Data da inativacao: {Data_da_inativacao}\n" +
                   $"Latitude: {Latitude}\n" +
                   $"Longitude: {Longitude}\n" +
                   $"Velocidade leve: {Velocidade_leve}\n";
        }
    }
}
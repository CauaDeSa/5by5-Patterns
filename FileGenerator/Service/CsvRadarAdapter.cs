using Model;

namespace Service
{
    public class CsvRadarAdapter : IRadar
    {
        public static string ToString(List<Radar> lst)
        {
            return string.Join("\n", lst.Select(radar => $"{radar.Concessionaria},{radar.Ano_do_pnv_snv},{radar.Tipo_de_radar},{radar.Rodovia},{radar.Uf}," +
            $"{radar.Km_m},{radar.Municipio},{radar.Tipo_de_pista},{radar.Sentido},{radar.Situacao}{radar.Data_da_inativacao},{radar.Latitude}," +
            $"{radar.Longitude},{radar.Velocidade_leve}"));
        }
    }
}
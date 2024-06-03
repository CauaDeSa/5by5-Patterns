using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Model;

namespace RepositoryDao
{
    public class SqlRepositoryDao
    {
        #region SqlVariables
        private readonly string _connection = "Data Source=127.0.0.1; Initial Catalog=BDRadar; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes; MultipleActiveResultSets=True ";
        private readonly SqlConnection _sqlConnection;
        private readonly SqlCommand _sqlCommand;
        #endregion
        
        private static SqlRepositoryDao? _instance;

        private SqlRepositoryDao()
        {
            _sqlConnection = new(_connection);
            _sqlCommand = new()
            {
                CommandType = CommandType.StoredProcedure,
                Connection = _sqlConnection,
                CommandText = Radar.Initialize
            };

            _sqlConnection.Open();
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();

            _sqlCommand.Parameters.Clear();

            _instance = this;
        }

        public static SqlRepositoryDao GetInstance() => _instance ?? new SqlRepositoryDao();

        public bool LoadData(List<Radar> lst)
        {
            if (!IsEmpty())
                return false;

            _sqlConnection.Open();

            var tasks = lst.Select(async radar =>
            {
                var cmd = new SqlCommand() { CommandText = Radar.Insert, CommandType = System.Data.CommandType.StoredProcedure, Connection = _sqlConnection };
                cmd.Parameters.AddRange(

                    new SqlParameter[]
                    {
                        new SqlParameter("@concessionaria", radar.Concessionaria),
                        new SqlParameter("@ano_do_pnv_snv", radar.Ano_do_pnv_snv),
                        new SqlParameter("@tipo_de_radar", radar.Tipo_de_radar),
                        new SqlParameter("@rodovia", radar.Rodovia),
                        new SqlParameter("@uf", radar.Uf),
                        new SqlParameter("@km_m", radar.Km_m),
                        new SqlParameter("@municipio", radar.Municipio),
                        new SqlParameter("@tipo_de_pista", radar.Tipo_de_pista),
                        new SqlParameter("@sentido", radar.Sentido),
                        new SqlParameter("@situacao", radar.Situacao),
                        new SqlParameter("@data_da_inativacao", (radar.Data_da_inativacao.ToString().Length == 0) ? DBNull.Value : DateTime.Parse(radar.Data_da_inativacao.ToString()) ),
                        new SqlParameter("@latitude", radar.Latitude),
                        new SqlParameter("@longitude", radar.Longitude),
                        new SqlParameter("@velocidade_leve", radar.Velocidade_leve)
                    });

                await cmd.ExecuteNonQueryAsync();
            });

            Task.WhenAll(tasks).Wait();

            _sqlConnection.Close();

            return true;
        }

        public List<Radar> RetrieveAll()
        {
            List<Radar> lst = new();

            _sqlCommand.CommandText = Radar.RetrieveAll;
            _sqlCommand.CommandType = CommandType.StoredProcedure;

            _sqlCommand.Connection = _sqlConnection;
            _sqlConnection.Open();

            using SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                lst.Add(new()
                {
                    Concessionaria = reader["concessionaria"].ToString(),
                    Ano_do_pnv_snv = int.Parse(reader["ano_do_pnv_snv"].ToString()),
                    Tipo_de_radar = reader["tipo_de_radar"].ToString(),
                    Rodovia = reader["rodovia"].ToString(),
                    Uf = reader["uf"].ToString(),
                    Km_m = reader["km_m"].ToString(),
                    Municipio = reader["municipio"].ToString(),
                    Tipo_de_pista = reader["tipo_de_pista"].ToString(),
                    Sentido = reader["sentido"].ToString(),
                    Situacao = reader["situacao"].ToString(),
                    Data_da_inativacao = reader["data_da_inativacao"] == DBNull.Value ? null : (DataTable)reader["data_da_inativacao"],
                    Latitude = reader["latitude"].ToString(),
                    Longitude = reader["longitude"].ToString(),
                    Velocidade_leve = int.Parse(reader["velocidade_leve"].ToString())
                });
            }

            _sqlCommand.Parameters.Clear();
            _sqlConnection.Close();

            return lst;
        }

        private bool IsEmpty() => RetrieveAll().Count == 0;
    }
}

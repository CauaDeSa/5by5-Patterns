using Model;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Repository
{
    public class SqlRepositoryDao : IRepository
    {
        #region SqlVariables
        private readonly string _connection = "Data Source=127.0.0.1; Initial Catalog=BDRadar; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes";
        private readonly SqlConnection _sqlConnection;
        private readonly SqlCommand _sqlCommand;
        #endregion

        private static SqlRepositoryDao? _instance;
        private bool _isEmpty;

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

            _isEmpty = IsEmpty();
            _instance = this;
        }

        public static SqlRepositoryDao GetInstance() => _instance ?? new SqlRepositoryDao();

        public List<Radar> RetrieveAll()
        {
            List<Radar> lst = new();

            _sqlCommand.CommandText = Radar.RetrieveAll;
            _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            _sqlCommand.Connection = _sqlConnection;
            _sqlConnection.Open();

            using SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                lst.Add(new()
                {
                    Id = int.Parse(reader["id"].ToString()),
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
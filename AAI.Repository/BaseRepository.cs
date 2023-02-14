using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Data;
using AAI.DataContract.Enums;
using Microsoft.Data.SqlClient;

namespace AAI.Repository
{
    public class BaseRepository
    {
        protected readonly IConfiguration Configuration;

        public object Connection { get; private set; }
        public object Transaction { get; private set; }

        public BaseRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Returns first row of type T based on query parameter
        /// </summary>
        public async Task<T> GetFirstOrDefaultAsync<T>(string query, DynamicParameters parameter = null, CommandType? commandType = null, DataBaseNameEnum? databaseID = null)
        {
            T result = default(T);
            using (IDbConnection conn = GetConnection(databaseID))
            {
                result = await conn.QueryFirstOrDefaultAsync<T>(query, parameter, null, null, commandType);
            }

            return result;
        }

        /// <summary>
        /// Returns a list of type T based on query parameter
        /// </summary>
        public async Task<IEnumerable<T>> GetAsync<T>(string query, DynamicParameters parameters = null, CommandType? commandType = null, DataBaseNameEnum? databaseID = null)
        {
            IEnumerable<T> result = default(IEnumerable<T>);
            using (IDbConnection conn = GetConnection(databaseID))
            {
                result = await conn.QueryAsync<T>(query, parameters, null, null, commandType);
            }

            return result;
        }

        public async Task<int> AddAsync(string sql, DynamicParameters parameters = null, CommandType? commandType = null, DataBaseNameEnum databaseID = DataBaseNameEnum.DataBaseHotel)
        {
            int result = 0;

            using (IDbConnection conn = GetConnection(databaseID))
            {
                result = await conn.ExecuteAsync(sql, parameters, null, null, commandType);
            }

            return result;
        }

        private IDbConnection GetConnection(DataBaseNameEnum? databaseID)
        {
            string connectionString = Configuration.GetSection("Data:" + databaseID).GetSection("ConnectionString").Value;
            return new SqlConnection(connectionString);
        }

        protected async Task DeleteAsync(string sql, object parameters = null, CommandType? commandType = null)
        {
            using (IDbConnection conn = GetConnection(DataBaseNameEnum.DataBaseHotel))
            {
                await conn.ExecuteAsync(sql, parameters, null, null, commandType);
            }
        }

        public async Task<SqlMapper.GridReader> QueryMultiple(string query, DynamicParameters parameters = null, CommandType? commandType = null, DataBaseNameEnum databaseID = DataBaseNameEnum.DataBaseHotel)
        {
            SqlMapper.GridReader result;
            using (IDbConnection conn = GetConnection(databaseID))
            {
                result = await conn.QueryMultipleAsync(query, parameters, null, null, commandType);
            }

            return result;
        }

        /// <summary>
        /// Returns a list of type T based on query parameter
        /// </summary>
        public async Task<List<T>> GetAsyncList<T>(string query, DynamicParameters parameters = null, CommandType? commandType = null, DataBaseNameEnum? databaseID = null)
        {
            List<T> result = default(List<T>);
            using (IDbConnection conn = GetConnection(databaseID))
            {
                result = (await conn.QueryAsync<T>(query, parameters, null, null, commandType)).ToList();
            }
            return result;
        }

        private object GetSqlConnection(DataBaseNameEnum? databaseID)
        {
            string connectionString = Configuration.GetSection("Data:" + databaseID).GetSection("ConnectionString").Value;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        private void ReleaseConnection(object Connection)
        {
            SqlConnection cnn = (SqlConnection)Connection;
            if (cnn != null)
            {
                if (cnn.State != ConnectionState.Closed)
                    cnn.Close();
                cnn.Dispose();
            }
        }

        /// <summary>
        /// To get single or default row of type T based on query parameters.
        /// </summary>
        /// <typeparam name="T">T For Generic Returns Type</typeparam>
        /// <param name="query">Query Name</param>
        /// <param name="parameter">Query Parameters</param>
        /// <param name="commandType">Sql Command Type</param>
        /// <param name="databaseID">Database ID</param>
        /// <returns></returns>
        public async Task<T> GetQuerySingleOrDefaultAsync<T>(string query, DynamicParameters parameter = null, CommandType? commandType = null, DataBaseNameEnum databaseID = DataBaseNameEnum.DataBaseHotel)
        {
            T result = default(T);
            using (IDbConnection conn = GetConnection(databaseID))
            {
                result = await conn.QuerySingleOrDefaultAsync<T>(query, parameter, null, null, commandType);
            }
            return result;
        }

        public object ReturnObject(Hashtable Params, string CommandText, ObjectEnum Obj)
        {
            int i;
            string cmdpara, cmddbtype, cmdvalue;
            DataTable cmddatatablevalue;
            SqlCommand theCmd = new SqlCommand();
            SqlTransaction theTran = (SqlTransaction)GetSqlConnection(DataBaseNameEnum.DataBaseHotel);
            SqlConnection cnn;

            if (null == this.Connection)
            {
                cnn = (SqlConnection)GetSqlConnection(DataBaseNameEnum.DataBaseHotel);
            }
            else
            {
                cnn = (SqlConnection)GetSqlConnection(DataBaseNameEnum.DataBaseHotel);
            }

            if (null == this.Transaction)
            {
                theCmd = new SqlCommand(CommandText, cnn);
            }
            else
            {
                theCmd = new SqlCommand(CommandText, cnn, theTran);
            }

            for (i = 1; i < Params.Count;)
            {

                cmdpara = Params[i].ToString();
                cmddbtype = Params[i + 1].ToString();

                SqlDbType cmdtype = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmddbtype, true);

                if (Params[i + 2].GetType() == typeof(DataTable))
                {
                    cmddatatablevalue = (DataTable)Params[i + 2];
                    theCmd.Parameters.Add(cmdpara, cmdtype).Value = cmddatatablevalue;
                }
                else
                {
                    cmdvalue = Params[i + 2].ToString();
                    theCmd.Parameters.Add(cmdpara, cmdtype).Value = cmdvalue;
                }

                i = i + 3;
            }

            theCmd.CommandType = CommandType.StoredProcedure;
            string theSubstring = CommandText.Substring(0, 6).ToUpper();
            switch (theSubstring)
            {
                case "SELECT":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "UPDATE":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "INSERT":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "DELETE":
                    theCmd.CommandType = CommandType.Text;
                    break;
            }

            theCmd.Connection = cnn;
            try
            {
                if (Obj == ObjectEnum.DataSet)
                {

                    SqlDataAdapter theAdpt = new SqlDataAdapter(theCmd);
                    DataSet theDS = new DataSet();
                    theAdpt.Fill(theDS);
                    theAdpt.Dispose();
                    return theDS;
                }

                if (Obj == ObjectEnum.DataTable)
                {
                    SqlDataAdapter theAdpt = new SqlDataAdapter(theCmd);
                    DataTable theDT = new DataTable();
                    theAdpt.Fill(theDT);
                    theAdpt.Dispose();
                    return theDT;
                }

                if (Obj == ObjectEnum.DataRow)
                {
                    SqlDataAdapter theAdpt = new SqlDataAdapter(theCmd);
                    DataTable theDT = new DataTable();
                    theAdpt.Fill(theDT);
                    theAdpt.Dispose();
                    return theDT.Rows[0];
                }

                if (Obj == ObjectEnum.ExecuteNonQuery)
                {
                    int NoRowsAffected = theCmd.ExecuteNonQuery();
                    return NoRowsAffected;
                }
                return 0;
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                if (null != cnn)
                    if (null == this.Connection)
                        this.ReleaseConnection(cnn);
            }

        }
    }
}

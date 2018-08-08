using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


    public class SqlFunctions
{
       
    private static string connectionString = ConfigurationManager.ConnectionStrings["testConnection"].ConnectionString;
        //Get Sql Data Reader by select query
        public static SqlDataReader GetSqlDataReader(string sProc, string[] sArgField, string[] sArgValue, string sConnStr = "")
        {
            SqlConnection conn = new SqlConnection(sConnStr);
            SqlCommand cmd = new SqlCommand(sProc, conn);
            SqlDataReader dr = null;
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;

                if (sArgField != null)
                    for (int i = 0; i < sArgField.Count(); i++)
                        cmd.Parameters.Add(new SqlParameter(sArgField[i], sArgValue[i]));

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                dr = cmd.ExecuteReader();
                return dr;
            }
            catch
            {
                return dr;
            }
        }



    public static DataSet ExecuteDataSet(string StoredProcedureName, List<SqlParameter> ProcedureParameters)
    {
        DataSet ds = new DataSet();

        string commandText = StoredProcedureName;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            if (ProcedureParameters != null)
            {
                cmd.Parameters.AddRange(ProcedureParameters.ToArray());
            }
            conn.Open();
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
        }


        return ds;
    }


    public static int ExecuteNonQuery(String StoredProcedureName, List<SqlParameter> ProcedureParameters)
    {

        int isUpdated = 0;
        using (SqlConnection dBConnection = new SqlConnection(connectionString))
        {
            dBConnection.Open();
            using (SqlCommand command = dBConnection.CreateCommand())
            {
                command.CommandText = StoredProcedureName;
                command.CommandType = CommandType.StoredProcedure;

                if (ProcedureParameters != null)
                {
                    command.Parameters.AddRange(ProcedureParameters.ToArray());
                }

                isUpdated = command.ExecuteNonQuery();

            }
        }
        return isUpdated;
    }
}



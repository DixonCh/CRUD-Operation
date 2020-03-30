using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

namespace CRUDOPERATION.DbUtility
{
    public class DbConnection
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        public void Open()
        {
            conn = new SqlConnection();
           
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            conn.Open();
        }


        public void InitCommand(string sql, CommandType type)
        {
            cmd= new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandType = type;
            cmd.Connection = conn;
        }

        public SqlDataReader ExecuteReader()
        {
          
            return cmd.ExecuteReader();

        }
        public void AddInputParameter(DbType type, string pName, object pValue)
        {
            cmd.Parameters.Add(new SqlParameter()
            {
                DbType = DbType.String,
                ParameterName = pName,
                Value = pValue
            });
        }
        public int ExecuteNonQuery()
        {
            return cmd.ExecuteNonQuery();

        }
        public void Close()
        {
            if(conn!=null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
                conn = null;
            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SqlFactory
{
    public class SqlFactory
    {
        public SqlFactory()
        {
        }

        public SqlCommand GetSqlCommand(SqlConnection sqlConnection, string sql, Parameter[] sqlParameter)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

                if (sqlParameter.Length > 0)
                {
                    for (int i = 0; i < sqlParameter.Length; i++)
                    {
                        AddSqlParameter(sqlCommand, sqlParameter[i].name, sqlParameter[i].sqlDbType, sqlParameter[i].value);
                    }
                }

                return sqlCommand;
            }
            catch (SqlException sqlException)
            {
            }
            finally
            {
            }

            return null;
        }

        private void AddSqlParameter(SqlCommand sqlCommand, string name, SqlDbType sqlDbType, Object value)
        {
            SqlParameter sqlParameter = sqlCommand.CreateParameter();
            sqlParameter.ParameterName = name;
            sqlParameter.SqlDbType = sqlDbType;
            sqlParameter.Direction = ParameterDirection.Input;
            sqlParameter.Value = value;
            sqlCommand.Parameters.Add(sqlParameter);   
        }
    }
}

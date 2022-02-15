using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Vasthu_DataAccess
{
    public class AdoHelper 
    {
        private string _connString { get; set; }
        /// <summary>
        /// constructor for connectionstring
        /// </summary>
        /// <param name="connString">Connection string for this instance</param>
        public AdoHelper(string connString)
        {
            _connString = connString;

        }
        public int ExecuteNonQuery(CommandType commandType,string CommandText, List<SqlParameter> lstparams)
        {

            int result;
            try
            {
                using (var conn = new SqlConnection(_connString))
                {

                    conn.Open();
                    using (var command = conn.CreateCommand())
                    {
                        command.CommandType = commandType;
                        command.CommandText = CommandText;
                        command.Parameters.AddRange(lstparams.ToArray());
                        result = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //result = -1;
            }
            return result;
        }

      

        public List<T> ExecuteReader<T>(CommandType commandType, string CommandText, List<SqlParameter> lstparams) where T : new()  
        {
            List<T> res = new List<T>();
            DataTable dt = null;
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    using (var command = conn.CreateCommand())
                    {
                        command.CommandType = commandType;
                        command.CommandText = CommandText;
                        command.Parameters.AddRange(lstparams.ToArray());

                        using (IDataReader _reader = command.ExecuteReader())
                        {
                            while (_reader.Read())
                            {
                                T t = new T();

                                for (int inc = 0; inc < _reader.FieldCount; inc++)
                                {
                                    
                                    Type type = t.GetType();
                                    PropertyInfo prop = type.GetProperty(_reader.GetName(inc));
                                    if (!object.Equals(_reader[prop.Name], DBNull.Value))
                                    {
                                        prop.SetValue(t, Convert.ChangeType(_reader.GetValue(inc), prop.PropertyType), null);
                                    }
                                    else
                                    {
                                        string test = "hai";
                                    }
                                        
                                }

                                res.Add(t);
                            }

                        }
                    }
                }
                return res;
            }
            catch (Exception ex )
            {

                throw ex;
            }
          
           
        }

        public T ExecuteReaderSingle<T>(CommandType commandType, string CommandText, List<SqlParameter> lstparams) where T : new()
        {
            T res = new T();
            DataTable dt = null;
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    using (var command = conn.CreateCommand())
                    {
                        command.CommandType = commandType;
                        command.CommandText = CommandText;
                        command.Parameters.AddRange(lstparams.ToArray());

                        using (IDataReader _reader = command.ExecuteReader())
                        {
                            while (_reader.Read())
                            {
                                T t = new T();

                                for (int inc = 0; inc < _reader.FieldCount; inc++)
                                {
                                    Type type = res.GetType();
                                    PropertyInfo prop = type.GetProperty(_reader.GetName(inc));
                                    if (!object.Equals(_reader[prop.Name], DBNull.Value))
                                    {
                                        prop.SetValue(t, Convert.ChangeType(_reader.GetValue(inc), prop.PropertyType), null);
                                    }
                                    else
                                    {
                                        string test = "hai";
                                    }

                                }
                                res = t;
                                //res.Add(t);
                            }

                        }
                    }
                }
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public T ExecuteScalar<T>(CommandType commandType, string CommandText, List<SqlParameter> lstparams)
        {
            T t;
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    using (var command = conn.CreateCommand())
                    {
                        command.CommandType = commandType;
                        command.CommandText = CommandText;
                        command.Parameters.AddRange(lstparams.ToArray());
                        t = (T)command.ExecuteScalar();
                    }
                }
                return t;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet ExecDataSet(CommandType commandType, string CommandText, List<SqlParameter> lstparams)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    using (var command = conn.CreateCommand())
                    {
                        command.CommandType = commandType;
                        command.CommandText = CommandText;
                        command.Parameters.AddRange(lstparams.ToArray());
                        SqlDataAdapter adapt = new SqlDataAdapter(command);
                        adapt.Fill(ds);
                    }
                }
            }
            catch (Exception ex )
            {
                throw ex;
            }
            return ds;
        }
    }
}

//public IDataReader ExecuteReader(CommandType commandType, string CommandText, List<SqlParameter> lstparams)
//{

//    IDataReader reader;
//    using (var conn = new SqlConnection(_connString))
//    {
//        conn.Open();
//        using (var command = conn.CreateCommand())
//        {
//            command.CommandType = commandType;
//            command.CommandText = CommandText;
//            command.Parameters.AddRange(lstparams.ToArray());

//            using (IDataReader _reader = command.ExecuteReader())
//            {
//                reader = _reader;

//            }
//        }
//    }
//    return reader;
//}



//public DataTable ExecuteReader(CommandType commandType, string CommandText, List<SqlParameter> lstparams)
//{
//    DataTable dt = null;
//    try
//    {
//        using (var conn = new SqlConnection(_connString))
//        {
//            conn.Open();
//            using (var command = conn.CreateCommand())
//            {
//                command.CommandType = commandType;
//                command.CommandText = CommandText;
//                command.Parameters.AddRange(lstparams.ToArray());

//                using (IDataReader _reader = command.ExecuteReader())
//                {
//                    dt = new DataTable();
//                    dt.Load(_reader);
//                }
//            }
//        }
//        return dt;
//    }
//    catch (Exception ex)
//    {

//        throw ex;
//    }
//}





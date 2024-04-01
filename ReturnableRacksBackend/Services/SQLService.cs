using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Dynamic;

namespace ReturnableRacksBackend.Services
{
    public class SQLService
    {
        static readonly string path = "Server=NITRO-5\\SQLEXPRESS;Database=NombreBaseDeDatos;Integrated Security=True;";
        public static List<T> SelectMethod<T>(string qry, string? connectionString = "Server=NITRO-5\\SQLEXPRESS;Database=ReturnableRacks;Integrated Security=True;", bool production = false, Dictionary<string, object?>? param = null)
        {
            List<T> datalist = new List<T>(); 
            var cs = connectionString;
            using (var cnx = new SqlConnection(cs))
            {
                try
                {
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand(qry, cnx);
                    if (param != null)
                    {
                        param.ToList().ForEach(x => cmd.Parameters.AddWithValue(x.Key, x.Value ?? DBNull.Value));
                    }
                    cmd.CommandTimeout = 600;
                    SqlDataReader reader = cmd.ExecuteReader();
                    datalist.AddRange(GetItems<T>(reader));
                    return datalist;
                }
                catch (Exception)
                {
                    cnx.Close();
                    cnx.Dispose();
                    throw;
                }
                finally
                {
                    cnx.Close();
                    cnx.Dispose();
                }
            }

        }
        public static List<dynamic> SelectMethod(string qry, string? connectionString = "Server=NITRO-5\\SQLEXPRESS;Database=ReturnableRacks;Integrated Security=True;", bool production = false, Dictionary<string, object?>? param = null)
        {
            List<dynamic> datalist = new List<dynamic>(); 
            var cs = connectionString;
            using (var cnx = new SqlConnection(cs))
            {
                try
                {
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand(qry, cnx);
                    if (param != null)
                    {
                        param.ToList().ForEach(x => cmd.Parameters.AddWithValue(x.Key, x.Value ?? DBNull.Value));
                    }
                    cmd.CommandTimeout = 600;
                    SqlDataReader reader = cmd.ExecuteReader();
                    datalist.AddRange(GetItems(reader));
                    return datalist;
                }
                catch (Exception)
                {
                    cnx.Close();
                    cnx.Dispose();
                    throw;
                }
                finally
                {
                    cnx.Close();
                    cnx.Dispose();
                }
            }

        }

        public static int InsertMethod(string query, Dictionary<string, object?>? param = null, string? connectionString = "Server=NITRO-5\\SQLEXPRESS;Database=ReturnableRacks;Integrated Security=True;", bool production = false)
        {
            try
            {
                var cs = connectionString;
                //Agregar select scope identity
                using (SqlConnection cnx = new SqlConnection(cs))
                {
                    try
                    {
                        query = query.Trim() + "; select SCOPE_IDENTITY()";
                        cnx.Open();
                        SqlCommand cmd = new SqlCommand(query, cnx);
                        if (param != null)
                        {
                            param.ToList().ForEach(x => cmd.Parameters.AddWithValue(x.Key, x.Value ?? DBNull.Value));
                        }
                        cmd.CommandTimeout = 1000;
                        int.TryParse(cmd.ExecuteScalar()?.ToString() ?? "0", out int result);
                        return result;
                    }
                    catch (Exception)
                    {
                        cnx.Close();
                        cnx.Dispose();
                        throw;
                    }
                    finally
                    {
                        cnx.Close();
                        cnx.Dispose();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateMethod(string query, Dictionary<string, object?>? param = null, string? connectionString = "Server=NITRO-5\\SQLEXPRESS;Database=ReturnableRacks;Integrated Security=True;", bool production = false)
        {
            try
            { 
                var cs = connectionString;
                using (SqlConnection cnx = new SqlConnection(cs))
                {
                    try
                    {
                        cnx.Open();
                        SqlCommand cmd = new SqlCommand(query, cnx);
                        if (param != null)
                        {
                            param.ToList().ForEach(x => cmd.Parameters.AddWithValue(x.Key, x.Value ?? DBNull.Value));
                        }
                        cmd.CommandTimeout = 1000;
                        return Convert.ToInt32(cmd.ExecuteNonQuery());
                    }
                    catch (Exception)
                    {
                        cnx.Close();
                        cnx.Dispose();
                        throw;
                    }
                    finally
                    {
                        cnx.Close();
                        cnx.Dispose();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int DeleteMethod(string query, Dictionary<string, object?>? param = null, string? connectionString = "Server=NITRO-5\\SQLEXPRESS;Database=ReturnableRacks;Integrated Security=True;", bool production = false)
        {
            try
            { 
                var cs = connectionString;
                using (SqlConnection cnx = new SqlConnection(cs))
                {
                    try
                    {
                        cnx.Open();
                        SqlCommand cmd = new SqlCommand(query, cnx);
                        if (param != null)
                        {
                            param.ToList().ForEach(x => cmd.Parameters.AddWithValue(x.Key, x.Value ?? DBNull.Value));
                        }
                        cmd.CommandTimeout = 1000;
                        return Convert.ToInt32(cmd.ExecuteNonQuery());
                    }
                    catch (Exception)
                    {
                        cnx.Close();
                        cnx.Dispose();
                        throw;
                    }
                    finally
                    {
                        cnx.Close();
                        cnx.Dispose();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static IEnumerable<T> GetItems<T>(SqlDataReader reader)
        {
            var properties = typeof(T).GetProperties();
            var columnNames = Enumerable.Range(0, reader.FieldCount)
                                         .Select(i => reader.GetName(i).ToLower())
                                         .ToDictionary(name => name);
            while (reader.Read())
            {

                var item = Activator.CreateInstance<T>();
                foreach (var property in properties)
                {
                    try
                    {

                        var columnName = property.Name.ToLower();
                        if (columnNames.ContainsKey(columnName) && !reader.IsDBNull(columnNames[columnName]))
                        {
                            var value = reader.GetValue(columnNames[columnName]);
                            var type = property.PropertyType.GenericTypeArguments.Length > 0 ? property.PropertyType.GenericTypeArguments[0] : property.PropertyType;
                            var readerType = reader[columnName].GetType();

                            switch (type.Name)
                            {
                                case "String":
                                    property.SetValue(item, value?.ToString()?.Trim());
                                    break;
                                case "Decimal":
                                    if (decimal.TryParse(value?.ToString() ?? "0", out var valueDec))
                                        property.SetValue(item, valueDec);
                                    break;
                                case "Double":
                                    if (double.TryParse(value?.ToString() ?? "0", out var valueDouble))
                                        property.SetValue(item, valueDouble);
                                    break;
                                case "Int32":
                                    if (int.TryParse(value?.ToString() ?? "0", out var valueInt))
                                        property.SetValue(item, valueInt);
                                    break;
                                default:
                                    property.SetValue(item, value);
                                    break;
                            }


                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.Write(ex.Message);
                    }
                }
                yield return item;
            }
        }

        public static bool BulkCopy(DataTable data, string table, List<SqlBulkCopyColumnMapping>? mapping = null, string? connectionString = "Server=NITRO-5\\SQLEXPRESS;Database=ReturnableRacks;Integrated Security=True;", bool production = false)
        { 
            var cs = connectionString;
            using (SqlConnection cnx = new SqlConnection(cs))
            {
                try
                {
                    cnx.Open();
                    SqlBulkCopy bulk = new SqlBulkCopy(cnx);
                    bulk.DestinationTableName = table;
                    if (mapping != null)
                    {
                        mapping.ForEach(x =>
                        {
                            bulk.ColumnMappings.Add(x);
                        });
                    }
                    bulk.WriteToServer(data);
                    return true;
                }
                catch (Exception e)
                {
                    cnx.Close();
                    cnx.Dispose();
                    throw;
                }
                finally
                {
                    cnx.Close();
                    cnx.Dispose();
                }
            }
        }
        public static IEnumerable<dynamic> GetItems(SqlDataReader reader)
        {
            var columnNames = Enumerable.Range(0, reader.FieldCount)
                                         .Select(i => reader.GetName(i).ToLower())
                                         .ToDictionary(name => name);
            while (reader.Read())
            {
                dynamic dyn = new ExpandoObject();
                foreach (var column in columnNames)
                {
                    var dic = (IDictionary<string, object>)dyn;
                    if (reader[column.Key] != DBNull.Value)
                    {

                        if (reader[column.Key].GetType() == typeof(String))
                        {
                            dic[column.Key] = ((string?)reader[column.Key])?.Trim();
                        }
                        else
                        {
                            dic[column.Key] = reader[column.Key];
                        }
                    }
                    else
                    {
                        dic[column.Key] = null;
                    }

                }
                yield return dyn;
            }
        }

        public static T GetScalar<T>(string qry, string? connectionString = "Server=NITRO-5\\SQLEXPRESS;Database=ReturnableRacks;Integrated Security=True;", bool production = false)
        { 
            var cs = connectionString;

            using (var cnx = new SqlConnection(cs))
            {
                try
                {
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand(qry, cnx);
                    cmd.CommandTimeout = 600;
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        return (T)result;
                    }
                    else
                    {
                        return default(T);
                    }
                }
                catch (Exception)
                {
                    cnx.Close();
                    cnx.Dispose();
                    throw;
                }
                finally
                {
                    cnx.Close();
                    cnx.Dispose();
                }
            }
        }

        public static int GetNonQuery(string qry, string? connectionString = "Server=NITRO-5\\SQLEXPRESS;Database=ReturnableRacks;Integrated Security=True;", bool production = false)
        { 
            var cs = connectionString;
            using (var cnx = new SqlConnection(cs))
            {
                try
                {
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand(qry, cnx);
                    cmd.CommandTimeout = 600;
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    cnx.Close();
                    cnx.Dispose();
                    throw;
                }
                finally
                {
                    cnx.Close();
                    cnx.Dispose();
                }
            }
        }
    }
}

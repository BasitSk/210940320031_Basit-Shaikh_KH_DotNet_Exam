using DotNetExamWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DotNetExamWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Product> Get()
        {
            List<Product> list = new List<Product>();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BasitDB;Integrated Security=True";
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Products";
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Product { ProductId = reader.GetInt32(0), ProductName = reader.GetString(1), Rate = reader.GetDecimal(2), Description = reader.GetString(3), CategoryName = reader.GetString(4) });
                }
                reader.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return list;
           // return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] Product pd)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BasitDB;Integrated Security=True";
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into Products values (@ProductId, @ProductName, @Rate, @Description, @CategoryName)";
            cmd.Parameters.AddWithValue("@ProductId", pd.ProductId);
            cmd.Parameters.AddWithValue("@ProductName", pd.ProductName);
            cmd.Parameters.AddWithValue("@Rate", pd.Rate);
            cmd.Parameters.AddWithValue("@Description", pd.Description);
            cmd.Parameters.AddWithValue("@CategoryName", pd.CategoryName);
            try
            {
                cmd.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception e)
            {
                connection.Close();
                Console.WriteLine(e.Message);
            }
           

        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

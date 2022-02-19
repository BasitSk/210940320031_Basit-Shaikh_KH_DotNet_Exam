using DotNetExam.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetExam.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Product> list = new List<Product>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = BasitDB; Integrated Security = True";
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * from Products";
            try 
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Product { ProductId = reader.GetInt32(0), ProductName = reader.GetString(1), Rate = reader.GetDecimal(2), Description = reader.GetString(3), CategoryName = reader.GetString(4) });
                }
                reader.Close();
               
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return View(list);


        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult PartialView1()
        {
            ViewBag.name = "Basit Shaikh";
            ViewBag.center = "Kharghar";
            ViewBag.roll = 31;
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            Product pd = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = BasitDB; Integrated Security = True";
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * from Products where ProductId = @Id";
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                
                while (reader.Read())
                {
                    pd = new Product { ProductId = reader.GetInt32(0), ProductName = reader.GetString(1), Rate = reader.GetDecimal(2), Description = reader.GetString(3), CategoryName = reader.GetString(4) };
                }
                reader.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return View(pd);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product pd)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = BasitDB; Integrated Security = True";
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Update Products set ProductName = @ProductName, Rate = @Rate, Description = @Description, CategoryName = @CategoryName where ProductId = @Id";
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@ProductName", pd.ProductName);
            cmd.Parameters.AddWithValue("@Rate", pd.Rate);
            cmd.Parameters.AddWithValue("@Description", pd.Description);
            cmd.Parameters.AddWithValue("@CategoryName", pd.CategoryName);
            try
            {
                cmd.ExecuteNonQuery();
                connection.Close();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                connection.Close();
                Console.WriteLine(e.Message);
            }
            return View();
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

using ExamMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamMVC.Controllers
{
    public class ProductsController : Controller
    {
        SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True;");
        SqlCommand cmd = new SqlCommand();
        private object prd;

        public object ProductName { get; private set; }
        public object Description { get; private set; }
        public object Rate { get; private set; }
        public object CategoryName { get; private set; }

        // GET: Products
        public ActionResult Index()
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Products";
            List<Product> plist = new List<Product>();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    plist.Add(new Product { ProductId = (int)dr["ProductId"], ProductName = dr["Productname"].ToString(), Rate = (decimal)dr["Rate"], Description = (string)dr["Description"], CategoryName = (string)dr["CategoryName"] });

                }
                dr.Close();

            }
            catch(Exception ex)
            {
                ViewBag.err = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return View(plist);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        
        public ActionResult Create()
        {
            //ViewBag.list = GetCategories();

            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Product prd)
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Products";

            cmd.Parameters.AddWithValue("@ProductName", prd.ProductName);
            cmd.Parameters.AddWithValue("@@Rate", prd.Rate);
            cmd.Parameters.AddWithValue("@Description", prd.Description);
            cmd.Parameters.AddWithValue("@category", prd.CategoryName);
            try
            {
                // TODO: Add insert logic here
                cmd.ExecuteNonQuery();

                return RedirectToAction("Index");
            }
            catch
            {
                //ViewBag.err = ex;
                return View();
            }
            finally
            {
                conn.Close();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductsController obj)
        {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Products";

                cmd.Parameters.AddWithValue("@ProductName", obj.ProductName);
                cmd.Parameters.AddWithValue("@@Rate", obj.Rate);
                cmd.Parameters.AddWithValue("@Description", obj.Description);
                cmd.Parameters.AddWithValue("@category", obj.CategoryName);
               
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
    

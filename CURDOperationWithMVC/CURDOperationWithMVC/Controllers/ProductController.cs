 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using CURDOperationWithMVC.Models;


namespace CURDOperationWithMVC.Controllers
{
    public class ProductController : Controller
    {
        string connectionString = "Data Source=localhost;Initial Catalog = northwind; User ID = sa; Password=sa";
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtProduct = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter dta = new SqlDataAdapter("execute product", con);
            dta.Fill(dtProduct);
            
            return View(dtProduct);
        }

        // GET: Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new ProductModel());
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(string ProductName,decimal UnitPrice, int UnitsInStock)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "Execute insertProduct @ProductName=" + ProductName + ",@UnitPrice=" + UnitPrice + ",@UnitsInStock=10" + UnitsInStock;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            return RedirectToAction("Index");
        }

        // GET: Product/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ProductModel objProductModel = new ProductModel();
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "execute Selectproduct @Productid="+id;
            //SqlCommand cmd = new SqlCommand(query,con);
            SqlDataAdapter datr = new SqlDataAdapter(query, con);
            datr.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                objProductModel.ProductID = Convert.ToInt32(dt.Rows[0][0].ToString());
                objProductModel.ProductName = dt.Rows[0][1].ToString();
                objProductModel.UnitPrice = Convert.ToDecimal(dt.Rows[0][2].ToString());
                objProductModel.UnitsInStock = Convert.ToInt32(dt.Rows[0][3].ToString());
                return View(objProductModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        
        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, string ProductName, Decimal UnitPrice, int UnitsInStock)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            String query = "execute Updateproduct  @Productid="+id+", @ProductName='"+ ProductName + "', @UnitPrice="+ UnitPrice + ", @UnitsInStock="+ UnitsInStock;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            return RedirectToAction("Index");
           
        }

        // GET: Product/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            String query = "execute Deleteproduct @Productid="+ id;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            return RedirectToAction("Index");
        }
    }
}

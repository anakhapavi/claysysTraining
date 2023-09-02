using MVC_ProductApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProductApplication.DAL
{
    public class item_DAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["shopConnectionString"].ToString();

        //get all items
        public List<Item> GetAllItems()
        {
            List<Item> itemsList = new List<Item>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getALLITEMS";

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                adp.Fill(dt);
                con.Close();

                foreach(DataRow dr in dt.Rows)
                {
                    itemsList.Add(new Item
                    {
                        id = Convert.ToInt32(dr["id"]),
                        name = dr["name"].ToString(),
                        price = Convert.ToDecimal(dr["price"]),
                        qty = Convert.ToInt32(dr["qty"]),
                    }) ;
                }
            }
            return itemsList;
        }

        //insert items

        public bool InsertItems(Item item, HttpPostedFileBase image)
        {
            int id = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("insertALLITEMS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", item.name);
                cmd.Parameters.AddWithValue("@price", item.price);
                cmd.Parameters.AddWithValue("@qty", item.qty);

                if (image != null && image.ContentLength > 0)
                { 
                    string fileName = Path.GetFileName(image.FileName);
                    string filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/"), fileName);
                    image.SaveAs(filePath);
                 }

                con.Open();
                id = cmd.ExecuteNonQuery();
                con.Close();
            }
            if (id > 0)
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}

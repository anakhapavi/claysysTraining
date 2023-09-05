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
using System.Xml.Linq;

namespace MVC_ProductApplication.DAL
{
    public class item_DAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["shopConnectionString"].ToString();

        /// <summary>
        /// get all items
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// insert items by id
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        public bool InsertItems(Item item)
        {
            int id = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("insertALLITEMS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", item.name);
                cmd.Parameters.AddWithValue("@price", item.price);
                cmd.Parameters.AddWithValue("@qty", item.qty);

                con.Open();
                cmd.ExecuteNonQuery();
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

        /// <summary>
        /// update items
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool UpdateItem(Item item)
        {
            int rowsAffected = 0;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("updateALLITEMS", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", item.id);
                    cmd.Parameters.AddWithValue("@name", item.name);

                    con.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected > 0;
        }


        /// <summary>
        /// get all items
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Item> GetProductsById(int id)
        {
            List<Item> itemsList = new List<Item>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getITEMBYID ";
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                adp.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    itemsList.Add(new Item
                    {
                        id = Convert.ToInt32(dr["id"]),
                        name = dr["name"].ToString(),
                        price = Convert.ToDecimal(dr["price"]),
                        qty = Convert.ToInt32(dr["qty"]),
                    });
                }
            }
            return itemsList;
        }

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="id"></param>
        public void DeleteItem(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("deleteALLITEMS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }




    }
}

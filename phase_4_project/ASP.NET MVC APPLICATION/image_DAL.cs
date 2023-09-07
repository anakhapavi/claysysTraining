using MVC_ProductApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace MVC_ProductApplication.DAL
{
    public class image_DAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["shopConnectionString"].ToString();


         public List<Image> GetImages()
 {
     List<Image> imgList = new List<Image>();

     using (SqlConnection con = new SqlConnection(connectionString))
     {
         SqlCommand cmd = con.CreateCommand();
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.CommandText = "sp_ViewImage";

         con.Open();
         SqlDataReader rdr = cmd.ExecuteReader();

         while (rdr.Read())
         {
             string imgName = rdr["imgname"].ToString();
             byte[] imgData = rdr["imgpath"] as byte[];

             imgList.Add(new Image
             {
                 imgname = imgName,
                 imgpath = imgData
             });
         }
         con.Close();
     }

     return imgList;

 }

        public bool InsertImage(Image image)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INSERTIMAGE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@imgname", image.imgname);
                cmd.Parameters.AddWithValue("@imgpath", image.imgpath);



                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                return rowsAffected > 0;
            }
        }


    }
}

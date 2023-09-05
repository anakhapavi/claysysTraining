using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MVC_ProductApplication.DAL;
using MVC_ProductApplication.Models;

namespace MVC_ProductApplication.Controllers
{
    public class ImageController : Controller
    {

        image_DAL obj = new image_DAL();

        /// <summary>
        /// GET: Image
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
           return View();
        }

        //[HttpPost]
        //public ActionResult Index()
        //{


        //    return View();
        //}


        public ActionResult Add()
        {
            return View();
        }

        ///Add img

        //[HttpPost]
        //public ActionResult Add(HttpPostedFileBase file, Image image)
        //{
        //    if (file != null && file.ContentLength > 0)
        //    {
        //        string fileName = Path.GetFileName(file.FileName);
        //        string fileExt = Path.GetExtension(fileName);

        //        if (fileExt == ".jpg" || fileExt == ".png")
        //        {
        //            string filePath = Path.Combine(Server.MapPath("~/Images"), fileName);
        //            file.SaveAs(filePath);

        //            image.imgname = fileName;
        //            image.imgpath = filePath;

        //            bool insertionResult = obj.InsertImage(image);
        //            if (insertionResult)
        //            {
        //                ViewBag.UploadMessage = "Uploaded sucessfully";
        //            }
        //            else
        //            {
        //                ViewBag.ErrorMessage = "Not Uploaded ";
        //            }
        //            return RedirectToAction("Index");

        //        }
        //        else
        //        {
        //            ViewBag.ErrorMessage = "Invalid format,file extension should be 'jpg' or 'png' ";
        //        }

        //    }
        //    return View();
        //}

        [HttpPost]
        public ActionResult Add(HttpPostedFileBase file, Image image)
        {
            if (file != null && file.ContentLength > 0)
            {
                // Read the file into a byte array
                byte[] imageData = new byte[file.ContentLength];
                file.InputStream.Read(imageData, 0, file.ContentLength);

                image.imgname = Path.GetFileName(file.FileName);
                image.imgpath = imageData;

                bool insertionResult = obj.InsertImage(image);
                if (insertionResult)
                {
                    ViewBag.UploadMessage = "Uploaded successfully";
                }
                else
                {
                    ViewBag.ErrorMessage = "Not Uploaded";
                }
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid format, file extension should be 'jpg' or 'png'";
                return View();
            }
        }


    }
}

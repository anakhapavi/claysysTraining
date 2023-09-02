using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ProductApplication.DAL;
using MVC_ProductApplication.Models;

namespace MVC_ProductApplication.Controllers
{
    public class ItemController : Controller
    {
        item_DAL obj = new item_DAL();


        // GET: Item
        public ActionResult Index()
        {
            var itemList = obj.GetAllItems();
            if (itemList.Count == 0)
            {
                TempData["infoMessage"] = "currently no data is available";
            }
            return View(itemList);
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        public ActionResult Create(Item item,HttpPostedFileBase image)
        {
            try
            {
                // TODO: Add insert logic here
                bool IsInserted = false;
                if (ModelState.IsValid && image != null && image.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(image.FileName);
                    string uniqueFileName = Guid.NewGuid().ToString()+"_"+fileName;
                    string filePath = Path.Combine(Server.MapPath("~/Images/"),uniqueFileName);
                    image.SaveAs(filePath);

                    item.image = uniqueFileName;
                    bool isInserted = item_DAL.InsertItems(item, image);


                    if (IsInserted)
                    {
                        TempData["SucessMessage"] = "Item details are saved sucessfully";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to save item details";
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please provide a valid image.");
                    return View(item); // Return to the create view with validation errors
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Item/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
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

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Item/Delete/5
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

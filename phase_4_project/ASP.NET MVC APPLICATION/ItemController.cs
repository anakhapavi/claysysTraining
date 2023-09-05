using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using MVC_ProductApplication.DAL;
using MVC_ProductApplication.Models;

namespace MVC_ProductApplication.Controllers
{
    public class ItemController : Controller
    {
        item_DAL obj = new item_DAL();


        /// <summary>
        /// GET: Item
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var itemList = obj.GetAllItems();
            if (itemList.Count == 0)
            {
                TempData["infoMessage"] = "currently no data is available";
            }
            return View(itemList);
        }

        /// <summary>
        /// GET: Item/Details/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            return View();
        }


        /// <summary>
        /// GET: Item/Create
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: Item/Create
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Item item)
        {
            bool IsInserted = false;
            if (ModelState.IsValid)
            { 
                IsInserted = obj.InsertItems(item);
                if (IsInserted)
                {
                    ///TempData["SuccessMessage"] = "Saved Sucessfully";
                }
                else {
                    ///TempData["ErrorMessage"] = " save";
                }
                return RedirectToAction("Index");
            }
            return View();
        }



        /// <summary>
        /// GET: Item/Edit/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var item = obj.GetProductsById(id).FirstOrDefault();
            if (item == null)
            {
                TempData["infoMessage"] = "currently no data is available with id"+id.ToString();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        /// <summary>
        /// POST: Item/Edit/5
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost,ActionName("Edit")]
        public ActionResult Update(Item item)
        {
            if (ModelState.IsValid)
            { 
                bool IsUpdated = obj.UpdateItem(item);
                if (IsUpdated)
                { 
                
                }
                else{
                
                }
                return RedirectToAction("Index");
            }
            return View();
        }


        /// <summary>
        /// GET: Item/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public ActionResult Delete(int id)
        {
            var item = obj.GetProductsById(id).FirstOrDefault();
            if (item == null)
            {
                TempData["infoMessage"] = "currently no data is available with id" + id.ToString();
                return RedirectToAction("Index");

            }
            return View(item);
        }
        /// <summary>
        /// POST: Item/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            /// Call the DeleteItem method to delete the item by its ID
            obj.DeleteItem(id);

            if (ModelState.IsValid)
            {
                

                return RedirectToAction("Index");
            }
            return View();
        }


    }
}

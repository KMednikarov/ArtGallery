using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtGallery.Models;

namespace ArtGallery.Controllers
{
    public class UploadController : Controller
    {
        private string IMAGES_FOLDER = "~/Resources/Images/";
        // GET: Upload
        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload(FormCollection form, HttpPostedFileBase postedImage)
        {
            Artwork artwork = new Artwork();
            artwork.Name = form["Name"];
            artwork.Author = form["Author"];
            artwork.Price = Convert.ToDecimal(form["Price"]);
            artwork.Category_Id = Convert.ToInt32(form["Category"]);
            artwork.Size = form["Size"];
            artwork.Status = form["Status"];
            artwork.ImagePath = IMAGES_FOLDER + Path.GetFileName(postedImage.FileName);

            
            if (postedImage != null)
            {
                string uploadFolder = Server.MapPath(IMAGES_FOLDER);
                postedImage.SaveAs(uploadFolder + "\\" + Path.GetFileName(postedImage.FileName));
            }            
                        

            DBManager dbManager = new DBManager();
            dbManager.InsertArtwork(artwork);

            ModelState.Clear();

            return View();
        }
    }
}
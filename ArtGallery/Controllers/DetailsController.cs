using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtGallery.Models;

namespace ArtGallery.Controllers
{
    public class DetailsController : Controller
    {
        // GET: Details
        public ActionResult Details(string id)
        {
            int primaryKey = Convert.ToInt32(id);
            ArtGalleryDatabaseEntities entities = new ArtGalleryDatabaseEntities();
            List<Artwork> foundArtwork = entities.Artworks.Where(x => x.Artwork_Id == primaryKey).ToList();

            return View(foundArtwork);
        }

        
    }
}
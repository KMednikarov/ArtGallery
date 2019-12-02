using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtGallery.Models;

namespace ArtGallery.Controllers
{
    public class HomeController : Controller
    {
        private List<Artwork> allArtworks;
        private List<Category> allCategories;
        public ActionResult Index()
        {
            LoadModels();

            ViewData["categoriesList"] = GetCategoriesList();

            return View(allArtworks);
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            ArtGalleryDatabaseEntities entities = new ArtGalleryDatabaseEntities();
            List<Artwork> filteredArtworks;
            int chosenCategory = Convert.ToInt32(formCollection[0]);
            if (chosenCategory == 0)
            {
                filteredArtworks = entities.Artworks.ToList();
            }
            else
            {
                filteredArtworks = entities.Artworks
                    .Where(artwork => artwork.Category_Id == chosenCategory)
                    .ToList();
            }

            LoadModels();
            ViewData["categoriesList"] = GetCategoriesList();

            return View(filteredArtworks);
        }
        private void LoadModels()
        {
            ArtGalleryDatabaseEntities entities = new ArtGalleryDatabaseEntities();
            allArtworks = entities.Artworks.ToList();
            allCategories = entities.Categories.ToList();
        }
        private SelectList GetCategoriesList()
        {
            List<SelectListItem> cat = new List<SelectListItem>();
            foreach (var category in allCategories)
            {
                cat.Add(new SelectListItem
                {
                    Value = category.Category_Id.ToString(),
                    Text = category.Name.ToString()
                });
            }
            
            return  new SelectList(cat, "Value", "Text", 1);
        }
    }
}
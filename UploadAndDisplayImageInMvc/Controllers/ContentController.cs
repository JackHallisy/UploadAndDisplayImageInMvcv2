using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UploadAndDisplayImageInMvc.Models;
using UploadAndDisplayImageInMvc.Repositories;
using UploadAndDisplayImageInMvc.ViewModel;

namespace UploadAndDisplayImageInMvc.Controllers
{
    [RoutePrefix("Content")]
    [ValidateInput(false)]
    public class ContentController : Controller
    {
        private DBContext db = new DBContext();
        /// <summary>
        /// Retrive content from database 
        /// </summary>
        /// <returns></returns>
        [Route("Index")]
        [HttpGet]
        public ActionResult Index()
        {
            var content = db.Contents.Select(s => new
            {
                s.ID,
                s.Title,
                s.Image1,
                s.Image2,
                s.Contents,
                s.Description
            });

            List<ContentViewModel> contentModel = content.Select(item => new ContentViewModel()
            {
                ID = item.ID,
                Title = item.Title,
                Image1 = item.Image1,
                Image2 = item.Image2,
                Description = item.Description,
                Contents = item.Contents
            }).ToList();
            return View(contentModel);
        }

        /// <summary>
        /// Retrive Image from database 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult RetrieveImage1(int id)
        {
            byte[] cover1 = GetImage1FromDataBase(id);
            if (cover1 != null)
            {
                return File(cover1, "image/jpg");
            }
            else
            {
                return null;
            }
        }
        public ActionResult RetrieveImage2(int Id)
        {
            byte[] cover2 = GetImage2FromDataBase(Id);
            if (cover2 != null)
            {
                return File(cover2, "image/jpg");
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>


        public byte[] GetImage1FromDataBase(int Id)
        {
            var q = from temp in db.Contents where temp.ID == Id select temp.Image1;
            byte[] cover1 = q.First();
            return cover1;
        }
        public byte[] GetImage2FromDataBase(int Id)
        {
            var q = from temp in db.Contents where temp.ID == Id select temp.Image2;
            byte[] cover2 = q.First();
            return cover2;
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Save content and images
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("Create")]
        [HttpPost]
        public ActionResult Create(ContentViewModel model)
        {
            HttpPostedFileBase file = Request.Files["ImageData1"];
            HttpPostedFileBase file2 = Request.Files["ImageData2"];

            ContentRepository service = new ContentRepository();
            int i = service.UploadImageInDataBase(file, file2, model);
            if (i == 1)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}

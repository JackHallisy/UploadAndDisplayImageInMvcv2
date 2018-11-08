using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using UploadAndDisplayImageInMvc.Models;
using UploadAndDisplayImageInMvc.ViewModel;

namespace UploadAndDisplayImageInMvc.Repositories
{
    public class ContentRepository
    {
        private readonly DBContext db = new DBContext();
        public int UploadImageInDataBase(HttpPostedFileBase file, HttpPostedFileBase file2, ContentViewModel contentViewModel)
        {
            contentViewModel.Image1 = ConvertToBytes(file);
            contentViewModel.Image2 = ConvertToBytes(file);
            var Content = new Content
            {
                Title = contentViewModel.Title,
                Description = contentViewModel.Description,
                Contents = contentViewModel.Contents,
                Image1 = contentViewModel.Image1,
                Image2 = contentViewModel.Image2
            };

            db.Contents.Add(Content);
            int i = db.SaveChanges();
            if (i == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
    }
}
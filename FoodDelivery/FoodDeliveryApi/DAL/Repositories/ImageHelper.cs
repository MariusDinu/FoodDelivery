using FoodDeliveryApi.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryApi.DAL.Repositories
{
    public class ImageHelper : IImageHelper
    {
        string IImageHelper.AddImage(string Data, string Email)
        {
            var imageDataByteArray = Convert.FromBase64String(Data);
            var imageDataStream = new MemoryStream(imageDataByteArray);
            try
            {
                if (!Directory.Exists(Environment.CurrentDirectory + "\\uploads\\"))
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + "\\uploads\\");
                }

                using (System.Drawing.Image image = System.Drawing.Image.FromStream(imageDataStream, true))
                {
                    image.Save(Environment.CurrentDirectory + "\\uploads\\" + $"{Email}.png");  // Or Png
                }
               return Environment.CurrentDirectory + "\\uploads\\" + $"{Email}.png";

                
            }
            catch (Exception)
            {
                return null;
            }

        }

        string IImageHelper.ReadImage(string path)
        {
            byte[] code = System.IO.File.ReadAllBytes(path);
            var stream = new MemoryStream(code);
            string base64String = Convert.ToBase64String(stream.ToArray());
            return base64String;

        }
    }
}

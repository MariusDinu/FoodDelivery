using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryApi.DAL.IRepositories
{
    public interface IImageHelper
    {
        string AddImage(string Data,string Email);
        string ReadImage(string Path);
    }
}

using Android.App;
using Android.Content;
using System.IO;
using System.Reflection;

namespace FoodDelivery.Repository
{
    public class ConfigRepository
    {

        public void AddConfig()
        {
            ISharedPreferences pref = Application.Context.GetSharedPreferences("PathInfo", FileCreationMode.Private);
            ISharedPreferencesEditor edit = pref.Edit();
            edit.PutString("Paths", ReadJson());
            edit.Apply();
        }

        private string ReadJson()
        {
            string nameFile = "config.json";
            var assembly = typeof(MainActivity).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.Config.{nameFile}");
            using (StreamReader reader = new StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();
                return jsonString;
            }
        }
        public ConfigRepository() { AddConfig(); }
    }
}
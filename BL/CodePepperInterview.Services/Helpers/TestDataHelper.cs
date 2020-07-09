using CodePepperInterview.Contracts.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CodePepperInterview.Services.Helpers
{
    public static class TestDataHelper
    {
        public static RootoObject LoadCharacters()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "CodePepperInterview.Services.SampleData.Characters.json";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string jsonStr = reader.ReadToEnd();

                return JsonConvert.DeserializeObject<RootoObject>(jsonStr);
            }
        }
    }
}
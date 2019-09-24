using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic data retrieval from JSON test
    /// </summary>
    public class JsonReadingTest : ITest
    {
        public string Name { get { return "JSON Reading Test";  } }

        public void Run()
        {
            var jsonData = Resources.SamplePoints;

            // TODO: 
            // Determine for each parameter stored in the variable below, the average value, lowest and highest number.
            // Example output
            // parameter   LOW AVG MAX
            // temperature   x   y   z
            // pH            x   y   z
            // Chloride      x   y   z
            // Phosphate     x   y   z
            // Nitrate       x   y   z

            string jsonStr = Encoding.UTF8.GetString(jsonData);
           // var des= JsonConvert.DeserializeObject<Dictionary<String, Object>>(jsonStr);
            var items = JsonConvert.DeserializeObject<Sample>(jsonStr);

            //string json = JsonConvert.SerializeObject(jsonData);
            Console.WriteLine(items.date);

            //string bitString = BitConverter.ToString(jsonData);

            //var items = JsonConvert.DeserializeObject<List<Sample>>(bitString);

          //  var fah = JsonConvert.DeserializeObject <List < Sample>> (json);
           // Console.WriteLine(fah);

            PrintOverview(jsonData);
        }

        private void PrintOverview(byte[] data)
        {
        }
    }

    public class Sample
    {
        public DateTime date { get; set; }
        public double temperature { get; set; }
        public int pH { get; set; }
        public int phosphate { get; set; }
        public int chloride { get; set; }
        public int nitrate { get; set; }
    }

    public class SamplePoints
    {
        public List<Sample> samples { get; set; }
    }
}

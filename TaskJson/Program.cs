using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TaskJson
{
    internal class Program
    {
        public class tests
        {
            public int id { get; set; }
            public string title { get; set; }
            public string values { get; set; }
        }
        public class values
        {
            public int id { get; set; }
            public string value { get; set; }
        }
        static void Main(string[] args)
        {
            string testsF = File.ReadAllText("tests.json");
            var testsJ = JsonConvert.DeserializeObject<tests[]>(testsF);

            string valuesF = File.ReadAllText("values.json");
            var valuesJ = JsonConvert.DeserializeObject<values[]>(valuesF);

            //var testList = new tests();
            //var valuesList = new values();
            
            foreach (var value in valuesJ)
            {
                foreach (var test in testsJ)
                {
                    if(value.id == test.id)
                    {
                        test.values = value.value;
                    }
                }
            }
            string result = JsonConvert.SerializeObject(testsJ);
            File.WriteAllText("res.json", result);
        }
    }
}

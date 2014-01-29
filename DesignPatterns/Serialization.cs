using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns
{
    [Serializable]
    public class SerializableType
    {
        public SerializableType()
        {
            Children = new List<string>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public bool YesOrNo { get; set; }
        public IList<string> Children { get; set; }
    }

    [TestClass]
    public class SerializationTests
    {
        [TestMethod]
        public void SerializeAndDeserialize()
        {
            var obj = new SerializableType
            {
                Id = 123,
                Name = "Test",
                DateTime = DateTime.Now,
                YesOrNo = true,
                Children = new List<string>
                {
                    "Child1",
                    "Child2"
                }
            };
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, obj);
                stream.Flush();
                stream.Position = 0;
                var str = Convert.ToBase64String(stream.ToArray());
                Console.WriteLine(str);
                stream.Seek(0, SeekOrigin.Begin);
                var newObj = (SerializableType)formatter.Deserialize(stream);
                Assert.IsTrue(newObj.Id == obj.Id);
                Assert.IsTrue(newObj.Name == obj.Name);
                Assert.IsTrue(newObj.DateTime == obj.DateTime);
                Assert.IsTrue(newObj.YesOrNo == obj.YesOrNo);
                Assert.IsTrue(newObj.Children.Count == obj.Children.Count);
            }
        }
    }
}

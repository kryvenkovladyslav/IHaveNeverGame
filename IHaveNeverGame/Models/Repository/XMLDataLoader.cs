using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace IHaveNeverGame.Models.Repository
{
    public class XMLDataLoader<T> : IDataLoader<T>
    {
        private readonly string path = @"C:\Games\Questions.xml";
        public IEnumerable<T> LoadData()
        {
            List<T> result;
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (var stream = File.OpenRead(path))
            {
                var deserialized = serializer.Deserialize(stream);
                result = (List<T>)deserialized;
            }
            return result;
        }
    }
}

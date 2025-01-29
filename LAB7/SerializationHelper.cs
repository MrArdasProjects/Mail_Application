using System.IO;
using System.Xml.Serialization;

namespace LAB7
{
    public class SerializationHelper
    {
        // Serileştirme metodu
        public static void SerializeUser(string fileName, User user)
        {
            // Eğer User sınıfındaki özellikler public değilse, serileştirme başarısız olur.
            XmlSerializer serializer = new XmlSerializer(typeof(User));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(fs, user);
            }
        }

        // Deserileştirme metodu
        public static User DeserializeUser(string fileName)
        {
            // Eğer User sınıfındaki özellikler public değilse, serileştirme başarısız olur.
            XmlSerializer serializer = new XmlSerializer(typeof(User));
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                return (User)serializer.Deserialize(fs);
            }
        }
    }
}

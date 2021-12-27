using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace MVVM.Model
{
    public class XMLFileService : IFileService
    {
        public List<Phone> Open(string fileName)
        {
            List<Phone> list = new List<Phone>();
            XmlSerializer formatter = 
                new XmlSerializer(typeof(List<Phone>));
            using (FileStream fs = 
                new FileStream(fileName,
                FileMode.OpenOrCreate))
            {
                list = (List<Phone>)formatter.Deserialize(fs);
            }
            return list;
        }

        public void Save(string fileName, List<Phone> phonesList)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Phone>));
            using (FileStream fs = new 
                FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, phonesList);
                MessageBox.Show("Сериализован");
            }
        }
    }
}

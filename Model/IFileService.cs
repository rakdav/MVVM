using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    public interface IFileService
    {
        List<Phone> Open(string fileName);
        void Save(string fileName, List<Phone> phonesList);
    }
}

using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModel
{
    public class PhoneViewModel : INotifyPropertyChanged
    {
        private Phone selectedPhone;
        public ObservableCollection<Phone> Phones { get; set; }

        public Phone SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public PhoneViewModel()
        {
            Phones = new ObservableCollection<Phone>
            {
                new Phone{Title="Samsung Galaxy",Company="Samsung",Price=1500},
                new Phone{Title="IOS 5S",Company="Apple",Price=65000}
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(
           [CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

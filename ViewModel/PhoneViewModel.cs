using MVVM.Model;
using MVVM.View;
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
        IFileService fileService;
        IDialogService dialogService;
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

        public PhoneViewModel(IDialogService dialogService,
            IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;
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

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ?? (saveCommand = new RelayCommand(obj =>
                {
                    try
                    {
                        if (dialogService.SaveFileDialog() == true)
                        {
                            fileService.Save(dialogService.FilePath,
                                Phones.ToList());
                            dialogService.ShowMessage("Файл сохранен");
                        }
                    }
                    catch (Exception ex)
                    {
                        dialogService.ShowMessage(ex.Message);
                    }
                }));
            }
        }
        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ?? (openCommand = new RelayCommand(obj =>
                {
                    try
                    {
                        if(dialogService.OpenFileDialog()==true)
                        {
                            var phones = fileService.Open(dialogService.FilePath);
                            Phones.Clear();
                            foreach (var item in phones)
                            {
                                Phones.Add(item);
                            }
                            dialogService.ShowMessage("Файл открыт");
                        }
                    }
                    catch(Exception ex)
                    {

                    }
                }));
            }
        }
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand(obj =>
                    {
                        AddEditPhone addEditPhone = new AddEditPhone();
                        if(addEditPhone.ShowDialog()==true)
                        {
                            Phone phone = new Phone();
                            phone.Title = addEditPhone.TitleName;
                            phone.Company = addEditPhone.Company;
                            phone.Price = addEditPhone.Price;
                            Phones.Add(phone);
                            SelectedPhone = phone;
                        }
                    }));
            }
        }

        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ?? (editCommand = new RelayCommand(obj =>
                {
                    if (selectedPhone != null)
                    {
                        AddEditPhone addEditPhone = new AddEditPhone();
                        addEditPhone.TitleName = selectedPhone.Title;
                        addEditPhone.Company = selectedPhone.Company;
                        addEditPhone.Price = selectedPhone.Price;
                        if (addEditPhone.ShowDialog() == true)
                        {
                            selectedPhone.Title = addEditPhone.TitleName;
                            selectedPhone.Company = addEditPhone.Company;
                            selectedPhone.Price = addEditPhone.Price;
                        }
                    }
                }));
            }
        }
        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ?? (deleteCommand = new RelayCommand(obj =>
                {
                    if (selectedPhone != null)
                    {
                        Phones.Remove(selectedPhone);
                    }
                }));
            }
        }
    }
}

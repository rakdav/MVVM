using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для AddEditPhone.xaml
    /// </summary>
    public partial class AddEditPhone : Window
    {
        public AddEditPhone()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        public string TitleName
        {
            get { return TitlePhone.Text; }
            set { TitlePhone.Text = value; }
        }
        public string Company
        {
            get { return CompanyPhone.Text; }
            set { CompanyPhone.Text = value; }
        }
        public int Price
        {
            get { return int.Parse(PricePhone.Text); }
            set { PricePhone.Text = value.ToString(); }
        }
    }
}

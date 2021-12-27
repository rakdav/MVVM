﻿using MVVM.Model;
using MVVM.ViewModel;
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
    /// Логика взаимодействия для PhoneView.xaml
    /// </summary>
    public partial class PhoneView : Window
    {
        public PhoneView()
        {
            InitializeComponent();
            DataContext = new PhoneViewModel(new DefaultDialogService(),
                new XMLFileService()
                );
        }
    }
}

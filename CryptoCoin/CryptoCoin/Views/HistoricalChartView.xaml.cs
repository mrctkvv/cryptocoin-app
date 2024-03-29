﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CryptoCoin.ViewModels;

namespace CryptoCoin.Views
{
    /// <summary>
    /// Interaction logic for HistoricalChartView.xaml
    /// </summary>
    public partial class HistoricalChartView : Page
    {
        public HistoricalChartView(string modelId)
        {
            InitializeComponent();
            DataContext = new HistoricalChartViewModel(modelId);
        }
    }
}

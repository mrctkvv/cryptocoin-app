using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for FullCurrencyView.xaml
    /// </summary>
    public partial class FullCurrencyView : Page
    {
        public FullCurrencyView(string modelId)
        {
            InitializeComponent();
            DataContext = new FullCurrencyViewModel(modelId);
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            if (Uri.IsWellFormedUriString(e.Uri.ToString(), UriKind.Absolute))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = e.Uri.AbsoluteUri,
                    UseShellExecute = true
                });
                e.Handled = true;
            }
        }
    }
}

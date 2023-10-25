using CryptoCoin.Models;
using CryptoCoin.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CryptoCoin.Views
{
    /// <summary>
    /// Interaction logic for ChartsView.xaml
    /// </summary>
    public partial class ChartsView : Page
    {
        public ChartsView()
        {
            InitializeComponent();
            DataContext = new ChartsViewModel();
        }
        private void ListViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (CoinsGrid.SelectedItem.GetType() == typeof(CryptoCoinModel))
            {
                var model = (CryptoCoinModel)CoinsGrid.SelectedItem;
                if (model.Id is null)
                {
                    MessageBox.Show("Currency Id is null.");
                    return;
                }
                var chartPage = new HistoricalChartView(model.Id);
                ChartsFrame.Content = chartPage;
            }
            else MessageBox.Show("Something went wrong. Try to pick another currency");
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            var searchString = SearchStringTextBox.Text.Trim();
            var viewModel = DataContext as CryptoCoinViewModel;
            if (viewModel is null)
            {
                MessageBox.Show("Something went wrong");
                return;
            }
            if (string.IsNullOrEmpty(searchString))
            {
                viewModel.SelectedModels = viewModel.Models;
            }
            else
            {
                searchString = searchString.ToLower();
                var searchBy = ModelsSearchBy.SelectedValue as TextBlock;
                if (searchBy is null) return;
                switch (searchBy.Text.ToLower())
                {
                    case "id":
                        viewModel.SelectedModels = GetMatchingAssets(viewModel.Models.ToList(),
                            asset => asset.Id != null && asset.Id.ToLower().Contains(searchString));
                        break;
                    case "name":
                        viewModel.SelectedModels = GetMatchingAssets(viewModel.Models.ToList(),
                            asset => asset.Name != null && asset.Name.ToLower().Contains(searchString));
                        break;
                }
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            SearchStringTextBox.Text = string.Empty;
            var viewModel = DataContext as CryptoCoinViewModel;
            if (viewModel is null)
            {
                MessageBox.Show("Something went wrong");
                return;
            }
            viewModel.SelectedModels = viewModel.Models;
            ChartsFrame.Content = null;
        }

        private static ObservableCollection<CryptoCoinModel> GetMatchingAssets(List<CryptoCoinModel> assetsList, Func<CryptoCoinModel, bool> predicate)
        {
            var mathingModels = assetsList.Where(predicate).ToList();

            return new ObservableCollection<CryptoCoinModel>(mathingModels);
        }


    }
}

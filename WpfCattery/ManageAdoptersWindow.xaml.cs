using Application.Dto;
using Application.Mappers;
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

namespace WpfCattery
{
    /// <summary>
    /// Logica di interazione per ManageAdoptersWindow.xaml
    /// </summary>
    public partial class ManageAdoptersWindow : Window
    {
        public ManageAdoptersWindow()
        {
            InitializeComponent();
            LoadAdopters();
        }
        List<AdopterDto> AllAdopters = new List<AdopterDto>();
        private void AdoptersList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AdoptersList.SelectedItem is AdopterDto adopter)
            {
                UpdateAdopterWindow updateWindow = new UpdateAdopterWindow(adopter);
                updateWindow.ShowDialog();
                LoadAdopters();
            }
        }
        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void LoadAdopters()
        {
            AllAdopters = App.AdopterService.GetAllAdopters().ToList();
            AdoptersList.ItemsSource = AllAdopters;
        }
    }
}

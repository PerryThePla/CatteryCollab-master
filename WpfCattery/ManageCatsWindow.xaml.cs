using Application.Dto;
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
    /// Logica di interazione per ManageCatsWindow.xaml
    /// </summary>
    public partial class ManageCatsWindow : Window
    {
        List<CatDto> Catdtos= new List<CatDto>();
        public ManageCatsWindow()
        {
            InitializeComponent();
            var catdtos=App.CatService.GetAllCats();
            Catdtos=catdtos.ToList();
            CatsList.ItemsSource = Catdtos;
        }
        private void CatsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            CatDto cat = listBox.SelectedItem as CatDto;
            UpdateCatWindow updateCatWindow = new UpdateCatWindow(cat);
            updateCatWindow.ShowDialog();
            CatsList.ItemsSource = CatsList.ItemsSource = App.CatService.GetAllCats();
        }
    }
}

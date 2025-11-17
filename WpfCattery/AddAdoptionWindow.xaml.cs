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
    /// Logica di interazione per AddAdoptionWindow.xaml
    /// </summary>
    public partial class AddAdoptionWindow : Window
    {
        public AddAdoptionWindow()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            CBAdopters.ItemsSource = App.AdopterService.GetAllAdopters();
            CBCats.ItemsSource = App.CatService.GetAllCats().Where(c=>c.departureDate==null);
        }

        private void BTNAggiungi_Click(object sender, RoutedEventArgs e)
        {
            if (CBCats.SelectedItem is null) return;
            if (CBAdopters.SelectedItem is null) return;
            if(DPAdoptionDate.SelectedDate is null)
            {
                MessageBox.Show("Seleziona una data di adozione valida.");
                return;
            }
            CatDto cat = (CatDto)CBCats.SelectedItem;
            AdoptionDto adoption = new AdoptionDto
                ((CatDto)CBCats.SelectedItem,
                DateOnly.FromDateTime(DPAdoptionDate.SelectedDate.Value),
                (AdopterDto)CBAdopters.SelectedItem, Domain.Model.Entities.Adoption.AdoptionStatus.Completed);
            App.CatService.UpdateDepartureDate(cat.ID, adoption.AdoptionDate);
            App.AdoptionService.Create(adoption);
            this.Close();
        }
    }
}

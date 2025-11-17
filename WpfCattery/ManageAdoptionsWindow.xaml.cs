using Application.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfCattery
{
    public partial class ManageAdoptionsWindow : Window
    {
        List<AdoptionDto> AllAdoptions = new List<AdoptionDto>();

        public ManageAdoptionsWindow()
        {
            InitializeComponent();
            LoadAdoptions();
        }

        private void LoadAdoptions()
        {
            // Il metodo .Where() restituisce un IEnumerable<T>, non un List<T>.
            // Per assegnare il risultato a una variabile di tipo List<AdoptionDto> serve chiamare .ToList() dopo .Where().
            // Corretto:
            AllAdoptions = App.AdoptionService.GetAllAdoptions()
                .Where(a => a.status == Domain.Model.Entities.Adoption.AdoptionStatus.Cancelled)
                .ToList();
            AdoptionsList.ItemsSource = AllAdoptions;
        }

        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = TBSearch.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                AdoptionsList.ItemsSource = AllAdoptions;
            }
            else
            {
                var filtered = AllAdoptions.Where(a =>
                    a.Cat.name.ToLower().Contains(searchText) ||
                    a.Adopter.FirstName.ToLower().Contains(searchText) ||
                    a.Adopter.LastName.ToLower().Contains(searchText) ||
                    a.Adopter.FiscalCode.ToString().ToLower().Contains(searchText)
                ).ToList();
                AdoptionsList.ItemsSource = filtered;
            }
        }

        private void AdoptionsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AdoptionsList.SelectedItem is AdoptionDto adoption)
            {
                UpdateAdoptionWindow updateWindow = new UpdateAdoptionWindow(adoption);
                updateWindow.ShowDialog();
                LoadAdoptions();
            }
        }
    }
}
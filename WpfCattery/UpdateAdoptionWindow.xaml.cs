using Application.Dto;
using System;
using System.Windows;

namespace WpfCattery
{
    public partial class UpdateAdoptionWindow : Window
    {
        private AdoptionDto _adoption;

        public UpdateAdoptionWindow(AdoptionDto adoption)
        {
            InitializeComponent();
            _adoption = adoption;
            LoadData();
        }

        private void LoadData()
        {
            // Dati Gatto
            TBCatName.Text = _adoption.Cat.name;
            TBCatBreed.Text = _adoption.Cat.breed;
            TBCatID.Text = _adoption.Cat.ID ?? "N/A";

            // Dati Adottante
            TBAdopterName.Text = $"{_adoption.Adopter.FirstName} {_adoption.Adopter.LastName}";
            TBAdopterFC.Text = _adoption.Adopter.FiscalCode.ToString();
            TBAdopterPhone.Text = _adoption.Adopter.Phone.ToString();

            // Data Adozione
            DPAdoptionDate.SelectedDate = new DateTime(
                _adoption.AdoptionDate.Year,
                _adoption.AdoptionDate.Month,
                _adoption.AdoptionDate.Day
            );
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Elimina_Click(object sender, RoutedEventArgs e)
        {
            App.AdoptionService.CancelAdoption(_adoption);
            this.Close();
        }
    }
}
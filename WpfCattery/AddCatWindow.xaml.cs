using Application.Dto;
using Application.UseCases;
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
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace WpfCattery
{
    /// <summary>
    /// Logica di interazione per AddCatWindow.xaml
    /// </summary>
    public partial class AddCatWindow : Window
    {
        public AddCatWindow()
        {
            InitializeComponent();
        }

        private void BTNAggiungiGatto_Click(object sender, RoutedEventArgs e)
        {
            if (!Check()) return;
            CatDto catDto = new CatDto(
                TBCatName.Text,
                TBCatBreed.Text,
                (bool)CBIsMale.IsChecked,
                DateOnly.FromDateTime(DPArrivalDate.SelectedDate.Value),
                DPDepartureDate.SelectedDate.HasValue ? DateOnly.FromDateTime(DPDepartureDate.SelectedDate.Value) : null,
                DPBirthDate.SelectedDate.HasValue ? DateOnly.FromDateTime(DPBirthDate.SelectedDate.Value) : null,
                TBDescription.Text
            );
            try
            {
                App.CatService.AddCat(catDto);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante l'aggiunta del gatto: {ex.Message}", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            this.Close();
        }
        private bool Check()
        {
            if (string.IsNullOrWhiteSpace(TBCatName.Text))
            {
                MessageBox.Show("Il nome del gatto è obbligatorio.", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(TBCatBreed.Text))
            {
                MessageBox.Show("La razza del gatto è obbligatoria.", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!DPArrivalDate.SelectedDate.HasValue)
            {
                MessageBox.Show("La data di arrivo è obbligatoria.", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}

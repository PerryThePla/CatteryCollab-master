using Application.Dto;
using Domain.Model.ValueObjects;
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
    /// Logica di interazione per AddAdopterWindow.xaml
    /// </summary>
    public partial class AddAdopterWindow : Window
    {
        public AddAdopterWindow()
        {
            InitializeComponent();
        }

        private void BTNAggiungi_Click(object sender, RoutedEventArgs e)
        {
            if (!Check()) return;

            try
            {
                Email email = new Email(TBEmail.Text);
                PhoneNumber phone = new PhoneNumber(TBPhone.Text);
                FiscalCode fiscalCode = new FiscalCode(TBFiscalCode.Text);
                Cap cap = new Cap(TBCap.Text);

                AdopterDto adopterDto = new AdopterDto(
                    TBFirstName.Text,
                    TBLastName.Text,
                    email,
                    phone,
                    fiscalCode,
                    TBCity.Text,
                    cap
                );

                App.AdopterService.AddAdopter(adopterDto);
                MessageBox.Show("Adottante aggiunto con successo!", "Successo", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore: {ex.Message}", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool Check()
        {
            if (string.IsNullOrWhiteSpace(TBFirstName.Text))
            {
                MessageBox.Show("Il nome è obbligatorio.", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(TBLastName.Text))
            {
                MessageBox.Show("Il cognome è obbligatorio.", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(TBEmail.Text))
            {
                MessageBox.Show("L'email è obbligatoria.", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(TBPhone.Text))
            {
                MessageBox.Show("Il telefono è obbligatorio.", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(TBFiscalCode.Text))
            {
                MessageBox.Show("Il codice fiscale è obbligatorio.", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(TBCity.Text))
            {
                MessageBox.Show("La città è obbligatoria.", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(TBCap.Text))
            {
                MessageBox.Show("Il CAP è obbligatorio.", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}


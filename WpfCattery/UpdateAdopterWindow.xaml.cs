using Application.Dto;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Logica di interazione per UpdateAdopterWindow.xaml
    /// </summary>
    public partial class UpdateAdopterWindow : Window
    {
        private AdopterDto _adopter;
        public UpdateAdopterWindow(AdopterDto dto)
        {
            InitializeComponent();
            _adopter = dto;
            LoadData();
        }
        private void Elimina_Click(object sender, RoutedEventArgs e)
        {
            if(_adopter.FiscalCode is null) return;
            App.AdopterService.RemoveAdopter(_adopter.FiscalCode.Value);
            this.Close();
        }
        private void LoadData()
        {
            TBFirstName.Text = _adopter.FirstName;
            TBLastName.Text = _adopter.LastName;
            TBEmail.Text = _adopter.Address.Value;
            TBPhone.Text = _adopter.Phone.Value;
            TBFiscalCode.Text = _adopter.FiscalCode.Value;
            TBCity.Text = _adopter.City;
            TBCap.Text = _adopter.CityCap.Value;
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.AdopterService.UpdateAdopter(new AdopterDto(
    TBFirstName.Text,
    TBLastName.Text,
    new Domain.Model.ValueObjects.Email(TBEmail.Text),
    new Domain.Model.ValueObjects.PhoneNumber(TBPhone.Text),
    new Domain.Model.ValueObjects.FiscalCode(TBFiscalCode.Text),
    TBCity.Text,
    new Domain.Model.ValueObjects.Cap(TBCap.Text)
    ));
            }
            catch
            {
                MessageBox.Show("Error updating adopter.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            this.Close();
        }
    }
}

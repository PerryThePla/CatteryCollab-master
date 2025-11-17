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
    /// Logica di interazione per UpdateCatWindow.xaml
    /// </summary>
    public partial class UpdateCatWindow : Window
    {
        CatDto catdto;
        public UpdateCatWindow(CatDto dto)
        {
            InitializeComponent();
            catdto = dto;
            DataContext = catdto;
            DParrival.SelectedDate = new DateTime(catdto.arrivalDate.Year, catdto.arrivalDate.Month, catdto.arrivalDate.Day);
            DParrival.DisplayDate = new DateTime(catdto.arrivalDate.Year, catdto.arrivalDate.Month, catdto.arrivalDate.Day);
            if (catdto.departureDate.HasValue)
                DPdeparture.SelectedDate = new DateTime(catdto.departureDate.Value.Year, catdto.departureDate.Value.Month, catdto.departureDate.Value.Day);
                DPdeparture.DisplayDate = catdto.departureDate.HasValue ? new DateTime(catdto.departureDate.Value.Year, catdto.departureDate.Value.Month, catdto.departureDate.Value.Day) : DateTime.Now;
            if (catdto.birthDate.HasValue)
                DPbirth.SelectedDate = new DateTime(catdto.birthDate.Value.Year, catdto.birthDate.Value.Month, catdto.birthDate.Value.Day);
                DPbirth.DisplayDate = catdto.birthDate.HasValue ? new DateTime(catdto.birthDate.Value.Year, catdto.birthDate.Value.Month, catdto.birthDate.Value.Day) : DateTime.Now;

        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(DPdeparture.SelectedDate is null)
            {
                MessageBox.Show("Please select a valid departure date.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            App.CatService.UpdateDepartureDate(catdto.ID!, DateOnly.FromDateTime(DPdeparture.SelectedDate.Value));
            this.Close();
        }

        private void Elimina_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.CatService.Remove(catdto.ID!);
            }
            catch { 
                MessageBox.Show("Error deleting the cat.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            this.Close();
        }
    }
}

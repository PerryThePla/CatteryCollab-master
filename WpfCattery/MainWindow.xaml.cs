using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCattery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Refreshpage();
        }

        private void AddCat_Click(object sender, RoutedEventArgs e)
        {
            AddCatWindow addCatWindow = new AddCatWindow();
            this.Hide();
            addCatWindow.ShowDialog();
            this.Show();
            Refreshpage();

        }
        private void ManageCats_Click(object sender, RoutedEventArgs e)
        {
            ManageCatsWindow manageCatsWindow = new ManageCatsWindow();
            this.Hide();
            manageCatsWindow.ShowDialog();
            this.Show();
        }
        private void ManageAdoptions_Click(object sender, RoutedEventArgs e)
        {
            ManageAdoptionsWindow manageAdoptionsWindow = new ManageAdoptionsWindow();
            this.Hide();
            manageAdoptionsWindow.ShowDialog();
            this.Show();
        }
        private void AddAdoption_Click(object sender, RoutedEventArgs e)
        {
            AddAdoptionWindow addAdoptionWindow = new AddAdoptionWindow();
            this.Hide();
            addAdoptionWindow.ShowDialog();
            this.Show();
            Refreshpage();

        }
        private void ManageAdopters_Click(object sender, RoutedEventArgs e)
        {
            ManageAdoptersWindow manageAdoptersWindow = new ManageAdoptersWindow();
            this.Hide();
            manageAdoptersWindow.ShowDialog();
            this.Show();
        }
        private void AddAdopter_Click(object sender, RoutedEventArgs e)
        {
            AddAdopterWindow addAdopterWindow = new AddAdopterWindow();
            this.Hide();
            addAdopterWindow.ShowDialog();
            this.Show();

        }
        private void Refreshpage()
        {
            int totCats = App.CatService.GetAllCats().Count(c => c.departureDate == null);
            int totMales = App.CatService.GetAllCats().Count(c => c.ismale && c.departureDate == null);
            lblTotGatti.Content = "Totale gatti: " + totCats;
            lblTotGattiMaschi.Content = "Totale gatti maschi: " + totMales;
            lblTotGattiFemmine.Content = "Totale gatti femmine: " + (totCats - totMales);
        }
    }
}
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
using System.Linq;

namespace SCRUMTESZT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnMain_Click(object sender, RoutedEventArgs e)
        {
            if (listboxVezeto.SelectedItem != null)
            {
                var selectedListBoxItem = listboxVezeto.SelectedItem;

                if (selectedListBoxItem is ListBoxItem listBoxItem) labelScrumVezetoOutput.Content = listBoxItem.Content.ToString(); else labelScrumVezetoOutput.Content = selectedListBoxItem.ToString();
            }
            else labelScrumVezetoOutput.Content = "Hiba! Nem választottál ki semmit";

            if (comboboxModszertanok.SelectedItem != null)
            {
                var selectedComboboxItem = comboboxModszertanok.SelectedItem;
                if (selectedComboboxItem is ComboBoxItem comboBoxItem) labelModszertanOutput.Content = comboBoxItem.Content.ToString(); else labelDokumentumOutput.Content = selectedComboboxItem.ToString();
            }
            else labelModszertanOutput.Content = "Hiba! Nem választottál ki semmit";


            var checkedElementCount = stackpanelEsemenyek.Children
            .OfType<CheckBox>()
            .Where(e => e.IsChecked == true)
            .Select(e => e.Content)
            .ToList();

            if (checkedElementCount.Count == 0)
            {
                lblError.Visibility = Visibility.Visible;
            }
            else
            {
                ComboboxEsemenyekOutput.ItemsSource = checkedElementCount;
                lblError.Visibility = Visibility.Collapsed;
            }

        }
    }
}
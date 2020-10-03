using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Markup;


namespace CombGenV2
{
  public partial class MainWindow : Window, IComponentConnector
    {
        private Permutator c1;

        public MainWindow()
        {
            InitializeComponent();
            c1 = new Permutator();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            label.Visibility = Visibility.Hidden;
            label_Copy.Visibility = Visibility.Hidden;
            Stopwatch stopwatch = Stopwatch.StartNew();
            c1.Permute(textBox.Text);
            stopwatch.Stop();
            label.Content = "ოპერაცია დასრულდა";
            label.Visibility = Visibility.Visible;
            label_Copy.Visibility = Visibility.Visible;
            if (c1.dataForMain[1] > 1)
            {
                MessageBox.Show("ოპერაცია წარმატებით დასრულდა! დრო: " + stopwatch.Elapsed + "  \n კომბინაციები ბოლო ფაილში: " + c1.dataForMain[0] + ". ფაილები: " + c1.dataForMain[1] + ".\n თითო ფაილში 12,000,000 კომბინაციაა.");
            }
            else
            {
                MessageBox.Show("ოპერაცია წარმატებით დასრულდა! \n კომბინაციები: " + c1.dataForMain[0] + " ფაილები: " + c1.dataForMain[1]);
            }
        }
    }
}

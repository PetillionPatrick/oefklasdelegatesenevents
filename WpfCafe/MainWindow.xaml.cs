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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibCafe;

namespace WpfCafe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PintDish pintDish;
        int numberOfPints = 5;
        public MainWindow()
        {
            InitializeComponent();

            
            pintDish = new PintDish(numberOfPints);
            pintDish.PintStarted += PintDish_PintStarted;
            pintDish.DishCompleted += PintDish_DishCompleted;
        }

        private void PintDish_DishCompleted(object sender, DishCompletedArgs e)
        {
            lblMessage.Content = ($"Dish completed in {e.CreationTimeNeeded.TotalMilliseconds} ms, enjoy your drinks!");
        }

        private void PintDish_PintStarted(object sender, EventArgs e)
        {
            AddPintImage();
        }

        private void AddPintImage()
        {
            // zoek een pintfiguurtje, plaats dat in de map images
            Image img = new Image();
            img.Source = new BitmapImage(new Uri("images/pint.png", UriKind.Relative));
            img.Width = 40;

            spPints.Children.Add(img);
        }

        private void btnPintPlease_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pintDish.AddPint();
                lblCountPints.Content = ($"{pintDish.PintCount}/{numberOfPints}");
            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.Message);
            }
        }
    }
}

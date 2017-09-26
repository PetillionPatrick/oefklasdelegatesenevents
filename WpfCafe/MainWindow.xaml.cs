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

        public MainWindow()
        {
            InitializeComponent();

            int numberOfPints = 5;
            PintDish pintDish = new PintDish(numberOfPints);
        }



        private void AddPintImage()
        {
            // zoek een pintfiguurtje, plaats dat in de map images
            Image img = new Image();
            img.Source = new BitmapImage(new Uri("images/pint.png", UriKind.Relative));
            img.Width = 40;

            spPints.Children.Add(img);
        }



    }
}

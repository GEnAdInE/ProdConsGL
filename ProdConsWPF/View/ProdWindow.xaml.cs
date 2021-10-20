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

namespace ProdConsWPF
{
    /// <summary>
    /// Logique d'interaction pour ProdWindow.xaml
    /// </summary>
    public partial class ProdWindow : Window
    {
        public delegate void PUSHEvent(int iNValue);
        public event PUSHEvent NewPUSH;
        /// <summary>
        /// Constructor
        /// </summary>
        public ProdWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// On push clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            string value = txt.Text;
            int valueconverted = 0;
            if(int.TryParse(value, out valueconverted))
                NewPUSH?.Invoke(valueconverted);
        }
    }
}

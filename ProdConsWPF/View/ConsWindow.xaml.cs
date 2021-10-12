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
    /// Logique d'interaction pour ConsWindow.xaml
    /// </summary>
    public partial class ConsWindow : Window
    {
        public delegate void POPEvent(object sender);
        public event POPEvent NewPOP;
        public ConsWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewPOP?.Invoke(this);
        }
    }
}

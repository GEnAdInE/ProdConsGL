using ProdConsoTP1;
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

namespace ProdConsWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StockManager stockManager;
        public MainWindow()
        {
            InitializeComponent();
            stockManager = new StockManager(10);
        }


        private void Cons_Click(object sender, RoutedEventArgs e)
        {
            ConsWindow cons0 = new ConsWindow();
            cons0.Show();
            cons0.NewPOP += Cons0_NewPOP;
        }

        private void Cons0_NewPOP()
        {
            stockManager.Pop();
        }

        private void Prod_Click(object sender, RoutedEventArgs e)
        {
            ProdWindow prod0 = new ProdWindow();
            prod0.Show();
            prod0.NewPUSH += Prod0_NewPUSH;
        }

        private void Prod0_NewPUSH(int iNValue)
        {
            stockManager.Push(iNValue);
        }
    }
}

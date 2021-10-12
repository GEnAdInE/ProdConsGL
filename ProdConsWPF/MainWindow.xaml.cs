using ProdConsoTP1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private List<Window> openWindow;


        private StockManager stockManager;


        private int iLastValuePoped;
        public MainWindow()
        {
            InitializeComponent();
            openWindow = new List<Window>(); //create a collection of opened window to be able to close them on the closing of the main window

            stockManager = new StockManager(10,@"D:/test/");//taille 10


            //Manage Alert
            stockManager.MyAlert.OnAlertTriggered += MyAlert_OnAlertTriggered;
            stockManager.MyAlert.OnAlertTriggeredEnd += MyAlert_OnAlertTriggeredEnd;
           
        }

        private void MyAlert_OnAlertTriggeredEnd(object obj)
        {
            this.Lbl_Alert1.Visibility = Visibility.Hidden;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            foreach(Window w in openWindow)
            {
                if(w != null)
                    w.Close();
            }
            base.OnClosing(e);

        }



        private void MyAlert_OnAlertTriggered(object obj)
        {
            //here define the action to be done on alert

            //for the exemple we are gonna show a hiden alert text
            // can be hide with another event to be defined in alert to remove alert
            this.Lbl_Alert1.Visibility = Visibility.Visible;
        }



        #region Cons
        private void Cons_Click(object sender, RoutedEventArgs e)
        {
            ConsWindow cons0 = new ConsWindow();
            openWindow.Add(cons0);
            cons0.Show();
            cons0.NewPOP += Cons0_NewPOP;
        }

        private void Cons0_NewPOP(object sender)
        {
            iLastValuePoped = stockManager.Pop();
            ConsWindow temp = sender as ConsWindow;
            temp.txt_valueConsumed.Text = iLastValuePoped.ToString();
           
        }

        #endregion

        #region Prod
        private void Prod_Click(object sender, RoutedEventArgs e)
        {
            ProdWindow prod0 = new ProdWindow();
            openWindow.Add(prod0);
            prod0.Show();
            prod0.NewPUSH += Prod0_NewPUSH;
        }

        private void Prod0_NewPUSH(int iNValue)
        {
            stockManager.Push(iNValue);
        }
        #endregion

        #region Admin
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            stockManager.Clear();
        }

        #endregion
    }
}

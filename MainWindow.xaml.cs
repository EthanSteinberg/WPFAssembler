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

using System.Threading;

namespace WPFAssembler
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

        private void Button_Click_1(object sender,RoutedEventArgs e)
        {
            string text = SourceAssembly.Text;
            ThreadStart start = delegate()
            {

                Parser p = new Parser(text);
                string outputText = p.parse();
                Dispatcher.Invoke(new Action<string>(SetStatus),outputText);
            };

            new Thread(start).Start();
                

        }

        private void SetStatus(string text)
        {
           
            OutputAssembly.Text = text;
        }
    }
}

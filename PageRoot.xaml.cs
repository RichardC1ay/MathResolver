using MathResolver.Pages;
using System;
using System.Collections.Generic;
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

namespace MathResolver
{
    /// <summary>
    /// Interaction logic for PageRoot.xaml
    /// </summary>
    public partial class PageRoot : UserControl
    {
        public PageRoot()
        {
            InitializeComponent();

            ContentFrame.Navigate(typeof(BinomialExpansionPage));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFiDU
{
    /// <summary>
    /// Lógica de interacción para LoadingForm.xaml
    /// </summary>
    public partial class LoadingForm : Window
    {
        public LoadingForm()
        {
            InitializeComponent();
            //mediaElement1.Durat
            //mediaElement1.Play();
    
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mediaElement1_MediaEnded(object sender, RoutedEventArgs e)
        {

            //DependencyProperty o ;


            //mediaElement1.BeginAnimation(System.Windows.Media.Animation.AnimationTimeline.BeginTimeProperty);
               

        }
    }
}

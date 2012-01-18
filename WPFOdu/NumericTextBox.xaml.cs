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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;


namespace WPFiDU
{
    /// <summary>
    /// Lógica de interacción para NumericTextBox.xaml
    /// </summary>
    public partial class NumericTextBox : System.Windows.Controls.TextBox
    {
        private double mFactor = 1;

        public double Factor
        {
            get { return mFactor; }
            set 
            { 
                mFactor = value;
                
            }
        }

        public NumericTextBox()
        {
            this.Width = 150;
        }


        public new string RawText
        {
          get
          {
            if (base.Text.Equals(string.Empty))
              base.Text = "0";
            return base.Text;
          }

          set
          {
            double numero = double.Parse(value) * mFactor;
            base.Text = numero.ToString(mNumberFormat);
          }
        }

        public new string Text
        {
            get 
            {
                if (base.Text.Equals(string.Empty))
                    base.Text = "0";
                int numero = (int)(double.Parse(base.Text) / mFactor);
                return numero.ToString();
            }

            set
            {
                double numero = double.Parse(value) * mFactor;
                base.Text = numero.ToString(mNumberFormat);
            }
        }
        // 0.###
        public string mNumberFormat = "0.#";
        public string NumberFormat { get { return mNumberFormat; } set { mNumberFormat = value; } }

        protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            //base.OnKeyDown(e);
            /*if(e.Key = Key.
            e.Key = Key.sh*/
            // nonNumberEntered = false;
            //Key.

            //if( e.IsUp )
            //    return;


            //if (e.Key == Key.RightShift || e.Key == Key.LeftAlt || e.Key == Key.RightShift || e.Key == Key.RightAlt)
            //{
            //   // nonNumberEntered = true;
            //    //return;
            //}
            //if (e < Keys.D0 || e.KeyCode > Keys.D9)
            //{
            //    if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
            //    {
            //        if (e.KeyCode != Keys.Back)
            //        {
            //            nonNumberEntered = true;
            //        }
            //    }
            //}

            if (!((e.Key.CompareTo(Key.D0) >= 0 && e.Key.CompareTo(Key.D9) <= 0)
                || (e.Key.CompareTo(Key.NumPad0) >= 0 && e.Key.CompareTo(Key.NumPad9) <= 0)
                || e.Key.Equals(Key.Tab)
                || e.Key.Equals(Key.Return)
                || e.Key.Equals(Key.Enter)
                || e.Key.Equals(Key.Delete)
                || e.Key.Equals(Key.Back)
                || e.Key.Equals(Key.LeftCtrl | Key.V)
                || e.Key.Equals(Key.OemComma)
                || e.Key.Equals(Key.RightCtrl | Key.V)
                || e.Key.Equals(Key.LeftCtrl | Key.X)
                || e.Key.Equals(Key.RightCtrl | Key.X)
                || e.Key.Equals(Key.LeftCtrl | Key.C)
                || e.Key.Equals(Key.RightCtrl | Key.C)
                || ((e.Key.Equals(Key.Subtract)
                    || e.Key.Equals(Key.OemMinus))
                /*&& Text.IndexOf('-') < 0
                && SelectionStart == 0*/
                                            )
                ))
                e.Handled = true;
        }




    }



}
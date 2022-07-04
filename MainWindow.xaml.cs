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

namespace calc1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        double a = 0;
        double b = 0;
        double m = 0;
        public enum state
        {
            initial,
            divide,
            mod,
            mult,
            minus,
            plus
        }

        state state0 = state.initial;
        state prev = state.initial;

        private void eq(ref double a, double b)
        {
            if ((box0.Text != "-") && (box0.Text != "") && (box0.Text[box0.Text.Length - 1] != 'E') && (box0.Text[box0.Text.Length - 1] != '-') && (box0.Text[box0.Text.Length - 1] != '+'))
                if (state0 == state.initial)
            {
                box1.Text = "";
            }
            else if ((state0 == state.divide && prev == state.initial) || (prev == state.divide))
            {
                //b = System.Convert.ToDouble(box0.Text);
                if (b == 0)
                {
                    box1.Text = "Деление на 0";
                    MessageBox.Show("Деление на 0");
                }
                else
                {
                    box1.Text += box0.Text;
                    a = a / b; 
                    box0.Text = "0";
                    //a = System.Convert.ToDouble(box0.Text);
                }
                //state0 = state.initial;
                //b = 0;
                //box1.Text = "";
            }
            else if ((state0 == state.mod && prev == state.initial) || (prev == state.mod))
            {
                //b = System.Convert.ToDouble(box0.Text);
                if (b == 0)
                {
                    box1.Text = "Деление на 0";
                    MessageBox.Show("Деление на 0");
                }
                else
                {
                    box1.Text += box0.Text;
                    a = a % b;
                    box0.Text = "0";
                    //a = System.Convert.ToDouble(box0.Text);
                }
                //state0 = state.initial;
                //b = 0;
                //box1.Text = "";

            }
            else if ((state0 == state.mult && prev == state.initial) || (prev == state.mult))
            {
                //b = System.Convert.ToDouble(box0.Text);
                box1.Text += box0.Text;
                a = a * b;
                box0.Text = "0";
                //a = System.Convert.ToDouble(box0.Text);
                //state0 = state.initial;
                //b = 0;
                //box1.Text = "";
            }
            else if ((state0 == state.minus && prev == state.initial) || (prev == state.minus))
            {
                //b = System.Convert.ToDouble(box0.Text);
                box1.Text += box0.Text;
                a = a - b;
                box0.Text = "0";
                //a = System.Convert.ToDouble(box0.Text);
                //state0 = state.initial;
                //MessageBox.Show(a.ToString() + " - " + b.ToString());
                //b = 0;
                //box1.Text = "";
            }
            else if ((state0 == state.plus && prev == state.initial) || (prev == state.plus))
            {
                //b = System.Convert.ToDouble(box0.Text);
                box1.Text += box0.Text;
                a = a + b;
                box0.Text = "0";
                //a = System.Convert.ToDouble(box0.Text);
                //state0 = state.initial;
                //MessageBox.Show(a.ToString()+" + "+b.ToString());
                //b = 0;
                //box1.Text = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (box0.Text == "0") {
                box0.Text = "";
            }
            if (box0.Text.Length < 23)
            {
                box0.Text += (sender as Button).Content;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (box0.Text == "00")
            {
                box0.Text = "0";
            }

            int j = box0.Text.Split(',').Length - 1;
            if (j > 1)
            {
                Delete_Click(sender, e);
            }

            if (box0.Text.Length < 23)
            for (int i = 0; i < box0.Text.Length; i++)
            {
                if ((box0.Text[i] >= '0') && (box0.Text[i] <= '9'))
                {

                }
                else if (box0.Text[i] == 'E')
                {

                }
                else if (box0.Text[i] == ',')
                {

                }
                else if (box0.Text[i] == '+')
                {
                        if (i > 0)
                            if (box0.Text[i - 1] != 'E')
                            {
                                Delete_Click(sender, e);
                                Plus_Click(sender, e);
                            }
                }
                else if (box0.Text[i] == '-')
                {
                        if (i != 0)
                        {
                            Delete_Click(sender, e);
                            Minus_Click(sender, e);
                        }
                }
                else if (box0.Text[i] == '*')
                {
                    Delete_Click(sender, e);
                    Mult_Click(sender, e);
                }
                else if (box0.Text[i] == '/')
                {
                    Delete_Click(sender, e);
                    Divide_Click(sender, e);
                }
                else if (box0.Text[i] == '%')
                {
                    Delete_Click(sender, e);
                    Mod_Click(sender, e);
                }
                else if (box0.Text[i] == '=')
                {
                    Delete_Click(sender, e);
                    eq(ref a, b);
                }
                else
                {
                    Delete_Click(sender, e);
                }
            }
            else Delete_Click(sender, e);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (box0.Text.Length > 1)
            {
                box0.Text = box0.Text.Remove(box0.Text.Length - 1, 1);
            }
            else
            {
                box0.Text = "0";
            }
        }

        private void Comma_Click(object sender, RoutedEventArgs e)
        {
            int i = box0.Text.IndexOf(',');
            if (i == -1)
            {
                if (box0.Text != "-")
                box0.Text += ',';
            }
        }

        private void Ce_Click(object sender, RoutedEventArgs e)
        {
            box0.Text = "0";
        }

        private void Sign_Click(object sender, RoutedEventArgs e)
        {
            if ((box0.Text != "-") && (box0.Text != "") && (box0.Text[box0.Text.Length - 1] != 'E') && (box0.Text[box0.Text.Length - 1] != '-') && (box0.Text[box0.Text.Length - 1] != '+'))
                if (System.Convert.ToDouble(box0.Text) != 0)
            {
                if (box0.Text[0] == '-')
                {
                    box0.Text = box0.Text.Remove(0, 1);
                }
                else
                {
                    box0.Text = '-' + box0.Text;
                }
            }
        }

        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            if (state0 == state.initial)
            {
                if ((box0.Text != "-") && (box0.Text != "") && (box0.Text[box0.Text.Length - 1] != 'E') && (box0.Text[box0.Text.Length - 1] != '-') && (box0.Text[box0.Text.Length - 1] != '+'))
                    if (System.Convert.ToDouble(box0.Text) >= 0)
                {
                    a = Math.Sqrt(System.Convert.ToDouble(box0.Text));
                    box1.Text = "";
                    box0.Text = a.ToString();
                }
                else
                {
                    MessageBox.Show("Нельзя брать корень из отрицательного числа!");
                }
            }
            else
            {
                MessageBox.Show("Выражения с корнем не доступны в этой версии");
            }
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            if ((box0.Text != "-") && (box0.Text != "") && (box0.Text[box0.Text.Length - 1] != 'E') && (box0.Text[box0.Text.Length - 1] != '-') && (box0.Text[box0.Text.Length - 1] != '+'))
                if (state0 == state.initial)
            {
                a = System.Convert.ToDouble(box0.Text);
                box1.Text += box0.Text + '/';
                box0.Text = "0";
                state0 = state.divide;
                prev = state0;
            }
            else
            {
                state0 = state.divide;
                eq(ref a, System.Convert.ToDouble(box0.Text));
                box1.Text += '/';
                prev = state0;
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if ((box0.Text != "-") && (box0.Text != "") && (box0.Text[box0.Text.Length - 1] != 'E') && (box0.Text[box0.Text.Length - 1] != '-') && (box0.Text[box0.Text.Length - 1] != '+'))
            {
                eq(ref a, System.Convert.ToDouble(box0.Text));
                box0.Text = a.ToString();
                state0 = state.initial;
                box1.Text = "";
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            a = 0;
            b = 0;
            box1.Text = "";
            box0.Text = "0";
            state0 = state.initial;
            prev = state.initial;
        }

        private void Mod_Click(object sender, RoutedEventArgs e)
        {
            if ((box0.Text != "-") && (box0.Text != "") && (box0.Text[box0.Text.Length - 1] != 'E') && (box0.Text[box0.Text.Length - 1] != '-') && (box0.Text[box0.Text.Length - 1] != '+'))
                if (state0 == state.initial)
            {
                a = System.Convert.ToDouble(box0.Text);
                box1.Text += box0.Text + '%';
                box0.Text = "0";
                state0 = state.mod;
                prev = state0;
            }
            else
            {
                state0 = state.mod;
                eq(ref a, System.Convert.ToDouble(box0.Text));
                box1.Text += '%';
                prev = state0;
            }
        }

        private void Mult_Click(object sender, RoutedEventArgs e)
        {
            if ((box0.Text != "-") && (box0.Text != "") && (box0.Text[box0.Text.Length - 1] != 'E') && (box0.Text[box0.Text.Length - 1] != '-') && (box0.Text[box0.Text.Length - 1] != '+'))
                if (state0 == state.initial)
            {
                a = System.Convert.ToDouble(box0.Text);
                box1.Text += box0.Text + '*';
                box0.Text = "0";
                state0 = state.mult;
                prev = state0;
            }
            else
            {
                state0 = state.mult;
                eq(ref a, System.Convert.ToDouble(box0.Text));
                box1.Text += '*';
                prev = state0;
            }
        }

        private void Flip_Click(object sender, RoutedEventArgs e)
        {
            if ((box0.Text != "-") && (box0.Text != "") && (box0.Text[box0.Text.Length - 1] != 'E') && (box0.Text[box0.Text.Length - 1] != '-') && (box0.Text[box0.Text.Length - 1] != '+'))
                if (state0 == state.initial)
            {
                if (System.Convert.ToDouble(box0.Text) != 0)
                {
                    a = 1/(System.Convert.ToDouble(box0.Text));
                    box1.Text = "";
                    box0.Text = a.ToString();
                }
                else
                {
                    MessageBox.Show("Деление на 0");
                }
            }
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if ((box0.Text != "-") && (box0.Text != "") && (box0.Text[box0.Text.Length - 1] != 'E') && (box0.Text[box0.Text.Length - 1] != '-') && (box0.Text[box0.Text.Length - 1] != '+'))
                if (state0 == state.initial)
            {
                a = System.Convert.ToDouble(box0.Text);
                box1.Text += box0.Text + '-';
                box0.Text = "0";
                state0 = state.minus;
                prev = state0;
            }
            else
            {
                state0 = state.minus;
                eq(ref a, System.Convert.ToDouble(box0.Text));
                box1.Text += '-';
                //box0.Text = "0";
                prev = state0;
            }
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            if ((box0.Text != "-") && (box0.Text != "") && (box0.Text[box0.Text.Length - 1] != 'E') && (box0.Text[box0.Text.Length - 1] != '-') && (box0.Text[box0.Text.Length - 1] != '+'))
                if (state0 == state.initial)
            {
                a = System.Convert.ToDouble(box0.Text);
                box1.Text += box0.Text + '+';
                box0.Text = "0";
                state0 = state.plus;
                prev = state0;
            }
            else
            {
                state0 = state.plus;
                eq(ref a, System.Convert.ToDouble(box0.Text));
                box1.Text += '+';
                prev = state0;
                box0.Text = "0";
                //MessageBox.Show(b.ToString()+"many_plus");
            }
        }

        private void Mc_Click(object sender, RoutedEventArgs e)
        {
            m = 0;
        }

        private void Ms_Click(object sender, RoutedEventArgs e)
        {
            m = System.Convert.ToDouble(box0.Text);
        }

        private void Mr_Click(object sender, RoutedEventArgs e)
        {
            box0.Text = m.ToString();
        }

    }
}

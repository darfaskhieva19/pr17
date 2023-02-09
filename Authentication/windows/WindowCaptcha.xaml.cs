using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace Authentication
{
    /// <summary>
    /// Логика взаимодействия для WindowCaptcha.xaml
    /// </summary>
    public partial class WindowCaptcha : Window
    {
        string str = "";
        int k;
        public WindowCaptcha(int k)
        {
            InitializeComponent();
            this.k = k;
            Random random = new Random();
            int count = random.Next(7, 11); //рандомное кол-во линий
            for (int kol = 0; kol < count; kol++)
            {
                SolidColorBrush solidColor = new SolidColorBrush(Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256)));
                Line l = new Line()
                {
                    X1 = random.Next(Convert.ToInt32(CCaptcha.Width)),
                    Y1 = random.Next(Convert.ToInt32(CCaptcha.Height)),
                    X2 = random.Next(Convert.ToInt32(CCaptcha.Width)),
                    Y2 = random.Next(Convert.ToInt32(CCaptcha.Height)),
                    Stroke = solidColor
                };
                CCaptcha.Children.Add(l);
            }
            int x1 = 0;
            int x2 = Convert.ToInt32(CCaptcha.Width / k) - 20;
            char[] symbol = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char s = symbol[random.Next(symbol.Length)];
            for(int kol= 0; kol < count; kol++)
            {
                int position = random.Next(3);
                switch (position)
                {
                    case 0:
                        TextBlock txt = new TextBlock()
                        {
                            Text = s.ToString(),
                            FontSize = random.Next(20, 28),
                            FontFamily = new FontFamily("Calibri"),
                            Padding = new Thickness(random.Next(x1, x2), random.Next(Convert.ToInt32(CCaptcha.Height)) / 2, 0, 0),
                            FontStyle = FontStyles.Italic
                        };
                        CCaptcha.Children.Add(txt);
                        break;
                    case 1:
                        TextBlock txt1 = new TextBlock()
                        {
                            Text = s.ToString(),
                            FontSize = random.Next(20, 28),
                            FontFamily = new FontFamily("Calibri"),
                            Padding = new Thickness(random.Next(x1, x2), random.Next(Convert.ToInt32(CCaptcha.Height)) / 2, 0, 0),
                            FontWeight = FontWeights.Bold
                        };
                        CCaptcha.Children.Add(txt1);
                        break;
                    case 2:
                        TextBlock txt2 = new TextBlock()
                        {
                            Text = s.ToString(),
                            FontSize = random.Next(20, 28),
                            FontFamily = new FontFamily("Calibri"),
                            Padding = new Thickness(random.Next(x1, x2), random.Next(Convert.ToInt32(CCaptcha.Height)) / 2, 0, 0),
                            FontStyle = FontStyles.Italic,
                            FontWeight = FontWeights.Bold
                        };
                        CCaptcha.Children.Add(txt2);
                        break;
                }
                str += s.ToString();
            }
        }

        private void tbCaptcha_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbCaptcha.Text.Length == str.Length)
            {
                if (tbCaptcha.Text == str)
                {
                    MessageBox.Show("Успешная авторизация!");
                    ClassFrame.frameL.Navigate(new WindowResult());
                    Close();
                }
                else
                {
                    if (k == 1)
                    {
                        MessageBox.Show("CAPTCHA введена неправильно!\nПопробуйте еще", "Ошибка");
                        ClassFrame.frameL.Navigate(new PageAuthorization(3));
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Лимит исчерпан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        Close();
                    }
                }
            }
        }
    }
}

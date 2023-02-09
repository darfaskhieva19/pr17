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
        string str = String.Empty;
        int k;
        public WindowCaptcha(int k)
        {
            InitializeComponent();
            this.k = k;
            Random random = new Random();            
            for (int i = 0; i < 10; i++)
            {
                SolidColorBrush solidColor = new SolidColorBrush(Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256)));
                Line l = new Line()
                {
                    X1 = random.Next((int)CCaptcha.Width),
                    Y1 = random.Next((int)CCaptcha.Height),
                    X2 = random.Next((int)CCaptcha.Width),
                    Y2 = random.Next((int)CCaptcha.Height),
                    Stroke = solidColor
                };
                CCaptcha.Children.Add(l);
            }
            int count = random.Next(7, 11);
            string sym = "abcdefghijklmnopqrstuvwxyz01234567890";
            for (int i = 0; i < count; i++)
            {
                str += sym[random.Next(sym.Length)];
            }
            int position = random.Next(3);
            int margin = 20;
            for (int i= 0; i < str.Length; i++)
            {                
                switch (position)
                {
                    case 0:
                        TextBlock txt = new TextBlock()
                        {
                            Text = str[i].ToString(),
                            FontSize = random.Next(20, 28),
                            FontFamily = new FontFamily("Calibri"),
                            Margin = new Thickness(margin, random.Next(66), 0, 0),
                            FontStyle = FontStyles.Italic
                        };
                        CCaptcha.Children.Add(txt);
                        margin += 20;
                        break;
                    case 1:
                        TextBlock txt1 = new TextBlock()
                        {
                            Text = str[i].ToString(),
                            FontSize = random.Next(20, 28),
                            FontFamily = new FontFamily("Calibri"),
                            Margin = new Thickness(margin, random.Next(66), 0, 0),
                            FontWeight = FontWeights.Bold
                        };
                        CCaptcha.Children.Add(txt1);
                        margin += 20;
                        break;
                    case 2:
                        TextBlock txt2 = new TextBlock()
                        {
                            Text = str[i].ToString(),
                            FontSize = random.Next(20, 28),
                            FontFamily = new FontFamily("Calibri"),
                            Margin = new Thickness(margin, random.Next(66), 0, 0),
                            FontStyle = FontStyles.Italic,
                            FontWeight = FontWeights.Bold
                        };
                        CCaptcha.Children.Add(txt2);
                        margin += 20;
                        break;
                }
            }
        }

        private void tbCaptcha_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbCaptcha.Text.Length == str.Length)
            {
                if (tbCaptcha.Text == str)
                {
                    MessageBox.Show("Успешная авторизация!");
                    Close();
                    //ClassFrame.frameL.Navigate(new PageAuthorization(1));
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

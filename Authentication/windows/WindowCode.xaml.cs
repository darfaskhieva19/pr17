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
using System.Windows.Threading;

namespace Authentication
{
    /// <summary>
    /// Логика взаимодействия для WindowCode.xaml
    /// </summary>
    public partial class WindowCode : Window
    {
        DispatcherTimer times = new DispatcherTimer();
        string kod;
        int index;
        int time = 10; 
     
        public WindowCode(string kod, int index)
        {
            InitializeComponent();
            this.kod = kod;
            this.index = index;
            times.Interval = new TimeSpan(0, 0, 1); 
            times.Tick += new EventHandler(TimerC_tick);
            times.Start();            
        }

        public void TimerC_tick(object sender, EventArgs e)
        {
            time--;
            tbTime.Text = "Осталось " + time + " секунд";
            if (time < 0)
            {
                times.Stop();
                ClassFrame.frameL.Navigate(new PageAuthorization(index));
                Close();
            }
        }

        private void tbCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(tbCode.Text.Length == 5)
            {
                if (tbCode.Text == kod)
                {
                    times.Stop();
                    MessageBox.Show("Успешно!", "Авторизация");
                    Close();
                }
                else
                {
                    times.Stop();
                    MessageBox.Show("Код введен неверно!", "Ошибка");
                    ClassFrame.frameL.Navigate(new PageAuthorization(index));
                    Close();
                    
                }
            }
        }
    }
}

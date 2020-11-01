using System.Linq;
using System.Windows;

namespace HomeWork_3
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

        void function_for_cipher(bool flag)
        {
            int number = 0;
            string text = "";
            bool check = false;

            if (flag == true)
            {
                text = tb_1.Text;
            }
            else
            {
                text = tb_2.Text;
            }

            check = int.TryParse(text, out number);

            if (check == false)
            { 
                string text_font = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

                var mas = text_font.ToArray();
                var text_lower = text.ToLower();
                var text_mas = text_lower.ToArray();

                char[] newTextArray = new char[text_mas.Length];

                for (int i = 0; i < text.Length; i++)
                {
                    if (flag == true)
                    {
                        for (int j = 0; j < text_font.Length; j++)
                        {
                            if (text_mas[i] == mas[j])
                            {
                                int values_mas = 32 - j;
                                newTextArray[i] = mas[values_mas];
                            }
                        }
                    }
                    else
                    {
                        for (int j = (text_font.Length) - 1; j >= 0; j--)
                        {
                            if (text_mas[i] == mas[j])
                            {
                                int values_mas = 32 - j;
                                newTextArray[i] = mas[values_mas];
                            }
                        }
                    }
                }


                string new_Text = "";
                for (int i = 0; i < text.Length; i++)
                {
                    new_Text += newTextArray[i];
                }
                if (flag == true)
                    tb_result_1.Text = new_Text;
                else
                    tb_result_2.Text = new_Text;
            }
            else
                MessageBox.Show("Вы ввели число");
        }

        private void bt_1_Click(object sender, RoutedEventArgs e)
        {
            if (tb_1.Text == "")
            {
                MessageBox.Show("Введите текст для шифровки!");
            }
            else
            {
                bool flag = true;
                function_for_cipher(flag);
            }
        }

        private void bt_2_Click(object sender, RoutedEventArgs e)
        {
            if (tb_2.Text == "")
            {
                MessageBox.Show("Введите текст для расшифровки!");
            }
            else
            {
                bool flag = false;
                function_for_cipher(flag);
            }
        }

    }
}
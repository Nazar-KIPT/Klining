using System;
using System.IO;
using System.Windows.Forms;

namespace Clean_house
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            radioButton1.Checked = true;
            textBox1.Focus();
            //Вывод доп. сообщения при наведении на элементы.
            ToolTip t = new ToolTip();
            t.SetToolTip(radioButton1, "Легке прибирання\nЧас збирання від 1 до 2 годин в залежності від завдань. Використовуються тільки ЕКО-компоненти для прибирання і ніякої хімії.");
            t.SetToolTip(radioButton2, "Середнє прибирання\nЧас збирання від 3 до 6 годин залежно від завдань. Більше 25 спеціальних засобів для виведення забруднень і прибирання поверхонь з будь-яких матеріалів.");
            t.SetToolTip(radioButton3, "Важке прибирання\nЧас збирання від 6-9 годин. Виконання послуг будь-якої складності. Так само входить висновок плям крові / вина / фарби.");
            t.SetToolTip(label5, "Прибирання приміщень\nВітальня / підсобні приміщення. Час залежить від завдань для виконання.");
            t.SetToolTip(checkBox7, "Прибирання ванної кімнати\nОчищення від грибка на будь-якій поверхні / чистка кахлю за допомогою чистячих засобів.");
            t.SetToolTip(checkBox8, "Прибирання кухні\nПрочищення труб від засмічень, чистка газових / електро-плит. Використовуються тільки кошти без змісту хімії.");
            SaveButton.Enabled = false;
        }
        //Легкая уборка
        //Исключения
        private void RadioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButton1.Checked)
            {
                AdditionalServices.Enabled = false;
                OtherPremises.Enabled = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                textBox19.Enabled = false;
                textBox20.Enabled = false;
                textBox21.Enabled = false;
                textBox22.Enabled = false;
            }
        }
        //Средняя уборка
        //Исключения
        private void RadioButton2_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButton2.Checked)
            {
                AdditionalServices.Enabled = false;
                OtherPremises.Enabled = true;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
            }
        }
        //Исключение для уборки вванной комнаты.
        private void CheckBox7_CheckedChanged(object sender, System.EventArgs e)
        {
            if(checkBox7.Checked)
            {
                textBox19.Enabled = true;
                textBox20.Enabled = true;
            }
            else
            {
                textBox19.Clear();
                textBox20.Clear();
                textBox19.Enabled = false;
                textBox20.Enabled = false;
            }
        }
        //Исключение для уборки кухни.
        private void CheckBox8_CheckedChanged(object sender, System.EventArgs e)
        {
            if (checkBox8.Checked)
            {
                textBox21.Enabled = true;
                textBox22.Enabled = true;
            }
            else
            {
                textBox21.Enabled = false;
                textBox22.Enabled = false;
                textBox21.Clear();
                textBox22.Clear();
            }
        }
        //Сложная уборка
        //Исключения
        private void RadioButton3_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButton3.Checked)
            {
                AdditionalServices.Enabled = true;
                OtherPremises.Enabled = true;
                textBox6.Enabled = false;
                amountWin.Enabled = false;
                textBox8.Enabled = false;
                amountFridge.Enabled = false;
                amountSofa.Enabled = false;
                textBox16.Enabled = false;
                textBox17.Enabled = false;
                textBox14.Enabled = false;
            }
        }
        //Исключения для доп. окна.
        private void CheckBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox6.Enabled = true;
                amountWin.Enabled = true;
            }
            else
            {
                textBox6.Enabled = false;
                amountWin.Enabled = false;
                textBox6.Clear();
                amountWin.Value = 0;
            }
        }
        //Исключения для доп. холодильник.
        private void CheckBox2_CheckedChanged(object sender, System.EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox8.Enabled = true;
                amountFridge.Enabled = true;
            }
            else
            {
                textBox8.Enabled = false;
                amountFridge.Enabled = false;
                textBox8.Clear();
                amountFridge.Value = 0;
            }
        }
        //Исключения для доп. диван.
        private void CheckBox5_CheckedChanged(object sender, System.EventArgs e)
        {
            if (checkBox5.Checked)
            {
                textBox14.Enabled = true;
                amountSofa.Enabled = true;
            }
            else
            {
                textBox14.Enabled = false;
                amountSofa.Enabled = false;
                textBox14.Clear();
                amountSofa.Value = 0;
            }
        }
        //Исключения для доп. ковёр.
        private void CheckBox6_CheckedChanged(object sender, System.EventArgs e)
        {
            if (checkBox6.Checked)
            {
                textBox16.Enabled = true;
                textBox17.Enabled = true;
            }
            else
            {
                textBox16.Enabled = false;
                textBox17.Enabled = false;
                textBox16.Clear();
                textBox17.Clear();
            }
        }
        //Кнопка очистить.
        private void ClearButton_Click(object sender, System.EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            radioButton1.Checked = true;
            ResultTextBox.Clear();
        }
        //Кнопка посчитать.
        private void CountButton_Click(object sender, System.EventArgs e)
        {
            double suma = 0;
            //Уборка помещения
            if (textBox4.TextLength > 0 && textBox5.TextLength > 0)
            {
                double quadrature = Convert.ToDouble(textBox4.Text);
                double priceQuadrature = Convert.ToDouble(textBox5.Text);
                double price = quadrature * priceQuadrature;
                suma += price;
            }
            else
            {
                MessageBox.Show("Не все поля заполнены в разделе 'Уборка помещения'.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Уборка ванной комнаты 
            if (checkBox7.Checked)
            {
                if (textBox20.TextLength > 0 && textBox19.TextLength > 0)
                {
                    double quadrature = Convert.ToDouble(textBox20.Text);
                    double priceQuadrature = Convert.ToDouble(textBox19.Text);
                    double price = quadrature * priceQuadrature;
                    suma += price;
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены в разделе 'Уборка ванной комнаты'.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            //Уборка кухни
            if (checkBox8.Checked)
            {
                if (textBox22.TextLength > 0 && textBox21.TextLength > 0)
                {
                    double quadrature = Convert.ToDouble(textBox22.Text);
                    double priceQuadrature = Convert.ToDouble(textBox21.Text);
                    double price = quadrature * priceQuadrature;
                    suma += price;
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены в разделе 'Уборка кухни'.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            //Дополнительно
            //Окна
            if (checkBox1.Checked)
            {
                if (amountWin.Value != 0 && textBox6.TextLength > 0)
                {
                    double amount = Convert.ToDouble(amountWin.Value);
                    double priceАmount = Convert.ToDouble(textBox6.Text);
                    double price = amount * priceАmount;
                    suma += price;
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены в разделе 'Окна'.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            //Холодильник
            if (checkBox2.Checked)
            {
                if (amountFridge.Value != 0 && textBox8.TextLength > 0)
                {
                    double amount = Convert.ToDouble(amountFridge.Value);
                    double priceАmount = Convert.ToDouble(textBox8.Text);
                    double price = amount * priceАmount;
                    suma += price;
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены в разделе 'Холодильник'.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            //Диван
            if (checkBox5.Checked)
            {
                if (amountSofa.Value != 0 && textBox14.TextLength > 0)
                {
                    double amount = Convert.ToDouble(amountSofa.Value);
                    double priceАmount = Convert.ToDouble(textBox14.Text);
                    double price = amount * priceАmount;
                    suma += price;
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены в разделе 'Диван'.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            //Ковёр
            if (checkBox6.Checked)
            {
                if (textBox17.TextLength > 0 && textBox16.TextLength > 0)
                {
                    double quadrature = Convert.ToDouble(textBox17.Text);
                    double priceQuadrature = Convert.ToDouble(textBox16.Text);
                    double price = quadrature * priceQuadrature;
                    suma += price;
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены в разделе 'Ковёр'.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            //Вывод окончательной сумы на экран.
            ResultTextBox.Text = suma.ToString("0.00") + " грн";
        }

        private void TextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Ограничение на ввод.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {

                e.Handled = true;
            }
            //Запрет ввода разделителя первым символом.
            if ((sender as TextBox).SelectionStart == 0 & e.KeyChar == '.')
            {
                e.Handled = true;
            }
            //Запрет таких значений как 03.xx 09999.xx После 0 должа быть точка. 
            if ((sender as TextBox).Text == "0")
            {
                if (e.KeyChar != '.' & e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
            //Запрет на ввод таких значений как 97.980, 0.33333. Должно быть 8.30, 5.09.
            if ((sender as TextBox).Text.IndexOf('.') > 0)
            {
                if ((sender as TextBox).Text.Substring((sender as TextBox).Text.IndexOf('.')).Length > 2)
                {
                    if (e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                }
            }
            //Ввод только 1 разделителя.
            if (e.KeyChar == '.')
            {
                if ((sender as TextBox).Text.IndexOf('.') != -1)
                {
                    e.Handled = true;
                }

            }
        }

        private void TextBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Ограничение на ввод.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {

                e.Handled = true;
            }
            //Запрет ввода разделителя первым символом.
            if ((sender as TextBox).SelectionStart == 0 & e.KeyChar == '.')
            {
                e.Handled = true;
            }
            //Запрет таких значений как 03.xx 09999.xx После 0 должа быть точка. 
            if ((sender as TextBox).Text == "0")
            {
                if (e.KeyChar != '.' & e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
            //Запрет на ввод таких значений как 97.980, 0.33333. Должно быть 8.30, 5.09.
            if ((sender as TextBox).Text.IndexOf('.') > 0)
            {
                if ((sender as TextBox).Text.Substring((sender as TextBox).Text.IndexOf('.')).Length > 2)
                {
                    if (e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                }
            }
            //Ввод только 1 разделителя.
            if (e.KeyChar == '.')
            {
                if ((sender as TextBox).Text.IndexOf('.') != -1)
                {
                    e.Handled = true;
                }

            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "0.00 грн")
            {
                MessageBox.Show("Конечная сума равна 0!", "Ошибка");
            }
            else
            {
                SaveFileDialog save = new SaveFileDialog();
                save.FileName = textBox1.Text + ", " + textBox2.Text + ", " + textBox3.Text + ", " + DateTime.Now.ToString("dd.MM.yyyy");
                save.InitialDirectory = @"С:\";
                save.Filter = "TXT files (*.txt)|*.txt|All files (*.*)|*.*";
                save.FilterIndex = 1;
                save.Title = "Сохранить файл как";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(save.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        using (StreamWriter wr = new StreamWriter(fs))
                        {
                            wr.WriteLine("        " + DateTime.Now + "        ");
                            wr.WriteLine("-----------Прибирання квартир-----------");
                            wr.WriteLine(" ");
                            wr.WriteLine("ПІБ - " + textBox1.Text);
                            wr.WriteLine("Адреса - " + textBox2.Text);
                            wr.WriteLine("Телефон - " + textBox3.Text);
                            wr.WriteLine(" ");
                            wr.WriteLine("---Прибирання приміщенняя---");
                            wr.WriteLine("Площа: " + textBox4.Text + "кв.м. Ціна: " + textBox5.Text);
                            if (checkBox7.Checked)
                            {
                                wr.WriteLine(" ");
                                wr.WriteLine("---Прибирання ванної кімнати---");
                                wr.WriteLine("Площа: " + textBox20.Text + "кв.м. Ціна: " + textBox19.Text);
                            }
                            if (checkBox8.Checked)
                            {
                                wr.WriteLine(" ");
                                wr.WriteLine("---Прибирання кухні---");
                                wr.WriteLine("Площа: " + textBox22.Text + "кв.м. Ціна: " + textBox21.Text);
                            }
                            if (radioButton3.Checked)
                            {
                                wr.WriteLine(" ");
                                wr.WriteLine("-----------Додатково-----------");
                                wr.WriteLine(" ");
                                if (checkBox1.Checked)
                                {
                                    wr.WriteLine(" ");
                                    wr.WriteLine("---Вікна---");
                                    wr.WriteLine("Кількість: " + amountWin.Text + " Ціна: " + textBox6.Text);
                                }
                                if (checkBox2.Checked)
                                {
                                    wr.WriteLine(" ");
                                    wr.WriteLine("---Холодильник---");
                                    wr.WriteLine("Кількість: " + amountFridge.Text + " Ціна: " + textBox8.Text);
                                }
                                if (checkBox5.Checked)
                                {
                                    wr.WriteLine(" ");
                                    wr.WriteLine("---Диван---");
                                    wr.WriteLine("Кількість: " + amountSofa.Text + " Ціна: " + textBox14.Text);
                                }
                                if (checkBox6.Checked)
                                {
                                    wr.WriteLine(" ");
                                    wr.WriteLine("---Ковер---");
                                    wr.WriteLine("Площа: " + textBox17.Text + "кв.м. Ціна: " + textBox16.Text);
                                }
                            }
                            wr.WriteLine(" ");
                            wr.WriteLine("---Кінцева ціна за прибирання - " + ResultTextBox.Text + "---");
                            wr.Flush();
                            wr.Close();
                        }
                        fs.Close();
                    }
                }
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && ResultTextBox.Text.Length >0)
            {
                SaveButton.Enabled = true;
            }
            else
            {
                SaveButton.Enabled = false;
            }
        }
    }
}

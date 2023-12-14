using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Net.Sockets;
using iText.IO.Font.Constants;
using iText.IO.Font;
using iText.Kernel.Font;


namespace Klient
{
    public partial class HoroscopeForm : Form
    {
        static string[] monthsOfTheYear = { "Styczeń", "Luty", "Marzec", "Kwiecień", "Maj", "Czerwiec", "Lipiec", "Sierpień", "Wrzesień", "Październik", "Listopad", "Grudzień" };
        static string serverIp = "10.44.1.6";
        static int serverPort = 1234;
        static int BufferSize = 32296;
        static string serverResponse;
        static PdfFont font;
        public HoroscopeForm()
        {
            InitializeComponent();

            this.MaximizeBox = false;
            firstPersonYear.KeyPress += TextBox_KeyPress;
            secondPersonDate.KeyPress += TextBox_KeyPress;
            secondPersonYear.KeyPress += TextBox_KeyPress;
            firstPersonDate.MaxLength = 2;
            firstPersonYear.MaxLength = 4;
            secondPersonDate.MaxLength = 2;
            secondPersonYear.MaxLength = 4;
            txtButton.Enabled = false;
            pdfButton.Enabled = false;
            LoadFontAsync();

            string[] fortuneTellingStyles = { "Zodiak europejski", "Zodiak chiński"};
            fortuneTellingStyle.Items.AddRange(fortuneTellingStyles);
            firstPersonMonth.Items.AddRange(monthsOfTheYear);
            secondPersonMonth.Items.AddRange(monthsOfTheYear);
        }

        private async void LoadFontAsync()
        {
            try
            {
                string fontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NotoSans-VariableFont_wdth,wght.ttf");
                font = await Task.Run(() => PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H, true));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке шрифта: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //zakazuje wpisania liter i wykonania komendy ctrl + v w textboxie przez klawiszy
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 22 || !char.IsControl(e.KeyChar)) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            //sprawdzam, czy pola są wypełnione
            if (fortuneTellingStyle.SelectedItem!=null &&
                    firstPersonMonth.SelectedItem!=null &&
                        secondPersonMonth.SelectedItem!=null &&
                            !string.IsNullOrEmpty(firstPersonDate.Text) &&
                                !string.IsNullOrEmpty(firstPersonYear.Text) &&
                                    !string.IsNullOrEmpty(secondPersonDate.Text) &&
                                        !string.IsNullOrEmpty(secondPersonYear.Text))
            {
                //sprawdzam, czy tylko cyfry są wpisane w polach
                if (IsStringNumeric(firstPersonDate.Text) && IsStringNumeric(firstPersonYear.Text) && IsStringNumeric(secondPersonDate.Text) && IsStringNumeric(secondPersonYear.Text))
                {
                    PersonBirthDate firstPerson = new PersonBirthDate(int.Parse(firstPersonDate.Text), (Array.IndexOf(monthsOfTheYear, firstPersonMonth.Text) + 1), int.Parse(firstPersonYear.Text));
                    PersonBirthDate secondPerson = new PersonBirthDate(int.Parse(secondPersonDate.Text), (Array.IndexOf(monthsOfTheYear, secondPersonMonth.Text) + 1), int.Parse(secondPersonYear.Text));
                    if (isTheDateCorrect(firstPerson) && isTheDateCorrect(secondPerson))
                    {
                        try
                        {
                            using (TcpClient client = new TcpClient(serverIp, serverPort))
                            {
                                using (NetworkStream stream = client.GetStream())
                                {
                                    // Wyslanie danych na serwer
                                    string dataToSend = string.Concat(fortuneTellingStyle.Text.Substring(7, Math.Min(2, fortuneTellingStyle.Text.Length)), 
                                                                        firstPerson.Day.ToString("D2"),
                                                                            firstPerson.Month.ToString("D2"),
                                                                                firstPerson.Year.ToString("D4"),
                                                                                   secondPerson.Day.ToString("D2"),
                                                                                    secondPerson.Month.ToString("D2"),
                                                                                      secondPerson.Year.ToString("D4"));
                                    byte[] data = Encoding.UTF8.GetBytes(dataToSend);
                                    stream.Write(data, 0, data.Length);

                                   // Otrzymanie odpowiedzi od serwera
                                    byte[] buffer = new byte[BufferSize];
                                    using (MemoryStream memoryStream = new MemoryStream())
                                    {
                                        int bytesRead;
                                        do
                                        {
                                            bytesRead = stream.Read(buffer, 0, buffer.Length);
                                            memoryStream.Write(buffer, 0, bytesRead);
                                        } while (stream.DataAvailable);

                                        // Wklejanie odpowiedzi do RichTextBox
                                        serverResponse = Encoding.UTF8.GetString(memoryStream.ToArray());
                                        DisplayResponseInRichTextBox();
                                        pdfButton.Enabled = true;
                                        txtButton.Enabled = true;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Błąd: {ex.Message}");
                        }
                    }
                    else
                    {
                        dateOfBirthErrorMessage();
                    }
                }
                else
                {
                    dateOfBirthErrorMessage();
                }
            }
            else
            {
                MessageBox.Show("Wypełnij pola przed wysłaniam danych! Żadne pole nie może być pustym.");
            }
        }

        private void DisplayResponseInRichTextBox()
        {
            fortuneTellingResult.Invoke((MethodInvoker)delegate
            {
                fortuneTellingResult.Text = serverResponse;
            });
        }

        //sprawdzam, czy istnieje wpisana data(max do 9999 roku)
        private bool isTheDateCorrect (PersonBirthDate person)
        {
            if (person.Year==0)
            {
                return false;
            }
            else
            {
                int maxDaysInMonth = DateTime.DaysInMonth(person.Year, person.Month);
                return (person.Day >= 1 && person.Day <= maxDaysInMonth);
            }
           
        }

        private System.Windows.Forms.DialogResult dateOfBirthErrorMessage()
        {
            return MessageBox.Show("Data urodzenia jest nieprawidłowa.");
        }
        //sprawdza, czy zawierz string coś oprócz cyfr
        static bool IsStringNumeric(string inputString)
        {
            return double.TryParse(inputString, out _);
        }

        private void pdfButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog.Title = "Save PDF File";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    using (PdfWriter writer = new PdfWriter(fs))
                    {
                        using (PdfDocument pdf = new PdfDocument(writer))
                        {
                            Document document = new Document(pdf);

                            
                            document.SetFont(font);


                            document.Add(new Paragraph(serverResponse));
                        }
                    }
                }
            }

            MessageBox.Show("PDF-plik został zapisany!", "Sukces.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Format tekstowy (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Otszymujemy ścieżkę do mowego pliku
                string filePath = saveFileDialog.FileName;

                try
                {
                    // Tworzymy i zapisujemy tekst do nowego pliku
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.Write(serverResponse);
                    }

                    MessageBox.Show("Plik został zapisany", "Sukces.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"W czasie zapisywania pliku powstał błąd: {ex.Message}", "Błąd:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

using System;
using System.Diagnostics;
using System.Windows;

namespace Base64Decoder
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

        private void CopyEncoded_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(encodedTextBox.Text);
        }

        private void PasteEncoded_Click(object sender, RoutedEventArgs e)
        {

            encodedTextBox.Text = Clipboard.GetText();
        }

        private void Decode_Click(object sender, RoutedEventArgs e)
        {
            string results = "";

            if (sender == decodeButton)
            {
                results = Decoder(encodedTextBox.Text);
            }
            else if (sender == decodeButtonX2)
            {
                results = Decoder(Decoder(encodedTextBox.Text));
            }


            decodedTextBox.Text = results;
        }

        private void CopyDecoded_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(decodedTextBox.Text);
        }

        private void PasteDecoded_Click(object sender, RoutedEventArgs e)
        {
            decodedTextBox.Text = Clipboard.GetText();
        }

        private void Encode_Click(object sender, RoutedEventArgs e)
        {

            string results = "";
            if (sender == encodeButton)
            {
                results = Encoder(decodedTextBox.Text);

            }
            else if (sender == encodeButtonX2)
            {
                string temp = (Encoder(decodedTextBox.Text));
                results = Encoder(temp);
            }

            encodedTextBox.Text = results.ToString();

        }

        private void OpenWebPage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(decodedTextBox.Text); // opens a web page, value must be a hyperlink. 
            }
            catch { }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            if (sender == clearDecodedButton)
                decodedTextBox.Text = string.Empty;

            if (sender == clearEncodedButton)
                encodedTextBox.Text = string.Empty;
        }


        private string Encoder(string str)
        {
            if (encodedTextBox.Text != null)
            {
                try
                {
                    var results = System.Text.Encoding.UTF8.GetBytes(str);
                    return System.Convert.ToBase64String(results);

                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error: {e}");
                }
            }

            return "";
        }

        private string Decoder(string str)
        {
            if (decodedTextBox.Text != null)
            {
                try
                {
                    var base64EncodedBytes = System.Convert.FromBase64String(str);
                    return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error: {e}");
                }
            }

            return "";
        }
    }
}

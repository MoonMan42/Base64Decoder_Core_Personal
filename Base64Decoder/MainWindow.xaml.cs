using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            if (sender == decodeButton)
            {
                Decoder(decodedTextBox.Text);
            } else if (sender == decodeButtonX2)
            {
                Decoder(Decoder(decodedTextBox.Text));
            }
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
           

            if (sender == encodeButton)
            {
               Encoder(decodedTextBox.Text);

            } else if (sender == encodeButtonX2)
            {
               Encoder(Encoder(decodedTextBox.Text));
            }
           
        }

        private void OpenWebPage_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(decodedTextBox.Text); // opens a web page, value must be a hyperlink. 
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            if (sender == clearDecodedButton)
                decodedTextBox.Text = string.Empty;

            if (sender == clearEncodedButton)
                encodedTextBox.Text = string.Empty;
        }


        private string Encoder (string str)
        {
            if (encodedTextBox.Text != null)
            {
                try
                {
                    var result = System.Text.Encoding.UTF8.GetBytes(str);
                    encodedTextBox.Text = System.Convert.ToBase64String(result);
                    return result.ToString();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error: {e}");
                }
            }

            return "";
        }

        private string Decoder (string str)
        {
            if (decodedTextBox.Text != null)
            {
                try
                {
                    var result = System.Convert.FromBase64String(encodedTextBox.Text);
                    decodedTextBox.Text = System.Text.Encoding.UTF8.GetString(result);
                    return result.ToString();
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

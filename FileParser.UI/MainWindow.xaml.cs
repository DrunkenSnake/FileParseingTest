using System;
using System.Collections.Generic;
using System.IO;
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
using FileParser.Logic;

namespace FileParser.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FileProcessor _processor;
        public MainWindow()
        {
            InitializeComponent();
            _processor = new FileProcessor();
        }

        private void filePath_PreviewDragEnter(object sender, DragEventArgs e)
        {
            var effects = DragDropEffects.All;
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                var fileNames = (string[]) e.Data.GetData(DataFormats.FileDrop, true);
                if (fileNames != null)
                {
                    foreach (var fileName in fileNames)
                    {
                        if (File.Exists(fileName) && effects != DragDropEffects.None)
                        {
                            effects = DragDropEffects.All;
                        }
                        else
                        {
                            effects = DragDropEffects.None;
                        }
                    }
                }
            }
            e.Effects = effects;
        }

        private void filePath_PreviewDrop(object sender, DragEventArgs e)
        {
            var fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, true);
            if (fileNames != null)
            {
                var totals = _processor.ProcessFromPath(fileNames[0]).ToArray();
                foreach (var total in totals)
                {
                    totalTextBox.Text += total + "\r\n";
                }
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            var fileName = filePath.Text;
            if (fileName != null)
            {
                var totals = _processor.ProcessFromPath(fileName).ToArray();
                foreach (var total in totals)
                {
                    totalTextBox.Text += total + "\r\n";
                }
            }
        }

        private void FilePath_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                button_Click(sender, e);
            }
        }
    }
}

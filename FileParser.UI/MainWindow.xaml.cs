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

        private void filePath_PreviewDragEnter(object sender, DragEventArgs e)//allows for files to be dragged and dropped in
        {
            var effects = DragDropEffects.All;
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))//make sure appropriate file type
            {
                var fileNames = (string[]) e.Data.GetData(DataFormats.FileDrop, true);
                if (fileNames != null)
                {
                    foreach (var fileName in fileNames)
                    {
                        if (File.Exists(fileName) && effects != DragDropEffects.None)//make sure files exist
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

        private void filePath_PreviewDrop(object sender, DragEventArgs e)//handle file drop
        {
            try
            {
                totalTextBox.Text = ""; //clear results box
                var fileNames = (string[]) e.Data.GetData(DataFormats.FileDrop, true);
                if (fileNames != null)
                {
                    foreach (var fileName in fileNames)
                    {
                        var totals = _processor.ProcessFromPath(fileName).ToArray();
                        //sends each filename up to be handled
                        foreach (var total in totals)
                        {
                            totalTextBox.Text += total + "\r\n";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                totalTextBox.Text = ex.Message;
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fileName = filePath.Text; //get value of input box
                if (fileName != null)
                {
                    var totals = _processor.ProcessFromPath(fileName).ToArray();
                    foreach (var total in totals)
                    {
                        totalTextBox.Text += total + "\r\n";
                    }
                }
                filePath.Text = ""; //clear input box
            }
            catch (Exception ex)
            {
                totalTextBox.Text = ex.Message;
            }
        }

        private void FilePath_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)//if enter key is pressed treat like button click
            {
                button_Click(sender, e);
            }
        }
    }
}

using Microsoft.Win32;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Runtime.InteropServices;
using System.Globalization;

namespace ImageFilters
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Bitmap originalImage = null;
        private Bitmap previewImage = null;
        private Bitmap resultImage = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLoadImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imágenes |*.jpg; *.png; *.tif; *.tiff";

            if (ofd.ShowDialog() == true)
            {
                StreamReader stream = new StreamReader(ofd.FileName);
                originalImage = (Bitmap)Bitmap.FromStream(stream.BaseStream);
                previewImage = originalImage;

                stream.Close();

                image.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(originalImage.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

                lblFilename.Content = ofd.FileName.Replace("_", "__");
            }
        }        

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            double[,] matrix = new double[3, 3];

            matrix[0, 0] = double.Parse(txt00.Text, CultureInfo.InvariantCulture);
            matrix[0, 1] = double.Parse(txt01.Text, CultureInfo.InvariantCulture);
            matrix[0, 2] = double.Parse(txt02.Text, CultureInfo.InvariantCulture);
            matrix[1, 0] = double.Parse(txt10.Text, CultureInfo.InvariantCulture);
            matrix[1, 1] = double.Parse(txt11.Text, CultureInfo.InvariantCulture);
            matrix[1, 2] = double.Parse(txt12.Text, CultureInfo.InvariantCulture);
            matrix[2, 0] = double.Parse(txt20.Text, CultureInfo.InvariantCulture);
            matrix[2, 1] = double.Parse(txt21.Text, CultureInfo.InvariantCulture);
            matrix[2, 2] = double.Parse(txt22.Text, CultureInfo.InvariantCulture);

            GenericFilter sharpen = new GenericFilter();
            sharpen.FilterName = "Sharpen";
            sharpen.FilterMatrix = matrix;
            //sharpen.FilterMatrix = new double[,] {{ 0.0,  0.2, 0.0 },
            //                                      { 0.2,  0.2, 0.2 },
            //                                      { 0.0,  0.2, 0.2 }};

            resultImage = previewImage.ConvolutionFilter(sharpen);

            image.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(resultImage.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            previewImage = resultImage;
        }
    }
}

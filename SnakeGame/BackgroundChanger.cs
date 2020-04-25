using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SnakeGame_Assignment
{
    // Class consist of method responsible for changing 
    // a canvas background to a grayscale image.
    static class BackgroundChanger
    {

        // Draw an element from string list method.
        private static string Draw(List<string> texts)
        {
            Random random = new Random();
            int randomIndex = random.Next(texts.Count);
            return texts[randomIndex];
        }

        // Change background method.
        public static void Change(Canvas gameBoard, string imageURL)
        {
            // Download an image.
            Bitmap bitmap;
            try
            {
                bitmap = ImageDownloader.Download(imageURL);
            }
            catch (WebException exception)
            {
                throw exception;
            }

            // Convert the image type from System.Drawing.Bitmap
            // to System.Windows.Media.Imaging.BitmapImage.
            BitmapImage bitmapImage = ImageTypeConverter.Convert(bitmap);

            // Convert the image to grayscale.
            FormatConvertedBitmap newFormatedBitmapSource = new FormatConvertedBitmap();
            newFormatedBitmapSource.BeginInit();
            newFormatedBitmapSource.Source = bitmapImage;
            newFormatedBitmapSource.DestinationFormat = PixelFormats.Gray32Float;
            newFormatedBitmapSource.EndInit();
            ImageBrush imageBrush = new ImageBrush(newFormatedBitmapSource);

            // Change canvas background.
            gameBoard.Background = imageBrush;
        }
    }
}

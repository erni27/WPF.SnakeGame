using System;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace SnakeGame_Assignment
{
    // Class consist of method responsible for loading an image from local directory.
    static class ImageLoader
    {
        // Load method.
        public static Image Load(string imagePath, System.Drawing.Size imageSize)
        {
            Image myImage = new Image();
            myImage.Width = imageSize.Width;
            myImage.Height = imageSize.Height;
            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(imagePath, UriKind.Relative);
            myBitmapImage.DecodePixelWidth = imageSize.Width;
            myBitmapImage.DecodePixelHeight = imageSize.Height;
            myBitmapImage.EndInit();
            myImage.Source = myBitmapImage;
            return myImage;
        }
    }
}

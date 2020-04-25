using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace SnakeGame_Assignment
{
    // Class consist of method responsible for converting System.Drawing.Image 
    // to System.Windows.Media.Imaging.BitmapImage.
    static class ImageTypeConverter
    {
        // Convert method.
        public static BitmapImage Convert(System.Drawing.Bitmap bitmap)
        {
            BitmapImage bitmapImage;

            // Load image from MemoryStream.
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }
            return bitmapImage;
        }
    }
}

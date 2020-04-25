using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace SnakeGame_Assignment
{
    // Class consist of methods responsible for downloading image using
    // its URL Address.
    static class ImageDownloader
    {
        // Check Internet connectivity method.
        private static bool CheckInternetConnectivity()
        {
            try
            {
                using (WebClient client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }

        // Download image.
        public static Bitmap Download(string imageURLAddress)
        {
            // Check Internet connectivity. 
            if (!CheckInternetConnectivity())
            {
                throw new WebException("No Internet access");
            }

            // Download an image writing it from stream.
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(imageURLAddress);
            Bitmap downloadedImage = new Bitmap(stream);
            if (downloadedImage == null)
                throw new ArgumentException("Image download failed");
            stream.Flush();
            stream.Close();
            return downloadedImage;
        }
    }
}

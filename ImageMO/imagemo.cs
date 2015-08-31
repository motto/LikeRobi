using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Windows;
namespace ImageMO
{
    // screenShot.Save(@"D:\Temp\sc11555.png");
    //string content = new StreamReader(@"D:\Temp\sc1152.png", Encoding.Unicode).ReadToEnd();
    //  byte[] imageArray = System.IO.File.ReadAllBytes(@"D:\Temp\sc1152.png");
    // MemoryStream m = new MemoryStream();
    // screenShot.Save(m, screenShot.RawFormat);
    //byte[] imageBytes = m.ToArray();
    /*
                var stream = new MemoryStream();
                screenShot.Save(stream, screenShot.bm);
                var ggg = stream.ToArray();

                MemoryStream memoryStream = new MemoryStream();
                byte[] bitmapData;

                using (memoryStream)
                {
                    screenShot.Save(memoryStream, ImageFormat.Bmp);
                    bitmapData = memoryStream.ToArray();
                } 
                string content = Convert.ToBase64String(bitmapData);
    */
   
    public class Img
    {
        /*
        //beolvassa a képet bytonként ésúgy szúrja be a htmlbe 
        string s = "<img src=\"" + getImageFromFile("~/Content/skin/Office2010Blue.png", "image/png") + "\" style=\"width: 100px;height: 100px;\" />";
        var html = new HtmlDocument();



        @html.CreateElement(s)


public string getImageFromFile(String url, String imgType)
        {
            using (FileStream fs = new FileStream(Server.MapPath(url),
                                           FileMode.Open,
                                           FileAccess.Read))
            {
                byte[] filebytes = new byte[fs.Length];
                fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
            }
            string encodedData = Convert.ToBase64String(filebytes);
            return "data:" + imgType + ";base64,+"encodedData;
        }
*/


        /// <summary>
        /// Képlopó, eg ywebbrowser képét adja vissza
        /// </summary>
        /// <param name="Browser1"></param>
        /// <returns></returns>
        public static Bitmap screen_img(WebBrowser Browser1)
        {
            var topLeftCorner = Browser1.PointToScreen(new Point(0, 0));
            var topLeftGdiPoint = new System.Drawing.Point((int)topLeftCorner.X, (int)topLeftCorner.Y);
            var size = new System.Drawing.Size((int)Browser1.Width, (int)Browser1.Height);
            Bitmap screenShot = new Bitmap(size.Width,size.Height);
                using (var graphics = Graphics.FromImage(screenShot))
                {
                    graphics.CopyFromScreen(topLeftGdiPoint, new System.Drawing.Point(),
                         size, CopyPixelOperation.SourceCopy);
                }
            return screenShot;
        }

 
        /// <summary>
        /// Képlopó, eg ywebbrowser képét adja vissza. át is méretezi
        /// </summary>
        /// <param name="Browser1"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Bitmap screen_img_resize(WebBrowser Browser1,int width=250,int height=150)
        { 
        var topLeftCorner = Browser1.PointToScreen(new Point(0, 0));
        var topLeftGdiPoint = new System.Drawing.Point((int)topLeftCorner.X, (int)topLeftCorner.Y);
        var size = new System.Drawing.Size((int)Browser1.Width, (int)Browser1.Height);
        var size2 = new System.Drawing.Size(width, height);
        Bitmap screenShot = new Bitmap(width, height);
                // Bitmap b = new Bitmap(size.Width, size.Height);

                using (var graphics = Graphics.FromImage(screenShot))
                {
                    graphics.CopyFromScreen(topLeftGdiPoint, new System.Drawing.Point(),
                         size2, CopyPixelOperation.SourceCopy);
                }

            return screenShot;
         }

    }
}

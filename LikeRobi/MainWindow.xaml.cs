using System;
using System.Collections.Generic;
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
//-----------------------------------------------------------
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using mshtml;
using System.Security.Permissions;
using System.Runtime.InteropServices;

using HtmlMO;
using System.Web;
using System.Web.UI.HtmlControls;
using ImageMO;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Net; // ftphez
using System.Net.Http;
using System.IO;
using System.Drawing.Imaging;
//using NReco;
//using NReco.ImageGenerator;
namespace LikeRobi
{

    public partial class MainWindow : Window
    {
        public static string feed_id;
        bool web1_betoltve = false; //fő böngésző betöltve
        bool pop1_betoltve = false; //popup1 böngésző betöltve
        Htmlseged seged;
        public MainWindow()
        {
            seged = new Htmlseged();
            InitializeComponent();
            web1.LoadCompleted += web1_LoadCompleted; //fő ablak
            popBrowser1.LoadCompleted += popup_LoadCompleted;//popup1 böngésző
        }
        public void web1_loaded(object sender, EventHandler e)
        {
           web1_betoltve = false;
          //  System.Windows.MessageBoxResult messageBoxResult2 = System.Windows.MessageBox.Show("töltődik");

        }
        private Uri currentUri;

        void myBrowser_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (currentUri.AbsolutePath != e.Uri.AbsolutePath)
            {
                // Url has changed ...

                // Update current uri
                currentUri = e.Uri;
               // System.Windows.MessageBoxResult messageBoxResult3 = System.Windows.MessageBox.Show("változott");
            }
            //System.Windows.MessageBoxResult messageBoxResult2 = System.Windows.MessageBox.Show("inicializálódott");
        }

        /// <summary>
        /// fő böngésző ablak betöltődésekor fut le
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void web1_LoadCompleted(object sender, NavigationEventArgs e)
        {
            ///document = (mshtml.HTMLDocument)web1.Document;
            Htmlseged.document = (mshtml.HTMLDocument)web1.Document;
            Htmlseged.doc = (IHTMLDocument2)web1.Document;
            web1_betoltve = true;
           // System.Windows.MessageBoxResult messageBoxResult2 = System.Windows.MessageBox.Show("betöltve");
        }

        public void proba()
        {


        }

        /// <summary>
        /// a popupban megnyitott post betöltődesekor fut le
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void popup_LoadCompleted(object sender, NavigationEventArgs e)
        { 
        
        }


        // popup bezárás----------------------------------------------
        public void butnExitPopup_Click(object sender, RoutedEventArgs e)
        {
            Popup1.IsOpen = false;
        }





        bool iEvent_onclick(IHTMLEventObj pEvtObj)
        {



            return true;
        }

        // likerobi képet tesz a postba------------------------------------------------------
        public void divtext(object sender, RoutedEventArgs e)
        {
           
            seged.LR_sav();

        }
        /*
            
            //string currentURl = "file";
          //currentURl = e.Uri.ToString();
            pop_document = (HTMLDocument)popBrowser1.Document;
            // WebRequest request = WebRequest.Create("http://infolapok.hu/like/index.php");
            if (screen_image == true)
            {
                int width = 350;
                int height = 250;
                var topLeftCorner = popBrowser1.PointToScreen(new System.Windows.Point(0, 0));
                var topLeftGdiPoint = new System.Drawing.Point((int)topLeftCorner.X, (int)topLeftCorner.Y);
                var size = new System.Drawing.Size((int)popBrowser1.Width, (int)popBrowser1.Height);
                var size2 = new System.Drawing.Size(width, height);
                Bitmap screenShot = new Bitmap(width, height);
                // Bitmap b = new Bitmap(size.Width, size.Height);

                using (var graphics = Graphics.FromImage(screenShot))
                {
                    graphics.CopyFromScreen(topLeftGdiPoint, new System.Drawing.Point(),
                         size, CopyPixelOperation.SourceCopy);
                }

                screenShot.Save(@"D:\Temp\sc11555.png");
                screen_image = false;
            }
            if (div_text == true)
            {

                //IHTMLElement tartalom = pop_document.getElementById("globalContainer");
                string feed_div_string = feed_div.innerHTML;
                //   tartalom.innerHTML = feed_div_string;
                //  string tartalom_text = tartalom.innerHTML;

                pop_document.body.innerHTML = feed_div_string;
                IHTMLDocument3 documentAsIHtmlDocument3 = (mshtml.IHTMLDocument3)popBrowser1.Document;
                string content = documentAsIHtmlDocument3.documentElement.innerHTML;

                screen_image = true; div_text = false;
                popBrowser1.NavigateToString(content);
                /*
                
                
                
                var htmlToImageConv = new NReco.ImageGenerator.HtmlToImageConverter();
                byte[] jpegBytes = htmlToImageConv.GenerateImage(tartalom_text,"Jpeg");

                MemoryStream ms = new MemoryStream(jpegBytes);
                System.Drawing.Image hhh = System.Drawing.Image.FromStream(ms);
                hhh.Save(@"D:\Temp\hhh.jpg");*/

        // }

        // image2.save("c:\\a.bmp", imageformat.bmp);



        /*
                 using (Bitmap bmp = (Bitmap)System.Windows.Clipboard.GetDataObject().GetData(System.Windows.DataFormats.Bitmap))
                 {
                    bmp.Save(@"d:\Temp\" + img.nameProp);
                   //  bmp.Save(@"D:\Temp\gggg.png");
                  }

        /*
        WebRequest req = WebRequest.Create(sour);
        WebResponse response = req.GetResponse();
        Stream stream = response.GetResponseStream();

        System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
        stream.Close();*/

        //img.Save(@"D:\Temp\gggg.png");

        //System.Windows.MessageBoxResult messageBoxResult2 = System.Windows.MessageBox.Show(sour + "hjjh");




        // Bitmap screenShot = new Bitmap(500, 400);
        // Bitmap b = new Bitmap(size.Width, size.Height);
        // String str = ??????? // I want to assign c:/my/test.html to this string



        // screenShot.Save(@"D:\Temp\sc11555.png");





        //if (htmlDoc != null) htmlDoc.parentWindow.scrollBy(265, 20);

        //

        /*
        int width = 350;
        int height = 250;
          var topLeftCorner = popBrowser1.PointToScreen(new System.Windows.Point(0, 0));
       // var topLeftGdiPoint = new System.Drawing.Point(top, left);
        var topLeftGdiPoint = new System.Drawing.Point((int)topLeftCorner.X,(int)topLeftCorner.Y);
        var size = new System.Drawing.Size(500,400);
        var size2 = new System.Drawing.Size(width, height);
        Bitmap screenShot = new Bitmap(width, height);
        // Bitmap b = new Bitmap(size.Width, size.Height);

        using (var graphics = Graphics.FromImage(screenShot))
        {
            graphics.CopyFromScreen(topLeftGdiPoint, new System.Drawing.Point(),
                 size2, CopyPixelOperation.SourceCopy);
        }

        screenShot.Save(@"D:\Temp\dgsdfsdf.png");*/

        /*           
                   string strHTML = File.ReadAllText(feed_view_html); 
                   Popup1.IsOpen = true;
                   popBrowser1.NavigateToString(strHTML);
                   while (tovabb==true) {
                     System.Threading.Thread.Sleep(1000);
                       i++; if (i == 5) { tovabb = true; }
       /*/
        // div_text = true;
        // Popup1.IsOpen = true;
        // popBrowser1.Navigate(feed_link);

    }

}


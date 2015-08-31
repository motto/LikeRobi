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
using NReco;
//using NReco.ImageGenerator;
namespace LikeRobi
{
    public partial class MainWindow : Window
    {
        HTMLDocument document;
        HTMLDocument pop_document;
        IHTMLElement feed_div;
        string feed_id;
        bool web1_betoltve = false; //fő böngésző első betöltődése
        bool screen_image = false; //ha képernyőképet kell készíteni;
        bool div_text = false;//ha manipulálni kell a html-t_s0 _5xib _5sq7 _rw img
                              // feed adatok kígyűjtéséhez-----------------------------------
        List<string> user_ikon_class = new List<string>(new string[] { "_s0 _5xib _5sq7 _rw img" });
        List<string> feed_image_class = new List<string>(new string[] { "scaledImageFitWidth img", "scaledImageFitHeight img" }); 
        List<string> feed_image_szoveg_class = new List<string>(new string[] { "_6m3" });
         List<string> cimsor_class = new List<string>(new string[] { "fwn fcg" });
        List<string> szoveg_class = new List<string>(new string[] { "text_exposed_root" });
        //feed adatok
        string cimadatok=" ";
        string szoveg=" ";
        string user_ikon_sourci=" ";
        string feed_image_sourci=" ";
        string feed_image_szoveg = " ";
        //likerobi sávhoz kell----------------------------------------    
        List<string> feed_div_class = new List<string>(new string[] { "_5jmm _5pat _3lb4", "_5jmm _5pat _3lb4 _x72 _50nb" });
        List<string> cel_div_class = new List<string>(new string[] { "_5pcp _5vsi _52i6 _4l4", "_5pcp _5vsi _52i6 _1tsu _4l4" });
        //string feed_view_html = @"view/HTMLPage1.html";

        public MainWindow()
        {
            InitializeComponent();
            web1.LoadCompleted += web1_LoadCompleted; //fő ablak
            popBrowser1.LoadCompleted += popup_LoadCompleted;//popup1 böngésző
        }

        /// <summary>
        /// fő böngésző ablak betöltődésekor fut le
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void web1_LoadCompleted(object sender, NavigationEventArgs e)
        {
            document = (mshtml.HTMLDocument)web1.Document;
            web1_betoltve = true;
            /*     
            //HTMLPopup 
            mshtml.HTMLDocument doc;
            
            mshtml.HTMLDocumentEvents2_Event iEvent;
            iEvent = (mshtml.HTMLDocumentEvents2_Event)doc;
            iEvent.onclick += new mshtml.HTMLDocumentEvents2_onclickEventHandler(ClickEventHandler);
        
            */
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
        { //string currentURl = "file";
           //currentURl = e.Uri.ToString();
          pop_document = (HTMLDocument)popBrowser1.Document;
            // WebRequest request = WebRequest.Create("http://infolapok.hu/like/index.php");
            if (screen_image==true)
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

                pop_document.body.innerHTML =feed_div_string;
               IHTMLDocument3 documentAsIHtmlDocument3 = (mshtml.IHTMLDocument3) popBrowser1.Document;
              string content = documentAsIHtmlDocument3.documentElement.innerHTML;

                screen_image = true;div_text = false;
                popBrowser1.NavigateToString(content);
                /*
                
                
                
                var htmlToImageConv = new NReco.ImageGenerator.HtmlToImageConverter();
                byte[] jpegBytes = htmlToImageConv.GenerateImage(tartalom_text,"Jpeg");

                MemoryStream ms = new MemoryStream(jpegBytes);
                System.Drawing.Image hhh = System.Drawing.Image.FromStream(ms);
                hhh.Save(@"D:\Temp\hhh.jpg");*/

            }

        }


        // popup bezárás----------------------------------------------
        public void butnExitPopup_Click(object sender, RoutedEventArgs e)
        {
            Popup1.IsOpen = false;
        }


  


bool iEvent_onclick(IHTMLEventObj pEvtObj)
        {
           IHTMLElement gg = pEvtObj.srcElement;
            feed_id = gg.getAttribute("feedid");
           string feed_link= gg.getAttribute("feedlink");
          
            IHTMLDocument2 doc = (IHTMLDocument2)web1.Document;
            mshtml.IHTMLElementCollection feed_div = document.getElementById(feed_id).all;


            foreach (mshtml.IHTMLElement elem1 in feed_div)
            {
                if (cimsor_class.Contains(elem1.className))
                {
                    cimadatok = elem1.innerHTML;

                }
                else if (szoveg_class.Contains(elem1.className))
                {
                    szoveg = elem1.innerHTML;
                }
                else if (user_ikon_class.Contains(elem1.className))
                {
                 user_ikon_sourci = elem1.getAttribute("src");
                }
                else if (feed_image_class.Contains(elem1.className))
                {
                feed_image_sourci = elem1.getAttribute("src");
                }
                else if (feed_image_szoveg_class.Contains(elem1.className))
                {
                   feed_image_szoveg = elem1.innerHTML;
                }
            }
              int i = 1;
            IHTMLControlRange imgRange = (IHTMLControlRange)((HTMLBody)document.body).createControlRange();
            foreach ( mshtml.IHTMLImgElement img in doc.images)
             {   string sourci = img.src;
            //
                if (sourci == user_ikon_sourci || sourci == feed_image_sourci)
                { System.Windows.MessageBoxResult messageBoxResult2 = System.Windows.MessageBox.Show("Kép mentése elkészult");
               
                    imgRange.add((IHTMLControlElement)img);

                    imgRange.execCommand("Copy", false, null);

                    if (System.Windows.Forms.Clipboard.ContainsImage())
                    {
                        System.Drawing.Image image_clipboard = System.Windows.Forms.Clipboard.GetImage();
                        image_clipboard.Save(@"d:\Temp\hh" + i+".jpg", ImageFormat.Jpeg);


         
                    }
                    i++;
                }
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
                  

                 }

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
            div_text = true;
                    // Popup1.IsOpen = true;
                    // popBrowser1.Navigate(feed_link);

            return true;
        }

        // likerobi képet tesz a postba------------------------------------------------------
        public void divtext(object sender, RoutedEventArgs e)
        {
            string feedlink = "nincs";
           
                foreach (HTMLDivElement div in document.getElementsByTagName("div"))
            {
                //if (div.id == feed_div_id_19.Substring(0, 18))
                if (feed_div_class.Contains(div.className))
                {

                    string feed_div_id = div.getAttribute("ID");
                    foreach (IHTMLElement link1 in div.getElementsByTagName("a"))
                    {
                        if (link1.className == "_5pcq")
                        {
                            feedlink = link1.getAttribute("href");
                        }
                    }

                    foreach (HTMLDivElement fff in div.getElementsByTagName("div"))
                    {
                        

                            if (cel_div_class.Contains(fff.className))
                            {
                                string likediv = "<div class=\"robi\" feedid=\""+feed_div_id+ "\" feedlink=\"" +feedlink+ "\" style=\" margin:5px;padding:5px;color:red;background-color:blue;\" >like</div>";
                                fff.innerHTML = likediv;
                                HTMLElementEvents2_Event iEvent;
                                iEvent = (HTMLElementEvents2_Event )fff;
                                iEvent.onclick += new HTMLElementEvents2_onclickEventHandler(iEvent_onclick);
                              // LR Lrobi  = new LR(document );
                            } // Lrobi.aktival();
                        }
                    }

                }
            }
        }



    }




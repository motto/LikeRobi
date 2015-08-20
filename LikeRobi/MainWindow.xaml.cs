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


using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Net; // ftphez
using System.Net.Http;
using System.IO;
using System.Drawing.Imaging;


namespace LikeRobi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            web1.LoadCompleted += web1_LoadCompleted;  
            
             
        }
        private static System.Drawing.Image  resizeImage(System.Drawing.Image imgToResize, System.Drawing.Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            //g.InterpolationMode = System.Drawing.InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (System.Drawing.Image)b;
          
        }




        public void web1_LoadCompleted(object sender, NavigationEventArgs e)
        {
        
            mshtml.HTMLDocument doc;
            doc = (mshtml.HTMLDocument)web1.Document;
            mshtml.HTMLDocumentEvents2_Event iEvent;
            iEvent = (mshtml.HTMLDocumentEvents2_Event)doc;
            iEvent.onclick += new mshtml.HTMLDocumentEvents2_onclickEventHandler(ClickEventHandler);
        }
        //post küldés-------------------------------------
        public void postkuld()
        {
            WebRequest request = WebRequest.Create("http://infolapok.hu/like/index.php");
            // Set the Method property of the request to POST.
            request.Method = "POST";

            // Create POST data and convert it to a byte array.
            string postData = "hhh=This is a test that posts this string to a Web server.";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;

            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            //PostData.Close();
          
        }
// a popuban megnyitott post betöltődesekor fut le------------------------------
        public void poup_LoadCompleted(object sender, NavigationEventArgs e)
        {
            string currentURl = e.Uri.ToString();
            ///MessageBoxResult messageBoxResult2 = System.Windows.MessageBox.Show(currentURl, "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            // Get the object used to communicate with the server.
            // WebRequest request = WebRequest.Create("http://infolapok.hu/like/index.php");
            //postkuld();
            if (currentURl != "http://infolapok.hu/like/index.php")
            {
                var topLeftCorner = popBrowser1.PointToScreen(new System.Windows.Point(0, 0));
                var topLeftGdiPoint = new System.Drawing.Point((int)topLeftCorner.X, (int)topLeftCorner.Y);
                var size = new System.Drawing.Size((int)popBrowser1.ActualWidth, (int)popBrowser1.ActualHeight);
                var size2 = new System.Drawing.Size(250, 150);
                Bitmap screenShot = new Bitmap(250, 150);
                // Bitmap b = new Bitmap(size.Width, size.Height);

                using (var graphics = Graphics.FromImage(screenShot))
                {
                    graphics.CopyFromScreen(topLeftGdiPoint, new System.Drawing.Point(),
                         size2, CopyPixelOperation.SourceCopy);


                }
                string data = "hhh=jjjjj&gg=sjgoasg"; //replace <
                byte[]  byteArray= Encoding.UTF8.GetBytes(data);
                string PostHeaders = "Content-Type: application/x-www-form-urlencoded";
                popBrowser1.Navigate("http://infolapok.hu/like/index.php", null, byteArray,PostHeaders);

            }  else { postkuld(); }
           
        
        //adatküldés--------------------------------------------------
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

        /*     
                 //StreamReader sourceStream = new StreamReader(@"D:\Temp\sc1152.png");
                 //string postData = "key=" + sourceStream.ReadToEnd();
                 string data = "username=jjjjj&hhh=fghsdfhs"; //replace <value>
                 //byte[]  byteArray= Encoding.UTF8.GetBytes(data);
                 var   byteArray= Encoding.ASCII.GetBytes(data);
                 //byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                 request.ContentType = "application/x-www-form-urlencoded";
                 // Set the ContentLength property of the WebRequest.
                 request.ContentLength = byteArray.Length;
                 // Get the request stream.
                 Stream dataStream = request.GetRequestStream();
                 // Write the data to the request stream.
                 dataStream.Write(byteArray, 0, byteArray.Length);
                 // Close the Stream object.
                 //dataStream.Close();

       //válasz a webszervertől
                 // Get the response.
                 WebResponse response = request.GetResponse();
                 // Display the status.
                // Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                 // Get the stream containing content returned by the server.
                 dataStream = response.GetResponseStream();
                 // Open the stream using a StreamReader for easy access.
                 StreamReader reader = new StreamReader(dataStream);
                 // Read the content.
                 string responseFromServer = reader.ReadToEnd();
                 // Display the content.
                 //Console.WriteLine(responseFromServer);
                 // Clean up the streams.
                 reader.Close();
                 dataStream.Close();
                 response.Close();
                 Popup1.IsOpen = false; // ablak bezárása
                 Popup2.IsOpen = true;
                 popBrowser2.NavigateToString(responseFromServer);
                 // Copy the contents of the file to the request stream.



                 // Console.WriteLine(result.Result.ToString());


                 //screenShot.Save(@"D:\Temp\sc1152.png");

                 /*
       MemoryStream stream = new MemoryStream();
                 screenShot.Save(stream,ImageFormat.Png);
                 byte[]  poststream= stream.ToArray();
                 ASCIIEncoding Encode = new ASCIIEncoding();
                string base64String= Encode.GetString(poststream);
                  //string base64String = Convert.ToBase64String(poststream);
                 string postadat = "adat="+base64String;
                 //string postData = String.Format(postadat);
                 byte[] Post = Encoding.UTF8.GetBytes(postadat);

                // byte[] post = Encode.GetBytes(postadat);
                 string cim ="http://kk.infolapok.hu";
                 Popup1.IsOpen = false;
                 Popup2.IsOpen = true; //popBrowser1.Navigate(new Uri(kkk), null, null, null);


                 string PostHeaders = "Content-Type: application/x-www-form-urlencoded";
                 popBrowser2.Navigate(cim, null, Post, PostHeaders);

        */




    }


        // likerobi ikonra kattintva megnyit egy popupot a posttal------------------------
        private bool ClickEventHandler(mshtml.IHTMLEventObj e)
        {
         
            System.Drawing.Point point = System.Windows.Forms.Control.MousePosition;
            var doc = (mshtml.HTMLDocument)web1.Document;
            IHTMLElement elem =doc.elementFromPoint(point.X,point.Y);
            // IHTMLElement ch =doc.elementFromPoint(point.X,point.Y);
            if (elem == null || elem.className == null)
            {
            }
            else
            { 
                if (elem.className == "_5pcp _5vsi _52i6 _1tsu _4l4" || elem.className == "_5pcp _5vsi _52i6 _4l4")
                {
                    foreach (IHTMLElement d in elem.all)
                    {
                        if (d.className != null)
                        {
                            if (d.className.Equals("robi"))
                            {
                                // MessageBoxResult messageBoxResult2 = System.Windows.MessageBox.Show(d.getAttribute("hhh"), "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                              //string postid = d.getAttribute("postid");
                                string postlink =d.getAttribute("postlink");
                               // string postlink ="httpsgggggggggg";
                               string kkk = postlink.Replace("https","http");
                                 //MessageBoxResult messageBoxResult2 = System.Windows.MessageBox.Show(kkk, "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                                // IHTMLElement postdiv = doc.getElementById(postid);
                                // string divhtml = postdiv.innerHTML;
                                //string divhtml = "kkkkkkkkkkkkk";
                                //adatkuld_popup1("adat="+divhtml , "http://kk.infolapok.hu/index.php?kk=");
                                //adatkuld_popup1("adat=ggggggg","http://"+postlink );
                               // web1.Navigate(new Uri("http://www.facebook.com/photo.php?fbid=10153440546882521&set=a.10153440546602521.1073741856.826292520&type=1"), null, null, null);
                              Popup1.IsOpen = true;popBrowser1.Navigate(new Uri(kkk), null, null, null);
                                popBrowser1.LoadCompleted += poup_LoadCompleted;
                                return false;
                            }
                        }
                    }
                }
            }
        
            return true;     
        }
// popup bezárás----------------------------------------------
        public void butnExitPopup_Click(object sender, RoutedEventArgs e)
        {
            Popup1.IsOpen = false;
        }
//string adatküldés post--------------------------------------------------
        public void screen_popup1(string postadat, string cim)
        {
           // Popup1.IsOpen = true;
            ASCIIEncoding Encode = new ASCIIEncoding();
            byte[] post = Encode.GetBytes(postadat);
            string PostHeaders = "Content-Type: application/x-www-form-urlencoded";
            popBrowser1.Navigate(cim, null, post, PostHeaders);
           // HTMLDocument document = (HTMLDocument)popBrowser1.Document;
    
            }


 //byte adatküldés public void adatkuld_popup1(string postadat,string cim)
        public void adatkuld_popup1(byte[] postadat,string cim)
        {
            Popup1.IsOpen = true;
            // Convert the string into a byte array
            //ASCIIEncoding Encode = new ASCIIEncoding();
           // 
           // byte[] post = Encode.GetBytes(postadat);
         
            // The same Header that its sent when you submit a form.
            string PostHeaders = "Content-Type: application/x-www-form-urlencoded";

            popBrowser1.Navigate(cim, null, postadat, PostHeaders);
        }

    
// likerobi képet tesz a postba------------------------------------------------------
        public void divtext(object sender, RoutedEventArgs e)
        {
            string Postlink = "";
            string Postid = "";

            HTMLDocument document = (HTMLDocument)web1.Document;
            foreach (IHTMLElement div in document.getElementsByTagName("div"))
            {
                //if (div.className == "_5pcp _5vsi _52i6 _1tsu _4l4" || div.className == "_5pcp _5vsi _52i6 _4l4"  )
              // if (div.className == "userContentWrapper _5pcr")
                 if (div.className == "_5jmm _5pat _3lb4" || div.className == "_5jmm _5pat _3lb4 _x72 _50nb")
                {
                    Postid= div.getAttribute("ID");
                    IHTMLElementCollection elem = div.all;
                    foreach (IHTMLElement fff in elem)
                    {
                        if (fff.className == "_5pcq")
                        {
                            Postlink = fff.getAttribute("href");
                        }

                        if (fff.className == "_5pcp _5vsi _52i6 _1tsu _4l4" || fff.className == "_5pcp _5vsi _52i6 _4l4")
                        {

                            //fff.innerHTML = "<div class=\"robi\" onclick=\"kattint('" + lll + "');\">like Robi<div>";
                            //fff.innerHTML = "<div class=\"robi\" hhh=\"" + lll + "\" >like Robi</div>";
                            fff.innerHTML = "<img src=\"http://kk.infolapok.hu/2.png\" class=\"robi\" Postlink=\"" + Postlink + "\" Postid=\"" + Postid + "\" />";
                       /*     IHTMLElement sourceDiv =document.createElement("div");
                            sourceDiv.className = "robi";
                            sourceDiv.innerHTML = "LikeRobi";*/
                            //fff.innerHTML.add;
                        }


                        //MessageBoxResult messageBoxResult3 = System.Windows.MessageBox.Show("Are youbbbbb sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                        //  if (messageBoxResult3 == MessageBoxResult.Yes) ;
                        // div.innerHTML = "something" + div.innerHTML;
                    }
                }
            }

        }
    }
       
   



}

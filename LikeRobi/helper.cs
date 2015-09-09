using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mshtml;
using System.Drawing;
using System.Runtime.InteropServices;
namespace LikeRobi
{
    class Conf
    {
        //html segéd.Lr_sav-----------------------------------------------
        static public List<string> feed_div_class = new List<string>(new string[] { "_5jmm _5pat _3lb4", "_5jmm _5pat _3lb4 _x72 _50nb" });
        /// <summary>
        /// Az ilyen osztályú divek tartalmát cseréli ki LR sávra
        /// </summary>
        static public List<string> cel_div_class = new List<string>(new string[] { "_5pcp _5vsi _52i6 _4l4", "_5pcp _5vsi _52i6 _1tsu _4l4" });
        //LR_click--------------------------------------------------------------------
        static public List<string> user_ikon_class = new List<string>(new string[] { "_s0 _5xib _5sq7 _rw img","_s0 _5xib _54ru img", "_s0 _5xib _5sq7 _rw img" });
        static public List<string> feed_image_class = new List<string>(new string[] { "scaledImageFitWidth img", "scaledImageFitHeight img"});
        static public List<string> feed_image_szoveg_class = new List<string>(new string[] { "_6m3" });
        static public List<string> cimsor_class = new List<string>(new string[] { "_6a _6b" });
        static public List<string> cimsor_elem_class = new List<string>(new string[] { "profileLink", "fwb fcg" });// <a>:profileLink <span>:fwb fcg
        static public List<string> intro_class = new List<string>(new string[] { "text_exposed_show" });


    }
    public class Htmlseged
    {
        static public IHTMLDocument2 doc;
        static public HTMLDocument document;
        //feed adatok---------------------------- 
        public string feed_id;
        static public List<string> cim_elemek = new List<string>();
        string intro = " ";
        string user_ikon_sourci = " ";
        string feed_image_sourci = " ";
        string feed_image_szoveg = " ";

        //-------------------------------------------------
         [ComImport, InterfaceType((short)1), Guid("3050F669-98B5-11CF-BB82-00AA00BDCE0B")]
        private interface IHTMLElementRenderFixed
        {
            void DrawToDC(IntPtr hdc);
            void SetDocumentPrinter(string bstrPrinterName, IntPtr hdc);
        }

        public Bitmap GetImage(IHTMLImgElement img)
        {
             IHTMLElementRenderFixed render = (IHTMLElementRenderFixed)img;

            Bitmap bmp = new Bitmap(img.width, img.height);

            Graphics g = Graphics.FromImage(bmp);
            IntPtr hdc = g.GetHdc();
            render.DrawToDC(hdc);
            g.ReleaseHdc(hdc);

            return bmp;
        }

        //---------------------------------------





        bool LR_click(IHTMLEventObj pEvtObj)
        {
            IHTMLElement gg = pEvtObj.srcElement;
            feed_id = gg.getAttribute("feedid");
            string feed_link = gg.getAttribute("feedlink");


            mshtml.IHTMLElementCollection feed_div = document.getElementById(feed_id).all;


            foreach (mshtml.IHTMLElement elem1 in feed_div)
            {
                // bejárja a címsor(lista) 
                if (Conf.cimsor_class.Contains(elem1.className))
                {

                    foreach (IHTMLElement cim_elem in elem1.all)
                    {
                       if (Conf.cimsor_elem_class.Contains(cim_elem.className))
                        {
                            cim_elemek.Add(cim_elem.innerText);
                        }
                    }

                 


                }
                else if (Conf.intro_class.Contains(elem1.className))
                {
                    intro = elem1.innerHTML;
                }
                else if (Conf.user_ikon_class.Contains(elem1.className))
                {
                    user_ikon_sourci = elem1.getAttribute("src");
                }
                else if (Conf.feed_image_class.Contains(elem1.className))
                {
                    feed_image_sourci = elem1.getAttribute("src");
                }
                else if (Conf.feed_image_szoveg_class.Contains(elem1.className))
                {
                    feed_image_szoveg = elem1.innerHTML;
                }
            }
            int i = 1;
            IHTMLControlRange imgRange = (IHTMLControlRange)((HTMLBody)document.body).createControlRange();
            foreach (mshtml.IHTMLImgElement img in doc.images)
            {


        string sourci = img.src;
                //
                if (sourci == user_ikon_sourci || sourci == feed_image_sourci)
                {

                    Bitmap ujkep = GetImage(img);
                    ujkep.Save(@"d:\Temp\hh" + i + ".jpg");
                    /*
                 

                    System.Windows.Forms.Clipboard.Clear();
                System.Windows.MessageBoxResult messageBoxResult2 = System.Windows.MessageBox.Show("vágólap törlése törlése");

                  
                    imgRange.add((IHTMLControlElement)img);
                    imgRange.execCommand("Copy", false, null);
                System.Windows.MessageBoxResult messageBoxResult3 = System.Windows.MessageBox.Show("Kép mentése elkészult");

                    if (System.Windows.Forms.Clipboard.ContainsImage())
                    {
                        System.Drawing.Image image_clipboard = System.Windows.Forms.Clipboard.GetImage();
                        image_clipboard.Save(@"d:\Temp\hh" + i + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                      //  img.nameProp;

                    }*/
                    i++;
                }
            }

            bool kk = true;
            return kk;
        }
           


           
   
        public void LR_sav()
        {
            string feedlink = "nincs";

            foreach (HTMLDivElement div in document.getElementsByTagName("div"))
            {
                //if (div.id == feed_div_id_19.Substring(0, 18))
                if (Conf.feed_div_class.Contains(div.className))
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


                        if (Conf.cel_div_class.Contains(fff.className))
                        {
                            string likediv = "<div class=\"robi\" feedid=\"" + feed_div_id + "\" feedlink=\"" + feedlink + "\" style=\" margin:5px;padding:5px;color:red;background-color:blue;\" >like</div>";
                            fff.innerHTML = likediv;
                            HTMLElementEvents2_Event iEvent;
                            iEvent = (HTMLElementEvents2_Event)fff;
                            iEvent.onclick += new HTMLElementEvents2_onclickEventHandler(LR_click);
                            // LR Lrobi  = new LR(document );
                        } // Lrobi.aktival();
                    }

                }

            }
        }
    }

    /*
  //  button click----------------------------------------
     var element = doc.getElementById("button id"); //Id of the input element
            if (element != null)
            { 
                element.click();
            }

    //file feltöltés--------------------------------------------
    string url = "http://myserver/myapp/upload.aspx";
    string file = "c:\\files\\test.jpg";
    WebClient wc = new WebClient();
    wc.UploadFile(url,"post",file);

//image source streamből----------------------------- 

    byte[] imageArr ;

//set your imageArr here---

BitmapImage bi = new BitmapImage();
bi.BeginInit();
bi.CreateOptions = BitmapCreateOptions.None;
bi.CacheOption = BitmapCacheOption.Default;
bi.StreamSource = new MemoryStream(imageArr);
bi.EndInit();

Image img = new Image();  //Image control of wpf

img.Source = bi;


        bool wait_to_clear(int kk = 100)
            {
                bool vankep = false;
                int k = 1;
                while (System.Windows.Forms.Clipboard.ContainsImage())
                {
                    for (int i = 1; i == 100; i++) { }
                    k++;
                    if (k == kk) { vankep = true; return vankep; }
                }
                return vankep;
            }
            bool wait_to_image(int kk = 100)
            {
                bool vankep = true;
                int k = 1;
                while (!System.Windows.Forms.Clipboard.ContainsImage())
                {

                    k++;
                    if (k == kk) { vankep = false; return vankep; }
                }

                return vankep;
            }


    */

}
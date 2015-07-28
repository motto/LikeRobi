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
using mshtml;
using System.Security.Permissions;
using System.Runtime.InteropServices;


using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;




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
        public void web1_LoadCompleted(object sender, NavigationEventArgs e)
        {
        
            mshtml.HTMLDocument doc;
            doc = (mshtml.HTMLDocument)web1.Document;
            mshtml.HTMLDocumentEvents2_Event iEvent;
            iEvent = (mshtml.HTMLDocumentEvents2_Event)doc;
            iEvent.onclick += new mshtml.HTMLDocumentEvents2_onclickEventHandler(ClickEventHandler);
        }

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
                                MessageBoxResult messageBoxResult2 = System.Windows.MessageBox.Show(d.getAttribute("hhh"), "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);

                               // web1.Navigate("https://facebook.com");
                                return false;

                            }
                        }
                    }
                }
            }
        
            return true;
          

             //MessageBoxResult messageBoxResult3 = System.Windows.MessageBox.Show(elem.innerHTML, "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
           
            
        }


        public void divtext(object sender, RoutedEventArgs e)
        {
            string lll = "";

            HTMLDocument document = (HTMLDocument)web1.Document;
            foreach (IHTMLElement div in document.getElementsByTagName("div"))
            {
                //if (div.className == "_5pcp _5vsi _52i6 _1tsu _4l4" || div.className == "_5pcp _5vsi _52i6 _4l4"  )
                if (div.className == "userContentWrapper _5pcr _3ccb")
                {
                    IHTMLElementCollection elem = div.all;
                    foreach (IHTMLElement fff in elem)
                    {
                        if (fff.className == "_5pcq")
                        {
                            lll = fff.getAttribute("href");
                        }

                        if (fff.className == "_5pcp _5vsi _52i6 _1tsu _4l4" || fff.className == "_5pcp _5vsi _52i6 _4l4")
                        {

                            //fff.innerHTML = "<div class=\"robi\" onclick=\"kattint('" + lll + "');\">like Robi<div>";
                        //fff.innerHTML = "<div class=\"robi\" hhh=\"" + lll + "\" >like Robi</div>";
                    fff.innerHTML = "<img src=\"http://kk.infolapok.hu/2.png\" class=\"robi\" hhh=\"" + lll + "\" />";
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

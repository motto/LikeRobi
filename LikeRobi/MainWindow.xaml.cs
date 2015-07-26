﻿using System;
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



namespace LikeRobi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

  

       // public partial class Singleton
        public partial class MainWindow : Window
          {
            private static MainWindow instance;

            private MainWindow()
            {
            InitializeComponent();
            web1.LoadCompleted += web1_LoadCompleted;   // web1.ObjectForScripting = new Scriptinghelper();
                                                        // Scriptinghelper helper =new Scriptinghelper();
            this.web1.ObjectForScripting = new Scriptinghelper();
             }

            public static MainWindow Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new MainWindow();
                    }
                    return instance;
                }
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
                            fff.innerHTML = "<div class=\"robi\" onclick=\"kattint('"+lll+"');\">like Robi<div>";
                        }

                        //MessageBoxResult messageBoxResult3 = System.Windows.MessageBox.Show("Are youbbbbb sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                        //  if (messageBoxResult3 == MessageBoxResult.Yes) ;
                        // div.innerHTML = "something" + div.innerHTML;
                    }
                }
            }

        }
       
        public void web1_LoadCompleted(object sender, NavigationEventArgs e)
        {

            //  WebBrowser browser = sender as WebBrowser;
            dynamic doc = web1.Document;
            dynamic script = doc.createElement("SCRIPT");
            script.type = "text/javascript";
            script.text = "function kattint(kkk){window.external.likerobi(kkk);}";
            //dynamic head = doc.getElemetsByTagname("HEAD")[0];
            doc.head.appendChild(script);

        }

    }

    [ComVisible(true)]
    public class Scriptinghelper
    {

        public void likerobi(string adat)
        {
           // Window mainWindow =this.mai
           MainWindow fp = LikeRobi.MainWindow.Instance ;
           // fp.Show();
            //MessageBoxResult messageBoxResult3 = System.Windows.MessageBox.Show("Are youbbbbb sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            //  if (messageBoxResult3 == MessageBoxResult.Yes) ;
            //Popup myPopupWithText = new Popup();
            fp.Popup1.IsOpen = true;
            // Convert the string into a byte array
            ASCIIEncoding Encode = new ASCIIEncoding();
            byte[] post = Encode.GetBytes("username=nyuszoka&password=123");

            // The destination url
            string url = "http://localhost";

            // The same Header that its sent when you submit a form.
            string PostHeaders = "Content-Type: application/x-www-form-urlencoded";

           fp.popBrowser1.Navigate(url, null, post, PostHeaders);
        }

    }



}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobiDll
{
    public class webmatat
    {
    }
    public class idozito 
    {
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();


        t.Interval = 3000; // 3s
            t.Tick += new EventHandler(timer_Tick);
        //   t.Start();

    }

    void timer_Tick(object sender, EventArgs e)
    {
        //Call method
        linkcsere2();
    }
}

}
namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            web1.LoadCompleted += web1_LoadCompleted;
            // webb.Navigate("http://www.google.com");

            //web1.AddHandler.OnContentChanged
            // csere();
     
        public void linkcsere2()
        {
            HTMLDocument document = (HTMLDocument)web1.Document;
            foreach (IHTMLElement link in document.links)
            {
                if (link.className == "share_action_link")
                { link.innerHTML = "fffffffffff"; }

            }
        }

        public void linkcsere(object sender, RoutedEventArgs e)
        {
            HTMLDocument document = (HTMLDocument)web1.Document;
            foreach (IHTMLElement link in document.links)
            {
                if (link.className == "share_action_link")
                { link.innerHTML = "dddddddddddd"; }

            }
        }





        public void divtext(object sender, RoutedEventArgs e)
        {
            string lll = "";
            //web2.AllowDrop = true;
            // web2.Navigate("http://localhost");
            HTMLDocument document = (HTMLDocument)web1.Document;
            foreach (IHTMLElement div in document.getElementsByTagName("div"))
            {
                //if (div.className == "_5pcp _5vsi _52i6 _1tsu _4l4" || div.className == "_5pcp _5vsi _52i6 _4l4"  )
                if (div.className == "userContentWrapper _5pcr _3ccb")
                {
                    IHTMLElementCollection bejar = div.all;
                    // IHTMLElement[] body =div.GetElementsByName("body");
                    //Collecting the children of the body element in a collection
                    IHTMLElementCollection elem = div.all;
                    foreach (IHTMLElement fff in elem)
                    {


                        if (fff.className == "_5pcq")
                        {

                            lll = fff.getAttribute("href");
                            //  MessageBoxResult messageBoxResult3 = System.Windows.MessageBox.Show(lll, "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                            //  if (messageBoxResult3 == MessageBoxResult.Yes) ;

                        }


                        if (fff.className == "_5pcp _5vsi _52i6 _1tsu _4l4" || fff.className == "_5pcp _5vsi _52i6 _4l4")
                        {
                            fff.innerHTML = "<div class=\"robi\">like Robi<div>";
                            // fff.onclick(kepcsere);

                        }

                        //MessageBoxResult messageBoxResult3 = System.Windows.MessageBox.Show("Are youbbbbb sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                        //  if (messageBoxResult3 == MessageBoxResult.Yes) ;
                        // div.innerHTML = "something" + div.innerHTML;
                    }
                }
            }
        }

        public void kepcsere1(object sender, RoutedEventArgs e)
        {
            HTMLDocument document = (HTMLDocument)web1.Document;

            foreach (IHTMLElement image in document.images)
            { //image.setAttribute("src", string.Empty);
            }
            // popBrowser1.Navigate("http://192.168.1.66");
            Popup1.IsOpen = true;
            // Convert the string into a byte array
            ASCIIEncoding Encode = new ASCIIEncoding();
            byte[] post = Encode.GetBytes("username=nyuszoka&password=123");

            // The destination url
            string url = "http://192.168.1.66";

            // The same Header that its sent when you submit a form.
            string PostHeaders = "Content-Type: application/x-www-form-urlencoded";

            popBrowser1.Navigate(url, null, post, PostHeaders);

        }

        public void web1_LoadCompleted(object sender, NavigationEventArgs e)
        {

            HTMLDocument document = (HTMLDocument)web1.Document;

            // document.body.innerHTML = "hsfbashfbs";
            foreach (IHTMLSpanElement myelem in document.getElementsByTagName("span"))
            {
                HTMLSpanElement el = myelem as HTMLSpanElement;
                if (el.className.Equals("_2dpb"))
                {
                    el.innerText = "Nyuszóka párja";
                    // MessageBoxResult messageBoxResult3 = System.Windows.MessageBox.Show("Are youbbbbb sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                    //  if (messageBoxResult3 == MessageBoxResult.Yes) ;
                }

                //    HTMLElementCollection elems = web1.Document.Equals;







            }

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void web1_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            HTMLDocument document = (HTMLDocument)web1.Document;
            foreach (IHTMLElement div in document.getElementsByTagName("div"))
            {
                if (div.className == "_5pcp _5vsi")
                {

                    div.innerHTML = "something" + div.innerHTML;
                }
            }
        }
    }
}

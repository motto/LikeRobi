using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using mshtml;
using System.IO; //filekezelés

namespace HtmlMO
{
    public class LR
    {

        List<string> feed_div_class = new List<string>(new string[] { "_5jmm _5pat _3lb4" ,"_5jmm _5pat _3lb4 _x72 _50nb"});
        List<string> cel_div_class = new List<string>();
       // string feed_div_id_19 = "hyperfeed_story_id_";
        string feed_div_id = "";
        string postlink = "";
        string feed_view_html = @"view/HTMLPage1.html";

        HTMLDocument document;  //mshtml.htmldocument !!! 

        public LR(HTMLDocument document1) //constructor
        {
            cel_div_class.Add("_5pcp _5vsi _52i6 _4l4");
            cel_div_class.Add("_5pcp _5vsi _52i6 _1tsu _4l4");
            document = document1;

        }

   
/*

        bool iEvent_onclick(IHTMLEventObj pEvtObj)
        {
            IHTMLElement gg = pEvtObj.srcElement;
            string feed_id = gg.getAttribute("feedid");
            // MessageBox messageBoxResult2 =MessageBox.Show(gg.getAttribute("feedid") + "hjjh");
            IHTMLElement feed_div = document.getElementById(feed_id);
            string strHTML = File.ReadAllText(feed_view_html);
            var br1 = new WebBrowser();
            br1.Navigate(strHTML);
            return true;
        }

        public void aktival()
        {
            foreach (HTMLDivElement div in document.getElementsByTagName("div"))
            {
                //if (div.id == feed_div_id_19.Substring(0, 18))
                if (feed_div_class.Contains(div.className))
                {
                    string feed_div_id = div.getAttribute("ID");

                    foreach (HTMLDivElement fff in div.getElementsByTagName("div"))
                    {
                        if (fff.className == "_5pcq")
                        {
                            string postlink = fff.getAttribute("href");
                        }

                        if (cel_div_class.Contains(fff.className))
                        {

                            string likediv = "<div class=\"robi\" feedid=\"" + feed_div_id + "\"  style=\" margin:5px;padding:5px;color:red;background-color:blue;\" >like</div>";
                            fff.innerHTML = likediv;
                            HTMLElementEvents2_Event iEvent;
                            iEvent = (HTMLElementEvents2_Event)fff;
                            iEvent.onclick += new HTMLElementEvents2_onclickEventHandler( iEvent_onclick);

                        }
                    }
                }

            }
        }
*/

    }


    public class HtmlMO
    {





        public static void elem_to_popup(IHTMLElement elem)
        {
            if (elem == null || elem.className == null) { }
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
                                string postlink = d.getAttribute("postlink");
                                string kkk = postlink.Replace("https", "http");
                             // lpo Browser1.Navigate(new Uri(kkk), null, null, null);
                            }
                        }
                    }
                }

            }


        }
    }
}

/*

IHTMLElement likebox =document.createElement("DIV");
likebox.className = "robi";
likebox.innerHTML = "like";
likebox.setAttribute("postid",feed_div_id);




    */

using Gtk;
using SharpWebview;
using SharpWebview.Content;
using System;

namespace WebViewGtk
{
    /// <summary>
    /// A web browser widget.
    /// </summary>
    public class WebView : Bin
    {
        /// <summary>
        /// The internal browser control.
        /// </summary>
        /// <value></value>
        public Webview Browser { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent">The parent to which this widget will be added as a child.</param>
        public WebView() : base()
        {
            //Browser = new Webview(Id, true, true);
            Destroyed += OnDestroyed;
            Realized += OnRealized;
        }

        private void OnRealized(object sender, EventArgs args)
        {
            Realized -= OnRealized;
            Browser = new Webview(Handle, true, true);

            string url = "https://en.wikipedia.org/wiki/The_Hitchhiker%27s_Guide_to_the_Galaxy_(novel)";
            Browser.Navigate(new UrlContent(url));
        }

        private void OnDestroyed(object sender, EventArgs e)
        {
            Browser.Dispose();
        }
    }
}
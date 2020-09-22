using System;
using Gtk;
using SharpWebview.Content;

namespace WebViewGtk
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.Init();

            var app = new Application("org.WebViewGtk.WebViewGtk", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);

            var win = CreateWindow();
            app.AddWindow(win);

            win.Show();
            Application.Run();
        }

        private static Window CreateWindow()
        {
            Window win = new Window("Embedded browser demo");
            win.DefaultSize = new Gdk.Size(800, 600);

            Box container = new Box(Orientation.Vertical, 0);
            container.PackStart(new Label("Web browser inside a gtk application:"), false, false, 0);

            var web = new WebView();
            
            container.PackStart(web, true, true, 0);

            win.Add(container);
            win.ShowAll();
            return win;
        }

        
    }
}

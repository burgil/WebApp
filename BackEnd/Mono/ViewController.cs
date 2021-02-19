using System;

using AppKit;
using Foundation;
using WebKit;

namespace WebApp
{
    public partial class ViewController : NSViewController
    {
        static NSView currentView;
        public ViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            currentView = View;
            // Do any additional setup after loading the view.
            WebAppBrowser.Configuration.Preferences.SetValueForKey(NSObject.FromObject(true), new NSString("developerExtrasEnabled"));
            NSUrl url = new NSUrl("file://"+System.IO.Path.GetFullPath("../../../FrontEnd/index.html"));//new NSUrl("https://www.apple.com");
            WebAppBrowser.LoadFileUrl(url, url);
            WebAppBrowser.NavigationDelegate = new WKWebViewDelegate();
        }

        public override void ViewDidAppear()
        {            
            //This is insanely stupid:
            //View.Window.RepresentedFilename = new NSUrl(System.IO.Path.GetFullPath("../../../favicon.png"));
            //var icon = View.Window.StandardWindowButton(NSWindowButton.DocumentIconButton);
            //NSImage image = NSImage.ImageNamed(System.IO.Path.GetFullPath("/"));
            //icon.Image = image;
            //Haha fuck it I got it:
            View.Window.RepresentedFilename = "../../../FrontEnd/CrossIcon/favicon.mac";
            //foreach(var file in System.IO.Directory.GetFiles("../../../"))
            //{
            //var alert = new NSAlert();
            //alert.MessageText = "found file:";
            //alert.InformativeText = file;
            //alert.RunModal();
            //}
        }

        public static void ChangeTitle(string title)
        {
            currentView.Window.Title = title;
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}

using System;

using AppKit;
using Foundation;

namespace WebApp
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
            NSUrl url = new NSUrl("https://www.apple.com");
            WebAppBrowser.LoadRequest(new NSUrlRequest(url));
            WebAppBrowser.Configuration.Preferences.SetValueForKey(NSObject.FromObject(true), new NSString("developerExtrasEnabled"));
        }

        public override void ViewDidAppear()
        {
            //View.Window.RepresentedFilename = new NSUrl(System.IO.Path.GetFullPath("../../../favicon.png"));
            View.Window.RepresentedFilename = "../../../favicon.mac";
            View.Window.Title = "tester";

            //This is insanely stupid:
            //var icon = View.Window.StandardWindowButton(NSWindowButton.DocumentIconButton);
            //NSImage image = NSImage.ImageNamed(System.IO.Path.GetFullPath("/"));
            //icon.Image = image;

            //foreach(var file in System.IO.Directory.GetFiles("../../../"))
            //{
            //var alert = new NSAlert();
            //alert.MessageText = "found file:";
            //alert.InformativeText = file;
            //alert.RunModal();
            //}
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

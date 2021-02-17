using Foundation;
using WebKit;

namespace WebApp
{
    internal class WKWebViewDelegate : WKNavigationDelegate
    {
        public override void DidFinishNavigation(WKWebView webView, WKNavigation navigation)
        {
            var js = (NSString)"document.title";
            WKJavascriptEvaluationResult handler = (NSObject result, NSError err) =>
            {
                if (err != null)
                {
                    //System.Console.WriteLine("error:" + err.ToString());
                    ViewController.ChangeTitle(err.ToString());
                }
                if (result != null)
                {
                    //System.Console.WriteLine("result:" + result.ToString());
                    ViewController.ChangeTitle(result.ToString());
                }
            };
            webView.EvaluateJavaScript(js, handler);
        }
    }
}
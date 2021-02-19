using AppKit;
using Foundation;
using WebKit;

namespace WebApp
{
    internal class WKWebViewDelegate : WKNavigationDelegate, IWKScriptMessageHandler
    {
        const string JavaScriptFunction = "function invokeCSharpAction(data){window.webkit.messageHandlers.invokeAction.postMessage(data);}";
        WKUserContentController userController;

        public override void DidFinishNavigation(WKWebView webView, WKNavigation navigation)
        {
            userController = webView.Configuration.UserContentController;
            var script = new WKUserScript(new NSString(JavaScriptFunction), WKUserScriptInjectionTime.AtDocumentEnd, false);
            userController.AddUserScript(script);
            userController.AddScriptMessageHandler(this, "invokeAction");
            //userContentController.AddScriptMessageHandler();
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

        public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
        {
            var alert = new NSAlert();
            alert.MessageText = "got message:";
            alert.InformativeText = message.Body.ToString();
            alert.RunModal();
        }
    }
}
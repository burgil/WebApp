using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Microsoft.VisualBasic.CompilerServices;

namespace WebApp
{
    public partial class Client
    {
        public Client()
        {
            InitializeComponent();
        }

        public ChromiumWebBrowser Browser;
        private bool Debug = false;

        private System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return System.Reflection.Assembly.LoadFrom("Chromium/" + Generic.GetStringBetween("," + args.Name, ",", ",") + ".dll");
        }

        private void Browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (e.IsLoading == false)
            {
                var p = new ProcessStartInfo();
                if (Debug)
                    Process.Start("chrome", "-incognito http://localhost:2222");
                Browser.ExecuteScriptAsync(Conversions.ToString(ServerParser.ParseServerJS(@"FrontEnd\ServerSide.js")));
            }
        }

        private void Browser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            Text = e.Title;
        }

        public void ClearCache(string folder)
        {
            if (Directory.Exists(@"Chromium\" + folder))
                Directory.Delete(@"Chromium\" + folder, true);
        }

        public void InitBrowser()
        {
            ClearCache("blob_storage");
            ClearCache("Cache");
            ClearCache("GPUCache");
            ClearCache("Local Storage");
            ClearCache("Session Storage");
            var Settings = new CefSettings();
            Settings.LogFile = @"Chromium\debug.log";
            Settings.CachePath = Path.GetFullPath("Chromium");
            if (Debug)
                Settings.RemoteDebuggingPort = 2222;
            Cef.Initialize(Settings);
            Browser = new ChromiumWebBrowser("file:///" + Path.GetFullPath(@".\FrontEnd\index.html"));
            Controls.Add(Browser);
            Browser.Dock = DockStyle.Fill;
            Browser.LoadingStateChanged += Browser_LoadingStateChanged;
            Browser.TitleChanged += Browser_TitleChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            CheckForIllegalCrossThreadCalls = false;
            if (File.Exists(@"Icon\favicon.ico"))
                Icon = new Icon(@"Icon\favicon.ico");
            if (File.Exists("debug"))
                Debug = true;
            InitBrowser();
        }
    }
}
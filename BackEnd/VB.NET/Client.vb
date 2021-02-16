Imports System.IO
Imports CefSharp
Imports CefSharp.WinForms
Public Class Client
    Public Browser As ChromiumWebBrowser
    Dim Debug As Boolean = False
    Private Function CurrentDomain_AssemblyResolve(sender As Object, args As ResolveEventArgs)
        Return Reflection.Assembly.LoadFrom("Chromium\" + GetStringBetween("," + args.Name, ",", ",") + ".dll")
    End Function
    Private Sub Browser_LoadingStateChanged(sender As Object, e As LoadingStateChangedEventArgs)
        If e.IsLoading = False Then
            Dim p As New ProcessStartInfo
            If Debug Then Process.Start("chrome", "-incognito http://localhost:2222")
            Browser.ExecuteScriptAsync(ParseServerJS("FrontEnd\ServerSide.js"))
        End If
    End Sub
    Private Sub Browser_TitleChanged(sender As Object, e As CefSharp.TitleChangedEventArgs)
        Me.Text = e.Title
    End Sub
    Sub ClearCache(folder As String)
        If Directory.Exists("Chromium\" + folder) Then Directory.Delete("Chromium\" + folder, True)
    End Sub
    Public Sub InitBrowser()
        ClearCache("blob_storage")
        ClearCache("Cache")
        ClearCache("GPUCache")
        ClearCache("Local Storage")
        ClearCache("Session Storage")
        Dim Settings As New CefSettings()
        Settings.LogFile = "Chromium\debug.log"
        Settings.CachePath = System.IO.Path.GetFullPath("Chromium")
        If Debug Then Settings.RemoteDebuggingPort = 2222
        Cef.Initialize(Settings)
        Browser = New ChromiumWebBrowser("file:///" & Path.GetFullPath(".\FrontEnd\index.html"))
        Me.Controls.Add(Browser)
        Browser.Dock = DockStyle.Fill
        AddHandler Browser.LoadingStateChanged, AddressOf Browser_LoadingStateChanged
        AddHandler Browser.TitleChanged, AddressOf Browser_TitleChanged
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf CurrentDomain_AssemblyResolve
        CheckForIllegalCrossThreadCalls = False
        If File.Exists("FrontEnd\CrossIcon\favicon.ico") Then Me.Icon = New Icon("FrontEnd\CrossIcon\favicon.ico")
        If File.Exists("debug") Then Debug = True
        InitBrowser()
    End Sub
End Class

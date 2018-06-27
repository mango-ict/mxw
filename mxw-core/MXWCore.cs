using CefSharp;
using CefSharp.Wpf;
using System.Diagnostics;

namespace mxw_core
{

    public class MXWCore
    {
        // Declare a local instance of chromium and the main form in order to execute things from here in the main thread
        private static ChromiumWebBrowser _instanceBrowser = null;

        public MXWCore(ChromiumWebBrowser originalBrowser)
        {
            _instanceBrowser = originalBrowser;
        }

        public void showDevTools()
        {
            _instanceBrowser.ShowDevTools();
        }

        public void opencmd()
        {
            ProcessStartInfo start = new ProcessStartInfo("cmd.exe", "/c pause");
            Process.Start(start);
        }
    }

}

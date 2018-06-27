using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CefSharp;
using CefSharp.Wpf;
using System.Runtime.InteropServices;

namespace mxw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Set legacy javascript enabler
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;

            // Initialize components
            InitializeComponent();

            // Register JavaScript object
            this.cefBrowser.RegisterJsObject("mxw", new MXWCore(this.cefBrowser, this));

        }

        private void cefBrowser_IsBrowserInitializedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.cefBrowser.IsBrowserInitialized)
            {
                // Load a resource page
                String page = string.Format(@"{0}html-resources\html\index.html", System.AppDomain.CurrentDomain.BaseDirectory);

                if (!File.Exists(page))
                {
                    MessageBox.Show("Error The html file doesn't exists : " + page);
                }

                // Allow the use of local resources in the browser
                BrowserSettings browserSettings = new BrowserSettings();
                browserSettings.FileAccessFromFileUrls = CefState.Enabled;
                browserSettings.UniversalAccessFromFileUrls = CefState.Enabled;
                this.cefBrowser.BrowserSettings = browserSettings;

                // Set CefBrowser content.
                this.cefBrowser.Address = string.Format(@"{0}" + page.Replace(@"\", @"/"), @"file://");
                this.cefBrowser.Reload();
            }
        }
    }
}

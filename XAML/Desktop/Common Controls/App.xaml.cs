﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Common_Controls
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.StartupUri = new Uri("ButtonControl.xaml", UriKind.RelativeOrAbsolute);
            this.StartupUri = new Uri("CalendarControl.xaml", UriKind.RelativeOrAbsolute);
            this.StartupUri = new Uri("MenuControl.xaml", UriKind.RelativeOrAbsolute);
            this.StartupUri = new Uri("ViewBoxControl.xaml", UriKind.RelativeOrAbsolute);
            this.StartupUri = new Uri("TreeViewControl.xaml", UriKind.RelativeOrAbsolute);
            this.StartupUri = new Uri("ScrollViewerControl.xaml", UriKind.RelativeOrAbsolute);
            
        }
    }
}

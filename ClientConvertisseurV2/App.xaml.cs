﻿// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using ClientConvertisseurV2.ViewModels;
using ClientConvertisseurV2.Views;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientConvertisseurV2
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                .AddSingleton<ConvertisseurEuroViewModel>()
                .AddSingleton<ConvertisseurDeviseViewModel>()
                .BuildServiceProvider()
            );
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            Frame rootFrame = new Frame();
            this.m_window.Content = rootFrame;
            m_window.Activate();
            rootFrame.Navigate(typeof(ConvertisseurDevisePage));

            MainRoot = m_window.Content as FrameworkElement;
        }
        
        public static FrameworkElement MainRoot { get; private set; }

        private Window m_window;

        public ConvertisseurEuroViewModel ConvertisseurEuroVM
        {
            get { return Ioc.Default.GetService<ConvertisseurEuroViewModel>(); }
        }

        public ConvertisseurDeviseViewModel ConvertisseurDeviseVM
        {
            get { return Ioc.Default.GetService<ConvertisseurDeviseViewModel>(); }
        }
    }
}

// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;
using ClientConvertisseurV2.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Chat;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.
namespace ClientConvertisseurV2.Views
{
    /// <summary>
    /// La page qui convertit un montant en euros en un montant dans la devise sélectionnée
    /// </summary>
    public sealed partial class ConvertisseurEuroPage : Page
    {
        public ConvertisseurEuroPage()
        {
            this.InitializeComponent();
            DataContext = ((App)Application.Current).ConvertisseurEuroVM;
        }
    }
}

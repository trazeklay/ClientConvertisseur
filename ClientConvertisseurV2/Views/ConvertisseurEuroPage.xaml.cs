// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;
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
    /// La page qui convertit un montant en euros en un montant dans la devise s�lectionn�e
    /// </summary>
    public partial class ConvertisseurEuroPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public ConvertisseurEuroPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            GetDataOnLoadAsync();
        }

        private ObservableCollection<Devise> lesDevises;
        public ObservableCollection<Devise> LesDevises
        {
            get { return lesDevises; }
            set 
            { 
                lesDevises = value;
                OnPropertyChanged(nameof(LesDevises));
            }
        }

        private double montantEuros;
        public double MontantEuros
        {
            get { return montantEuros; }
            set
            {
                montantEuros = value;
                OnPropertyChanged(nameof(MontantEuros));
            }
        }

        private Devise? devise;
        public Devise? Devise
        {
            get { return devise; }
            set
            {
                devise = value;
                OnPropertyChanged(nameof(Devise));
            }
        }

        private double montantDevise;
        public double MontantDevise
        {
            get { return montantDevise; }
            set
            {
                montantDevise = value;
                OnPropertyChanged(nameof(MontantDevise));
            }
        }

        private async void GetDataOnLoadAsync()
        {
            WSService service = new WSService("https://localhost:44394/api/");
            List<Devise> result = await service.GetDevisesAsync("devises");
            if (result == null)
                MessageBoxAsync("API non disponible !", "Error !");
            else
                LesDevises = new ObservableCollection<Devise>(result);
        }

        private async void MessageBoxAsync(string content, string title)
        {
            ContentDialog dialog = new ContentDialog();
            dialog.Title = title;
            dialog.Content = content;
            dialog.CloseButtonText = "OK";


            ContentDialogResult result = await dialog.ShowAsync();
        }

        protected void onBtnConvertir_Click(object sender, RoutedEventArgs e)
        {
            MontantDevise = MontantEuros * Devise.Taux;
        }
    }
}

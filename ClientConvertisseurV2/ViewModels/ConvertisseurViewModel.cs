using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;
using CommunityToolkit.Mvvm.Input;

namespace ClientConvertisseurV2.ViewModels
{
    public abstract class ConvertisseurViewModel: ObservableObject
    {

        protected ObservableCollection<Devise> lesDevises;
        public ObservableCollection<Devise> LesDevises
        {
            get { return lesDevises; }
            set
            {
                lesDevises = value;
                OnPropertyChanged();
            }
        }

        protected double montantEuros;
        public double MontantEuros
        {
            get { return montantEuros; }
            set
            {
                montantEuros = value;
                OnPropertyChanged();
            }
        }

        protected Devise? devise;
        public Devise? Devise
        {
            get { return devise; }
            set
            {
                devise = value;
                OnPropertyChanged();
            }
        }

        protected double montantDevise;
        public double MontantDevise
        {
            get { return montantDevise; }
            set
            {
                montantDevise = value;
                OnPropertyChanged();
            }
        }

        public IRelayCommand BtnSetConversion { get; }

        public ConvertisseurViewModel()
        {
            this.GetDataOnLoadAsync();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }

        public void ActionSetConversion()
        {
            if (MontantEuros <= 0)
                MessageBoxAsync("Le montant initial doit être supérieur à 0", "Error !");
            else if (Devise is null)
                MessageBoxAsync("Veuillez sélectionner une devise", "Error !");
            else
                CalculConversion();
        }

        protected abstract void CalculConversion();

        public async void GetDataOnLoadAsync()
        {
            WSService service = new WSService("https://localhost:44394/api/");
            List<Devise> result = await service.GetDevisesAsync("devises");
            if (result == null)
                MessageBoxAsync("API non disponible !", "Error !");
            else
                LesDevises = new ObservableCollection<Devise>(result);
        }

        protected async void MessageBoxAsync(string content, string title)
        {
            ContentDialog dialog = new ContentDialog();
            dialog.XamlRoot = App.MainRoot.XamlRoot;
            dialog.Title = title;
            dialog.Content = content;
            dialog.CloseButtonText = "OK";


            ContentDialogResult result = await dialog.ShowAsync();
        }
    }
}

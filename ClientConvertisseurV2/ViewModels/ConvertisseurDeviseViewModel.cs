using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;

namespace ClientConvertisseurV2.ViewModels
{
    public class ConvertisseurDeviseViewModel : ConvertisseurViewModel
    {
        public ConvertisseurDeviseViewModel() : base() { }

        protected override void CalculConversion()
        {
            MontantEuros = MontantDevise / Devise.Taux;
        }
    }
}

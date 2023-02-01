using ClientConvertisseurV2.Models;

namespace ClientConvertisseurV2.ViewModels
{
    public class ConvertisseurDeviseViewModel : ConvertisseurViewModel
    {
        public ConvertisseurDeviseViewModel() : base() { }

        protected override void CalculConversion()
        {
            MontantDevise = MontantEuros * Devise.Taux;
        }
    }
}

using ClientConvertisseurV2.Models;

namespace ClientConvertisseurV2.ViewModels
{
    public class ConvertisseurEuroViewModel : ConvertisseurViewModel
    {
        public ConvertisseurEuroViewModel() : base() { }

        protected override void CalculConversion()
        {
            MontantEuros = MontantDevise / Devise.Taux;
        }
    }
}

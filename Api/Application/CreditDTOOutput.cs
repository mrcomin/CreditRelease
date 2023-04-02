using System.Globalization;

namespace Api.Application
{
    public class CreditDTOOutput
    {
        public string CreditStatus { get; set; } = null!;
        public string CreditTotalValueWithFees { get; set; } = null!;
        public string CreditValueFee { get; set; } = null!;

        public CreditDTOOutput(string creditStatus, double creditTotalValueWithFees, double creditValueFee)
        {
            CreditStatus = creditStatus;
            CreditTotalValueWithFees = creditTotalValueWithFees.ToString("C2", new CultureInfo("pt-BR"));
            CreditValueFee = creditValueFee.ToString("C2", new CultureInfo("pt-BR"));
        }
    }
}

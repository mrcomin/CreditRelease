using Api.Enum;

namespace Api.Application
{
    public class CreditDTOInput
    {
        public double CreditValue { get; set; }
        public ECredit CreditType { get; set; }
        public int InstallmentsQuantity { get; set; }
        public DateTime DueDate { get; set; }
    }
}

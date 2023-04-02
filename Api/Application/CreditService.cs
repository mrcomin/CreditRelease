using Api.Enum;

namespace Api.Application
{
    public class CreditService : ICreditService
    {
        public string ValidateInput(CreditDTOInput creditDTO)
        {
            if (creditDTO.CreditValue > 1_000_000)
                return "Recusado";

            if (creditDTO.InstallmentsQuantity < 5 || creditDTO.InstallmentsQuantity > 72)
                return "Recusado";

            if (creditDTO.CreditType == ECredit.Juridica && creditDTO.CreditValue < 15_000)
                return "Recusado";

            if (Math.Abs((DateTime.Now - creditDTO.DueDate).TotalDays) < 15 || Math.Abs((DateTime.Now - creditDTO.DueDate).TotalDays) > 40)
                return "Recusado";

            return "Aprovado";
        }

        public CreditDTOOutput CalculateTotalValue(CreditDTOInput creditDTO)
        {
            var valid = ValidateInput(creditDTO);
            double creditWithFee = 0;
            int tax = 0;
            double totalFee = 0;

            if(valid == "Aprovado")
            {
                if (creditDTO.CreditType == ECredit.Direto)
                    tax = 2;
                else if (creditDTO.CreditType == ECredit.Consignado)
                    tax = 1;
                else if (creditDTO.CreditType == ECredit.Juridica)
                    tax = 5;
                else if (creditDTO.CreditType == ECredit.Fisica)
                    tax = 3;
                else if (creditDTO.CreditType == ECredit.Imobiliario)
                    tax = 9;

                totalFee = CalculateFees(creditDTO.CreditValue, tax);
                creditWithFee = creditDTO.CreditValue + totalFee;
            }

            return new CreditDTOOutput(valid, creditWithFee, totalFee);
        }

        public double CalculateFees(double value, double tax)
        {
            var teste = value * (tax / 100);
            return teste;
        }
    }
}

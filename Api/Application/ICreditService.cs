namespace Api.Application
{
    public interface ICreditService
    {
        CreditDTOOutput CalculateTotalValue(CreditDTOInput creditDTO);
    }
}

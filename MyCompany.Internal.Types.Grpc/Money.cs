namespace MyCompany.Internal.Types.Grpc;

public partial class Money
{
    public Money(DecimalValue value, string currency)
    {
        Value = value;
        Currency = currency;
    }

    public static implicit operator MyCompany.Internal.Types.Money(Money grpcMoney)
    {
        var currency = Enum.Parse<Currency>(grpcMoney.Currency);
        return new(grpcMoney.Value, currency);
    }

    public static implicit operator Money(MyCompany.Internal.Types.Money money)
    {
        var currency = ((int)money.Currency).ToString();
        return new(money.Value, currency);
    }
}
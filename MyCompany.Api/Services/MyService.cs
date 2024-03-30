using Grpc.Core;
using MyCompany.Internal.Types;

namespace MyCompany.Api.Services;

public class MyService() : OrderService.OrderServiceBase
{
    public override async Task<AmountReply> GetOrderAmount(GetOrderAmountRequest request, ServerCallContext context)
    {
        await Task.Delay(1);
        return new AmountReply
        {
            Amount = new Internal.Types.Money(5, Currency.USD)
        };
    }
}

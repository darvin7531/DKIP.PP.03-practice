namespace ReviewSamples.Modules.Variants;

public class Variant12_DeliveryRequestFixed
{
    public decimal OrderSum;
    public double Km;
}

public class Variant12_DeliveryFixed
{
    private const decimal FreeDeliveryLimit = 2000;
    private const decimal BaseFee = 100;
    private const double FreeDistance = 5;
    private const decimal ExtraKmPrice = 30;
    private const decimal SmallOrderLimit = 500;
    private const decimal SmallOrderFee = 50;

    public decimal CalculateFee(Variant12_DeliveryRequestFixed request)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        if (request.OrderSum < 0)
            throw new ArgumentException("Сумма заказа не может быть отрицательной.");

        if (request.Km < 0)
            throw new ArgumentException("Расстояние не может быть отрицательным.");

        if (request.OrderSum > FreeDeliveryLimit)
            return 0;

        decimal fee = BaseFee;

        if (request.Km > FreeDistance)
            fee += (decimal)(request.Km - FreeDistance) * ExtraKmPrice;

        if (request.OrderSum < SmallOrderLimit)
            fee += SmallOrderFee;

        return fee;
    }
}

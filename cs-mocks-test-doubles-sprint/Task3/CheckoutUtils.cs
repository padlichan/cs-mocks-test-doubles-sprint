using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_mocks_test_doubles_sprint.Task3;

public class CheckoutUtils : ICheckoutUtils
{
    public decimal CalculateIndividualItem(TrolleyItem item)
    {
        return item.Price*item.Quantity;
    }

    public decimal DiscountPurchase(TrolleyItem item)
    {
        if (item.Quantity < 4) item.Price *= 0.9m;
        else item.Price *= 0.8m;
        //return item.Price*item.Quantity;
        return CalculateIndividualItem(item);
    }
    
    public void LogOfferMessage(decimal amount)
    {
        Console.WriteLine($"You've spent {amount.ToString()} and have qualified for free shipping!");
    }
}

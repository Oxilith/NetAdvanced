namespace PartOne.Exercises;

public class Guides
{
    /// <summary>
    /// Zidentyfikuj miejsca, które naruszają zasady SOLID, DRY, KISS, oraz YAGNI
    /// </summary>
    public class BadOrderProcessor
    {
        public void ProcessOrder(string orderId)
        {
            // Step 1: Validate the order
            if (string.IsNullOrEmpty(orderId))
            {
                Console.WriteLine("Order ID is invalid");
                return;
            }

            // Step 2: Get order details
            Console.WriteLine("Getting order details for order ID: " + orderId);
            // Simulate getting order details
            var orderDetails = "Details of order " + orderId;

            // Step 3: Process payment
            Console.WriteLine("Processing payment for order: " + orderId);
            // Simulate payment processing
            var paymentSuccess = true;
            if (!paymentSuccess)
            {
                Console.WriteLine("Payment failed for order: " + orderId);
                return;
            }

            // Step 4: Ship order
            Console.WriteLine("Shipping order: " + orderId);
            // Simulate shipping
            var shippingSuccess = true;
            if (!shippingSuccess)
            {
                Console.WriteLine("Shipping failed for order: " + orderId);
                return;
            }

            Console.WriteLine("Order processed successfully: " + orderId);
        }
    }

    /// <summary>
    /// Napisz poprawioną wersję klasy OrderProcessor wraz z uzasadnieniem zmian/decyzji.
    /// </summary>
    public class OrderProcessor
    {
    }
}
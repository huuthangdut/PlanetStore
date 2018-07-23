namespace Planet.Service.OrderPipeline
{
    public class PsTakePayment : IPipelineSection
    {
        public void Processor(OrderProcessor processor)
        {
            processor.CreateAudit("PsTakePayment started.", 20400);
            processor.CreateAudit("'Funds deducted from customer credit card account.", 20402);
            processor.UpdateOrderStatus(5);
            processor.ContinueNow = true;
            processor.CreateAudit("PsTakePayment finished.", 20401);
        }
    }
}

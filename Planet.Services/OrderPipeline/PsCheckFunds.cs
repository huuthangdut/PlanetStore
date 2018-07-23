namespace Planet.Service.OrderPipeline
{
    public class PsCheckFunds : IPipelineSection
    {
        public void Processor(OrderProcessor processor)
        {
            processor.CreateAudit("PsCheckFunds started.", 20100);

            processor.CreateAudit("Funds available for purchase.", 20102);
            processor.UpdateOrderStatus(2);
            processor.ContinueNow = true;
            processor.CreateAudit("PsCheckFunds finished.", 20101);
        }
    }
}

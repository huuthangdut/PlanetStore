namespace Planet.Service.OrderPipeline
{
    public class PsStockOk : IPipelineSection
    {
        public void Processor(OrderProcessor processor)
        {
            processor.CreateAudit("PsStockOk started.", 20300);
            processor.CreateAudit("Stock confirmed by supplier.", 20302);
            processor.UpdateOrderStatus(4);
            processor.ContinueNow = true;
            processor.CreateAudit("PsStockOk finished.", 20301);
        }
    }
}

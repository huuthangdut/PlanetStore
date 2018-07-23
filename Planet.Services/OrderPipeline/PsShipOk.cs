namespace Planet.Service.OrderPipeline
{
    public class PsShipOk : IPipelineSection
    {
        public void Processor(OrderProcessor processor)
        {
            processor.CreateAudit("'PsShipOk started.", 20600);
            processor.SetDateShipped();
            processor.CreateAudit("Order dispatched by supplier.", 20602);
            processor.UpdateOrderStatus(7);
            processor.ContinueNow = true;
            processor.CreateAudit("PsShipOk finished.", 20601);
        }
    }
}

namespace Planet.Service.OrderPipeline
{
    public class PsShipGood : IPipelineSection
    {
        public void Processor(OrderProcessor processor)
        {
            processor.CreateAudit("PsShipGoods started.", 20500);
            processor.CreateAudit("PsShipGoods started.", 20500);
            processor.MailSupplier("", "");
            processor.CreateAudit("Ship goods e-mail sent to supplier.", 20502);
            processor.UpdateOrderStatus(6);
            processor.CreateAudit("'PsShipGoods finished.", 20501);
        }
    }
}

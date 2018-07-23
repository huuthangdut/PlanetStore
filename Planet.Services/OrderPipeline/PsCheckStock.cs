namespace Planet.Service.OrderPipeline
{
    public class PsCheckStock : IPipelineSection
    {
        public void Processor(OrderProcessor processor)
        {
            processor.CreateAudit("PsCheckStock started.", 20200);
            processor.MailSupplier("", "");
            processor.CreateAudit("Notification email sent to supplier.", 20202);
            processor.UpdateOrderStatus(3);
            processor.CreateAudit("PsCheckStock finished.", 20201);
        }
    }
}

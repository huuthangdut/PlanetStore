namespace Planet.Service.OrderPipeline
{
    public class PsFinalNotification : IPipelineSection
    {
        public void Processor(OrderProcessor processor)
        {
            processor.CreateAudit("PsFinalNotification started.", 20700);
            processor.MailCustomer("", "");
            processor.CreateAudit("Dispatch e-mail send to customer.", 20702);
            processor.UpdateOrderStatus(8);
            processor.CreateAudit("PsFinalNotification finished.", 20701);

        }
    }
}

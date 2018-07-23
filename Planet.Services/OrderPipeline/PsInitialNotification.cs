namespace Planet.Service.OrderPipeline
{
    public class PsInitialNotification : IPipelineSection
    {
        private OrderProcessor _processor;

        public void Processor(OrderProcessor processor)
        {
            _processor = processor;
            _processor.CreateAudit("PsInitialNotification started.", 20000);
            _processor.MailCustomer("", "");
            _processor.CreateAudit("Notification e-mail sent to customer.", 20002);
            _processor.UpdateOrderStatus(1);
            _processor.ContinueNow = true;
            _processor.CreateAudit("PsInitialNotification finished.", 20001);
        }
    }
}

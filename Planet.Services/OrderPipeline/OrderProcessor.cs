using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;

namespace Planet.Service.OrderPipeline
{
    public class OrderProcessor
    {
        private readonly IAuditRepository _auditRepository;

        public Order OrderInfo { get; set; }

        public AppUser CustomerInfo { get; set; }

        public bool ContinueNow { get; set; }

        private IPipelineSection _currentPipelineSection;
        private OrderProcessor _orderProcessorStage;

        public OrderProcessor(IAuditRepository auditRepository)
        {
            _auditRepository = auditRepository;
        }

        public void Process()
        {
            this.ContinueNow = true;

            _auditRepository.Add(new Audit { OrderId = OrderInfo.Id, Message = "Order Processor started.", Code = 10000 });



        }

        private void GetCurrentPipeLineSection()
        {
            switch (OrderInfo.StatusId)
            {
                case 0:
                    this._currentPipelineSection = new PsInitialNotification();
                    break;
                case 1:
                    this._currentPipelineSection = new PsCheckFunds();
                    break;
                case 2:
                    this._currentPipelineSection = new PsCheckStock();
                    break;
                case 3:
                    this._currentPipelineSection = new PsCheckFunds();
                    break;
                case 4:
                    this._currentPipelineSection = new PsStockOk();
                    break;
                case 5:
                    this._currentPipelineSection = new PsTakePayment();
                    break;
                case 6:
                    this._currentPipelineSection = new PsShipGood();
                    break;
                case 7:
                    this._currentPipelineSection = new PsShipOk();
                    break;
                case 8:
                    this._currentPipelineSection = new PsFinalNotification();
                    break;

            }
        }

        public void CreateAudit(string message, int code)
        {

        }

        public void MailAdmin(string subject, string content)
        {

        }

        public void MailCustomer(string subject, string content)
        {

        }

        public void MailSupplier(string subject, string content)
        {

        }

        public void UpdateOrderStatus(int statusId)
        {

        }

        public void SetDateShipped()
        {

        }

    }
}

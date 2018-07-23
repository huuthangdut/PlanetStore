namespace Planet.Service.OrderPipeline
{
    public interface IPipelineSection
    {
        void Processor(OrderProcessor processor);
    }
}

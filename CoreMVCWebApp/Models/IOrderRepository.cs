namespace CoreMVCWebApp.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
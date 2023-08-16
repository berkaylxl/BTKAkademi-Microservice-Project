using BtkAkademi.OrderAPI.Models;

namespace BtkAkademi.OrderAPI.Repository
{
    public interface IRepository
    {
        Task<bool> AddOrder(OrderHeader orderHeader);
        Task UpdateOrderPaymentStatus(int orderHeaderId, bool paid);
    }
}

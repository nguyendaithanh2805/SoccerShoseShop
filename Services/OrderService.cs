using SoccerShoesShop.Common;
using SoccerShoesShop.Data;
using SoccerShoesShop.Models;
using SoccerShoesShop.Repositories;
using System.Net;

namespace SoccerShoesShop.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task AddOrderAsync(TblOrder order, int userId, OrderDetail orderDetail)
        {
            var newOrder = new TblOrder
            {
                OrderId = orderDetail.OrderId,
                PaymentMethod = order.PaymentMethod,
                UserId = userId,
                OrderDate = DateHelper.GetCurrentDate(),
                DeliveryDate = DateHelper.AddThreeDays(3),
                Status = false,
                Address = order.Address
            };
            await _orderRepository.AddAsync(newOrder);
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TblOrder>> GetAllOrderAsync()
        {
            return await _orderRepository.findAllAsync();
        }

        public async Task UpdateOrderAsync(TblOrder order, int userId)
        {
            var orderExisting = await _orderRepository.findByIdAsync(order.OrderId);
            if (orderExisting is null) throw new ArgumentNullException("Order is null");
            orderExisting.PaymentMethod = order.PaymentMethod;
            orderExisting.UserId = userId;
            orderExisting.OrderDate = DateHelper.GetCurrentDate();
            orderExisting.DeliveryDate = DateHelper.AddThreeDays(3);
            orderExisting.Status = order.Status;
            orderExisting.Address = order.Address;
            await _orderRepository.UpdateAsync(orderExisting);
        }
    }
}

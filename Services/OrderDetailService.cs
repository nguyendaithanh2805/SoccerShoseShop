using SoccerShoesShop.Areas.Admin.Models;
using SoccerShoesShop.Models;
using SoccerShoesShop.Repositories;

namespace SoccerShoesShop.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task AddOrderDetailAsync(OrderDetail orderDetail, Cart cart, int orderId)
        {
            var newOrderDetail = new OrderDetail
            {
                OrderId = orderId,
                ProductId = cart.ProductId,
                Discount = cart.Product.Discount,
                Quantity = cart.Quantity,
                TotalBill = cart.TotalBill
            };
            await _orderDetailRepository.AddAsync(newOrderDetail);
        }
    }
}

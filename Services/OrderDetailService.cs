using SoccerShoesShop.Areas.Admin.Models;
using SoccerShoesShop.Common;
using SoccerShoesShop.Models;
using SoccerShoesShop.Repositories;

namespace SoccerShoesShop.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderService _orderService;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IOrderService orderService)
        {
            _orderDetailRepository = orderDetailRepository;
            _orderService = orderService;
        }

        public async Task AddOrderDetailAsync(OrderDetail orderDetail, Cart cart, TblOrder order, int userId)
        {
            var newOrderDetail = new OrderDetail
            {
                OrderId = IdGenerator.GeneratedIdBasedOnTime(),
                ProductId = cart.ProductId,
                Discount = cart.Product.Discount,
                Quantity = cart.Quantity,
                TotalBill = cart.Product.SellingPrice * cart.Quantity
            };
            await _orderDetailRepository.AddAsync(newOrderDetail);
            await _orderService.AddOrderAsync(order, userId, newOrderDetail);
        }

        public Task DeleteOrderDetailAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDetail>> GetAllOrderDetailAsync()
        {
            throw new NotImplementedException();
        }
    }
}

using ECommercePlatform.Business.Operations.Order.Dtos;
using ECommercePlatform.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform.Business.Operations.Order
{
    public interface IOrderService
    {
        Task<ServiceMessage> AddOrder(AddOrderDto orderDto);

        Task<OrderDto> GetOrder(int id);

        Task<List<OrderDto>> GetOrders();

        Task<ServiceMessage> AdjustTotalAmount(int id, decimal changeTo);
        Task<ServiceMessage> DeleteOrder(int id);
        Task<ServiceMessage> UpdateOrder(UpdateOrderDto order);

    }
}

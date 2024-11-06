using ECommercePlatform.Business.Operations.Order.Dtos;
using ECommercePlatform.Business.Types;
using ECommercePlatform.Data.Entities;
using ECommercePlatform.Data.Repositories;
using ECommercePlatform.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform.Business.Operations.Order
{
    public class OrderManager : IOrderService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<OrderEntity> _orderRepo;
        private readonly IRepository<OrderProductEntity> _orderProductRepo;

        public OrderManager(IUnitOfWork unitOfWork, IRepository<OrderEntity> orderRepo, IRepository<OrderProductEntity> orderProductRepo)
        {
            _unitOfWork = unitOfWork;
            _orderRepo = orderRepo;
            _orderProductRepo = orderProductRepo;
        }

        public async Task<ServiceMessage> AddOrder(AddOrderDto orderDto)
        {
            var hasOrder = _orderRepo.GetAll(x => x.OrderName.ToLower() == orderDto.OrderName.ToLower()).Any();

            if (hasOrder)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Sipariş mevcut."
                };
            }

            await _unitOfWork.BeginTransactions();

            var orderEntity = new OrderEntity
            {
                OrderName = orderDto.OrderName,
                OrderDate = orderDto.OrderDate,
                TotalAmount = orderDto.TotalAmount,
            };

            _orderRepo.Add(orderEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Sipariş esnasında bir hata oluştu", ex);

            }

            foreach (var productId in orderDto.ProductId)
            {
                var orderProduct = new OrderProductEntity
                {
                    OrderId = orderEntity.Id,
                    ProductId = productId,
                };

                _orderProductRepo.Add(orderProduct);
            }
            try
            {
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactions();
            }
            catch (Exception)
            {
                await _unitOfWork.RollBackTransaction();
                throw new Exception("Sipariş eklenirken bir hata ile karşılaşıldı.");
            }
            return new ServiceMessage
            {
                IsSucceed = true,

            };

        }

        public async Task<ServiceMessage> AdjustTotalAmount(int id, decimal changeTo)
        {
            var order = _orderRepo.GetById(id);

            if (order is null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Bu id ile eşleşen sipariş bulunamadı."
                };
            }
            order.TotalAmount = changeTo;
            _orderRepo.Update(order);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                throw new Exception("Total Amount değiştirilirken bir hata oluştu");
            }
            return new ServiceMessage
            {
                IsSucceed = true,
            };
        }

        public async Task<ServiceMessage> DeleteOrder(int id)
        {
            var order = _orderRepo.GetById(id);
            if (order is null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Silinmek istenen order bulunamadı"
                };
            }

            _orderRepo.Delete(id);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                throw new Exception("Delete işlemi esnasında bir hata oluştu");
            }
            return new ServiceMessage
            {
                IsSucceed = true,
            };

        }


        public async Task<OrderDto> GetOrder(int id)
        {
            var order = await _orderRepo.GetAll(x => x.Id == id)
                                .Select(x => new OrderDto
                                {
                                    Id = x.Id,
                                    Name = x.OrderName,
                                    TotalAmount = x.TotalAmount,
                                    OrderDate = x.OrderDate,
                                    Products = x.OrderProduct.Select(o => new OrderProductDto
                                    {
                                        Id = o.Id,
                                        Name = o.Product.ProductName,

                                    }).ToList()

                                }).FirstOrDefaultAsync();

            return order;
        }

        public async Task<List<OrderDto>> GetOrders()
        {
            var orders = await _orderRepo.GetAll()
                               .Select(x => new OrderDto
                               {
                                   Id = x.Id,
                                   Name = x.OrderName,
                                   TotalAmount = x.TotalAmount,
                                   OrderDate = x.OrderDate,
                                   Products = x.OrderProduct.Select(o => new OrderProductDto
                                   {
                                       Id = o.Id,
                                       Name = o.Product.ProductName,

                                   }).ToList()

                               }).ToListAsync();

            return orders;
        }

        public async Task<ServiceMessage> UpdateOrder(UpdateOrderDto order)
        {
            var orderEntity = _orderRepo.GetById(order.Id);


            if (orderEntity is null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Sipariş bulunamadı"
                };
            }
            await _unitOfWork.BeginTransactions();

            orderEntity.OrderName = order.OrderName;
            orderEntity.TotalAmount = order.TotalAmount;
            orderEntity.OrderDate = order.OrderDate;

            _orderRepo.Update(orderEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                await _unitOfWork.RollBackTransaction();
                throw new Exception("Güncelleme işlemi esnasında bir hata oluştu", ex);
            }

            var orderProducts = _orderProductRepo.GetAll(x => x.OrderId == order.Id).ToList();
            foreach (var orderProduct in orderProducts)
            {
                _orderProductRepo.Delete(orderProduct, false);//hard delete

            }
            foreach (var productId in order.ProductIds)
            {
                var orderProduct = new OrderProductEntity
                {
                    OrderId = orderEntity.Id,
                    ProductId = productId,
                };

                _orderProductRepo.Add(orderProduct);

            }

            try
            {
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactions();
            }

            catch (Exception ex)
            {
                await _unitOfWork.RollBackTransaction();

                throw new Exception("Sipariş Bilgileri güncellenirken bir hata oluştu", ex);


            }


            return new ServiceMessage
            {
                IsSucceed = true,
            };


        }
    }
}

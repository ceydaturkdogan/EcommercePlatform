using ECommercePlatform.Business.Operations.Product.Dtos;
using ECommercePlatform.Business.Types;
using ECommercePlatform.Data.Entities;
using ECommercePlatform.Data.Repositories;
using ECommercePlatform.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform.Business.Operations.Product
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ProductEntity> _repository;
        public ProductManager(IUnitOfWork unitOfWork, IRepository<ProductEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;

        }
        public async Task<ServiceMessage> AddProduct(AddProductDto product)
        {
            var hasProduct = _repository.GetAll(x => x.ProductName.ToLower() == product.ProductName.ToLower()).Any();

            if (hasProduct)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Ürün sistemde mevcut.Ekleme yapılamaz.",

                };
            }
            var productEntity = new ProductEntity
            {
                ProductName = product.ProductName,
                StockQuantity = product.StockQuantity,
                Price = product.Price,
            };
            _repository.Add(productEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ürün ekleme sırasında bir hata oluştu");
            }

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Yeni ürün eklendi",
            };

        }
    }
}

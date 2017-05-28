using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Repositories;
using Sisacon.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Sisacon.Domain.Services
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetByUserId(int userId)
        {
            try
            {
                return _productRepository.GetByUserId(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetCount(int userId)
        {
            try
            {
                return _productRepository.GetCount(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

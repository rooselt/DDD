using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using static Sisacon.Domain.Enuns.ErrorGravity;
using static Sisacon.Domain.Enuns.OperationType;
using static Sisacon.Domain.Enuns.Sex;

namespace Sisacon.Application
{
    public class ProductAppService : AppServiceBase<Product>, IProductAppService
    {
        private readonly IProductService _productService;
        private readonly ILogAppService _logAppService;
        private readonly ICrudMsgFormater _crudMsgFormater;

        public ProductAppService(IProductService productService, ILogAppService logAppService, ICrudMsgFormater crudMsgFormatter) : base(productService)
        {
            _productService = productService;
            _logAppService = logAppService;
            _crudMsgFormater = crudMsgFormatter;
        }

        public ResponseMessage<Product> DeleteProduct(int productId)
        {
            var response = new ResponseMessage<Product>();

            try
            {
                var product = _productService.getById(productId);


                if (product != null)
                {
                    if (product.ValidatePendencesBeforeDelete())
                    {
                        _productService.delete(product);

                        response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Delete, eSex.Masculino, "Produto");
                    }
                }

                if (_productService.commit() == 0)
                {
                    response.Message = _crudMsgFormater.createErrorCrudMessage();
                }
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<Product> GetProductByUserId(int userId)
        {
            var response = new ResponseMessage<Product>();
            response.ValueList = new List<Product>();

            try
            {
                response.ValueList = _productService.GetByUserId(userId);
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<Product> SaveOrUpdate(Product product)
        {
            var response = new ResponseMessage<Product>();

            try
            {
                if (product != null)
                {
                    if (product.Id > 0)
                    {
                        _productService.update(product);

                        response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Update, eSex.Masculino, "Produto");
                    }
                    else
                    {
                        _productService.add(product);

                        response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Insert, eSex.Masculino, "Produto");
                    }

                    if (_productService.commit() == 0)
                    {
                        response.Message = _crudMsgFormater.createErrorCrudMessage();
                    }
                    else
                    {
                        response.Value = product;
                    }
                }
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }
    }
}

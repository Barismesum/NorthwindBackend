﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult("Ürün başarıyla eklendi");
        }

        public IResult Delete(Product product)
        {
           _productDal.Delete(product);
            return new SuccessResult("Ürün başarıyla silindi");
        }

        public IDataResult<Product> GetById(int productId)
        {
            
            return new SuccessDataResult<Product>(_productDal.Get(filter: p => p.ProductId == productId)) ;
        }

        public IDataResult<List<Product>> GetList()
        {
           return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList()) ;
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(filter: p => p.CategoryId == categoryId).ToList()) ;    
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult("Ürün başarıyla güncellendi");
        }
    }
}

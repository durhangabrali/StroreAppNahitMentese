﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    //Business katmanında Interface'ler Service olarak tanımlanır.
    public interface IProductService
    {
        List<Product> GetAll();
        void Add(Product product);
    }
}

using OA.Application.Bases;
using OA.Application.Features.Products.Exceptions;
using OA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Application.Features.Products.Rules
{
    public class ProductsRules:BaseRules
    {
        public Task ProductTitleMustNotBeSameException(IList<Product> products,string requestTitle)
        {
            if (products.Any(x=>x.Title == requestTitle)) throw new ProductTitleMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}

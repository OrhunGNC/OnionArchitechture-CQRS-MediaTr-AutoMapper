using OA.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Application.Features.Products.Exceptions
{
    public class ProductTitleMustNotBeSameException :BaseExceptions
    {
        public ProductTitleMustNotBeSameException():base("Product title already exists")
        {
            
        }
    }
}

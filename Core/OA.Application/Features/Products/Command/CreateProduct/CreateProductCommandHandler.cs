using MediatR;
using OA.Application.Features.Products.Rules;
using OA.Application.Interfaces.UnitOfWorks;
using OA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest,Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ProductsRules productsRules;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork,ProductsRules productsRules)
        {
            this.unitOfWork = unitOfWork;
            this.productsRules = productsRules;
        }
        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();
            await productsRules.ProductTitleMustNotBeSameException(products,request.Title);
            Product product = new(request.Title, request.Description, request.BrandId, request.Price, request.Discount);
            await unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            if(await unitOfWork.SaveAsync() > 0)
            {
                foreach(var categoryId in request.CategoryIds)
                {
                    await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId
                    });
                }
                await unitOfWork.SaveAsync();
            }
            return Unit.Value;

        }
    }
}

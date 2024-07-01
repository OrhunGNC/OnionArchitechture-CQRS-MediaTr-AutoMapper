﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandValidator :AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithName("Title");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithName("Description");
            RuleFor(x => x.BrandId)
                .GreaterThan(0)
                .WithName("Brand");
            RuleFor(x => x.Price)
                .GreaterThan(0);
            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.CategoryIds)
                .NotEmpty()
                .Must(categories => categories.Any());
        }
    }
}

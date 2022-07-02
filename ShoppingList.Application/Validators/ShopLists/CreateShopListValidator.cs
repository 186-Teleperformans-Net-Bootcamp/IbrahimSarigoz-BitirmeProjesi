using FluentValidation;
using ShoppingList.Application.ViewModels.ShopLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Validators.ShopLists
{
    public class CreateShopListValidator : AbstractValidator<VM_Create_ShopList>
    {
        public CreateShopListValidator()
        {
            RuleFor(p => p.ListName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please enter the list name correctly")
                .MaximumLength(80)
                .MinimumLength(5)
                .WithMessage("Name of the list should be 5-80 characters");

            RuleFor(p => p.IsItCompleted).NotNull().NotEmpty().WithMessage("ShopList can be completed or not");
        }


    }
}

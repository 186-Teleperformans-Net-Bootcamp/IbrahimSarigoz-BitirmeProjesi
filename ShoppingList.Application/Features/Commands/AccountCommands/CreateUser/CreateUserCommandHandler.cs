using MediatR;
using Microsoft.AspNetCore.Identity;
using ShoppingList.Application.Exceptions;
using ShoppingList.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Features.Commands.AccountCommands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly UserManager<User> _userManager;

        public CreateUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }


        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {

            IdentityResult result = await _userManager.CreateAsync(new()
            {
                NameSurname = request.NameSurname,
                UserName = request.UserName,
                Email = request.Email,
                Id = Guid.NewGuid().ToString()

            }, request.Password) ;

            if (result.Succeeded)
            {
                return new()
                {
                    Succeeded = true,
                    Message = "The User is completed successfuly"


                };
            }

            throw new UserCreateFailException();

        }
         



    }
}

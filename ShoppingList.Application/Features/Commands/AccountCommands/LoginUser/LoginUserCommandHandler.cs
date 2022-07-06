using MediatR;
using Microsoft.AspNetCore.Identity;
using ShoppingList.Application.Abstractions.Token;
using ShoppingList.Application.DTOs;
using ShoppingList.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Features.Commands.AccountCommands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {

        readonly UserManager<User> _userManager;
        readonly SignInManager<User> _signInManager;
        readonly ITokenHandler _tokenHandler;


        public LoginUserCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager, ITokenHandler tokenHandler = null)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {

           User user= await _userManager.FindByNameAsync(request.UserNameOrEmail);

            if (user ==null)
            {
                user =await  _userManager.FindByEmailAsync(request.UserNameOrEmail);

            }

            if (user == null )
            {
                throw new Exception("User Or Password is wrong");
            }


            SignInResult result =  await _signInManager.CheckPasswordSignInAsync(user, request.Password,false);


            if (result.Succeeded) //authentication successfuly done 
            { //yetki belirleyeceğim.
               Token token = _tokenHandler.CreateAccessToken();
               return new() { Token = token };
            }

            throw new Exception("User Or Password is wrong");
            
        }
    }
}

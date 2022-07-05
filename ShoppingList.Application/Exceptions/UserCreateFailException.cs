using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Exceptions
{
    public class UserCreateFailException :Exception
    {
        public UserCreateFailException() : base ("Something went wrong when you try to create a user")
        {

        }


    }
}

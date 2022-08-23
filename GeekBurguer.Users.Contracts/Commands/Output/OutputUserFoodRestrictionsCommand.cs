using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBurguer.Users.Contracts.Commands.Output
{
    public class OutputUserFoodRestrictionsCommand
    {
        public bool Processing { get; set; }
        public Guid UserId { get; set; }
    }
}

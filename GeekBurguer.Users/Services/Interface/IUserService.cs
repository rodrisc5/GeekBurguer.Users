using GeekBurguer.Users.Contracts.Commands.Input;
using GeekBurguer.Users.Contracts.Commands.Output;

namespace GeekBurguer.Users.Services.Interface
{
    public interface IUserService
    {
        public Task ReceiveMessageUser();
        public Task<OutputResponseBaseCommand<OutputUserFoodRestrictionsCommand>> SendMessageUserFoodRestriction(InputUserFoodRestrictionsCommand userFoodRestrictions);
    }
}

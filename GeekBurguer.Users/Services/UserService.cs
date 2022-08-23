using GeekBurguer.Users.Contracts.Commands.Input;
using GeekBurguer.Users.Contracts.Commands.Output;
using GeekBurguer.Users.ServiceBus;
using GeekBurguer.Users.Services.Interface;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System.Text;

namespace GeekBurguer.Users.Services
{
    public class UserService : IUserService
    {
        private IConfiguration _configuration;
        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task ReceiveMessageUser()
        {
            throw new NotImplementedException();
        }

        public async Task<OutputResponseBaseCommand<OutputUserFoodRestrictionsCommand>> SendMessageUserFoodRestriction(InputUserFoodRestrictionsCommand userFoodRestrictions)
        {
            try
            {
                ServiceBusConfigurationExtension.GetServiceBusNamespace(_configuration);
                //var message = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(userFoodRestrictions));
                //var queueClient = new QueueClient(_configuration["serviceBus:connectionString"], "UserRetrieved");

                //await queueClient.SendAsync(new Message(message));
                //await queueClient.CloseAsync();
                return new OutputResponseBaseCommand<OutputUserFoodRestrictionsCommand>()
                {
                    Data = new OutputUserFoodRestrictionsCommand() 
                    {
                        UserId = userFoodRestrictions.UserId,
                        Processing = true
                    }
                };
            }
            catch (Exception ex)
            {
                var error = new OutputResponseBaseCommand<OutputUserFoodRestrictionsCommand>();
                error.Errors.Add(ex.Message);
                return error;
            }
        }
    }
}

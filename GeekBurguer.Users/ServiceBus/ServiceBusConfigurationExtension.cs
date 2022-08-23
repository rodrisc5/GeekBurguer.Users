using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ServiceBus.Fluent;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace GeekBurguer.Users.ServiceBus
{
    public static class ServiceBusConfigurationExtension
    {
        private const string TopicName = "UserRetrieved";
        private static IConfiguration _configuration;
        private const string SubscriptionName = "Azure for Students Starter";


        public static IServiceBusNamespace GetServiceBusNamespace(this IConfiguration configuration)
        {
            var config = configuration.GetSection("serviceBus").Get<ServiceBusConfiguration>();

            var credentials = SdkContext.AzureCredentialsFactory.FromServicePrincipal(config.ClientId,config.ClientSecret,config.TenantId,AzureEnvironment.AzureGlobalCloud);

            var serviceBusNamespace = ServiceBusManager.Authenticate(credentials, config.SubscriptionId);

            return serviceBusNamespace.Namespaces.GetByResourceGroup(config.ResourceGroup, config.NamespaceName);

            _configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            var serviceBusNamespaces = _configuration.GetServiceBusNamespace();

            if (!serviceBusNamespaces.Topics.List().Any(t => t.Name.Equals(TopicName, StringComparison.InvariantCultureIgnoreCase)))
            {
                serviceBusNamespaces.Topics.Define(TopicName).WithSizeInMB(1024).Create();
            }

            var topic = serviceBusNamespaces.Topics.GetByName(TopicName);

            if (topic.Subscriptions.List().Any(subscription => subscription.Name.Equals(SubscriptionName,StringComparison.InvariantCultureIgnoreCase)))
            {
                topic.Subscriptions.DeleteByName(SubscriptionName);
            }

            topic.Subscriptions.Define(SubscriptionName).Create();

           

        }



    }
}

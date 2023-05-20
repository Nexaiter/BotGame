using Autofac;

namespace DiscordBot.Api.IoC
{
    public class DiscordBotApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.Contains("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.Contains("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}

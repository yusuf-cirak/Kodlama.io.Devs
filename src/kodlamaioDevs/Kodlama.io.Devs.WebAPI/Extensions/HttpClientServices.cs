namespace Kodlama.io.Devs.WebAPI.Extensions
{
    internal static class HttpClientServices
    {
        internal static IServiceCollection AddHttpClientServices(this IServiceCollection services)
        {
            services.AddHttpClient("GithubUserProfile", config =>
            {
                config.BaseAddress = new Uri("https://api.github.com/users/");
                config.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
            });

            return services;
        }
    }
}

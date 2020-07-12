using Gateway.API.Dto.Config;
using Gateway.Domain.Services;
using Gateway.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net.Http;

namespace Gateway.API.Extensions
{
    /// <summary>
    /// method that handles httpclient configuration
    /// </summary>
    public static class HttpExtensions
    {
        /// <summary>
        /// method that configures httpclient properties
        /// </summary>
        public static void AddUsers(this IServiceCollection services, IOptions<UsersConfig> config)
        {
            services.AddHttpClient<IUserService, UserService>(client =>
            {
                client.BaseAddress = new Uri(config.Value.Uri);
            }).AddPolicyHandler(GetRetryPolicy());
        }

        public static void AddWritter(this IServiceCollection services, IOptions<WritterConfig> config)
        {
            services.AddHttpClient<IWritterService, WritterService>(client =>
            {
                client.BaseAddress = new Uri(config.Value.Uri);
            }).AddPolicyHandler(GetRetryPolicy());
        }

        public static void AddEditor(this IServiceCollection services, IOptions<EditorConfig> config)
        {
            services.AddHttpClient<IEditorService, EditorService>(client =>
            {
                client.BaseAddress = new Uri(config.Value.Uri);
            }).AddPolicyHandler(GetRetryPolicy());
        }

        /// <summary>
        /// method that registers the service retry policy
        /// </summary>
        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
    }
}
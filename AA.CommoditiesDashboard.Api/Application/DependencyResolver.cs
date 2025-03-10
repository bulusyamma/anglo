﻿using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyResolver
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticationService, AuthenticationService>();
        }
    }
}

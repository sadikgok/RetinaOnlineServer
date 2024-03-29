﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using RetinaOnlineServer.WebApi.OptionsSetup;

namespace RetinaOnlineServer.WebApi.Configurations
{
    public class AuthenticationAndAuthorizationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureOptions<JwtOptionsSetup>();
            services.ConfigureOptions<JwtBearerOptionsSetup>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
        }
    }
}

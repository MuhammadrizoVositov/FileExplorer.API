﻿namespace FileExplorer.API.Configurations
{
    public static partial class HostConfiguration
    {
        public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
        {
            builder
                .AddMapping()
                .AddBrokers()
                .AddFileStorageInfrastructure()
                .AddDevTools()
                .AddRestExposes()
                .AddCostumers();

            return new ValueTask<WebApplicationBuilder>(builder);
        }

        public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
        {
            app.UseDevTools();
            app.MapRoutes();
            app.UseCustomCors();
            app.UseStaticFiles();

            return new ValueTask<WebApplication>(app);
        }
    }
}

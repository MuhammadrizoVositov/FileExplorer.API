using FileExplore.Aplication.FileStrorage.Broker;
using FileExplore.Aplication.FileStrorage.Models.Setting;
using FileExplore.Aplication.FileStrorage.Service;
using FileExplore.Infrastructure.FileStorage.Broker;
using FileExplore.Infrastructure.FileStorage.Service;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FileExplorer.API.Configurations
{
    public static partial class HostConfiguration
    {
        private static WebApplicationBuilder AddMapping(this WebApplicationBuilder builder)
        {
            var assambles = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
            
            assambles.Add(Assembly.GetExecutingAssembly());

            builder.Services.AddAutoMapper(assambles);

            return builder;
        }
        private static WebApplicationBuilder AddBrokers(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddSingleton<IDirectoryBroker,DirectoryBroker>()
                .AddSingleton<IDriveBroker, DriveBroker>()
                .AddSingleton<IFileBroker, FileBroker>();
            return builder;
        }
        private static WebApplicationBuilder AddFileStorageInfrastructure(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<FileFilterSettings>(builder.Configuration.GetSection(nameof(FileFilterSettings)));
            builder.Services.Configure<FileStorageSettings>(builder.Configuration.GetSection(nameof(FileStorageSettings)));

            builder
            .Services
                .AddSingleton<IDriveService, DriveService>()
                .AddSingleton<IDirectoryService, DirectoryService>()
                .AddSingleton<IFileService, FileService>();
            builder
            .Services
                .AddSingleton<IDirectoryProcessingService, DirectoryProcessingService>()
                .AddSingleton<IFileProcessingService, FileProcessingService>();

            return builder;
        }
        private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder) 
        {
            builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();
            return builder;
        }
        private static WebApplicationBuilder AddRestExposes(this WebApplicationBuilder builder) 
        {
            builder.Services.AddControllers().AddNewtonsoftJson();
            builder.Services.AddRouting(option => option.LowercaseUrls = true);
         return builder;
        }
        private static WebApplicationBuilder AddCostumers(this WebApplicationBuilder builder) 
        {
            builder.Services.AddCors(option =>
            {
                option.AddPolicy("CorePlocy", policyBuilder => { policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
            });
            return builder;
        }
        private static WebApplication UseDevTools(this WebApplication app)
        {
            app.UseSwagger().UseSwaggerUI();

            return app;
        }
        private static WebApplication UseCustomCors(this WebApplication app)
        {
            app.UseCors("CorsPolicy");

            return app;
        }

        private static WebApplication MapRoutes(this WebApplication app)
        {
            app.MapControllers();

            return app;
        }

        private static WebApplication UseFileStorage(this WebApplication app)
        {
            app.UseStaticFiles();

            return app;
        }

    }
   
}

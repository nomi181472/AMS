using AttendanceService.Common;
using System.Net.Mime;
using System.Text.Json;
using Logger;
using Microsoft.OpenApi.Models;
using AttendanceService.Common.Constant;
namespace AttendanceService
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCompleteDIs( this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddControllersDI()
                .AddBusinessLayer(configuration)
                .AddHelpers(configuration)
                .AddSwaggerDI(configuration, KConstant.ApiName);
                
            return services;
        }
        public static IServiceCollection AddHelpers( this IServiceCollection services, IConfiguration configuration)
        {

            services
                .AddCustomLogger(configuration);
                
            return services;
        }
        public static IServiceCollection AddControllersDI(this IServiceCollection services)
        {
            services.AddControllers(
                o =>
                {
                   // o.Filters.Add(typeof(AuthorizeAccessAndSecretKey));

                }
                )

            .ConfigureApiBehaviorOptions(o =>
            {

                o.InvalidModelStateResponseFactory = context =>
                {
                    var result = new ApiResult(context.ModelState);

                    result.ContentTypes.Add(MediaTypeNames.Application.Json);
                    result.ContentTypes.Add(MediaTypeNames.Application.Xml);
                    return result;

                };
            })

            .AddJsonOptions(
            options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy =
                    JsonNamingPolicy.CamelCase;
            });
            return services;
        }
        public static IServiceCollection AddSwaggerDI(this IServiceCollection services, IConfiguration configuration, string pTitle)
        {


            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = pTitle,
                    Version = "v1",
                });
                /* x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                 {
                     Name = "Authorization",
                     Type = SecuritySchemeType.ApiKey,
                     Scheme = "Bearer",
                     BearerFormat = "JWT",
                     In = ParameterLocation.Header,
                     Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                 });
                 x.AddSecurityRequirement(new OpenApiSecurityRequirement()
             {
                     {
                     new OpenApiSecurityScheme()
                     {
                         Reference=new OpenApiReference()
                         {
                             Type=ReferenceType.SecurityScheme,
                             Id="Bearer"
                         }
                     },
                     new string[]{}
                     }
             });*/

                x.EnableAnnotations();
               // x.OperationFilter<AddHeaderOperationFilter>();
            });

           

            return services;
        }
    }
}

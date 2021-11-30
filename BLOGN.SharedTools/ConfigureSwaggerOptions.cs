using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.SharedTools
{
     public class ConfigureSwaggerOptions:IConfigureOptions<SwaggerGenOptions>
     {
        
          public void Configure(SwaggerGenOptions options)
          {
              


               options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
               {
                    Description =
                  "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
                  "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
                  "Example: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
               });

               options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });


               var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
               var cmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);
               options.IncludeXmlComments(cmlCommentsFullPath);
          }
     }
}

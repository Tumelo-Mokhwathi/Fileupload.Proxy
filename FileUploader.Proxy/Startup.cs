using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileUploader.Proxy.Configuration;
using FileUploader.Proxy.Models;
using FileUploader.Proxy.Services;
using FileUploader.Proxy.Services.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FileUploader.Proxy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(option => {
                option.AddPolicy(OriginKey.specificOriginKey, builder =>
                {
                    var origin = Configuration["FileUploaderApplication:FileUploaderOrigin"];
                    builder.AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials()
                           .WithOrigins(origin);
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<FileUploaderContext>(option => option.UseSqlServer(Configuration.GetConnectionString("FileUploaderConnection")));
            services.AddScoped<IImageFileService, ImageFileService>();
            services.AddScoped<IDocumentFileService, DocumentFileService>();
            services.AddScoped<IOtherFileService, OtherFileService>();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(OriginKey.specificOriginKey);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

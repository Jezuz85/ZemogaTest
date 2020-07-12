namespace Editor.API
{
    using AutoMapper;
    using Facade.Implementations;
    using Facade.Interfaces;
    using Middlewares;
    using Domain.Repositories;
    using Domain.Services;
    using Infrastructure;
    using Infrastructure.Repositories;
    using Infrastructure.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using System;
    using System.IO;
    using System.Reflection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAutoMapper(typeof(Startup));

            //Database
            services.AddDbContext<EditorContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Swagger
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("V1", new OpenApiInfo
                {
                    Title = "Microservices Editor",
                    Version = "V1",
                    Description = "Este es el Api Microservices para el proyecto de Jesus Garcia"
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);
            });

            //DI
            services.AddScoped<IEditorService, EditorService>();
            services.AddScoped<IEditorFacade, EditorFacade>();
            services.AddScoped<IEditorRepository, EditorRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/V1/swagger.json", "Microservices EDITOR");
                x.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
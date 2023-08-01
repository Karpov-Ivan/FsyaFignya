using System;
using AutoMapper;
using System.Reflection;
using FsyaFignya.Mapper;
using FsyaFignya.DataBase;
using Microsoft.OpenApi.Models;
using FsyaFignya.DataBase.Mapper;
using Microsoft.EntityFrameworkCore;
using FsyaFignya.Interfaces.Repository;
using FsyaFignya.Adapter.Implementations;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace VsyaFignya
{
    public class Startup
    {
        private readonly string _corsPolicy = "FsyaFignyaBmstu";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("FsyaFignyaDB");
            services.AddDbContext<Context>(options =>
                options.UseNpgsql(connectionString)
            );
            services.AddMvc();

            services.AddTransient<IRepository, Repository>();
            services.AddTransient<MapperDto>();

            services.AddControllers();
            services.AddHealthChecks();

            services.AddCors(o => o.AddPolicy(_corsPolicy, builder =>
            {
                builder.AllowAnyOrigin();
            }));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "FsyaFignya", Version = "v1" });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            });

            services.AddLogging();
            services.AddAutoMapper(c => c.AddProfile<MappingDatabaseProfile>(), typeof(Startup));
            services.AddAutoMapper(c => c.AddProfile<MapperDto>(), typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "FsyaFignya backend v1"));
            }

            app.UseCors(_corsPolicy);
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
                endpoints.MapControllers();
            });
        }
    }
}
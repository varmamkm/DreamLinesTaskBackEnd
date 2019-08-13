using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DL.API.Middleware;
using DL.DataAccess;
using DL.Entities;
using DL.Infrastructure.Repository;
using DL.Infrastructure.Service;
using DL.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapperConfiguration = AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace DL.API
{
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            RegisterMapping();
            //services.AddDbContext<CruiseContext>(options => 
            //    options.UseNpgsql(Configuration.GetConnectionString("localdb"), b => b.MigrationsAssembly("DL.DataAccess")));
            services.AddDbContext<DataContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("localdb")));

            services.AddScoped<IDataBaseInitializer, DataBaseInitializer>();
            services.AddTransient<ICruiseService, CruiseService<Company>>();
            services.AddTransient<ICruiseRepository<Company>, CruiseRepository>();
            services.ConfigureSwagger();
            services.AddMvcCore().AddDataAnnotations();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IDataBaseInitializer dataBaseInitializer)
        {
            if (dataBaseInitializer != null)
            {
                dataBaseInitializer.Initialize();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("CorsPolicy");
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseConfiguredSwagger();
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void RegisterMapping()
        {
            var config = new AutoMapperConfiguration.MapperConfigurationExpression();
            config.ForAllMaps(IgnoreUnmappedProperties);
            AutoMapper.Mapper.Initialize(config);
        }

        private static void IgnoreUnmappedProperties(TypeMap map, IMappingExpression expr)
        {
            foreach (string propName in map.GetUnmappedPropertyNames())
            {
                if (map.DestinationType.GetProperty(propName) != null)
                {
                    expr.ForMember(propName, opt => opt.Ignore());
                }
            }
        }
    }
}

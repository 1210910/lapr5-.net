using System;
using DDDNetCore.Domain.TaskRequests.domain;
using DDDNetCore.Domain.TaskRequests.dto.mappers;
using DDDNetCore.Domain.TaskRequests.persistence;
using DDDNetCore.Domain.TaskRequests.service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using DDDSample1.Infrastructure;
using DDDSample1.Infrastructure.Shared;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Tasks;
using DDDSample1.Infrastructure.TaskRequests.Repos;
using DDDSample1.Infrastructure.Tasks.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


namespace DDDSample1
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
            services.AddDbContext<DDDSample1DbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SqlServerCs"))
                    .ReplaceService<IValueConverterSelector, StronglyEntityIdValueConverterSelector>());

            ConfigureMyServices(services);
            
            services.AddControllers().AddNewtonsoftJson();
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy("taskPolicy", policy =>
                {
                    policy.RequireClaim("role", "Task manager");
                });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseAuthentication();
        }
    
        public void ConfigureMyServices(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork,UnitOfWork>();
            
            services.AddAutoMapper(typeof(MappingProfile));
            // add domain services here
            services.AddTransient<ITaskRequestRepository, TaskRequestRepository>();
            services.AddTransient<TaskRequestService>();
            
            services.AddTransient<IDeliveryTaskRequestRepository, DeliveryTaskRequestRepository>();
            services.AddTransient<DeliveryTaskRequestService>();
 
        
            services.AddTransient<IVigilanceTaskRequestRepository, VigilanceTaskRequestRepository>();
            services.AddTransient<VigilanceTaskRequestService>();
            
           
            services.AddTransient<IVigilanceTaskRepository, VigilanceTaskRepository>();
            services.AddTransient<VigilanceTaskService>();
            
          
            services.AddTransient<IDeliveryTaskRepository, DeliveryTaskRepository>();
            services.AddTransient<DeliveryTaskService>();
            
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://dev-3hnosuh6oycbgons.us.auth0.com/";
                    options.Audience = "Sk0nEcUzFPLnFEdOx9QxkwEMNZ4yZP3N";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.Zero,
                    };
                });
            
            
        }
        
    }
}

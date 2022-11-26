using Core.Domain;
using Core.Repository;
using Core.Service;
using Infra.Domain;
using Infra.Repository;
using Infra.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace SnapChat
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
            services.AddCors(corsOptions =>

            {

                corsOptions.AddPolicy("policy",

                builder =>

                {

                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

                });

            });


            services.AddScoped<IDBContext, DBContext>();
            services.AddScoped<Imessage_snapchatrepository, message_snapchatrepository>();

            services.AddScoped<IOrder_Repository, Order_Repository>();
            services.AddScoped<IService_Repository, Service_Repository>();
            services.AddScoped<IOrderService_Repository, OrderService_Repository>();

            services.AddScoped<IOrder_service, Order_Service>();
            services.AddScoped<IOrderService_service, OrderService_service>();
            services.AddScoped<ISERVICE_service, SERVICE_service>();

            services.AddScoped<Ifollow_snapchatrepository, follow_snapchatrepository>();
            services.AddScoped<Imessage_snapchatservice, message_snapchatservice>();
            services.AddScoped<Ifollow_snapchatservice, follow_snapchatservice>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILoginServce, LoginSvice>();

            services.AddScoped<IReportSerivce, ReportService>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();

            services.AddScoped<IVisaRepository, VisaRepository>();
            services.AddScoped<IViewersRepository, ViewersRepository>();
            services.AddScoped<IStoryRepository, StoryRepository>();

            services.AddScoped<IVisaService, VisaService>();
            services.AddScoped<IViewersService, ViewersService>();
            services.AddScoped<IStoryService, StoryService>();

            services.AddScoped<Itestimonial_repository, testimonial_repository>();
            services.AddScoped<Itestimonial_service, testimonial_service>();

            services.AddScoped<Icreateregister_repository, createregister_repository>();
            services.AddScoped<Icreateregister_service, createregister_service>();

            services.AddScoped<Ihomepage_repository, homepage_repository>();
            services.AddScoped<Ihomepage_service, homepage_service>();

            services.AddScoped<AboutUs_Repository, AboutUs_Repo>();
            services.AddScoped<IAbout_Service, About_Service>();

            services.AddScoped<Isponsored_repository, sponsored_repository>();
            services.AddScoped<Isponsored_service, sponsored_service>();



            services.AddScoped<IContactusRepository, ContactusRepository>();
            services.AddScoped<IMsgContactusRepository, MsgContactusRepository>();
            services.AddScoped<IContactusService, ContactusService>();
            services.AddScoped<IMsgContactusService, MsgContactusService>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }

         ).AddJwtBearer(y =>
         {
             y.RequireHttpsMetadata = false;
             y.SaveToken = true;
             y.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidateIssuerSigningKey = true,
                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]")),
                 ValidateIssuer = false,
                 ValidateAudience = false,

             };


         });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("policy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

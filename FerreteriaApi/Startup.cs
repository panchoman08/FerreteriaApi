using FerreteriaApi.Models;
using FerreteriaApi.Repository.AuthenticateRepositories;
using FerreteriaApi.Repository.BuyDetailRepositories;
using FerreteriaApi.Repository.BuyRepositories;
using FerreteriaApi.Repository.CellarRepositories;
using FerreteriaApi.Repository.CellarTransferDetRepositories;
using FerreteriaApi.Repository.CellarTransferRepositories;
using FerreteriaApi.Repository.CustomerCatRepositories;
using FerreteriaApi.Repository.CustomerRepositories;
using FerreteriaApi.Repository.InventoryRepositories;
using FerreteriaApi.Repository.ProductCatRepositories;
using FerreteriaApi.Repository.ProductMeasureRepositories;
using FerreteriaApi.Repository.ProductRepositories;
using FerreteriaApi.Repository.ProductStatusRepositories;
using FerreteriaApi.Repository.SupplierCatRepositories;
using FerreteriaApi.Repository.SupplierRepositories;
using FerreteriaApi.Repository.TransactionStatusRepositories;
using FerreteriaApi.Services.TokenGenerators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaApi
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
            services.AddControllers();
            services.AddDbContext<ferreteria_dbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("FerreteriaDB"));
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddResponseCaching();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => 
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        //ValidIssuer = Configuration["Jwt:Issuer"],
                        //ValidAudience =  Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
            services.AddMvc();
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<AccessTokenGenerator>();
            //services.AddTransient(Configuration.);
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductCatRepository, ProductCatRepository>();
            services.AddTransient<IProductStatusRepository, ProductStatusRepository>();
            services.AddTransient<IProductMeasureRepository, ProductMeasureRepository>();
            services.AddTransient<ISupplierCatRepository, SupplierCatRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<ICustomerCatRepository, CustomerCatRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IBuyRepository, BuyRepository>();
            services.AddTransient<IBuyDetailRepository, BuyDetailRepository>();
            services.AddTransient<ITransactionStatusRepository, TransactionStatusRepository>();
            services.AddTransient<ICellarRepository, CellarRepository>();
            services.AddTransient<ICellarTransferRepository, CellarTransferRepository>();
            services.AddTransient<ICellarTransferDetRepository, CellarTransferDetRepository>();
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<Repository.AuthenticateRepositories.IAuthenticateRepository, AuthenticateRepository>();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseResponseCaching();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}

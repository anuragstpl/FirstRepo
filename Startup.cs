using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsApi.Contexts;
using ContactsApi.Models;
using ContactsApi.Repository;
using ContactsApi.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


namespace ContactsApi
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

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "My First API", Version = "V1" }));

            services.AddScoped<IContactsRepository, ContactsRepository>();

            services.AddDbContext<ContactsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ContactConnectionString")));

            services.AddCors();

            services.AddSession(options => { options.IdleTimeout = TimeSpan.FromMinutes(60); });

            services.AddSingleton<IValidator<Contacts>, ContactsValidator>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddFluentValidation();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(p => p.ErrorMessage)).ToList();
                    var result = new
                    {
                        Code = "911",
                        Message = "Validation Errors",
                        Errors = errors
                    };
                    return new BadRequestObjectResult(result);
                };
            });

            //var secretKey = Encoding.ASCII.GetBytes("XYZ");

            //services.AddAuthentication(auth =>
            //{
            //    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(token =>
            //{
            //    token.RequireHttpsMetadata = false;
            //    token.SaveToken = true;
            //    token.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        RequireExpirationTime = true,
            //        ValidateLifetime = true,
            //        ClockSkew = TimeSpan.Zero
            //    };
            //});


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "My API version 1");
            });

            app.UseCors("AllowMyOrigin");

            app.UseSession();

            //app.Use(async (context, next) =>
            //{

            //    var JWtoken = context.Session.GetString("JWToken");
            //    if (!string.IsNullOrEmpty(JWtoken))
            //    {
            //        context.Request.Headers.Add("Authorization", "Bearer" + JWtoken);
            //    }
            //    await next();
            //});

            app.UseAuthentication();
        }
    }
}

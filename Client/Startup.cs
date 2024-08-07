using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Client.EmailServices;
using Client.Identity;
using Data.Abstract;
using Data.Concrete.EFCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace ShopApp
{
  public class Startup
  {
    private IConfiguration _configuration;
    public Startup(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddDbContext<ApplicationContext>(options => options.UseSqlite("Data Source=shopDB"));
      services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

      services.Configure<IdentityOptions>(options =>
      {
        //pasword
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = true;

        //lockout
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        options.Lockout.AllowedForNewUsers = true;

        // options.User.AllowedUserNameCharacters = ""
        options.User.RequireUniqueEmail = true;
        options.SignIn.RequireConfirmedEmail = true;
        options.SignIn.RequireConfirmedPhoneNumber = false;

      });
      services.ConfigureApplicationCookie(options =>
      {
        options.LoginPath = "/account/login";
        options.LogoutPath = "/account/logout";
        options.AccessDeniedPath = "/account/accessdenied";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.Cookie = new CookieBuilder
        {
          HttpOnly = true,
          Name = ".ShoppApp.Security.Cookie",
          SameSite = SameSiteMode.Strict
        };

      });
      services.AddScoped<IProductRepository, EFCoreProductRepository>();
      services.AddScoped<ICategoryRepository, EFCoreCategoryRepository>();
      services.AddScoped<ICartRepository, EFCoreCartRepository>();

      services.AddScoped<IProductService, ProductManager>();
      services.AddScoped<ICategoryService, CategoryManager>();
      services.AddScoped<ICartService, CartManager>();
      services.AddScoped<IEmailSender, EmailSender>(i =>
      new EmailSender(
          _configuration["EmailSender:Host"],
          _configuration.GetValue<int>("EmailSender:Port"),
          _configuration.GetValue<bool>("EmailSender:EnabledSSL"),
          _configuration["EmailSender:Username"],
          _configuration["EmailSender:Password"]
          ));
      services.AddControllersWithViews();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
    {
      app.UseStaticFiles();
      app.UseStaticFiles(new StaticFileOptions
      {
        FileProvider = new PhysicalFileProvider(
              Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
        RequestPath = "/modules"
      });
      if (env.IsDevelopment())
      {
        SeedDatabase.Seed();
        app.UseDeveloperExceptionPage();
      }
      app.UseAuthentication();
      app.UseRouting();
      app.UseAuthorization();


      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                         name: "cart",
                         pattern: "cart",
                         defaults: new { controller = "Cart", action = "Index" }
                     );

        endpoints.MapControllerRoute(
                                  name: "adminuserdelete",
                                  pattern: "admin/user/delete/{id?}",
                                  defaults: new { controller = "admin", action = "deleteuser" }
                              );
        endpoints.MapControllerRoute(
                          name: "adminuseredit",
                          pattern: "admin/user/{id?}",
                          defaults: new { controller = "admin", action = "edituser" }
                      );

        endpoints.MapControllerRoute(
                          name: "adminusers",
                          pattern: "admin/user/list",
                          defaults: new { controller = "admin", action = "userlist" }
                      );

        endpoints.MapControllerRoute(
                  name: "adminroles",
                  pattern: "admin/role/list",
                  defaults: new { controller = "admin", action = "rolelist" }
              );

        endpoints.MapControllerRoute(
                  name: "adminrolecreate",
                  pattern: "admin/role/create",
                  defaults: new { controller = "admin", action = "createrole" }
              );
        endpoints.MapControllerRoute(
                  name: "adminroleedit",
                  pattern: "admin/role/{id?}",
                  defaults: new { controller = "admin", action = "editrole" }
              );
        endpoints.MapControllerRoute(
                  name: "admincategorylist",
                  pattern: "admin/categories",
                  defaults: new { controller = "admin", action = "categorylist" }
              );
        endpoints.MapControllerRoute(
                 name: "admineditcategory",
                 pattern: "admin/categories/{id?}",
                 defaults: new { controller = "admin", action = "editcategory" }
              );
        endpoints.MapControllerRoute(
                name: "admincreatecategory",
                pattern: "admin/category/create",
                defaults: new { controller = "admin", action = "createcategory" }
              );
        endpoints.MapControllerRoute(
                name: "adminproductlist",
                pattern: "admin/products",
                defaults: new { controller = "admin", action = "productlist" }
              );
        endpoints.MapControllerRoute(
                name: "admineditprocut",
                pattern: "admin/products/{id?}",
                defaults: new { controller = "admin", action = "editproduct" }
              );
        endpoints.MapControllerRoute(
                name: "admincreateproduct",
                pattern: "admin/product/create",
                defaults: new { controller = "admin", action = "createproduct" }
              );
        endpoints.MapControllerRoute(
                name: "search",
                pattern: "search",
                defaults: new { controller = "shop", action = "search" }
              );
        endpoints.MapControllerRoute(
                name: "productdetails",
                pattern: "product/{url}",
                defaults: new { controller = "shop", action = "details" }
              );
        endpoints.MapControllerRoute(
                name: "products",
                pattern: "products/{category?}",
                defaults: new { controller = "shop", action = "list" }
              );
        endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
              );
      });
      SeedIdentity.Seed(userManager, roleManager, configuration).Wait();
    }
  }
}

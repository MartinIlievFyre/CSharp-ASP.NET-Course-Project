namespace GymApp
{
    using Microsoft.EntityFrameworkCore;

    using GymApp.Data;
    using GymApp.Data.Models;
    using GymApp.Services.Data;
    using GymApp.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Identity;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<GymAppDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;

                options.Password.RequireNonAlphanumeric = false;

                options.Password.RequireLowercase = false;

                options.Password.RequireUppercase = false;

                options.Password.RequireDigit = false;

                options.Password.RequiredLength = 3;
            })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<GymAppDbContext>();

            builder.Services.AddScoped<IAccessoryService, AccessoryService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IFoodService, FoodService>();
            builder.Services.AddScoped<IExerciseService, ExerciseService>();
            builder.Services.AddScoped<ITrainingPlanService, TrainingPlanService>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<ISupplementService, SupplementService>();
            builder.Services.AddScoped<IWearService, WearService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IOrderService, OrderService>();


            builder.Services.AddControllersWithViews();

            var app = builder.Build();
           

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            app.Run();
        }
    }
}
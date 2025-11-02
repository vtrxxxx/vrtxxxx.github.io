using AspNetCoreHero.ToastNotification.Abstractions;
using HW12.Modules;
using HW12.Data;
using HW12.Middleware;
using AspNetCoreHero.ToastNotification;



namespace HW12
{
    public class Program
    {
        const int error404 = 404;
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddLogging();
            builder.Services.AddCore(builder.Configuration);
            builder.Services.AddScoped<ErrorHandlingMiddleware>();
            builder.Services.AddNotyf(config => { config.DurationInSeconds = 5; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });

            var app = builder.Build();

            app.UseMiddleware<ErrorHandlingMiddleware>();
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == error404)
                {
                    context.Request.Path = "/PageNotFound";
                    await next();
                }
            });


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Movie}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

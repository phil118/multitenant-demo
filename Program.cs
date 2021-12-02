using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Rewrite;
using MultiTenant.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.UseUrls("http://*.infinify.dev:5003");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMultiTenant<TenantViewModel>()
            .WithHostStrategy()
            .WithConfigurationStore();

builder.Services.AddRouting(x => { 
    x.LowercaseUrls = true;
    x.AppendTrailingSlash = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var rewrite = new RewriteOptions().AddRewrite("(.*)/$","$1", false);
app.UseRewriter(rewrite);

app.UseStaticFiles();
app.UseRouting();
app.UseMultiTenant();

app.UseEndpoints(endpoints => {
    //endpoints.MapControllers();
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();

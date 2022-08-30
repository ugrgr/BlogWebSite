
using BlogWebSite.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

//builder.Services.AddScoped<IBlogRepository, BlogRepository>();

//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//builder.Services.AddScoped<NotFoundFilter>();



//builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));

builder.Services.AddHttpClient<IBlogService, BlogService>(options =>
{
    options.BaseAddress = new Uri(builder.Configuration["WebApi:BaseUrl"]);
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.ServiceProcess;
//using System.Text;
//using System.Threading.Tasks;

//namespace MauiSignalR.Server
//{
//    internal static class Program
//    {
//        /// <summary>
//        /// The main entry point for the application.
//        /// </summary>
//        static void Main()
//        {
//            ServiceBase[] ServicesToRun;
//            ServicesToRun = new ServiceBase[]
//            {
//                new Service1()
//            };
//            ServiceBase.Run(ServicesToRun);
//        }
//    }
//}


using MauiSignalR.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Gerald: Enable SignalR functionality
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    // Gerald: Make sure to disable this for development!
    app.UseHttpsRedirection();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// Gerald: Configure SignalR Endpoint
app.MapHub<ChatHub>("/chat");

app.Run();
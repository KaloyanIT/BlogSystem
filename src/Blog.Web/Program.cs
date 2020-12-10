using Blog.Web;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

static void Main(string[] args)
    => CreateWebHostBuilder(args).Build().Run();


static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>();


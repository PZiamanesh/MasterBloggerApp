using MB.Infrastructure.IOC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

BootsTrapper.ConfigureService
    (builder.Services, builder.Configuration.GetConnectionString("MasterBloggerDb"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

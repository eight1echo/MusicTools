using MudBlazor.Services;
using MusicTools.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAzureServices();
builder.Services.AddDataSources();
builder.Services.AddFeatures();
builder.Services.AddMudServices();
builder.Services.AddRazorPages();
builder.Services.AddSecurityServices();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

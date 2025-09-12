using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Tilføj services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Tilføj dine egne services her
builder.Services.AddSingleton<DialogManager>();

var app = builder.Build();

// Brug standard opsætning for Blazor Server
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();           // <--- server side SignalR-hub
app.MapFallbackToPage("/_Host");  // <--- vigtig!

app.Run();

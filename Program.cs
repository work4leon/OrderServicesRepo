using Microsoft.EntityFrameworkCore;
using OrderService;
using OrderService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrderDbContext>(
        o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(OrdersMarker).Assembly));
builder.Services.AddScoped(typeof(OrderRepository));
//builder.Services.AddScoped(typeof(OrderReadRepository<Order>));
//builder.Services.AddScoped<IReadRepository<Order>, ReadRepository<Order>>();
builder.Services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<OrderDbContext>();
    if ("Development".Equals(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")))
    {
        context.Database.EnsureCreated();
    }

}
app.Run();

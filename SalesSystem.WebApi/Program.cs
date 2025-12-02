using SalesSystem.WebApi.Queries.ObterListaClientes;
using SalesSystem.WebApi.Queries.ObterListaProdutos;
using SalesSystem.WebApi.Repositories;
using SalesSystem.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IClienteRepository>(provider =>
//    new ClienteRepository(builder.Configuration.GetConnectionString("connect")));

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(ObterListaClientesQuery).Assembly);
    //config.RegisterServicesFromAssembly(typeof(ObterListaProdutosQuery).Assembly);
});

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

app.Run();

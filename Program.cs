using AutoMapper;
using BeerapiNet7._0;
using BeerapiNet7._0.DTO;
using BeerapiNet7._0.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("StringConnection");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BeerDbContext>(opt => opt.UseSqlServer(connectionString));

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<AutoMapperProfile>();
});

var mapper = config.CreateMapper();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/beers", async (BeerDbContext context) =>
{

    var BeerDto = await ApiUtilities.GetEntityAsync<BeerDTO, Beer>(context, mapper);
    return Results.Ok(BeerDto);
});


app.MapPost("/beers", async (BeerDTO beerDTO, BeerDbContext context) =>
{
    var beerMap = mapper.Map<Beer>(beerDTO);
    var createdBeer = await ApiUtilities.CreatedEntityAsync<Beer>(beerMap, context);
    return Results.Created($"/beersitems/{createdBeer.Id}", createdBeer);

});


app.MapGet("/countries", async (BeerDbContext context) =>
{
    var countryDto = await ApiUtilities.GetEntityAsync<CountryDTO, Country>(context, mapper);
    return Results.Ok(countryDto);
});

app.MapPost("/country", async (CountryDTO countryDTO, BeerDbContext context) =>
{
    var countryMap = mapper.Map<Country>(countryDTO);
    var createdCountry = await ApiUtilities.CreatedEntityAsync<Country>(countryMap, context);
    return Results.Created($"country/{createdCountry.Id}", createdCountry);

});


app.MapGet("/typebeers", async (BeerDbContext context) => 
{    
    var countryDto = await ApiUtilities.GetEntityAsync<TypeBeerDTO, TypeBeer>(context, mapper); 
    return Results.Ok(countryDto);
});

app.MapPost("/typebeer", async (TypeBeer type, BeerDbContext context) =>
{

    var createdType = await ApiUtilities.CreatedEntityAsync<TypeBeer>(type, context);
    return Results.Created($"type/{createdType.Id}", createdType);

});


app.MapGet("/companies", async (BeerDbContext context) => 
{ 
    var countryDto = await ApiUtilities.GetEntityAsync<CompanyDTO, Company>(context, mapper); 
    return Results.Ok(countryDto);
});

app.MapPost("/companies", async (Company company, BeerDbContext context) =>
{

    var createdCountry = await ApiUtilities.CreatedEntityAsync<Company>(company, context);
    return Results.Created($"type/{createdCountry.Id}", createdCountry);

});


app.Run();


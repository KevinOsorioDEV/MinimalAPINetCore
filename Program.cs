using AutoMapper;
using BeerapiNet7._0;
using BeerapiNet7._0.DTO;
using BeerapiNet7._0.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BeerDbContext>();

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

    var BeerDto = await ApiUtilities.GetEntityAsync<BeerDTO, Beer>(context,mapper);
    return Results.Ok(BeerDto);
    //var beers =  await context.Beers.ToListAsync();
    //var beersDto = mapper.Map<List<BeerDTO>>(beers);
    //return Results.Ok(beersDto);
});

app.MapPost("/beers", async (BeerDTO beerDTO, BeerDbContext context) =>
{
    var beerMap = mapper.Map<Beer>(beerDTO);
    var createdBeer = await ApiUtilities.CreatedEntityAsync<Beer>(beerMap, context);
    return Results.Created($"/beersitems/{createdBeer.Id}", createdBeer);

});


//app.MapGet("/countries", async (BeerDbContext context) => await ApiUtilities.GetEntityAsync<Country>(context));

app.MapPost("/country", async (CountryDTO countryDTO, BeerDbContext context) =>
{
    var countryMap = mapper.Map<Country>(countryDTO);
    var createdCountry = await ApiUtilities.CreatedEntityAsync<Country>(countryMap, context);
    return Results.Created($"country/{createdCountry.Id}",createdCountry);

});


//app.MapGet("/typebeers", async (BeerDbContext context) => await ApiUtilities.GetEntityAsync<TypeBeer>(context));

app.MapPost("/typebeer", async (TypeBeer type, BeerDbContext context) =>
{

    var createdType = await ApiUtilities.CreatedEntityAsync<TypeBeer>(type, context);
    return Results.Created($"type/{createdType.Id}", createdType);

});


//app.MapGet("/companies", async(BeerDbContext context) => await ApiUtilities.GetEntityAsync<Company>(context));

app.MapPost("/companies", async (Company company, BeerDbContext context) =>
{

    var createdCountry = await ApiUtilities.CreatedEntityAsync <Company> (company, context);
    return Results.Created($"type/{createdCountry.Id}", createdCountry);

});


app.Run();


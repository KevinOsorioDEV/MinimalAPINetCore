using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BeerapiNet7._0.Models;

public partial class Beer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Year { get; set; }

    public double Alcohol { get; set; }

    public double Price { get; set; }

    public int IdCountry { get; set; }

    public int IdType { get; set; }

    public int IdCompany { get; set; }

    public virtual Company IdCompanyNavigation { get; set; } = null!;

 
    public virtual Country IdCountryNavigation { get; set; } = null!;


    public virtual TypeBeer IdTypeNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BeerapiNet7._0.Models;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Beer> Beers { get; set; } = new List<Beer>();
}

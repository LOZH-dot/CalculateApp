﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CalculateApp.Data.CalculateApp;

public partial class ProductsEstimate
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int EstimateId { get; set; }

    public int Count { get; set; }

    public virtual Estimate Estimate { get; set; }

    public virtual Product Product { get; set; }
}
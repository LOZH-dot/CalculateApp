﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CalculateApp.Data.CalculateApp;

public partial class Characteristic
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Value { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; }
}
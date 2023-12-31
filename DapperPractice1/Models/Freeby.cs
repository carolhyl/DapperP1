﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DapperPractice1.Models;

public partial class Freeby
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Brand { get; set; }

    public int Price { get; set; }

    public string ShortDescription { get; set; }

    public string Thumbnail { get; set; }

    public int Inventory { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedTime { get; set; }

    public virtual ICollection<ActivityDiscount> ActivityDiscounts { get; set; } = new List<ActivityDiscount>();

    public virtual ICollection<Coupon> Coupons { get; set; } = new List<Coupon>();
}
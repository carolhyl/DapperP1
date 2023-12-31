﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DapperPractice1.Models;

public partial class ProductTag
{
    public int Id { get; set; }

    public int ProductTagCategoryId { get; set; }

    public string Name { get; set; }

    public virtual ProductTagCategory ProductTagCategory { get; set; }

    public virtual ICollection<ActivityDiscount> ActivityDiscounts { get; set; } = new List<ActivityDiscount>();

    public virtual ICollection<Coupon> Coupons { get; set; } = new List<Coupon>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
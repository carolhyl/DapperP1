﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DapperPractice1.Models;

public partial class ThirdCategory
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int SecondCategoryId { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual SecondCategory SecondCategory { get; set; }

    public virtual ICollection<ActivityDiscount> ActivityDiscounts { get; set; } = new List<ActivityDiscount>();

    public virtual ICollection<Coupon> Coupons { get; set; } = new List<Coupon>();
}
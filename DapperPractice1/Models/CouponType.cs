﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DapperPractice1.Models;

public partial class CouponType
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Coupon> Coupons { get; set; } = new List<Coupon>();
}
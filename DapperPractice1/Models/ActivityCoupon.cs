﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DapperPractice1.Models;

public partial class ActivityCoupon
{
    public int Id { get; set; }

    public int ActivityDetailId { get; set; }

    public int CouponId { get; set; }

    public virtual ActivityDetail ActivityDetail { get; set; }

    public virtual Coupon Coupon { get; set; }
}
﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DapperPractice1.Models;

public partial class Product
{
    public int Id { get; set; }

    public int ThirdCategoryId { get; set; }

    public int BrandId { get; set; }

    public string Name { get; set; }

    public string Code { get; set; }

    public int Price { get; set; }

    public string ShortDescription { get; set; }

    public string Description { get; set; }

    public string Thumbnail { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime UpdateTime { get; set; }

    public string ShelfStatus { get; set; }

    public virtual Brand Brand { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<ProductComment> ProductComments { get; set; } = new List<ProductComment>();

    public virtual ICollection<ProductStyle> ProductStyles { get; set; } = new List<ProductStyle>();

    public virtual ThirdCategory ThirdCategory { get; set; }

    public virtual ICollection<Dealer> Dealers { get; set; } = new List<Dealer>();

    public virtual ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
}
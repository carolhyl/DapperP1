﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DapperPractice1.Models;

public partial class Activity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string Description { get; set; }

    public string Thumbnail { get; set; }

    public string Status { get; set; }

    public DateTime CreatedTime { get; set; }

    public virtual ICollection<ActivityDetail> ActivityDetails { get; set; } = new List<ActivityDetail>();
}
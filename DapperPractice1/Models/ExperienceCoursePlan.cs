﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DapperPractice1.Models;

public partial class ExperienceCoursePlan
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Price { get; set; }

    public int PeopleMin { get; set; }

    public int PeopleMax { get; set; }

    public virtual ICollection<ExperienceEnrollment> ExperienceEnrollments { get; set; } = new List<ExperienceEnrollment>();
}
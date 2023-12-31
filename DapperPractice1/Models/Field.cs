﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DapperPractice1.Models;

public partial class Field
{
    public int Id { get; set; }

    public string PhoneNumber { get; set; }

    public string BusinessHours { get; set; }

    public string Address { get; set; }

    public bool Indoor { get; set; }

    public string Thumbnail { get; set; }

    public string ShortDescription { get; set; }

    public string Link { get; set; }

    public string Name { get; set; }

    public DateTime? BusinessWeekdayStartTime { get; set; }

    public DateTime? BusinessWeekdayEndTime { get; set; }

    public DateTime? BusinessWeekendStartTime { get; set; }

    public DateTime? BusinessWeekendEndTime { get; set; }

    public virtual ICollection<BanDate> BanDates { get; set; } = new List<BanDate>();

    public virtual ICollection<ExperienceEnrollment> ExperienceEnrollments { get; set; } = new List<ExperienceEnrollment>();

    public virtual ICollection<Skillcurriculum> Skillcurricula { get; set; } = new List<Skillcurriculum>();
}
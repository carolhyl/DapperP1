﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DapperPractice1.Models;

public partial class SkillEnrollment
{
    public int Id { get; set; }

    public int SkillcurriculumsId { get; set; }

    public int MemberId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int NumberOfPeople { get; set; }

    public virtual Member Member { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Skillcurriculum Skillcurriculums { get; set; }
}
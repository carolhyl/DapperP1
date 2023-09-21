﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DapperPractice1.Models;

public partial class ExperienceEnrollment
{
    public int Id { get; set; }

    public int ExperienceCoursePlanId { get; set; }

    public int MemberId { get; set; }

    public int PaymentId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int NumberOfPeople { get; set; }

    public bool Ststus { get; set; }

    public int FieldId { get; set; }

    public int? CoachId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public virtual Coach Coach { get; set; }

    public virtual ExperienceCoursePlan ExperienceCoursePlan { get; set; }

    public virtual Field Field { get; set; }

    public virtual Member Member { get; set; }
}
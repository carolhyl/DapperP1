﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DapperPractice1.Models;

public partial class MembersHistory
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public string Account { get; set; }

    public string Password { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Gender { get; set; }

    public DateTime Birthday { get; set; }

    public string PhoneNumber { get; set; }

    public bool Dmsubscribe { get; set; }

    public DateTime ModifiedTime { get; set; }

    public virtual Member Member { get; set; }
}
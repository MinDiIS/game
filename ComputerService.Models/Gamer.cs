﻿using System.ComponentModel.DataAnnotations;

namespace ComputerService.Models;

public class Gamer
{
    [Key] public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime BirthDate { get; set; }
}
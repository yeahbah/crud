﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDemo.WebApp.Models;

public record EmployeeModel
{
    public Guid EmployeeId { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
    public string? DepartmentCode { get; init; }
    public string? DepartmentName { get; init; }
    public DateTime BirthDate { get; init; }
    public string? Name => FirstName + " " + LastName;
}

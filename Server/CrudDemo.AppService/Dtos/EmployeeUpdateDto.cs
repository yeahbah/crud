﻿using System;

namespace CrudDemo.App.Dtos;

public record EmployeeUpdateDto
{
    public Guid EmployeeId { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string PhoneNumber { get; init; }
    public string DepartmentCode { get; set; }
    public DateTime BirthDate { get; init; }
}
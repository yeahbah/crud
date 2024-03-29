﻿using System;
using System.Collections.Generic;

namespace CrudDemo.App.Dtos;

public record EmployeeReadDto
{
    public Guid EmployeeId { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string PhoneNumber { get; init; }
    public string DepartmentCode { get; init; }
    public string DepartmentName { get; init; }
    public DateOnly BirthDate { get; init; }
    public ICollection<EmployeeProjectReadDto> Projects { get; set; }
}
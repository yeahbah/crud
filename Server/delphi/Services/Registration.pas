unit Registration;

interface

uses
  Spring.Container;

procedure RegisterTypes;

implementation

uses
  EmployeeService, DepartmentService;

procedure RegisterTypes;
var
  container: TContainer;
begin
  container := GlobalContainer;

  container.RegisterType<IEmployeeService, TEmployeeService>();
  container.RegisterType<IDepartmentService, TDepartmentService>();

  container.Build();
end;

end.

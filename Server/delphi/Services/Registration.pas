unit Registration;

interface

uses
  Spring.Container;

procedure RegisterTypes;

implementation

uses
  EmployeeService;

procedure RegisterTypes;
var
  container: TContainer;
begin
  container := GlobalContainer;

  container.RegisterType<IEmployeeService, TEmployeeService>();

  container.Build();
end;

end.

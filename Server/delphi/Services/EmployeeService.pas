unit EmployeeService;

interface

uses
  EmployeeDto, FireDAC.Comp.Client, MVCFramework.DataSet.Utils,
  System.Generics.Collections;

type
  IEmployeeService = interface
    ['{53D7C2D3-BAB6-420B-AB21-1F8A791C59CD}']
    function GetEmployees(): TObjectList<TEmployeeDto>;
  end;

  TEmployeeService = class(TInterfacedObject, IEmployeeService)
  public
    function GetEmployees(): TObjectList<TEmployeeDto>;
  end;


implementation

{ TEmployeeService }

uses
  CrudLifeDataModule;

function TEmployeeService.GetEmployees: TObjectList<TEmployeeDto>;
var
  employeeDto: TEmployeeDto;
begin
  var qry := TFdQuery.Create(nil);
  var connection := TFdConnection.Create(nil);
  connection.ConnectionDefName := 'CrudDemoDb';
  try
    qry.Connection := connection;
    qry.Sql.Add('select cast(e."EmployeeId" as varchar) as "EmployeeId", e."FirstName" , e."LastName" , e."Email" , e."PhoneNumber", e."BirthDate" , e."DepartmentCode" , e."IsDeleted"  from "Employee" e');
    qry.Open;
    result := qry.AsObjectList<TEmployeeDto>;

    qry.SQL.Clear;
    qry.Sql.Add('select e."FirstName" EmployeeFirstName,	e."LastName" EmployeeLastName,');
    qry.SQL.Add('CAST(e."EmployeeId" AS varchar) EmployeeId,	CAST(p."ProjectId" AS varchar) ProjectId, p."Description" ProjectName from "Employee" e');
    qry.Sql.Add('left join "EmployeeProject" ep on e."EmployeeId" = ep."EmployeeId"');
    qry.SQL.Add('left join "Project" p  on p."ProjectId" = ep."ProjectId"');
    qry.SQL.Add('where cast(e."EmployeeId" as varchar) = :employeeId');
    for employeeDto in result do
    begin
      qry.ParamByName('employeeId').AsString := employeeDto.EmployeeId;
      qry.Open;

      employeeDto.Projects := TObjectList<TEmployeeProjectDto>.Create;
      if not qry.FieldByName('ProjectId').IsNull then
      begin
        var project := qry.AsObject<TEmployeeProjectDto>;
        employeeDto.Projects.Add(project);
      end;


      qry.Close;
    end;

  finally
    qry.Free;
    connection.Free;
  end;
end;

end.

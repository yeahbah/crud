unit EmployeeService;

interface

uses
  EmployeeDto, CreateEmployeeDto, FireDAC.Comp.Client, MVCFramework.DataSet.Utils,
  System.Generics.Collections, Data.DB;

type
  IEmployeeService = interface
    ['{53D7C2D3-BAB6-420B-AB21-1F8A791C59CD}']
    function GetEmployees(): TObjectList<TEmployeeDto>;
    function GetEmployeeById(const id: string): TEmployeeDto;
    function AddEmployee(const dto: TCreateEmployeeDto): TEmployeeDto;
  end;

  TEmployeeService = class(TInterfacedObject, IEmployeeService)
  public
    function GetEmployees(): TObjectList<TEmployeeDto>;
    function GetEmployeeById(const id: string): TEmployeeDto;
    function AddEmployee(const dto: TCreateEmployeeDto): TEmployeeDto;
  end;


implementation

{ TEmployeeService }

uses
  CrudLifeDataModule, SysUtils;

function TEmployeeService.AddEmployee(
  const dto: TCreateEmployeeDto): TEmployeeDto;
var
  newGuid: TGuid;
begin
  var connection := TFdConnection.Create(nil);
  try
    connection.ConnectionDefName := 'CrudDemoDb';

    var employeeId := TGuid.NewGuid.ToString().ToLower();
    var x := connection.ExecSQLScalar('insert into "Employee" ("EmployeeId", "FirstName" , "LastName" , "Email" , "PhoneNumber", "BirthDate" , "DepartmentCode", "IsDeleted")'
                       + ' values (:employeeId, :firstName, :lastName, :email, :phone, :birthDate, :departmentCode, false) RETURNING CAST("EmployeeId" AS varchar)',
                       [employeeId, dto.FirstName, dto.LastName, dto.Email, dto.PhoneNumber, dto.BirthDate, dto.DepartmentCode],
                       [ftGuid, ftString, ftString, ftString, ftString, ftDate, ftString]);
    result := GetEmployeeById(x);

  finally
    connection.Free;
  end;
end;

function TEmployeeService.GetEmployeeById(const id: string): TEmployeeDto;
begin
  var qry := TFdQuery.Create(nil);
  var connection := TFdConnection.Create(nil);
  connection.ConnectionDefName := 'CrudDemoDb';
  try
    qry.Connection := connection;
    qry.Sql.Add('select cast(e."EmployeeId" as varchar) as "EmployeeId", e."FirstName" , e."LastName" , e."Email" , e."PhoneNumber", e."BirthDate" , e."DepartmentCode" , e."IsDeleted" from "Employee" e');
    qry.Sql.Add('where CAST(e."EmployeeId" AS varchar) = :employeeId');
    qry.Params[0].AsString := id;
    qry.Open;
    if qry.Eof then Exit(nil);

    result := qry.AsObject<TEmployeeDto>;

    result.Projects := TObjectList<TEmployeeProjectDto>.Create;

    qry.SQL.Clear;
    qry.Sql.Add('select e."FirstName" EmployeeFirstName,	e."LastName" EmployeeLastName,');
    qry.SQL.Add('CAST(e."EmployeeId" AS varchar) EmployeeId,	CAST(p."ProjectId" AS varchar) ProjectId, p."Name" ProjectName from "Employee" e');
    qry.Sql.Add('left join "EmployeeProject" ep on e."EmployeeId" = ep."EmployeeId"');
    qry.SQL.Add('left join "Project" p  on p."ProjectId" = ep."ProjectId"');
    qry.SQL.Add('where cast(e."EmployeeId" as varchar) = :employeeId');

    qry.ParamByName('employeeId').AsString := id;
    qry.Open;
    if qry.Eof then Exit;

    while not qry.Eof do
    begin
      if not qry.FieldByName('ProjectId').IsNull then
      begin
        var project := qry.AsObject<TEmployeeProjectDto>;
        result.Projects.Add(project);
      end;
      qry.Next;
    end;

    qry.Close;
  finally
    qry.Free;
    connection.Free;
  end;

end;

function TEmployeeService.GetEmployees: TObjectList<TEmployeeDto>;
var
  employeeDto: TEmployeeDto;
begin
  var qry := TFdQuery.Create(nil);
  var connection := TFdConnection.Create(nil);
  connection.ConnectionDefName := 'CrudDemoDb';
  try
    qry.Connection := connection;
    qry.Open('select cast(e."EmployeeId" as varchar) as "EmployeeId", e."FirstName" , e."LastName" , e."Email" , e."PhoneNumber", e."BirthDate" , e."DepartmentCode" , e."IsDeleted"  from "Employee" e');

    result := qry.AsObjectList<TEmployeeDto>;

    qry.SQL.Clear;
    qry.Sql.Add('select e."FirstName" EmployeeFirstName,	e."LastName" EmployeeLastName,');
    qry.SQL.Add('CAST(e."EmployeeId" AS varchar) EmployeeId,	CAST(p."ProjectId" AS varchar) ProjectId, p."Name" ProjectName from "Employee" e');
    qry.Sql.Add('left join "EmployeeProject" ep on e."EmployeeId" = ep."EmployeeId"');
    qry.SQL.Add('left join "Project" p  on p."ProjectId" = ep."ProjectId"');
    qry.SQL.Add('where cast(e."EmployeeId" as varchar) = :employeeId');
    for employeeDto in result do
    begin
      qry.ParamByName('employeeId').AsString := employeeDto.EmployeeId;
      qry.Open;
      employeeDto.Projects := TObjectList<TEmployeeProjectDto>.Create;
      if qry.Eof then continue;

      while not qry.Eof do
      begin
        if not qry.FieldByName('ProjectId').IsNull then
        begin
          var project := qry.AsObject<TEmployeeProjectDto>;
          employeeDto.Projects.Add(project);
        end;
        qry.Next;
      end;

      qry.Close;
    end;

  finally
    qry.Free;
    connection.Free;
  end;
end;

end.

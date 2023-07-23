unit ProjectService;

interface

uses
  CrudDemoDto, System.Generics.Collections;

type
  IProjectService = interface
    ['{957948E3-033C-46C6-809D-913F50913F6B}']
    function GetAllProjects(): TObjectList<TProjectDto>;
  end;

  TProjectService = class(TInterfacedObject, IProjectService)
  public
    function GetAllProjects(): TObjectList<TProjectDto>;
  end;

implementation

uses
  FireDAC.Comp.Client,
  FireDAC.Stan.Param,
  Data.DB, MVCFramework.DataSet.Utils;

{ TProjectService }

function TProjectService.GetAllProjects: TObjectList<TProjectDto>;
var
  dataSet: TDataset;
  projectDto: TProjectDto;
begin
  var connection := TFdConnection.Create(nil);
  try
    connection.ConnectionDefName := 'CrudDemoDb';
    connection.ExecSQL('select CAST("ProjectId" as varchar) ProjectId, "Name", "Description", "CreatedTimestamp", "IsDeleted", "CreatedByEmployeeId" from "Project" ', dataset);
    result := dataset.AsObjectList<TProjectDto>();
    if result.Count = 0 then Exit;

    for projectDto in result do
    begin
      var qry := TFdQuery.Create(nil);
      try
        qry.Connection := connection;
        qry.Sql.Text := 'select CAST(e."EmployeeId" AS varchar), e."FirstName" EmployeeFirstName, e."LastName" EmployeeLastName, e."Email", CAST(p."ProjectId" AS varchar), p."Name" ProjectName from "Project" p'
                      + ' inner join "EmployeeProject" ep on p."ProjectId" = ep."ProjectId"'
                      + ' inner join "Employee" e ON e."EmployeeId" = ep."EmployeeId"'
                      + ' where CAST(ep."ProjectId" AS varchar) = :projectId';
        qry.ParamByName('projectId').AsString := projectDto.ProjectId;
        qry.Open;
        projectDto.Employees := qry.AsObjectList<TEmployeeProjectDto>();
      finally
        qry.Free;
      end;
    end;


  finally
    dataset.Free;
    connection.Free;
  end;
end;

end.

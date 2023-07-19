unit EmployeeController;

interface

uses
  MVCFramework, MVCFramework.Commons, MVCFramework.Serializer.Commons,
  FireDAC.Comp.Client, Spring.Container, EmployeeService, Spring.Container.Common;

type
  [MVCPath('/api')]
  TEmployeeController = class(TMVCController)
  public
    [MVCPath]
    [MVCHTTPMethod([httpGET])]
    procedure Index;
//    [Inject]
//    fEmployeeService: IEmployeeService;

//    [MVCPath('/reversedstrings/($Value)')]
 //   [MVCHTTPMethod([httpGET])]
 //   procedure GetReversedString(const Value: String);
  protected



    procedure OnBeforeAction(Context: TWebContext; const AActionName: string; var Handled: Boolean); override;
    procedure OnAfterAction(Context: TWebContext; const AActionName: string); override;

  public

    [MVCPath('/Employee')]
    [MVCHttpMethod([httpGET])]
    procedure GetEmployees();

    [MVCPath('/Employee/($id)')]
    [MVCHTTPMethod([httpGET])]
    procedure GetEmployeeById(id: string);

    [MVCPath('/Employee')]
    [MVCHTTPMethod([httpPOST])]
    procedure CreateEmployee;

    [MVCPath('/Employee/($id)')]
    [MVCHTTPMethod([httpPUT])]
    procedure UpdateEmployee(id: string);

    [MVCPath('/Employee/($id)')]
    [MVCHTTPMethod([httpDELETE])]
    procedure DeleteEmployee(id: Integer);

  end;

implementation

uses
  System.SysUtils, MVCFramework.Logger, System.StrUtils, Json, CrudLifeDataModule,
  MVCFramework.DataSet.Utils,
  EmployeeDto, CreateOrUpdateEmployeeDto,
  MVCFramework.Serializer.JsonDataObjects, System.Net.URLClient;

//type
//  TPerson = class
//  private
//    fFirstName: string;
//  public
//    property FirstName: string read fFirstName write fFirstName;
//  end;

//procedure TEmployeeController.Index;
//begin
//  //use Context property to access to the HTTP request and response
//  Render('Hello DelphiMVCFramework World');
//end;

//procedure TEmployeeController.GetReversedString(const Value: String);
//begin
//  Render(System.StrUtils.ReverseString(Value.Trim));
//end;

procedure TEmployeeController.OnAfterAction(Context: TWebContext; const AActionName: string);
begin
  { Executed after each action }
  inherited;
end;

procedure TEmployeeController.OnBeforeAction(Context: TWebContext; const AActionName: string; var Handled: Boolean);
begin
  { Executed before each action
    if handled is true (or an exception is raised) the actual
    action will not be called }
  inherited;
end;

//Sample CRUD Actions for a "Customer" entity
procedure TEmployeeController.GetEmployeeById(id: string);
begin
  var service := GlobalContainer.Resolve<IEmployeeService>();
  var result := service.GetEmployeeById(id);
  if not Assigned(result) then Render(http_status.NotFound);

  Render(result);

end;

procedure TEmployeeController.GetEmployees;
var
  lDict: IMVCObjectDictionary;
  employee: TEmployeeDto;
  jsonArray: TJSONArray;
begin
  var service := GlobalContainer.Resolve<IEmployeeService>();
  var employeeList := service.GetEmployees();

  var serializer := TMVCJsonDataObjectsSerializer.Create();
  var result := serializer.SerializeCollection(employeeList, stDefault);

  Render(result);

end;

procedure TEmployeeController.Index;
begin
  GetEmployees();
end;

procedure TEmployeeController.CreateEmployee;
begin
  var payLoad := Context.Request.BodyAs<TCreateOrUpdateEmployeeDto>();
  if not Assigned(payLoad) then Render(http_status.BadRequest);

  var service := GlobalContainer.Resolve<IEmployeeService>();
  var newEmployee := service.AddEmployee(payLoad);
  if not Assigned(newEmployee) then Render(http_status.InternalServerError);

  var returnRoute := Context.Request.Headers['Host'];
  returnRoute := Format(returnRoute + '/api/Employee/%s', [newEmployee.EmployeeId]);
  Context.Response.SetCustomHeader('Location', returnRoute);
  Render(http_status.Created, newEmployee);

end;

procedure TEmployeeController.UpdateEmployee(id: string);
begin
  var payLoad := Context.Request.BodyAs<TCreateOrUpdateEmployeeDto>();
  if not Assigned(payLoad) then Render(http_status.BadRequest);

  var service := GlobalContainer.Resolve<IEmployeeService>();
  service.UpdateEmployee(id, payLoad);

  Render(http_status.NoContent);
end;

procedure TEmployeeController.DeleteEmployee(id: Integer);
begin
  //todo: delete customer by id
end;



end.

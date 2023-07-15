unit EmployeeController;

interface

uses
  MVCFramework, MVCFramework.Commons, MVCFramework.Serializer.Commons,
  FireDAC.Comp.Client, Spring.Container, EmployeeService, Spring.Container.Common;

type
  [MVCPath('/api/Employee')]
  TEmployeeController = class(TMVCController)
  public
//    [MVCPath]
//    [MVCHTTPMethod([httpGET])]
//    procedure Index;
//    [Inject]
//    fEmployeeService: IEmployeeService;

//    [MVCPath('/reversedstrings/($Value)')]
 //   [MVCHTTPMethod([httpGET])]
 //   procedure GetReversedString(const Value: String);
  protected



    procedure OnBeforeAction(Context: TWebContext; const AActionName: string; var Handled: Boolean); override;
    procedure OnAfterAction(Context: TWebContext; const AActionName: string); override;

  public

    [MVCPath('/')]
    [MVCHttpMethod([httpGET])]
    procedure GetEmployees();

    //Sample CRUD Actions for a "Customer" entity
    [MVCPath('/($id)')]
    [MVCHTTPMethod([httpGET])]
    procedure GetEmployeeById(id: integer);

    [MVCPath('/')]
    [MVCHTTPMethod([httpPOST])]
    procedure CreateEmployee;

    [MVCPath('/($id)')]
    [MVCHTTPMethod([httpPUT])]
    procedure UpdateEmployee(id: Integer);

    [MVCPath('/($id)')]
    [MVCHTTPMethod([httpDELETE])]
    procedure DeleteEmployee(id: Integer);

  end;

implementation

uses
  System.SysUtils, MVCFramework.Logger, System.StrUtils, Json, CrudLifeDataModule,
  MVCFramework.DataSet.Utils,
  EmployeeDto,
  MVCFramework.Serializer.JsonDataObjects;

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
procedure TEmployeeController.GetEmployeeById(id: integer);
begin
  //todo: render a list of customers
end;

procedure TEmployeeController.GetEmployees;
var
  lDict: IMVCObjectDictionary;
  employee: TEmployeeDto;
  jsonArray: TJSONArray;
begin
  var service := GlobalContainer.Resolve<IEmployeeService>();
  var employeeList := fEmployeeService.GetEmployees();

  var serializer := TMVCJsonDataObjectsSerializer.Create;
  var result := serializer.SerializeCollection(employeeList);

  Render(result);

end;

procedure TEmployeeController.CreateEmployee;
begin
  //todo: create a new customer
end;

procedure TEmployeeController.UpdateEmployee(id: Integer);
begin
  //todo: update customer by id
end;

procedure TEmployeeController.DeleteEmployee(id: Integer);
begin
  //todo: delete customer by id
end;



end.

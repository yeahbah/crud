unit CrudDemoDto;

interface

uses
  System.Generics.Collections,
  MVCFramework.Serializer.Commons;

type
  [MVCNameCaseAttribute(TMVCNameCase.ncCamelCase)]
  TEmployeeProjectDto = class;

  [MVCNameCaseAttribute(TMVCNameCase.ncCamelCase)]
  TEmployeeDto = class;

  [MVCNameCaseAttribute(TMVCNameCase.ncCamelCase)]
  TProjectDto = class;

  TEmployeeProjectDto = class
  private
    fEmployeeId: string;
    fProjectId: string;
    fEmployeeFirstName: string;
    fEmployeeLastName: string;
    fProjectName: string;
    fEmployees: TObjectList<TEmployeeDto>;
  public
    property EmployeeId: string read fEmployeeId write fEmployeeId;
    property ProjectId: string read fProjectId write fProjectId;
    property EployeeFirstName: string read fEmployeeFirstName write fEmployeeFirstName;
    property EployeeLastName: string read fEmployeeLastName write fEmployeeLastName;
    property ProjectName: string read fProjectName write fProjectName;
    property Employees: TObjectList<TEmployeeDto> read fEmployees write fEmployees;
  end;

  TEmployeeDto = class
  private
    fEmployeeId: string;
    fFirstName: string;
    fLastName: string;
    fEmail: string;
    fPhoneNumber: string;
    fBirthDate: TDate;
    fDepartmentCode: string;
    fProjects: TObjectList<TEmployeeProjectDto>;
  public
    property EmployeeId: string read fEmployeeId write fEmployeeId;
    property FirstName: string read fFirstName write fFirstName;
    property LastName: string  read fLastName write fLastName;
    property email: string read fEmail write fEmail;
    property PhoneNumber: string read fPhoneNumber write fPhoneNumber;
    property BirthDate: TDate read fBirthDate write fBirthDate;
    property DepartmentCode: string read fDepartmentCode write fDepartmentCode;
    property Projects: TObjectList<TEmployeeProjectDto> read fProjects write fProjects;
  end;

  TProjectDto = class
  private
    fProjectId: string;
    fName: string;
    fDescription: string;
    fCreatedTimestamp: TDateTime;
    fEmployeeID: string;
    fCreatedByEmployeeId: string;
  public
    property ProjectId: string read fProjectId write fProjectId;
    property EmployeeId: string read fEmployeeID write fEmployeeId;
    property Name: string read fName write fName;
    property Description: string read fDescription write fDescription;
    property CreatedTimestamp: TDateTime read fCreatedTimestamp write fCreatedTimestamp;
    property CreatedByEmployeeId: string read fCreatedByEmployeeId write fCreatedByEmployeeId;

  end;


implementation


end.

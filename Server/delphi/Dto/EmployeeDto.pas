unit EmployeeDto;

interface

uses
  System.Generics.Collections, MVCFramework.Serializer.JsonDataObjects, MVCFramework.Serializer.Commons;

type
  [MVCNameCaseAttribute(TMVCNameCase.ncCamelCase)]
  TEmployeeProjectDto = class
  private
    fEmployeeId: string;
    fProjectId: string;
    fEmployeeFirstName: string;
    fEmployeeLastName: string;
    fProjectName: string;
  public
    property EmployeeId: string read fEmployeeId write fEmployeeId;
    property ProjectId: string read fProjectId write fProjectId;
    property EployeeFirstName: string read fEmployeeFirstName write fEmployeeFirstName;
    property EployeeLastName: string read fEmployeeLastName write fEmployeeLastName;
    property ProjectName: string read fProjectName write fProjectName;
  end;

  [MVCNameCaseAttribute(TMVCNameCase.ncCamelCase)]
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


implementation

end.

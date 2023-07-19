unit EmployeeDto;

interface

uses
  System.Generics.Collections, MVCFramework.Serializer.JsonDataObjects, MVCFramework.Serializer.Commons;

type
  TEmployeeProjectDto = class
  private
    fEmployeeId: string;
    fProjectId: string;
    fEmployeeFirstName: string;
    fEmployeeLastName: string;
    fProjectName: string;
  public
    property eployeeId: string read fEmployeeId write fEmployeeId;
    property pojectId: string read fProjectId write fProjectId;
    property eployeeFirstName: string read fEmployeeFirstName write fEmployeeFirstName;
    property eployeeLastName: string read fEmployeeLastName write fEmployeeLastName;
    property pojectName: string read fProjectName write fProjectName;
  end;

//  [MVCNameCaseAttribute(TMVCNameCase.ncCamelCase)] -- slow and unstable
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
    property employeeId: string read fEmployeeId write fEmployeeId;
    property firstName: string read fFirstName write fFirstName;
    property lastName: string  read fLastName write fLastName;
    property email: string read fEmail write fEmail;
    property phoneNumber: string read fPhoneNumber write fPhoneNumber;
    property birthDate: TDate read fBirthDate write fBirthDate;
    property departmentCode: string read fDepartmentCode write fDepartmentCode;
    property projects: TObjectList<TEmployeeProjectDto> read fProjects write fProjects;
  end;


implementation

end.

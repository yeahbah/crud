unit CreateEmployeeDto;

interface

type
  TCreateEmployeeDto = class
  private
    fFirstName: string;
    fLastName: string;
    fEmail: string;
    fPhoneNumber: string;
    fBirthDate: TDate;
    fDepartmentCode: string;
  public
    property FirstName: string read fFirstName write fFirstName;
    property LastName: string  read fLastName write fLastName;
    property Email: string read fEmail write fEmail;
    property PhoneNumber: string read fPhoneNumber write fPhoneNumber;
    property BirthDate: TDate read fBirthDate write fBirthDate;
    property DepartmentCode: string read fDepartmentCode write fDepartmentCode;
  end;

implementation

end.

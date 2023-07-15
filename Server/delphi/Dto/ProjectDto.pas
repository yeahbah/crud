unit ProjectDto;

interface

type
  TProjectDto = class
  private
    fProjectId: string;
    fName: string;
    fDescription: string;
    fCreatedTimestamp: TDateTime;
    fEmployeeID: string;
  public
    property ProjectId: string read fProjectId write fProjectId;
    property EmployeeId: string read fEmployeeID write fEmployeeId;
    property Name: string read fName write fName;
    property Description: string read fDescription write fDescription;
    property CreatedTimestamp: TDateTime read fCreatedTimestamp write fCreatedTimestamp;
  end;

implementation

end.

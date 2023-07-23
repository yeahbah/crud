unit ProjectController;

interface

uses
  MVCFramework, MVCFramework.Commons;

type
  [MVCPath('/api')]
  TProjectController = class(TMVCController)
  public
    [MVCPath('/Project')]
    [MVCHttpMethod([httpGET])]
    procedure GetProjects();
  end;

implementation

uses
  Spring.Container, ProjectService, CrudDemoDto, MVCFramework.Serializer.JsonDataObjects;

{ TProjectController }

procedure TProjectController.GetProjects;
begin
  var service := GlobalContainer.Resolve<IProjectService>();
  var result := service.GetAllProjects();
  var serialier := TMVCJsonDataObjectsSerializer.Create();
  Render(serializer.SerializeCollection(result));
end;

end.

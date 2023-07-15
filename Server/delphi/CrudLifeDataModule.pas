unit CrudLifeDataModule;

interface

uses
  System.SysUtils, System.Classes, FireDAC.Stan.Intf, FireDAC.Stan.Option,
  FireDAC.Stan.Error, FireDAC.UI.Intf, FireDAC.Phys.Intf, FireDAC.Stan.Def,
  FireDAC.Stan.Pool, FireDAC.Stan.Async, FireDAC.Phys, FireDAC.Phys.PG,
  FireDAC.Phys.PGDef, FireDAC.VCLUI.Wait, Data.DB, FireDAC.Comp.Client,
  FireDAC.Stan.Param, FireDAC.DatS, FireDAC.DApt.Intf, FireDAC.DApt,
  FireDAC.Comp.DataSet, FireDAC.Moni.Base, FireDAC.Moni.RemoteClient;

type
  TDataModule1 = class(TDataModule)
    FDQuery1: TFDQuery;
    FDMoniRemoteClientLink1: TFDMoniRemoteClientLink;
    procedure DataModuleCreate(Sender: TObject);
    procedure DataModuleDestroy(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  DataModule1: TDataModule1;

implementation

{%CLASSGROUP 'Vcl.Controls.TControl'}

{$R *.dfm}

procedure TDataModule1.DataModuleCreate(Sender: TObject);
begin
  FDManager.Open;
  FDManager.ConnectionDefs.ConnectionDefByName('CrudDemoDb').Params.Pooled := True;
end;

procedure TDataModule1.DataModuleDestroy(Sender: TObject);
begin
  FDManager.Close();
end;

initialization
  DataModule1 := TDataModule1.Create(nil);

finalization
  DataModule1.Free;

end.

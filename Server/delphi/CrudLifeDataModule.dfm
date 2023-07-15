object DataModule1: TDataModule1
  OnCreate = DataModuleCreate
  OnDestroy = DataModuleDestroy
  Height = 750
  Width = 1000
  PixelsPerInch = 120
  object FDQuery1: TFDQuery
    Left = 400
    Top = 288
  end
  object FDMoniRemoteClientLink1: TFDMoniRemoteClientLink
    Tracing = True
    Left = 400
    Top = 200
  end
end

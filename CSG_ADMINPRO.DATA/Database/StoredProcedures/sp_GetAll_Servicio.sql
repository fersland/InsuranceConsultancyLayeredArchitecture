USE Consultorio_Seguros
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetAll_Servicio]
AS
BEGIN
    SELECT Id, NombreServicio FROM Servicios
END
GO

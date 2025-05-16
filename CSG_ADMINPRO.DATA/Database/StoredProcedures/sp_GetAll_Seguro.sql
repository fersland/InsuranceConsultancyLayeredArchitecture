USE Consultorio_Seguros
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAll_Seguro]
AS
	BEGIN
		SELECT Id, Codigo, NombreSeguro, Asegurada, Prima
		FROM Seguros
	END;
GO

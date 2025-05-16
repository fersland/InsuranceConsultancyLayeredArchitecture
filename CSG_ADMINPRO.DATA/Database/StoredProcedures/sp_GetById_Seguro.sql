USE Consultorio_Seguros
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetById_Seguro]
	@Id INT
AS
	BEGIN
		SELECT Id, Codigo, NombreSeguro, Asegurada, Prima
		FROM Seguros
		WHERE Id = @Id
	END
GO

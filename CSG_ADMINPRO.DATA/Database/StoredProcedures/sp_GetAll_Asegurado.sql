use Consultorio_Seguros
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAll_Asegurado]
AS
	BEGIN
		SELECT
			t1.Id, t2.Cedula AS Cedula, t2.NombreCliente AS NombreCliente, t3.Codigo AS Codigo, 
			t3.NombreSeguro AS NombreSeguro, t3.Asegurada AS Asegurada, t3.Prima AS Prima
		FROM Asegurados t1
			INNER JOIN Clientes t2 ON t1.ClienteId = t2.Id
			INNER JOIN Seguros t3 ON t1.SeguroId = t3.Id
	END;
GO

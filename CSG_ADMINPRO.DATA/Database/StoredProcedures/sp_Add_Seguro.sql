USE Consultorio_Seguros
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Add_Seguro]
@Codigo nvarchar(50),
@NombreSeguro nvarchar(150),
@Asegurada nvarchar(max),
@Prima nvarchar(max)
AS
	BEGIN
		IF NOT EXISTS (SELECT 1 FROM Seguros WHERE Codigo=@Codigo)
			BEGIN
				INSERT INTO Seguros (Codigo, NombreSeguro, Asegurada, Prima)
				VALUES (@Codigo, @NombreSeguro, @Asegurada, @Prima)
			END
		ELSE
			BEGIN
				RAISERROR('El codigo de este seguro ya existe, escoja otro codigo.', 16,1);
			END
	END;
GO

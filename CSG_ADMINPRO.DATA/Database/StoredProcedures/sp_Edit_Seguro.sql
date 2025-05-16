use Consultorio_Seguros
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Edit_Seguro]
@Id INT,
@Codigo NVARCHAR(50),
@NombreSeguro NVARCHAR(150),
@Asegurada NVARCHAR(MAX),
@Prima NVARCHAR(MAX)
AS
	BEGIN
		-- Verificar si la nueva cédula ya existe en otro cliente
		IF EXISTS (SELECT 1 FROM Seguros WHERE Codigo = @Codigo AND Id != @Id)
			BEGIN
				RAISERROR('Ya existe otro seguro con el mismo código.', 16, 1);
			END
		ELSE
		BEGIN
			-- Actualizar los datos del cliente
			UPDATE Seguros
			SET Codigo = @Codigo,
				NombreSeguro = @NombreSeguro,
				Asegurada = @Asegurada,
				Prima = @Prima
			WHERE Id = @Id;
		END
	END;
GO

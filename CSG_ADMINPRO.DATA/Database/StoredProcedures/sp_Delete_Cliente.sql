SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_Delete_Cliente]
    @Id INT
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM Asegurados WHERE ClienteId = @Id)
		BEGIN
			DELETE FROM Clientes
			WHERE Id = @Id;
		END
	ELSE
		BEGIN
			RAISERROR('Este cliente pertenece a un Asegurado activo, no puede eliminarlo', 16,1);
		END
END;
GO

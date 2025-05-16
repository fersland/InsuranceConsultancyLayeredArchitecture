SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_Delete_Seguro]
@Id int
AS
BEGIN
	IF NOT EXISTS(SELECT 1 FROM Asegurados WHERE SeguroId =@Id )
		BEGIN
			DELETE FROM Seguros
			WHERE Id=@Id
		END;
	ELSE
		BEGIN
			RAISERROR('Este seguro corresponde a un asegurado activo.', 16,1)
		END
	END;
GO

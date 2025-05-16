use Consultorio_Seguros
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Edit_Asegurado]
@Id INT,
@ClienteId INT,
@SeguroId INT
AS
	BEGIN
		IF EXISTS(SELECT 1 FROM Asegurados WHERE ClienteId=@ClienteId AND SeguroId=@SeguroId
					
							)
			BEGIN
				RAISERROR('Este registro ya existe.',16,1);
			END
		ELSE
			BEGIN
				UPDATE Asegurados
					SET ClienteId=@ClienteId, SeguroId=@SeguroId
					WHERE Id=@Id
			END
	END
GO

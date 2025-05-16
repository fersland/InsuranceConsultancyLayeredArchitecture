USE Consultorio_Seguros
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Add_Asegurado]
@ClienteId INT,
@SeguroId INT
AS
	BEGIN
		IF NOT EXISTS (SELECT 1 FROM Asegurados WHERE ClienteId=@ClienteId AND SeguroId=@SeguroId)
			BEGIN
				INSERT INTO Asegurados (ClienteId, SeguroId) VALUES (@ClienteId, @SeguroId)
			END
		ELSE
			BEGIN
				RAISERROR('Esta persona si esta asegurada', 16,1);
			END
	END;
GO

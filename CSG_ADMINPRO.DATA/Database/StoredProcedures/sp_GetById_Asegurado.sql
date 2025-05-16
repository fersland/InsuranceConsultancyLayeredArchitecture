USE Consultorio_Seguros
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetById_Asegurado]
@Id int
AS
	BEGIN
		SELECT
			t1.Id, t1.ClienteId, t1.SeguroId
		FROM Asegurados t1

		WHERE t1.Id = @Id
	END;
GO

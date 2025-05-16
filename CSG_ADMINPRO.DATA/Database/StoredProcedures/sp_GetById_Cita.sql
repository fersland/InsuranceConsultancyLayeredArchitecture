USE Consultorio_Seguros
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetById_Cita]
@CitaId int
AS
	BEGIN
		SET NOCOUNT ON;
		BEGIN TRY
			SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
			BEGIN TRANSACTION;
				SELECT 
					CitaId,
					ClienteId,
					Fecha,
					FechaCreacion,
					Motivo,
					Notas,
					Ubicacion,
					EstadoId
				FROM 
					Citas 
				WHERE 
					CitaId = @CitaId AND
					EstadoId = 1;

			COMMIT TRANSACTION;

		END TRY

		BEGIN CATCH
			IF @@TRANCOUNT > 0
			BEGIN
				ROLLBACK TRANSACTION;
			END;

			DECLARE @ErrorMessage NVARCHAR(4000);
			DECLARE @ErrorServerity INT;
			DECLARE @ErrorState INT;

			SELECT 
				@ErrorMessage = ERROR_MESSAGE(),
				@ErrorServerity = ERROR_SEVERITY(),
				@ErrorState = ERROR_STATE();

			RAISERROR(@ErrorMessage, @ErrorServerity, @ErrorState);
		END CATCH;
	END
GO

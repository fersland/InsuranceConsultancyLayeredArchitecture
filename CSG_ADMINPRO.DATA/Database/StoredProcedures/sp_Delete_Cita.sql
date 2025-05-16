SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_Delete_Cita]
@CitaId int
AS
	BEGIN
		SET NOCOUNT ON;

		BEGIN TRY
			BEGIN TRANSACTION;
					BEGIN
						DELETE FROM Citas
						WHERE 
							CitaId = @CitaId AND EstadoId = 1
					END
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

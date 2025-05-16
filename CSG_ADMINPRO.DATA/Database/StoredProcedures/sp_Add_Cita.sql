USE Consultorio_Seguros
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Add_Cita]
@ClienteId int
,@Fecha date
,@Motivo varchar(255)
,@Notas text
,@Ubicacion varchar(255)

AS
	BEGIN
		SET NOCOUNT ON;

		BEGIN TRY
			BEGIN TRANSACTION;
				IF NOT EXISTS(SELECT 1 FROM Citas WHERE Fecha=@Fecha AND EstadoId=1)
					BEGIN
						INSERT INTO Citas
								(ClienteId
								,Fecha
								,FechaCreacion
								,Motivo
								,Notas
								,Ubicacion
								,EstadoId)

						VALUES
							(
								@ClienteId
								,@Fecha
								,getdate()
								,@Motivo
								,@Notas
								,@Ubicacion
								,1
							)
						COMMIT TRANSACTION;
					END
				ELSE
					BEGIN
						ROLLBACK TRANSACTION;
						RAISERROR('Error: Esta cita ya se generó anteriormente.', 16,1);
					END

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

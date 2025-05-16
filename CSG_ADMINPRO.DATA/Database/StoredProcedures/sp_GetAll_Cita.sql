USE Consultorio_Seguros
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAll_Cita]
AS
	BEGIN
		SET NOCOUNT ON;
		BEGIN TRY

			BEGIN TRANSACTION;
				SELECT 
					t1.CitaId,
					t2.Cedula AS CedulaCliente,
					t2.NombreCliente AS NombreCliente,					
					t1.Fecha AS FechaCita,
					t1.FechaCreacion AS FechaCreacionCita,
					t1.Motivo,
					t1.Notas,
					t1.Ubicacion,
					t3.NombreEstado
				FROM 
					Citas t1
					INNER JOIN Clientes t2 ON t1.ClienteId = t2.Id
					INNER JOIN Estados T3 on t1.EstadoId = t3.Id
				WHERE 
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

use Consultorio_Seguros
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Edit_Usuario]
@Id int
,@NombreUsuario varchar(200)
,@CorreoUsuario varchar(200)
,@Estado int

AS
	IF NOT EXISTS(SELECT 1 FROM Usuarios WHERE NombreUsuario=@NombreUsuario AND EstadoId=1 AND Id!= @Id)
		BEGIN
			UPDATE Usuarios SET 
					NombreUsuario =@NombreUsuario, 
					CorreoUsuario=@CorreoUsuario, 
					FechaModificacion=getdate(), 
					EstadoId=@Estado
			WHERE Id=@Id
		END
	ELSE
		RAISERROR('El usuario ya existe en la base de datos.', 16,1);
GO

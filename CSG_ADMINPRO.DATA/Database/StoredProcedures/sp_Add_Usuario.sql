USE Consultorio_Seguros
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Add_Usuario]
@NombreUsuario varchar(200)
,@CorreoUsuario varchar(200)
,@ClaveUsuario varchar(200)
,@Estado int

AS
	IF NOT EXISTS(SELECT 1 FROM Usuarios WHERE NombreUsuario=@NombreUsuario AND EstadoId=1)
		BEGIN
			INSERT INTO Usuarios (NombreUsuario, CorreoUsuario, ClaveUsuario, FechaCrecion, EstadoId)
			VALUES
				(@NombreUsuario, @CorreoUsuario, @ClaveUsuario, getdate(), @Estado)
		END
	ELSE
		RAISERROR('El usuario ya existe en la base de datos.', 16,1);

GO

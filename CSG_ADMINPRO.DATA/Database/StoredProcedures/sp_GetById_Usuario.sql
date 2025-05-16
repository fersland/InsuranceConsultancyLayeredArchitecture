USE Consultorio_Seguros
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetById_Usuario]
@Id int
AS
	BEGIN
		SELECT t1.Id, t1.NombreUsuario, t1.CorreoUsuario, t1.FechaCrecion as FechaCreacion, t1.EstadoId 
		FROM Usuarios t1
		INNER JOIN Estados t2 ON t1.EstadoId = t2.Id
		WHERE t1.Id=@Id
	END
GO

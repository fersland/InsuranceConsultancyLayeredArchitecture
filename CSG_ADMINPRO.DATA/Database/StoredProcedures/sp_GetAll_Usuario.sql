USE Consultorio_Seguros
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAll_Usuario]
AS
BEGIN
	SELECT 
		Id
		,NombreUsuario
      ,CorreoUsuario
      ,FechaCrecion
      ,FechaModificacion
      ,EstadoId
	  FROM

	  Usuarios
END
GO

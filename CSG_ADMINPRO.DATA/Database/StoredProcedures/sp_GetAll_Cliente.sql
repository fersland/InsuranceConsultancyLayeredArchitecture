USE Consultorio_Seguros
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAll_Cliente]
AS
BEGIN
    SELECT Id, Cedula, NombreCliente, Telefono, Edad
    FROM Clientes;
END;
GO

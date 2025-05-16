USE Consultorio_Seguros
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetById_Cliente]
    @Id INT
AS
BEGIN
    SELECT Id, Cedula, NombreCliente, Telefono, Edad
    FROM Clientes
    WHERE Id = @Id;
END;
GO

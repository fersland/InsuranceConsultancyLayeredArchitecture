USE Consultorio_Seguros
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Add_Cliente]
	@Cedula NVARCHAR(10),
    @NombreCliente NVARCHAR(40),
    @Telefono NVARCHAR(10),
    @Edad INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Clientes WHERE Cedula = @Cedula)
    BEGIN
        INSERT INTO Clientes (Cedula, NombreCliente, Telefono, Edad)
        VALUES (@Cedula, @NombreCliente, @Telefono, @Edad);
    END
    ELSE
    BEGIN
        RAISERROR('El cliente con la cédula proporcionada ya existe.', 16, 1);
    END
END;
GO

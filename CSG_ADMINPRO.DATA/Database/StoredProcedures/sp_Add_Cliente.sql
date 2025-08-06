USE Consultorio_Seguros
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Add_Cliente]
	@Cedula NVARCHAR(10),
    @NombreCliente NVARCHAR(40),
    @Telefono NVARCHAR(10),
    @Edad INT,
	@Resultado INT OUTPUT
AS
BEGIN
	SET XACT_ABORT ON; 
    IF NOT EXISTS (SELECT 1 FROM Clientes WHERE Cedula = @Cedula)
        BEGIN
            INSERT INTO Clientes (Cedula, NombreCliente, Telefono, Edad)
            VALUES (@Cedula, @NombreCliente, @Telefono, @Edad);
		    SET @Resultado = 1;
        END
    ELSE
        BEGIN
            SET @Resultado = 0;
        END
END;

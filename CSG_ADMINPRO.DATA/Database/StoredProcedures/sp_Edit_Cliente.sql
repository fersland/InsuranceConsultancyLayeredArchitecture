use consultorio_seguros

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_Edit_Cliente]
    @Id INT,
    @Cedula NVARCHAR(10),
    @NombreCliente NVARCHAR(40),
    @Telefono NVARCHAR(10),
    @Edad INT
AS
BEGIN
    -- Verificar si la nueva cédula ya existe en otro cliente
    IF EXISTS (SELECT 1 FROM Clientes WHERE Cedula = @Cedula AND Id != @Id)
		BEGIN
			RAISERROR('Ya existe otro cliente con la misma cédula.', 16, 1);
		END
    ELSE
    BEGIN
        -- Actualizar los datos del cliente
        UPDATE Clientes
        SET Cedula = @Cedula,
            NombreCliente = @NombreCliente,
            Telefono = @Telefono,
            Edad = @Edad
        WHERE Id = @Id;
    END
END;
GO

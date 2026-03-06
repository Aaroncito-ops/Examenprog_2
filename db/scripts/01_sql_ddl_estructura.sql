USE test_utm_ACM;
GO

-- Eliminación de tablas en orden inverso para evitar conflictos de FK
IF OBJECT_ID('dbo.DetallePedido', 'U') IS NOT NULL DROP TABLE dbo.DetallePedido;
IF OBJECT_ID('dbo.Pedido', 'U') IS NOT NULL DROP TABLE dbo.Pedido;
IF OBJECT_ID('dbo.Restaurante', 'U') IS NOT NULL DROP TABLE dbo.Restaurante;
GO

-- Tabla de Restaurantes
CREATE TABLE Restaurante (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Especialidad NVARCHAR(100) NOT NULL,
    HorarioApertura TIME NOT NULL,
    HorarioCierre TIME NOT NULL
);

-- Tabla de Pedidos (Maestro)
CREATE TABLE Pedido (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Usuario NVARCHAR(100) NOT NULL,
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    CostoEnvio DECIMAL(18, 2) NOT NULL DEFAULT 0.00
);

-- Tabla de Detalle de Pedidos
CREATE TABLE DetallePedido (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PedidoId INT NOT NULL,
    RestauranteId INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(18, 2) NOT NULL,
    CONSTRAINT FK_Detalle_Pedido FOREIGN KEY (PedidoId) REFERENCES Pedido(Id),
    CONSTRAINT FK_Detalle_Restaurante FOREIGN KEY (RestauranteId) REFERENCES Restaurante(Id)
);
GO

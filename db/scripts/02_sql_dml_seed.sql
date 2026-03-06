USE test_utm_ACM;
GO

-- Insertar Restaurantes (12-15 registros con temática universitaria)
INSERT INTO Restaurante (Nombre, Especialidad, HorarioApertura, HorarioCierre) VALUES 
('Comedor Central UTM', 'Buffet Estudiantil', '07:00', '18:00'),
('La Facultad del Taco', 'Tacos y Tortas', '09:00', '21:00'),
('Pizza de Ingeniería', 'Pizzas y Pastas', '11:00', '22:00'),
('Café de Humanidades', 'Desayunos y Café', '07:30', '17:00'),
('El Cubo de Medicina', 'Ensaladas y Comida Saludable', '08:00', '19:00'),
('Sándwiches de Ciencias', 'Lonches Rápidos', '09:00', '16:00'),
('Tostadas de Derecho', 'Antojitos Mexicanos', '10:00', '20:00'),
('Arquitectura Snacks', 'Cafetería Gourmet', '08:30', '18:30'),
('Laboratorio de Hamburguesas', 'Comida Americana', '12:00', '23:00'),
('Sushi de Administración', 'Comida Oriental', '13:00', '21:00'),
('Eco-Comedor Agronomía', 'Productos Orgánicos', '07:00', '15:00'),
('Design Deli', 'Comida Internacional', '09:00', '19:00'),
('Rincón de los Idiomas', 'Crepas y Waffles', '10:00', '21:00'),
('Sport Bar Educación Física', 'Proteínas y Smoothies', '06:30', '20:00'),
('La Biblioteca del Sabor', 'Platillos Tradicionales', '11:00', '19:00');
GO

-- Insertar Pedidos Históricos (5 registros)
INSERT INTO Pedido (Usuario, Fecha, CostoEnvio) VALUES 
('JuanPerez', '2026-03-01 12:30:00', 15.00),
('MariaGomez', '2026-03-02 13:45:00', 20.00),
('CarlosRuiz', '2026-03-03 14:15:00', 10.00),
('AnaLopez', '2026-03-04 19:20:00', 25.00),
('JuanPerez', '2026-03-05 09:00:00', 12.00);
GO

-- Insertar Detalles de Pedidos (Relacionando con IDs generados)
-- Se asume que los IDs de Restaurante son 1-15 y los de Pedido son 1-5
INSERT INTO DetallePedido (PedidoId, RestauranteId, Cantidad, PrecioUnitario) VALUES 
(1, 1, 2, 45.00),  -- Pedido 1: Comedor Central
(1, 3, 1, 120.00), -- Pedido 1: Pizza
(2, 5, 1, 85.00),  -- Pedido 2: Cubo de Medicina
(2, 6, 2, 35.00),  -- Pedido 2: Sándwiches
(3, 9, 3, 95.00),  -- Pedido 3: Laboratorio de Hamburguesas
(4, 10, 2, 110.00),-- Pedido 4: Sushi
(5, 4, 1, 55.00),  -- Pedido 5: Café
(5, 13, 2, 70.00); -- Pedido 5: Rincón de los Idiomas
GO

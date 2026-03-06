# Prompt 1: Definición de Estructura de Base de Datos (DDL)

*Rol:* Arquitecto de Bases de Datos Senior.
*Contexto:* SQL Server 2022 (Plan gratuito Somee, límite 30MB).
*Tarea:* Generar un script SQL para la creación de tablas del sistema "FoodCampus".

*Requisitos Técnicos:*
1. Crear tablas: Restaurante (Id, Nombre [Not Null], Especialidad, HorarioApertura, HorarioCierre), Pedido (IdPedido, IdUsuario, FechaHora, CostoEnvio) y DetallePedido (IdDetalle, IdPedido, IdPlatillo, Cantidad, Subtotal).
2. Usar INT IDENTITY(1,1) para todas las Primary Keys.
3. Usar DECIMAL(19,4) para campos monetarios y NVARCHAR para soporte Unicode.
4. Restricciones: 
   - CHECK en Pedido: CostoEnvio >= 0.
   - CHECK en DetallePedido: Cantidad > 0.
5. Idempotencia: El script debe usar IF NOT EXISTS para evitar errores en ejecuciones repetidas.
6. Optimización: Ajustar tamaños de VARCHAR para no desperdiciar espacio en la cuota de 30MB.
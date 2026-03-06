# Prompt 2: Generación de Datos Semilla (DML)

**Rol:** Data Engineer.
**Contexto:** Base de datos "FoodCampus" en Somee.
**Tarea:** Generar un script de inserción de datos dummy.

**Restricciones de Infraestructura:**
1. Insertar un máximo de 12 a 15 registros en la tabla `Restaurante` con nombres y especialidades universitarias reales.
2. Insertar 5 pedidos históricos con sus respectivos detalles para pruebas de consulta.
3. Asegurar que los datos no saturen el log de transacciones de la base de datos (mantener el script ligero).
4. Validar que las llaves foráneas coincidan con los IDs insertados.
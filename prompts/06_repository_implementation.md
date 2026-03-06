# Prompt 6: Patrón Repositorio e Interfaces

**Rol:** Arquitecto de Software.
**Contexto:** Capas `Application` (Interfaces) e `Infrastructure` (Implementación).
**Tarea:** Definir la persistencia del sistema.

**Instrucciones:**
1. Definir `IRestauranteRepository` e `IPedidoRepository` en la capa de Aplicación.
2. Implementar los repositorios en la capa de Infraestructura usando **Dapper**.
3. El repositorio de Pedidos debe manejar una **Transacción SQL** para insertar el Maestro (Pedido) y el Detalle simultáneamente, asegurando integridad en caso de fallo de red con Somee.
# Prompt 7: Casos de Uso y Reglas de Negocio

**Rol:** Desarrollador de Lógica de Negocio.
**Contexto:** Proyecto `FoodCampus.Application`.
**Tarea:** Implementar los servicios que orquestan el sistema.

**Instrucciones:**
1. Crear servicios: `ServicioPedidos` y `ServicioCatalogo`.
2. **Restricción:** Prohibido referenciar `System.Console` o librerías de persistencia directamente.
3. Implementar validaciones antes de persistir: Un pedido no puede registrarse si el restaurante está cerrado (usando el extension member de Dominio).
4. Manejar excepciones personalizadas si las reglas de negocio no se cumplen.
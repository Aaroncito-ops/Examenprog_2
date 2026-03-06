# Prompt 3: Entidades de Dominio (C# 14 Features)

**Rol:** Desarrollador Backend Senior.
**Contexto:** Proyecto `FoodCampus.Domain` (Cero dependencias).
**Tarea:** Crear las entidades `Restaurante`, `Pedido` y `DetallePedido`.

**Requisitos de C# 14:**
1. **Keyword `field`:** Implementar las propiedades `Cantidad` (DetallePedido) y `CostoEnvio` (Pedido) usando la nueva palabra clave `field` en el setter para validar que no sean valores negativos o inválidos, evitando campos privados manuales.
2. **Extension Members:** Crear una propiedad de extensión estática llamada `EstaAbierto` que determine si un restaurante puede dar servicio comparando `TimeSpan.FromTicks(DateTime.Now.Ticks)` con sus campos de horario.
3. Usar **File-scoped namespaces** y **Primary Constructors** donde sea posible para un código limpio.
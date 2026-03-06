# Prompt 05: Extensiones de Mapeo (ToDomain, ToDTO)

Actúa como un desarrollador senior en C#. Genera una clase estática `MappingExtensions` en `FoodCampus.Application.Mappers` para el proyecto "FoodCampus". 
Incluir:
1. Métodos de extensión para convertir modelos de infraestructura a entidades de dominio (ToDomain): `RestauranteModel`, `PedidoModel` (incluyendo `Usuario`), `DetallePedidoModel`.
2. Métodos de extensión para convertir entidades de dominio a DTOs de presentación (ToDTO): `RestauranteDTO`, `PedidoDTO` (que acepte `totalCalculado` y asigne `Usuario`), `DetallePedidoDTO` (que acepte `restauranteNombre`).
3. DTOs correspondientes en el namespace `FoodCampus.Application.DTOs`.

Asegura un diseño limpio y que los DTOs utilicen `record` o clases inmutables. Genera solo el código C#.

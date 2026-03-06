# Prompt 4: Modelos de Persistencia (Dapper/EF)

**Rol:** Experto en Acceso a Datos.
**Contexto:** Proyecto `FoodCampus.Infrastructure`.
**Tarea:** Crear los modelos de datos que representen las tablas de SQL Server.

**Instrucciones:**
1. Crear POCOs (Plain Old CLR Objects) que mapeen exactamente con las columnas del script SQL DDL.
2. Asegurar que los tipos de datos sean compatibles con Dapper (int, decimal, string, DateTime).
3. Incluir atributos de `System.ComponentModel.DataAnnotations.Schema` si los nombres de las propiedades difieren de las columnas de la DB.
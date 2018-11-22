# TestDGT
Prueba Senior TestDGT

# Comentarios

La solución se compone de dos proyectos, una libreria que contiene los modelos y el repositorio y un proyecto de Consola para realizar las pruebas solicitadas en los requisitos funcionales

Se incluye un Diagrama de Clases (PNG) en el raiz de la solución.
Se incluye tambien el ejecutable de Consola para probar la aplicación ubicado en el raiz de la solución (TestDGT.exe)

La libreria de Clases implementa el patrón Repository de forma estandar, que permite centralizar y abstraer la capa de datos como ejemplo de 
una implementación real.

# FALTAS 
 
- Se excluye alguno de los requisitos funcionales por falta de practica concretamente en el uso de Linq, al haber implementado el objeto data como una coleccion
Concretamente y a modo de muestra, el caso de la consulta de los 5 tipos de infraccion más habituales, podría realizarlo en TSQL mediante la siguiente consulta

"select top(5) tipo,sum(puntos) from tipo_infraccion ti 
inner join infracciones i on i.id_tipo=ti.id
group by tipo
order by sum(puntos) desc" 

- Tampoco se detalla todo lo que debería el diagrama de clases (que se ha generado a partir de Visual Studio...deformación profesional) 
- Las condiciones de los requisitos funcionales, se controlan desde código, como el control del numero de instancias (maximo 10) de Vehiculo a Conductor
- La documentación tampoco se ha podido generar aunque en se ha probado con la herramienta DocfX , no he logrado generar la documentación de una forma "correcta"
en su defecto se ha tratado de documentar el codigo y generarl los comentarios y el archivo de documentacion en XML mediante Visual Studio.

Gracias 








--Listar Empleados por Departamento: (LISTO)
SELECT e.Nombre, e.Apellido, d.NombreDep AS Departamento
FROM Empleado e
INNER JOIN Departamento d ON e.IdDep = d.IdDep;

--Cantidad de Empleados por Departamento: (LISTO)
SELECT d.NombreDep AS Departamento, COUNT(e.IdEmp) AS CantidadEmpleados
FROM Departamento d
INNER JOIN Empleado e ON d.IdDep = e.IdDep
GROUP BY d.NombreDep;

-- Obtener la lista de empleados que trabajan en un proyecto espec�fico: (LISTO)
SELECT e.Nombre, e.Apellido
FROM Empleado e
INNER JOIN ProyectoEmpleado pe ON e.IdEmp = pe.IdEmpleado
WHERE pe.IdProyecto = 1;

-- Obtener el empleado y departamento de un proyecto y hora (LISTO)
SELECT e.Nombre, e.Apellido, d.NombreDep AS Departamento
FROM Empleado e
INNER JOIN Horario h ON e.IdHorario = h.IdHorario
INNER JOIN ProyectoEmpleado pe ON e.IdEmp = pe.IdEmpleado
INNER JOIN Proyecto p ON pe.IdProyecto = p.IdProyecto
INNER JOIN Departamento d ON e.IdDep = d.IdDep
WHERE p.NombreProyecto = 'Proyecto D'
AND h.HoraEntrada = '08:00'
AND h.HoraSalida = '17:00';

-- Proyectos y Empleados Asignados: (LISTO)
SELECT p.NombreProyecto AS Proyecto, e.Nombre, e.Apellido
FROM ProyectoEmpleado pe
INNER JOIN Proyecto p ON pe.IdProyecto = p.IdProyecto
INNER JOIN Empleado e ON pe.IdEmpleado = e.IdEmp;


--Listar Empleados por Departamento:
SELECT e.Nombre, e.Apellido, d.NombreDep AS Departamento
FROM Empleado e
INNER JOIN Departamento d ON e.IdDep = d.IdDep;

-- Proyectos Asignados a un Supervisor:
SELECT s.Nombre AS Supervisor, p.NombreProyecto AS Proyecto
FROM Supervisor s
INNER JOIN Proyecto p ON s.IdProyecto = p.IdProyecto;

-- Horarios de Trabajo de Empleados:
SELECT e.Nombre, e.Apellido, h.HoraEntrada, h.HoraSalida
FROM Empleado e
INNER JOIN Horario h ON e.IdHorario = h.IdHorario;

--Cantidad de Empleados por Departamento:
SELECT d.NombreDep AS Departamento, COUNT(e.IdEmp) AS CantidadEmpleados
FROM Departamento d
LEFT JOIN Empleado e ON d.IdDep = e.IdDep
GROUP BY d.NombreDep;

-- Proyectos y Empleados Asignados:
SELECT p.NombreProyecto AS Proyecto, e.Nombre, e.Apellido
FROM ProyectoEmpleado pe
INNER JOIN Proyecto p ON pe.IdProyecto = p.IdProyecto
INNER JOIN Empleado e ON pe.IdEmpleado = e.IdEmp;

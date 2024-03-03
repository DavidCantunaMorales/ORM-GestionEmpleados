INSERT INTO Departamento (NombreDep, DescripcionDep) VALUES
('Recursos Humanos', 'Gestión de personal'),
('Desarrollo', 'Equipo de desarrollo de software'),
('Ventas', 'Departamento de ventas'),
('Contabilidad', 'Gestión financiera'),
('Soporte Técnico', 'Asistencia técnica a clientes'),
('Marketing', 'Promoción y publicidad'),
('Operaciones', 'Gestión operativa'),
('Calidad', 'Control de calidad'),
('Innovación', 'Desarrollo de nuevas tecnologías'),
('Logística', 'Gestión de la cadena de suministro');

INSERT INTO Horario (HoraEntrada, HoraSalida) VALUES
('08:00', '17:00'),
('09:00', '18:00'),
('07:30', '16:30'),
('08:30', '17:30'),
('09:30', '18:30'),
('07:00', '16:00'),
('08:00', '16:00'),
('10:00', '19:00'),
('07:30', '15:30'),
('09:00', '17:00');

INSERT INTO Empleado (IdDep, IdHorario, Nombre, Apellido, Direccion, Telefono, Correo) VALUES
(1, 1, 'Juan', 'Pérez', 'Calle A 123', '555-1234', 'juan@email.com'),
(2, 2, 'María', 'Gómez', 'Avenida B 456', '555-5678', 'maria@email.com'),
(3, 3, 'Carlos', 'López', 'Calle C 789', '555-9876', 'carlos@email.com'),
(4, 4, 'Laura', 'Martínez', 'Avenida D 012', '555-3456', 'laura@email.com'),
(5, 5, 'Sofía', 'Ruiz', 'Calle E 345', '555-6789', 'sofia@email.com'),
(6, 6, 'Javier', 'Díaz', 'Avenida F 678', '555-2345', 'javier@email.com'),
(7, 7, 'Ana', 'Hernández', 'Calle G 901', '555-7890', 'ana@email.com'),
(8, 8, 'Daniel', 'García', 'Avenida H 234', '555-4567', 'daniel@email.com'),
(9, 9, 'Marta', 'Sánchez', 'Calle I 567', '555-8901', 'marta@email.com'),
(10, 10, 'Luis', 'Rodríguez', 'Avenida J 890', '555-1231', 'luis@email.com'),
(1, 1, 'Eva', 'Fernández', 'Calle K 123', '555-4560', 'eva@email.com'),
(2, 2, 'Roberto', 'Torres', 'Avenida L 456', '555-7891', 'roberto@email.com'),
(3, 3, 'Carmen', 'Vargas', 'Calle M 789', '555-0123', 'carmen@email.com'),
(4, 4, 'Pablo', 'Iglesias', 'Avenida N 012', '555-3457', 'pablo@email.com'),
(5, 5, 'Natalia', 'Pérez', 'Calle O 345', '555-6780', 'natalia@email.com'),
(6, 6, 'Adrián', 'Martínez', 'Avenida P 678', '555-2346', 'adrian@email.com'),
(7, 7, 'Isabel', 'Gómez', 'Calle Q 901', '555-7892', 'isabel@email.com'),
(8, 8, 'Diego', 'Hernández', 'Avenida R 234', '555-4568', 'diego@email.com'),
(9, 9, 'Lorena', 'García', 'Calle S 567', '555-8902', 'lorena@email.com'),
(10, 10, 'Oscar', 'Sánchez', 'Avenida T 890', '555-1230', 'oscar@email.com'),
(1, 1, 'Alejandra', 'Hernández', 'Calle UU 123', '555-1112', 'alejandra25@email.com'),
(1, 1, 'Gustavo', 'López', 'Avenida VV 456', '555-2224', 'gustavo2@email.com'),
(1, 1, 'Valeria', 'Sánchez', 'Calle WW 789', '555-1236', 'valeria12@email.com'),
(2, 2, 'Felipe', 'Gómez', 'Avenida XX 012', '555-4444', 'felipe32@email.com'),
(2, 2, 'Rocío', 'Martínez', 'Calle YY 345', '555-5555', 'rocio@email.com'),
(2, 2, 'Santiago', 'Ruiz', 'Avenida ZZ 678', '555-6666', 'santiago@email.com'),
(3, 3, 'Camila', 'Hernández', 'Calle AAA 901', '555-7777', 'camila@email.com'),
(3, 3, 'Fernando', 'García', 'Avenida BBB 234', '555-8888', 'fernando@email.com'),
(3, 3, 'Mariana', 'Sánchez', 'Calle CCC 567', '555-9999', 'mariana@email.com'),
(4, 4, 'Andrés', 'Rodríguez', 'Avenida DDD 890', '555-1010', 'andres@email.com'),
(4, 4, 'Valentina', 'Fernández', 'Calle EEE 123', '555-2020', 'valentina@email.com'),
(4, 4, 'Martín', 'Torres', 'Avenida FFF 456', '555-3030', 'martin@email.com'),
(5, 5, 'Lucas', 'Vargas', 'Calle GGG 789', '555-4040', 'lucas@email.com'),
(5, 5, 'Catalina', 'Iglesias', 'Avenida HHH 012', '555-5050', 'catalina@email.com'),
(5, 5, 'Facundo', 'Pérez', 'Calle III 345', '555-6060', 'facundo@email.com'),
(6, 6, 'Agustina', 'Martínez', 'Avenida JJJ 678', '555-7070', 'agustina@email.com'),
(6, 6, 'Renato', 'Gómez', 'Calle KKK 901', '555-8080', 'renato@email.com'),
(6, 6, 'Clara', 'Hernández', 'Avenida LLL 234', '555-9090', 'clara@email.com'),
(8, 2, 'Julián', 'Fernández', 'Calle NNN 567', '555-3412', 'julian3@email.com'),
(8, 2, 'Isabella', 'López', 'Avenida OOO 890', '555-6123', 'isabella21@email.com'),
(8, 2, 'Roberto', 'Martínez', 'Calle PPP 234', '555-7897', 'roberto21@email.com'),
(8, 9, 'Mónica', 'Gómez', 'Calle QQQ 678', '555-3452', 'monica@email.com'),
(8, 9, 'Hugo', 'Sánchez', 'Avenida RRR 901', '555-6787', 'hugo@email.com'),
(8, 9, 'Lucía', 'Martínez', 'Calle SSS 234', '555-7898', 'lucia@email.com'),
(9, 2, 'Gabriel', 'Fernández', 'Avenida TTT 567', '555-1435', 'gabriel32@email.com'),
(9, 2, 'Silvia', 'Gómez', 'Calle UUU 890', '555-6788', 'silvia32@email.com'),
(9, 3, 'Raúl', 'Sánchez', 'Avenida VVV 123', '555-7899', 'raul@email.com'),
(9, 3, 'Valentina', 'Fernández', 'Calle WWW 456', '555-3454', 'valentina3@email.com'),
(9, 1, 'Joaquín', 'López', 'Avenida XXX 789', '555-6700', 'joaquin@email.com'),
(9, 1, 'Camila', 'Martínez', 'Calle YYY 012', '555-7900', 'camila12@email.com'),
(10, 2, 'Francisco', 'Gómez', 'Avenida ZZZ 345', '555-3423', 'francisco21@email.com'),
(10, 2, 'Rocío', 'López', 'Calle AAAA 678', '555-6318', 'rocio12@email.com'),
(10, 2, 'Javier', 'Fernández', 'Avenida BBBB 901', '555-7901', 'javier32@email.com');



INSERT INTO Proyecto (NombreProyecto, DescripcionProyecto, FechaInicio, FechaFin) VALUES
('Proyecto A', 'Desarrollo de software de gestión', '2024-03-01', '2024-06-30'),
('Proyecto B', 'Implementación de sistema de ventas', '2024-04-15', '2024-08-31'),
('Proyecto C', 'Rediseño de la infraestructura', '2024-03-10', '2024-07-15'),
('Proyecto D', 'Desarrollo de aplicación móvil', '2024-05-01', '2024-09-30'),
('Proyecto E', 'Diseño de interfaz de usuario', '2024-04-01', '2024-08-15'),
('Proyecto F', 'Implementación de estrategia de marketing', '2024-03-15', '2024-07-30'),
('Proyecto G', 'Optimización de procesos operativos', '2024-05-15', '2024-10-15'),
('Proyecto H', 'Desarrollo de nuevas tecnologías', '2024-04-01', '2024-09-15'),
('Proyecto I', 'Implementación de sistema de logística', '2024-03-15', '2024-07-31'),
('Proyecto J', 'Desarrollo de aplicación web', '2024-05-01', '2024-09-30');

INSERT INTO Supervisor (IdDep, IdHorario, IdProyecto, Nombre, Apellido, Direccion, Telefono, Correo) VALUES
(1, 1, 1, 'Alejandro', 'Fernández', 'Calle U 123', '555-6789', 'alejandro@email.com'),
(2, 2, 2, 'Gabriela', 'López', 'Avenida V 456', '555-2345', 'gabriela@email.com'),
(3, 3, 3, 'Hugo', 'Sánchez', 'Calle W 789', '555-7890', 'hugo@email.com'),
(1, 1, 4, 'Irene', 'Gómez', 'Avenida X 012', '555-3456', 'irene@email.com'),
(2, 2, 5, 'Juan', 'Martínez', 'Calle Y 345', '555-6780', 'juan@email.com'),
(3, 3, 6, 'Karla', 'Díaz', 'Avenida Z 678', '555-2346', 'karla@email.com'),
(1, 1, 7, 'Luisa', 'Hernández', 'Calle AA 901', '555-7891', 'luisa@email.com'),
(2, 2, 8, 'Miguel', 'García', 'Avenida BB 234', '555-3457', 'miguel@email.com'),
(3, 3, 9, 'Natalia', 'Sánchez', 'Calle CC 567', '555-6788', 'natalia@email.com'),
(1, 1, 10, 'Oscar', 'Rodríguez', 'Avenida DD 890', '555-2347', 'oscar@email.com');


-- Proyecto 1: 5 empleados
INSERT INTO ProyectoEmpleado (IdProyecto, IdEmpleado) VALUES
(1, 1), (1, 2), (1, 3), (1, 4), (1, 5);

-- Proyecto 2: 10 empleados
INSERT INTO ProyectoEmpleado (IdProyecto, IdEmpleado) VALUES
(2, 6), (2, 7), (2, 8), (2, 9), (2, 10), (2, 11), (2, 12), (2, 13), (2, 14), (2, 15);

-- Proyecto 3: 15 empleados
INSERT INTO ProyectoEmpleado (IdProyecto, IdEmpleado) VALUES
(3, 16), (3, 17), (3, 18), (3, 19), (3, 20), (3, 21), (3, 22), (3, 23), (3, 24), (3, 25),
(3, 26), (3, 27), (3, 28), (3, 29), (3, 30);

-- Proyecto 4: 20 empleados
INSERT INTO ProyectoEmpleado (IdProyecto, IdEmpleado) VALUES
(4, 31), (4, 32), (4, 33), (4, 34), (4, 35), (4, 36), (4, 37), (4, 38), (4, 39), (4, 40),
(4, 41), (4, 42), (4, 43), (4, 44), (4, 45), (4, 46), (4, 47), (4, 48), (4, 49), (4, 50);

-- Proyecto 5: 25 empleados
INSERT INTO ProyectoEmpleado (IdProyecto, IdEmpleado) VALUES
(5, 51), (5, 52), (5, 53), (5, 1), (5, 2), (5, 3), (5, 4), (5, 5), (5, 6), (5, 7),
(5, 8), (5, 9), (5, 10), (5, 11), (5, 12), (5, 13), (5, 14), (5, 15), (5, 16), (5, 17),
(5, 18), (5, 19), (5, 20), (5, 21), (5, 22);

-- Proyecto 6: 30 empleados
INSERT INTO ProyectoEmpleado (IdProyecto, IdEmpleado) VALUES
(6, 23), (6, 24), (6, 25), (6, 26), (6, 27), (6, 28), (6, 29), (6, 30), (6, 31), (6, 32),
(6, 33), (6, 34), (6, 35), (6, 36), (6, 37), (6, 38), (6, 39), (6, 40), (6, 41), (6, 42),
(6, 43), (6, 44), (6, 45), (6, 46), (6, 47), (6, 48), (6, 49), (6, 50), (6, 51), (6, 52);

-- Proyecto 7: 35 empleados
INSERT INTO ProyectoEmpleado (IdProyecto, IdEmpleado) VALUES
(7, 1), (7, 2), (7, 3), (7, 4), (7, 5), (7, 6), (7, 7), (7, 8), (7, 9), (7, 10),
(7, 11), (7, 12), (7, 13), (7, 14), (7, 15), (7, 16), (7, 17), (7, 18), (7, 19), (7, 20),
(7, 21), (7, 22), (7, 23), (7, 24), (7, 25), (7, 26), (7, 27), (7, 28), (7, 29), (7, 30),
(7, 31), (7, 32), (7, 33), (7, 34), (7, 35);

-- Proyecto 8: 40 empleados
INSERT INTO ProyectoEmpleado (IdProyecto, IdEmpleado) VALUES
(8, 36), (8, 37), (8, 38), (8, 39), (8, 40), (8, 41), (8, 42), (8, 43), (8, 44), (8, 45),
(8, 46), (8, 47), (8, 48), (8, 49), (8, 50), (8, 51), (8, 52), (8, 53), (8, 1), (8, 2),
(8, 3), (8, 4), (8, 5), (8, 6), (8, 7), (8, 8), (8, 9), (8, 10), (8, 11), (8, 12),
(8, 13), (8, 14), (8, 15), (8, 16), (8, 17), (8, 18), (8, 19), (8, 20), (8, 21), (8, 22);

-- Proyecto 9: 45 empleados
INSERT INTO ProyectoEmpleado (IdProyecto, IdEmpleado) VALUES
(9, 23), (9, 24), (9, 25), (9, 26), (9, 27), (9, 28), (9, 29), (9, 30), (9, 31), (9, 32),
(9, 33), (9, 34), (9, 35), (9, 36), (9, 37), (9, 38), (9, 39), (9, 40), (9, 41), (9, 42),
(9, 43), (9, 44), (9, 45), (9, 46), (9, 47), (9, 48), (9, 49), (9, 50), (9, 51), (9, 52),
(9, 53), (9, 1), (9, 2), (9, 3), (9, 4), (9, 5), (9, 6), (9, 7), (9, 8), (9, 9),
(9, 10), (9, 11), (9, 12), (9, 13), (9, 14), (9, 15), (9, 16), (9, 17), (9, 18), (9, 19);

-- Proyecto 10: 53 empleados
INSERT INTO ProyectoEmpleado (IdProyecto, IdEmpleado) VALUES
(10, 20), (10, 21), (10, 22), (10, 23), (10, 24), (10, 25), (10, 26), (10, 27), (10, 28), (10, 29),
(10, 30), (10, 31), (10, 32), (10, 33), (10, 34), (10, 35), (10, 36), (10, 37), (10, 38), (10, 39),
(10, 40), (10, 41), (10, 42), (10, 43), (10, 44), (10, 45), (10, 46), (10, 47), (10, 48), (10, 49),
(10, 50), (10, 51), (10, 52), (10, 53), (10, 1), (10, 2), (10, 3), (10, 4), (10, 5), (10, 6),
(10, 7), (10, 8), (10, 9), (10, 10), (10, 11), (10, 12), (10, 13), (10, 14), (10, 15), (10, 16),
(10, 17), (10, 18), (10, 19);


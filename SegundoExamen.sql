create database SistemaMantenimiento
go

use SistemaMantenimiento
go

--Creación de la tabla de usuarios
create table Usuarios
(
UsiarioID int primary key identity(1,1),
Nombre varchar(50),
CorreoElectronico varchar(100),
Telefono varchar(13)
)

--Añadir usuario
insert into Usuarios (Nombre, CorreoElectronico, Telefono) values ('Sofía', 'sofia@gmail.com', '23-456-789')

--Modificar usuario
update Usuarios set Telefono = '123-456-789' where UsiarioID = 1

--Eliminar usuario
delete from Usuarios where UsiarioID = 1

--Consultar tabla
select * from Usuarios

--Creación de la tabla de equipos
create table Equipos
(
EquipoID int primary key identity(1,1),
TipoEquipo varchar(50),
Modelo varchar(50),
UsuarioID int foreign key references Usuarios
)

--Añadir equipo
insert into Equipos (TipoEquipo, Modelo, UsuarioID) values ('Móvil', 'Samsung Galaxy S24 Ultra', 1)

--Modificar equipo
update Equipos set Modelo = 'Samsung Galaxy S24 FE' where EquipoID = 1

--Eliminar equipo
delete from Equipos where EquipoID = 1

--Consultar tabla
select * from Equipos

--Creación de la tabla de reparaciones
create table Reparaciones
(
ReparacionID int primary key identity(1,1),
EquipoID int foreign key references Equipos,
FechaSolicitud date,
Estado varchar(20)
)

--Creación de la tabla de DetallesReparaciones
create table DetallesReparacion
(
DetalleID int primary key identity(1,1),
ReparacionID int foreign key references Reparaciones,
Descripcion varchar(500),
FechaInicio date,
FechaFin date
)

--Cración de la tabla técnicos
create table Tecnicos
(
TecnicoID int primary key identity(1,1),
Nombre varchar(50),
Especialidad varchar(20)
)

--Añadir técnico
insert into Tecnicos (Nombre, Especialidad) values ('Felipe', 'Móviles')

--Modificar técnico
update Tecnicos set Nombre = 'Denzel' where TecnicoID = 1

--Eliminar técnico
delete from Tecnicos where TecnicoID = 1

--Consultar tabla
select * from Tecnicos

--Creación de la tabla asignaciones
create table Asignaciones
(
AsignacionID int primary key identity(1,1),
ReparacionID int foreign key references Reparaciones,
TecnicoID int foreign key references Tecnicos,
FechaAsignacion date
)

--Creación del procedimiento para ingresar usuarios
create procedure IngresarUsuario
@nombre varchar(50),
@correoElectronico varchar(100),
@telefono varchar(13)
as
	begin
		insert into Usuarios (Nombre, CorreoElectronico, Telefono) values (@nombre, @correoElectronico, @telefono)
	end

--Creación del procedimiento para modificar usuarios
create procedure ModificarUsuario
@id int,
@nombre varchar(50),
@correoElectronico varchar(100),
@telefono varchar(13)
as
	begin
		update Usuarios set Nombre = @nombre, CorreoElectronico = @correoElectronico, Telefono = @telefono where UsiarioID = @id
	end

--Creación del procedimiento para eliminar usuarios
create procedure BorrarUsuario
@id int
as
	begin
		delete Usuarios where UsiarioID = @id
	end

--Creación del procedimiento para consultar usuarios
create procedure ConsultarUsiarios
as
	begin
		select UsiarioID, Nombre, CorreoElectronico, Telefono from Usuarios
	end

--Creación del procedimiento para ingresar equipos
create procedure IngresarEquipos
@tipoEquipo varchar(50),
@modelo varchar(50),
@usuarioId int
as
	begin
		insert into Equipos (TipoEquipo, Modelo, UsuarioID) values (@tipoEquipo, @modelo, @usuarioId)
	end

--Creación del procedimiento para modificar equipos
create procedure ModificarEquipos
@id int,
@tipoEquipo varchar(50),
@modelo varchar(50),
@usuarioId int
as
	begin
		update Equipos set TipoEquipo = @tipoEquipo, Modelo = @modelo, UsuarioID = @usuarioId where EquipoID = @id
	end

--Creación del procedimiento para eliminar equipos
create procedure BorrarEquipos
@id int
as
	begin
		delete Equipos where EquipoID = @id
	end

--Creación del procedimiento para consultar equipos
create procedure ConsultarEquipos
as
	begin
		select EquipoID, TipoEquipo, Modelo, UsuarioID from Equipos
	end

--Creación del procedimiento para ingresar reparaciones
create procedure IngresarReparaciones
@equipoId int,
@fechaSolicitud date,
@estado varchar(20)
as
	begin
		insert into Reparaciones (EquipoID, FechaSolicitud, Estado) values (@equipoId, @fechaSolicitud, @estado)
	end

--Creación del procedimiento para modificar reparaciones
create procedure ModificarReparaciones
@id int,
@equipoId int,
@fechaSolicitud date,
@estado varchar(20)
as
	begin
		update Reparaciones set EquipoID = @equipoId, FechaSolicitud = @fechaSolicitud, Estado = @estado where ReparacionID = @id
	end

--Creación del procedimiento para eliminar reparaciones
create procedure BorrarReparaciones
@id int
as
	begin
		delete Reparaciones where ReparacionID = @id
	end

--Creación del procedimiento para consultar reparaciones
create procedure ConsultarReparaciones
as
	begin
		select ReparacionID, EquipoID, FechaSolicitud, Estado from Reparaciones
	end

--Creación del procedimiento para ingresar detalles de reparación
create procedure IngresarDetallesReparacion
@reparacionId int,
@descripcion varchar(500),
@fechaInicio date,
@fechaFin date
as
	begin
		insert into DetallesReparacion (ReparacionID, Descripcion, FechaInicio, FechaFin) values (@reparacionId, @descripcion, @fechaInicio, @fechaFin)
	end

--Creación del procedimiento para modificar detalles de reparación
create procedure ModificarDetallesReparacion
@id int,
@reparacionId int,
@descripcion varchar(500),
@fechaInicio date,
@fechaFin date
as
	begin
		update DetallesReparacion set ReparacionID = @reparacionId, Descripcion = @descripcion, FechaInicio = @fechaInicio, FechaFin = @fechaFin where DetalleID = @id
	end

--Creación del procedimiento para eliminar detalles de reparación
create procedure BorrarDetallesReparacion
@id int
as
	begin
		delete DetallesReparacion where DetalleID = @id
	end

--Creación del procedimiento para consultar detalles de reparación
create procedure ConsultarDetallesReparacion
as
	begin
		select DetalleID, ReparacionID, Descripcion, FechaInicio, FechaFin from DetallesReparacion
	end

--Creación del procedimiento para ingresar técnicos
create procedure IngresarTecnicos
@nombre varchar(50),
@especialidad varchar(20)
as
	begin
		insert into Tecnicos (Nombre, Especialidad) values (@nombre, @especialidad)
	end

--Creación del procedimiento para modificar técnicos
create procedure ModificarTecnicos
@id int,
@nombre varchar(50),
@especialidad varchar(20)
as
	begin
		update Tecnicos set Nombre = @nombre, Especialidad = @especialidad where TecnicoID = @id
	end

--Creación del procedimiento para eliminar técnicos
create procedure BorrarTecnicos
@id int
as
	begin
		delete Tecnicos where TecnicoID = @id
	end

--Creación del procedimiento para consultar técnicos
create procedure ConsultarTecnicos
as
	begin
		select TecnicoID, Nombre, Especialidad from Tecnicos
	end

--Creación del procedimiento para ingresar asignaciones
create procedure IngresarAsignaciones
@reparacionId int,
@tecnicoId int,
@fechaAsignacion date
as
	begin
		insert into Asignaciones (ReparacionID, TecnicoID, FechaAsignacion) values (@reparacionId, @tecnicoId, @fechaAsignacion)
	end

--Creación del procedimiento para midificar asignaciones
create procedure ModificarAsignaciones
@id int,
@reparacionId int,
@tecnicoId int,
@fechaAsignacion date
as
	begin
		update Asignaciones set ReparacionID = @reparacionId, TecnicoID = @tecnicoId, FechaAsignacion = @fechaAsignacion where AsignacionID = @id
	end

--Creación del procedimiento para eliminar asignaciones
create procedure BorrarAsignaciones
@id int
as
	begin
		delete Asignaciones where AsignacionID = @id
	end

--Creación del procedimiento para consultar asignaciones
create procedure ConsultarAsignaciones
as
	begin
		select AsignacionID, ReparacionID, TecnicoID, FechaAsignacion from Asignaciones
	end
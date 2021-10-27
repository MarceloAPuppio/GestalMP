use bdmarcelopuppio
go
--create table roles(
--nombre varchar(20)primary key
--) 
--go

--insert roles values('administrador')
--insert roles values('aspirante')
--insert roles values('alumno')
--insert roles values('profesor')
--insert roles values('preceptor')
--insert roles values('egresado')
--insert roles values('director de estudios')
--go
--========================================================================================================
--												USUARIOS
--========================================================================================================
create table usuarios(
id int identity(1,1) primary key,
nombre varchar(80) not null,
dni int unique not null,
domicilio varchar(80) not null,
telefono varchar(15)not null, 
mail varchar(80)not null unique,
fechanac date not null, 
password varchar(40) not null, 
estudios varchar(200)not null,
materiasadeudadas varchar(200) default '' 
) 
go

--Voy a agregar una columna nueva 11-10-21 22:29
alter table usuarios add url varchar(30) default 'images/usuarios/default.png' 


--hardcoding administrador password admin
insert usuarios values('admin',1,'adm','adm','admin@mail.com', CONVERT(date, GETDATE())
,'D033E22AE348AEB5660FC2140AEC35850C4DA997','adm','adm')
go

--Stored procedures de usuarios
alter procedure usuarios_insert(
@nombre varchar(80),
@dni int,
@domicilio varchar(80),
@telefono varchar(15),
@mail varchar(80),
@fechanac smalldatetime,
@password varchar(40),
@estudios varchar(200),
@materiasadeudadas varchar(200), 
@url varchar(30)
)
as begin
insert usuarios(
nombre,
dni,
domicilio,
telefono,
mail,
fechanac,
password,
estudios,
materiasadeudadas,
url
)
values(
@nombre,
@dni,
@domicilio,
@telefono,
@mail,
@fechanac,
@password,
@estudios,
@materiasadeudadas,
@url
)
select @@identity
end
go

alter procedure usuarios_update(
@id int,
@nombre varchar(80),
@dni int,
@domicilio varchar(80),
@telefono varchar(15),
@mail varchar(80),
@fechanac smalldatetime,
@password varchar(40),
@estudios varchar(200),
@materiasadeudadas varchar(200),
@url varchar(30)
)
as 
if @password ='' 
begin
update usuarios set 
nombre=@nombre,
dni=@dni,
domicilio=@domicilio,
telefono=@telefono,
mail=@mail,
fechanac=@fechanac,
estudios=@estudios,
materiasadeudadas=@materiasadeudadas,
url=@url
where id=@id
end
else
begin
update usuarios set 
nombre=@nombre,
dni=@dni,
domicilio=@domicilio,
telefono=@telefono,
mail=@mail,
fechanac=@fechanac,
password=@password,
estudios=@estudios,
materiasadeudadas=@materiasadeudadas,
url=@url
where id=@id
end
go

create procedure usuarios_delete(@id int)
as
delete usuarios where id=@id
go

create procedure usuarios_find(@id int)
as
select * from usuarios where id=@id
go

create procedure usuarios_findbymail(@mail varchar(80))
as
select * from usuarios where mail=@mail
go

create procedure usuarios_list
as
select * from usuarios
go

create procedure usuarios_login(@mail varchar(80),@password varchar(40))
as
select * from usuarios where mail=@mail and password=@password
go

create proc usuarios_mailexists(@id int, @mail varchar(80))
as
select count(*) from usuarios where id<>@id and mail=@mail
go

create proc usuarios_dniexists(@id int, @dni int)
as
select count(*) from usuarios where id<>@id and dni=@dni
go

exec usuarios_mailexists 4, 'daten@mail.com'
--========================================================================================================
--												USUARIOS ROLES
--========================================================================================================
create table usuariosroles(
id int identity(1,1) primary key,
idusuario int foreign key references usuarios(id) not null,
rol varchar(20)foreign key references roles(nombre) not null,
constraint ukur unique(idusuario, rol)
)
go
--agregamos el rolde administrador al usuario 1
insert usuariosroles values(1,'administrador')
go
create procedure usuariosroles_insert(@idusuario int,@rol varchar(20))
as begin
insert usuariosroles(idusuario,rol) 
values (@idusuario,@rol)
select @@identity
end
go

create procedure usuariosroles_update(@id int, @idusuario int,@rol varchar(20))
as
update usuariosroles set 
idusuario=@idusuario,
rol=@rol
where id=@id
go

create procedure usuariosroles_delete(@id int)
as
delete usuariosroles where id=@id
go

create procedure usuariosroles_deletebyuserandrol(@idusuario int, @rol varchar(20))
as
delete usuariosroles where idusuario=@idusuario and rol=@rol
go

create procedure usuariosroles_find(@id int)
as
select * from usuariosroles where id=@id
go

create procedure usuariosroles_list
as
select * from usuariosroles
go

create procedure usuariosroles_listbyusuario(@idusuario int)
as
select * from usuariosroles where idusuario=@idusuario
go

create procedure usuariosroles_listrolesbyusuario(@idusuario int)
as
select rol from usuariosroles where idusuario=@idusuario
go

create proc usuariosroles_rolexists(@idusuario int, @rol varchar(20))
as
select count(*) from usuariosroles where idusuario=@idusuario and rol=@rol
go

select * from usuariosroles
select * from usuarios

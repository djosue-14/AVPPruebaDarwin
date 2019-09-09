CREATE TABLE Empleados(
	Id int identity(1,1),
	Nombre varchar(30),
	Apellido varchar(30),
	Dpi varchar(15),
	Direccion varchar(50),
	Telefono int,
	UserName varchar(30),
	Password varchar(50),
	Role varchar(30),
	Constraint Pk_Empleados Primary Key(Id)
);

select * from Empleados;
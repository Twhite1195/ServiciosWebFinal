/*** Table Consecutivo ****/

CREATE TABLE [dbo].[Consecutivos]
(
    [ID_Consecutivos] [INT] IDENTITY(1,1) NOT NULL,
    [Nombre] [varchar](200) NULL,
    [Valor] [INT] NOT NULL,
    [Tiene_Prefijo][BIT] null,
    [Prefijo] [varchar](200) NULL,
    [Posee_Rango] [BIT] NOT NULL,
    [Rango_Inicial] [int] Null,
    [Rango_Final] [int] Null,
    CONSTRAINT PK_Consecutives PRIMARY KEY (ID_Consecutivos)
);
/*** Table Almacenamiento ****/
CREATE TABLE [dbo].[Almacenamiento]
(
    [ID_Almacenamiento] [INT] IDENTITY(1,1) NOT NULL,
    [Nombre] [varchar](200) NOT NULL,
    [Path_Almacenamiento] [varchar](200) NOT NULL,
    CONSTRAINT PK_Almacenamiento PRIMARY KEY (ID_Almacenamiento)
);
/*** Table Actor ****/
CREATE TABLE [dbo].[Actor]
(
	[ID_Actor] [INT] IDENTITY(1,1) NOT NULL,
	[Nombre_Actor] [varchar](200) NOT NULL,
 CONSTRAINT [PK_tbl_Actor] PRIMARY KEY (ID_Actor)
);
/*** ~~~~~~~~ ****/
/*** Table Genero ****/
CREATE TABLE [dbo].[Genero](
	[ID_Genero] [INT] IDENTITY(1,1) NOT NULL,
	[Nombre_Genero] [varchar](200) NULL,
 CONSTRAINT [PK_tbl_Genero] PRIMARY KEY (ID_Genero)
);
/*** Table Idioma ****/
CREATE TABLE [dbo].[Idioma](
    [ID_Idioma] [INT] IDENTITY (1,1)NOT NULL ,
    [Nombre_Idioma] [varchar](200) NOT NULL,
    CONSTRAINT [PK_tbl_Idioma] PRIMARY KEY (ID_Idioma)
);
/*** Table Autor ****/
CREATE TABLE [dbo].[Autor](
    [ID_Autor] [INT] IDENTITY (1,1)NOT NULL ,
    [Nombre_Autor] [varchar](200) NOT NULL,
    CONSTRAINT [PK_tbl_Autor] PRIMARY KEY (ID_Autor)
);
/*** Table Editorial ****/
CREATE TABLE [dbo].[Editorial](
    [ID_Editorial] [INT] IDENTITY (1,1)NOT NULL ,
    [Nombre_Editorial] [varchar](200) NOT NULL,
    CONSTRAINT [PK_tbl_Editorial] PRIMARY KEY (ID_Editorial)
);
/*** Table Pais ****/
CREATE TABLE [dbo].[Pais](
    [ID_Pais] [INT] IDENTITY (1,1)NOT NULL ,
    [Nombre_Pais] [varchar](200) NOT NULL,
    CONSTRAINT [PK_tbl_Pais] PRIMARY KEY (ID_Pais)
);
/*** Table Disquera ****/
CREATE TABLE [dbo].[Disquera](
    [ID_Disquera] [INT] IDENTITY (1,1)NOT NULL ,
    [Nombre_Disquera] [varchar](200) NOT NULL,
    CONSTRAINT [PK_tbl_Disquera] PRIMARY KEY (ID_Disquera)
);
/*** Table Disco ****/
CREATE TABLE [dbo].[Disco](
    [ID_Disco] [INT] IDENTITY (1,1)NOT NULL ,
    [Nombre_Disco] [varchar](200) NOT NULL,
    CONSTRAINT [PK_tbl_Disco] PRIMARY KEY (ID_Disco)
);

/*** Table Peliculas ****/
CREATE TABLE [dbo].[Pelicula](
    [ID_Pelicula] [varchar](200) UNIQUE NOT NULL,
    [Genero_Pelicula] [INT] FOREIGN KEY REFERENCES Genero(ID_Genero),
    [Nombre_Pelicula]  [varchar](200) NOT NULL,
    [Ano_Pelicula]  [INT] NOT NULL,
    [Idioma_Pelicula] [INT] FOREIGN KEY REFERENCES Idioma(ID_Idioma),
    [Actor1_Pelicula] [INT] FOREIGN KEY REFERENCES Actor(ID_Actor) NOT NULL,
    [Actor2_Pelicula] [INT] FOREIGN KEY REFERENCES Actor(ID_Actor) NOT NULL,
    [Actor3_Pelicula] [INT] FOREIGN KEY REFERENCES Actor(ID_Actor),
    [Actor4_Pelicula] [INT] FOREIGN KEY REFERENCES Actor(ID_Actor),
    [Archivo_Descarga_Pelicula][varchar](200) NULL,
    [Archivo_Previsualizacion_Pelicula][varchar](200) NULL,
    CONSTRAINT [PK_tbl_Pelicula] PRIMARY KEY (ID_Pelicula)
);
/*** Table Libros ****/
CREATE TABLE [dbo].[Libros](
    [ID_Libro] [varchar](200) UNIQUE NOT NULL,
    [Genero_Libro] [INT] FOREIGN KEY REFERENCES Genero(ID_Genero),
    [Nombre_Libro] [varchar](200) NOT NULL,
    [Autor_Libro] [INT] FOREIGN KEY REFERENCES Autor(ID_Autor),
    [Idioma_Libro] [INT] FOREIGN KEY REFERENCES Idioma(ID_Idioma),
    [Editorial_Libro] [INT] FOREIGN KEY REFERENCES Editorial(ID_Editorial),
    [Ano_Libro] [INT] NOT NULL,
    [Archivo_Descarga_Libros][varchar](200) NULL,
    [Archivo_Previsualizacion_Libro][varchar](200) NULL,
    CONSTRAINT [PK_tbl_Libro] PRIMARY KEY (ID_Libro)
);

/*** Table Musica ****/
CREATE TABLE [dbo].[Musica](
    [ID_Musica] [varchar](200) UNIQUE NOT NULL,
    [Genero_Musica] [INT]FOREIGN KEY REFERENCES Genero(ID_Genero),
    [Nombre_Musica] [varchar](200) NOT NULL,
    [Tipo_Inerpretacion_Musica] [varchar](200) NOT NULL,
    [Idioma_Musica] [INT] FOREIGN KEY REFERENCES Idioma(ID_Idioma),
    [Pais_Musica] [INT]FOREIGN KEY REFERENCES Pais(ID_Pais),
    [Disquera_Musica] [INT] FOREIGN KEY REFERENCES Disquera(ID_Disquera),
    [Disco_Musica] [INT] FOREIGN KEY REFERENCES Disco(ID_Disco),
    [Ano_Musica] [INT] NOT NULL,
    [Archivo_Descarga_Musica][varchar](200) NULL,
    [Archivo_Previsualizacion_Musica][varchar](200) NULL,
    CONSTRAINT [PK_tbl_Musica] PRIMARY KEY (ID_Musica)
);

/*** Table Tipo_Usuario ****/

CREATE TABLE [dbo].[Tipo_Usuario](
    [Cod_Tipo_Usuario] [INT]  IDENTITY(1,1) NOT NULL,
	[Nombre_Tipo_Usuario] [varchar](200) NOT NULL,
    CONSTRAINT [PK_Tipo_Usuarios] PRIMARY KEY (Cod_Tipo_Usuario)
);

/*** Table Usuarios ****/

CREATE TABLE [dbo].[Usuarios](
	[Cod_Usuario] [INT] IDENTITY(1,1) NOT NULL,
	[Nombre_Usuario] [varchar](200) NULL,
	[Pri_Ape_Usuario] [varchar](200) NULL,
	[Seg_Ape_Usuario] [varchar](200) NULL,
	[Email_Usuario] [varchar](200) NOT NULL,
	[Pass_Usuario] [varchar](200) NOT NULL,
	[Tipo_Usuario] [INT] FOREIGN KEY REFERENCES Tipo_Usuario(Cod_Tipo_Usuario),
    CONSTRAINT [PK_Usuarios] PRIMARY KEY (Cod_Usuario)
);


/*** Table Tipo_Bitacora ****/
CREATE TABLE [dbo].[Tipo_Bitacora](
	[Cod_Tipo_Bitacora] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_Bitacora] [varchar](1000) NOT NULL,
    CONSTRAINT [PK_Tipo_Bitacora] PRIMARY KEY (Cod_Tipo_Bitacora)
);

/*** TableBitacora ****/
CREATE TABLE [dbo].[Bitacora](
	[Cod_Bitacora] [int] IDENTITY(1,1) NOT NULL,
	[Cod_Usuario] [int] NOT NULL,
	[Fecha_Hora] [datetime] NOT NULL,
	[Descripcion] [varchar](1000) NOT NULL,
    [Tipo] [int] FOREIGN KEY REFERENCES Tipo_Bitacora(Cod_Tipo_Bitacora),
    CONSTRAINT [PK_Bitacora] PRIMARY KEY (Cod_Bitacora)
);
/*** INSERT CONSECUTIVOS ****/

INSERT INTO [dbo].[Consecutivos] ([Nombre],[Valor],[Tiene_Prefijo],[Prefijo],[Posee_Rango],[Rango_Inicial],[Rango_Final]) VALUES ('Musica',10,1,'MSC-',0,0,0)
INSERT INTO [dbo].[Consecutivos] ([Nombre],[Valor],[Tiene_Prefijo],[Prefijo],[Posee_Rango],[Rango_Inicial],[Rango_Final]) VALUES ('Libro',50,1,'LBR-',0,0,0)
INSERT INTO [dbo].[Consecutivos] ([Nombre],[Valor],[Tiene_Prefijo],[Prefijo],[Posee_Rango],[Rango_Inicial],[Rango_Final]) VALUES ('Pelicula',50,1,'PLC-',0,0,0)

/*** INSERT Tipo Usuario ****/
INSERT INTO [dbo].[Tipo_Usuario] ([Nombre_Tipo_Usuario]) VALUES ('Admin')
INSERT INTO [dbo].[Tipo_Usuario] ([Nombre_Tipo_Usuario]) VALUES ('Cliente')
INSERT INTO [dbo].[Tipo_Usuario] ([Nombre_Tipo_Usuario]) VALUES ('Seguridad')

/***** Insert Genero *****/
INSERT INTO [dbo].[Genero] ([Nombre_Genero]) VALUES ('Romance')
INSERT INTO [dbo].[Genero] ([Nombre_Genero]) VALUES ('Ciencia Ficción')
INSERT INTO [dbo].[Genero] ([Nombre_Genero]) VALUES ('Suspenso')
INSERT INTO [dbo].[Genero] ([Nombre_Genero]) VALUES ('Terror')
INSERT INTO [dbo].[Genero] ([Nombre_Genero]) VALUES ('Drama')
INSERT INTO [dbo].[Genero] ([Nombre_Genero]) VALUES ('Adolecente')
INSERT INTO [dbo].[Genero] ([Nombre_Genero]) VALUES ('Auto-Ayuda')
INSERT INTO [dbo].[Genero] ([Nombre_Genero]) VALUES ('Espiritualidad')
INSERT INTO [dbo].[Genero] ([Nombre_Genero]) VALUES ('Ilustrado/Historieta')
INSERT INTO [dbo].[Genero] ([Nombre_Genero]) VALUES ('Suspenso')

/******** Insertar Autores **********/

INSERT INTO [dbo].[Autor] ([Nombre_Autor]) VALUES ('JK Rowling')
INSERT INTO [dbo].[Autor] ([Nombre_Autor]) VALUES ('Isabel Allende')
INSERT INTO [dbo].[Autor] ([Nombre_Autor]) VALUES ('Steven King')
INSERT INTO [dbo].[Autor] ([Nombre_Autor]) VALUES ('Carmen Lira')
INSERT INTO [dbo].[Autor] ([Nombre_Autor]) VALUES ('J.R.R.Tolken')
INSERT INTO [dbo].[Autor] ([Nombre_Autor]) VALUES ('Ana Coello')

/********Insertar Actores*****/
INSERT INTO [dbo].[Actor] ([Nombre_Actor]) VALUES ('Empty')
INSERT INTO [dbo].[Actor] ([Nombre_Actor]) VALUES ('Robert Downe JR.')
INSERT INTO [dbo].[Actor] ([Nombre_Actor]) VALUES ('Scarleth Johanson.')
INSERT INTO [dbo].[Actor] ([Nombre_Actor]) VALUES ('Matt Demon')
INSERT INTO [dbo].[Actor] ([Nombre_Actor]) VALUES ('Anne Hateway')
INSERT INTO [dbo].[Actor] ([Nombre_Actor]) VALUES ('Emma Watson')
INSERT INTO [dbo].[Actor] ([Nombre_Actor]) VALUES ('Daniel Radlifc')

/*******Insertar Idiomas *********/
INSERT INTO [dbo].[Idioma] ([Nombre_Idioma]) VALUES ('Español')
INSERT INTO [dbo].[Idioma] ([Nombre_Idioma]) VALUES ('Ingles')
INSERT INTO [dbo].[Idioma] ([Nombre_Idioma]) VALUES ('Italiano')
INSERT INTO [dbo].[Idioma] ([Nombre_Idioma]) VALUES ('Frances')
INSERT INTO [dbo].[Idioma] ([Nombre_Idioma]) VALUES ('Aleman')
INSERT INTO [dbo].[Idioma] ([Nombre_Idioma]) VALUES ('Japones')
INSERT INTO [dbo].[Idioma] ([Nombre_Idioma]) VALUES ('Chino')

/********Editoriales***********/
INSERT INTO [dbo].[Editorial] ([Nombre_Editorial]) VALUES ('Salamandra')
INSERT INTO [dbo].[Editorial] ([Nombre_Editorial]) VALUES ('De Bolsillo')
INSERT INTO [dbo].[Editorial] ([Nombre_Editorial]) VALUES ('Eduvision')
INSERT INTO [dbo].[Editorial] ([Nombre_Editorial]) VALUES ('Alienta')
INSERT INTO [dbo].[Editorial] ([Nombre_Editorial]) VALUES ('Austral')

/**********Disqueras*********/
INSERT INTO [dbo].[Disquera] ([Nombre_Disquera]) VALUES ('SONY')
INSERT INTO [dbo].[Disquera] ([Nombre_Disquera]) VALUES ('UNIVERSAL')
INSERT INTO [dbo].[Disquera] ([Nombre_Disquera]) VALUES ('EMI')
INSERT INTO [dbo].[Disquera] ([Nombre_Disquera]) VALUES ('TimeWarner')
INSERT INTO [dbo].[Disquera] ([Nombre_Disquera]) VALUES ('LiveNation')
INSERT INTO [dbo].[Disquera] ([Nombre_Disquera]) VALUES ('Universal Music')

/*****STORED PROCEDURES*********STORED PROCEDURES********STORED PROCEDURES********STORED PROCEDURES*********STORED PROCEDURES************/
/****Insert y Actualizar Consecutivos Usuario****/
CREATE PROCEDURE InsertUser
    (
        @Nombre varchar(200),
        @Pri_Ape varchar(200),
        @Seg_Ape varchar(200),
        @Email varchar(200),
        @Pass varchar(200),
        @TipoUsuario int
    )
    AS
        DECLARE @ID varchar(200)
        
        SELECT @ID = CAST([Prefijo] AS VARCHAR(200)) + 
                CAST([valor]  AS VARCHAR(200))
                FROM [dbo].[Consecutivos]
                WHERE Nombre = 'Usuario'
                         
        INSERT INTO [dbo].[Usuarios] ([Cod_Usuario],[Nombre_Usuario],[Pri_Ape_Usuario],[Seg_Ape_Usuario],[Email_Usuario], [Pass_Usuario],[Tipo_Usuario])
        VALUES (@ID,@Nombre,@Pri_Ape,@Seg_Ape,@Email,@Pass,@TipoUsuario)
        
        UPDATE [dbo].[Consecutivos]
        SET Valor = Valor + 1
        WHERE Nombre ='Usuario'
        
    GO
/********/
/****Insert y Actualizar Consecutivos Musica****/
CREATE PROCEDURE InsertMusica
    (
        @Genero int,
        @Nombre varchar(200),
        @Tipo_Interpretacion varchar(200),
        @Idioma int,
        @Pais int,
        @Disquera int,
        @Disco int,
        @Ano int,
        @Preview varchar (200),
        @Descarga varchar (200)
    )
    AS
        DECLARE @ID varchar(200)
        
        SELECT @ID = CAST([Prefijo] AS VARCHAR(200)) + 
                CAST([valor]  AS VARCHAR(200))
                FROM [dbo].[Consecutivos]
                WHERE Nombre = 'Musica'
                         
        INSERT INTO [dbo].[Musica] ([ID_Musica],[Genero_Musica],[Nombre_Musica],[Tipo_Inerpretacion_Musica],[Idioma_Musica], [Pais_Musica],[Disquera_Musica],[Disco_Musica],[Ano_Musica],[Archivo_Descarga_Musica],[Archivo_Previsualizacion_Musica])
        VALUES (@ID,@Genero,@Nombre,@Tipo_Interpretacion,@Idioma,@Pais,@Disquera,@Disco,@Ano,@Descarga,@Preview)
        
        UPDATE [dbo].[Consecutivos]
        SET Valor = Valor + 1
        WHERE Nombre ='Musica'
        
    GO
/********/
/****Insert y Actualizar Consecutivos Libro****/
CREATE PROCEDURE InsertLibro
    (
        @Genero int,
        @Nombre varchar(200),
        @Autor int,
        @Idioma int,
        @Editorial int,
        @ano int,
        @Preview varchar (200),
        @Descarga varchar (200)
        
    )
    AS
        DECLARE @ID varchar(200)
        
        SELECT @ID = CAST([Prefijo] AS VARCHAR(200)) + 
                CAST([valor]  AS VARCHAR(200))
                FROM [dbo].[Consecutivos]
                WHERE Nombre = 'Libro'
                         
        INSERT INTO [dbo].[Libros] ([ID_Libro],[Genero_Libro],[Nombre_Libro],[Autor_Libro],[Idioma_Libro], [Editorial_Libro],[Ano_Libro],[Archivo_Descarga_Libros],[Archivo_Previsualizacion_Libro])
        VALUES (@ID,@Genero,@Nombre,@Autor,@Idioma,@Editorial,@Ano,@Descarga,@Preview)
        
        UPDATE [dbo].[Consecutivos]
        SET Valor = Valor + 1
        WHERE Nombre ='Libro' 
    GO


/********/
/****Insert y Actualizar Consecutivos Pelicula****/
CREATE PROCEDURE InsertPelicula
    (
        @Genero int,
        @Nombre varchar(200),
        @ano int,
        @Idioma int,
        @Actor1 int,
        @Actor2 int,
        @Actor3 int,
        @Actor4 int,
        @Preview varchar (200),
        @Descarga varchar (200)
    )
    AS
        DECLARE @ID varchar(200)
        
        SELECT @ID = CAST([Prefijo] AS VARCHAR(200)) + 
                CAST([valor]  AS VARCHAR(200))
                FROM [dbo].[Consecutivos]
                WHERE Nombre = 'Pelicula'
                         
        INSERT INTO [dbo].[Pelicula] ([ID_Pelicula],[Genero_Pelicula],[Nombre_Pelicula],[Ano_Pelicula],[Idioma_Pelicula], [Actor1_Pelicula],[Actor2_Pelicula],[Actor3_Pelicula],[Actor4_Pelicula],[Archivo_Descarga_Pelicula],[Archivo_Previsualizacion_Pelicula])
        VALUES (@ID,@Genero,@Nombre,@Ano,@Idioma,@Actor1,@Actor2,@Actor3,@Actor4,@Descarga,@Preview)
        
        UPDATE [dbo].[Consecutivos]
        SET Valor = Valor + 1
        WHERE Nombre ='Pelicula' 
    GO

/********/

create procedure IngresarTipoConsecutivoEncrypt
@Tipo VARCHAR(200)
As
begin
Insert INTo Tipo_Consecutivo
(
Tipo_Consecutivo
)
VALUE
(
ENCRYPTBYPASSPHRASE('Encrypt',@Tipo) 
)
End
Go

/********/

create procedure IngresarUsuario
@Name VARCHAR(200),
@Pass VARCHAR(200),
@Tipo VARCHAR(200)
As
begin
Insert INTo Usuario
(
	Usuario_login,
	Usuario_Password,
    Usuario_tipo
)
VALUES
(
@Name,
ENCRYPTBYPASSPHRASE('password',@Pass),
@Tipo 
)
End
Go
/********/

Create procedure IngresarActorEncrypt
(@Nombre_Actor)
AS
Begin
INSERT INTO Actor
(
    Nombre_Actor
)
VALUES
(
    @Nombre_Actor,
    ENCRYPTBYPASSPHRASE('encrypt',@Nombre_Actor)
)
End
GO
/********/

Create procedure IngresarGeneroEncrypt
(@Genero_Nombre)
AS
Begin
INSERT INTO Genero
(
    Nombre_Genero
)
VALUES
(
    @Nombre_Genero,
    ENCRYPTBYPASSPHRASE('encrypt',@Nombre_Genero)
)
End
GO
/********/
Create procedure IngresarIdiomaEncrypt
(@Idioma_Nombre)
AS
Begin
INSERT INTO Idioma
(
    Idioma_Nombre
)
VALUES
(
    @Idioma_Nombre,
    ENCRYPTBYPASSPHRASE('encrypt',@Idioma_Nombre)
)
End
GO
/********/
Create procedure IngresarAutorEncrypt
(@Nombre_Autor)
AS
Begin
INSERT INTO Autor
(
    Nombre_Autor
)
VALUES
(
    @Nombre_Editorial,
    ENCRYPTBYPASSPHRASE('encrypt',@Nombre_Autor)
)
End
GO

/********/
Create procedure IngresarEditorialEncrypt
(@Nombre_Editorial)
AS
Begin
INSERT INTO Editorial
(
    Nombre_Editorial
)
VALUES
(
    @Nombre_Editorial,
    ENCRYPTBYPASSPHRASE('encrypt',@Nombre_Editorial)
)
End
GO
/********/

Create procedure IngresarPaisEncrypt
(@Nombre_Pais)
AS
Begin
INSERT INTO Pais
(
    Nombre_Pais
)
VALUES
(
    @Nombre_Pais,
    ENCRYPTBYPASSPHRASE('encrypt',@Nombre_Pais)
)
End
GO
/********/

Create procedure IngresarDisqueraEncrypt
(@Nombre_Disquera)
AS
Begin
INSERT INTO Disquera
(
    Nombre_Disquera
)
VALUES
(
    @Nombre_Disquera,
    ENCRYPTBYPASSPHRASE('encrypt',@Nombre_Disquera)
)
End
GO

/********/

create procedure IngresarUsuarioEncrypt
(@Name nVARCHAR(200),
@Pass nVARCHAR(200))
As
begin
Insert INTo Usuario
(
	Usuario_login,
	Usuario_Password
)
VALUES
(
@Name,
ENCRYPTBYPASSPHRASE('password',@Pass) 
)
End
Go
/********/ 
create procedure LoginUsuarioDecrypt
	@Name nVARCHAR(200),
	@Pass nVARCHAR(200),
	@Result bit output
AS
	Declare @PassEncode as nvarchar(300)
	Declare @PassDecode as nVARCHAR(200)
Begin
	Select @PassEncode = Pass From Login Where Name = @Name
	set @PassDecode = DECRYPTBYPASSPHRASE('password',@PassEncode)
End

Begin
	If @PassDecode = @Pass
		set @Result = 1
	else
		set @Result = 0
End

Go
/********/
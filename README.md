# ZemogaTest

# Test Jesus Garcia

Esta es el codigo fuente de la prueba tecnica para el proceso de entrevista del candidato Jesús Garcia y la empresa **Zemoga**, que contiene lo siguiente:.

  - Un microservicio para la gestion de Escritores. ![alt text](https://1.bp.blogspot.com/-P6lyCFg1mhk/Xwt_2_ecbpI/AAAAAAABEVo/8IvysRYNtREuiY7MdGf5M_PVpPftU7VgACLcBGAsYHQ/s1600/Captura3.PNG)
  - Un microservicio para la gestion de Editores. ![alt text](https://1.bp.blogspot.com/-2cNzESrG8Fc/Xwt_3Zj5JUI/AAAAAAABEV0/Kx2PxcoNLGIlsl_a7Ke-h7XVbTmxS7CmwCLcBGAsYHQ/s1600/Captura4.PNG)
  - Un microservicio para la gestion de Usuarios. ![alt text](https://1.bp.blogspot.com/-6PSdOx8wNFo/Xwt_3j9719I/AAAAAAABEV4/UTJp-LTNW2c7m7hDgcEMYMtqUe8J7DIXgCLcBGAsYHQ/s1600/Captura5.PNG)
  - Un Api Gateway ![alt text](https://1.bp.blogspot.com/-A8A4-Sx68_o/Xwt_29zO-oI/AAAAAAABEVs/XtJ5PPkQaJcFpt_5d-bqkXOXdAn06tyfgCLcBGAsYHQ/s1600/Captura2.PNG)
  - Un proyecto de Base de Datos.
 
## 1. Funcionalidades a evaluar
  PART I

Build a simple blog engine using ASP.NET MVC 4.5 or later ( Core is preferable). The app should use some kind of authentication to distinguish between non-authenticated and authenticated users. There must be two user roles defined: “writer” and “editor”.
  - Writer users should be able to create, edit and submit posts. When a Writer submits a post, the post should update to a “pending publish approval” status where it cannot be further updated.
  - Editor users should be able to query for “pending” posts and approve or reject their publishing. Once an Editor approves the publishing, the post is published and visible to non-authenticated users. If the post is rejected, it will be editable again by Writer users.
  - Editor users should be able to delete posts. Once a post is published, the app should allow both authenticated and non-authenticated users to add comments to posts. Each post should display its author name (Writer user) and publish ( approval ) date.

The posts can be composed in plain text, so it’s not necessary to include text formatting or images support, but will be considered as extra points if implemented.

Do not pay much attention to the UI/design side of things nor to the authentication mechanism (even hard-coded usernames and passwords are valid). The focus of the test should be the business logic and the overall architecture design. You can use Entity Framework or another ORM of your choice, or even a different persistence solution (other than a rdbms).

Design Rules
  - The Controllers should not have direct dependency on the DbContext/Data access classes.
  - Use a Dependency Injection/IoC container of your choice for dependency resolution.

PART II

Build a REST API to manage the posts as an Editor user. The API must expose at least two endpoints: to query the pending posts, and to approve or reject a pending post:

  - Query endpoint: The endpoint should return a list of the posts that are pending for approval. For each post, the response must include the post identifier, the author name (Writer user) and the submit date.
  - Approval endpoint(s)
The endpoint(s) should receive the post identifier and an indicator about the action to perform (approve or reject). Feel free to implement one or two endpoints according to your API design.

All request and responses must be in JSON format.

## 2. Arquitectura
Para este proyecto como es en microservicios, se optó por una arquitectura orientada al dominio, puedes consultar este enlace para mas información https://devexperto.com/domain-driven-design-1/

Diagramas:

- Nivel 1 ![alt text](https://1.bp.blogspot.com/-GUiCV1fODrY/Xwt_4N28rPI/AAAAAAABEV8/hzvs2LDcETUw7-ldOhCVXq3RzhPnl2FWQCLcBGAsYHQ/s1600/Captura6.PNG) 

## 3. Patron de Diseño

Para este proyecto utilizamos la inyección de dependencias para el consumo de los servicios que serán expuestos en el **APiGateway y Microservicios**

Segun la definicion de wikipedia:
> Inyección de dependencias (en inglés Dependency Injection, DI) es un patrón de diseño orientado a objetos, en el que se suministran objetos a una clase en lugar de ser la propia clase la que cree dichos objetos. Esos objetos cumplen contratos que necesitan nuestras clases para poder funcionar (de ahí el concepto de dependencia). Nuestras clases no crean los objetos que necesitan, sino que se los suministra otra clase 'contenedora' que inyectará la implementación deseada a nuestro contrato.

## 4. Base de Datos

La base de datos a la cual se accede esta en un repositorio en Azure, a continuación se deja el script para la creación de las tablas que se usaron en este proyecto.

```sh
/****** Object:  Table [dbo].[Comment]    Script Date: 12/07/2020 4:00:54 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_post] [int] NULL,
	[body] [varchar](50) NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 12/07/2020 4:00:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Application] [nvarchar](50) NOT NULL,
	[Logged] [datetime] NOT NULL,
	[Level] [nvarchar](50) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[Logger] [nvarchar](250) NULL,
	[Callsite] [nvarchar](max) NULL,
	[Exception] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 12/07/2020 4:00:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[state] [varchar](50) NULL,
	[datePublish] [datetime] NULL,
	[body] [varchar](500) NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post_User]    Script Date: 12/07/2020 4:00:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post_User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_editor] [int] NULL,
	[id_writter] [int] NOT NULL,
	[id_post] [int] NOT NULL,
 CONSTRAINT [PK_Post_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/07/2020 4:00:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_login] [varchar](50) NULL,
	[password_login] [varchar](50) NULL,
	[isEditor] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
```

## 5. Tecnologias Utilizadas
* [.Net Core](https://docs.microsoft.com/en-us/dotnet/core/)
* [Nlog](https://nlog-project.org/)
* [Polly](https://www.nuget.org/packages/Polly.Extensions.Http/)
* [AutoMapper](https://automapper.org/)
* [FluentValidation](https://fluentvalidation.net/)
* [JWT](https://jwt.io/)

## 6. Ejecucion del código.

Descomprimir el archivo que contiene el proyect, esto te generará una carpeta que contiene las siguientes subcarpetas: 
- Carpeta Root
  - Database
  - Gateway
  - Microservices

![alt text](https://1.bp.blogspot.com/-3b2Ruzn7or0/Xwt_2-4BPzI/AAAAAAABEVw/gjKtXTZ5dB07rbbSatpOaD4f6sRGEmBqgCLcBGAsYHQ/s1600/Captura1.PNG)

```sh
$ cd [ruta de la carpeta donde se descargó el gateway]
$ dotnet run
```
esto levantara el servicio en la siguiente URL https://localhost:5001/index.html


```sh
$ cd [ruta de la carpeta donde se descargó el microservices Writter]
$ dotnet run
```
esto levantara el servicio en la siguiente URL https://localhost:2001/swagger/index.html

```sh
$ cd [ruta de la carpeta donde se descargó el microservices Editor]
$ dotnet run
```
esto levantara el servicio en la siguiente URL https://localhost:3001/swagger/index.html

```sh
$ cd [ruta de la carpeta donde se descargó el microservices Users]
$ dotnet run
```
esto levantara el servicio en la siguiente URL https://localhost:4001/swagger/index.html

## 7. Acciones del Api Gateway

**Writter**
- POST ​/api​/Writter​/CreatePost
  - Method that creates a post
  
**Editor**
- PUT​/api/Editor/AproveRejectPost
  - Method that approves or rejects a post 
- DELETE ​/api/Editor/DeletePost
  - Method that deletes a post
- GET ​/api/Editor/GetPendingPosts
  - Method that obtains the post pending approval or rejection

**Users**
- POST ​/api​/Users​/Login
  - Method that validates a user's username and password.
- POST ​/api​/Users​/SaveComment
  - Method that stores a comment for an approved post
  
  ![alt text](https://1.bp.blogspot.com/-T9gvXBi_Ca4/XwuAF3Z6lwI/AAAAAAABEWA/NgxBK9ghmUwnDMwXv5ILrK8JBoOkkwQ_gCLcBGAsYHQ/s1600/Untitled%2BDiagram.png)

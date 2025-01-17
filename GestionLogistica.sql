USE [master]
GO
/****** Object:  Database [GestionLogisticaDB]    Script Date: 9/07/2024 5:55:32 p. m. ******/
CREATE DATABASE [GestionLogisticaDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GestionLogisticaDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GestionLogisticaDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GestionLogisticaDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GestionLogisticaDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GestionLogisticaDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GestionLogisticaDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GestionLogisticaDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GestionLogisticaDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GestionLogisticaDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GestionLogisticaDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GestionLogisticaDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [GestionLogisticaDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GestionLogisticaDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GestionLogisticaDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GestionLogisticaDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GestionLogisticaDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GestionLogisticaDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GestionLogisticaDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GestionLogisticaDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GestionLogisticaDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GestionLogisticaDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GestionLogisticaDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GestionLogisticaDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GestionLogisticaDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GestionLogisticaDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GestionLogisticaDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GestionLogisticaDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GestionLogisticaDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GestionLogisticaDB] SET RECOVERY FULL 
GO
ALTER DATABASE [GestionLogisticaDB] SET  MULTI_USER 
GO
ALTER DATABASE [GestionLogisticaDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GestionLogisticaDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GestionLogisticaDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GestionLogisticaDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GestionLogisticaDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GestionLogisticaDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [GestionLogisticaDB] SET QUERY_STORE = OFF
GO
USE [GestionLogisticaDB]
GO
/****** Object:  Table [dbo].[Bodega]    Script Date: 9/07/2024 5:55:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bodega](
	[BodegaId] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionBodega] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Bodega] PRIMARY KEY CLUSTERED 
(
	[BodegaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 9/07/2024 5:55:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Cedula] [nvarchar](20) NOT NULL,
	[Telefono] [nvarchar](20) NOT NULL,
	[Direccion] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guia]    Script Date: 9/07/2024 5:55:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guia](
	[GuiaId] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[FechaEntrega] [datetime] NOT NULL,
	[BodegaId] [int] NOT NULL,
	[TipoGuiaId] [int] NOT NULL,
	[Consecutivo] [nvarchar](10) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[NumeroGuia] [nvarchar](10) NULL,
 CONSTRAINT [PK_Guia] PRIMARY KEY CLUSTERED 
(
	[GuiaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guia_Producto]    Script Date: 9/07/2024 5:55:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guia_Producto](
	[GuiaProductoId] [int] IDENTITY(1,1) NOT NULL,
	[GuiaId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[CantidadProducto] [int] NOT NULL,
	[DescripcionGuiaProducto] [nvarchar](250) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[PrecioEnvio] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Guia_Producto] PRIMARY KEY CLUSTERED 
(
	[GuiaProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 9/07/2024 5:55:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[PersonaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[PersonaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 9/07/2024 5:55:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[ProductoId] [int] IDENTITY(1,1) NOT NULL,
	[TipoProductoId] [int] NOT NULL,
	[DescripcionProducto] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Respuestum]    Script Date: 9/07/2024 5:55:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Respuestum](
	[IdRespuesta] [int] NOT NULL,
	[CodigoRespuesta] [int] NOT NULL,
	[IdIdioma] [int] NOT NULL,
	[MensajeRespuesta] [nvarchar](100) NOT NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_Respuestum] PRIMARY KEY CLUSTERED 
(
	[IdRespuesta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 9/07/2024 5:55:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RolId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoGuia]    Script Date: 9/07/2024 5:55:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoGuia](
	[TipoGuiaId] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionTipoGuia] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_TipoGuia] PRIMARY KEY CLUSTERED 
(
	[TipoGuiaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoProducto]    Script Date: 9/07/2024 5:55:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoProducto](
	[TipoProductoId] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionTipoProducto] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_TipoProducto] PRIMARY KEY CLUSTERED 
(
	[TipoProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 9/07/2024 5:55:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[Bloqueado] [bit] NOT NULL,
	[IntentosFallidos] [int] NOT NULL,
	[PersonaId] [int] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioxRoles]    Script Date: 9/07/2024 5:55:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioxRoles](
	[UsuarioIdxRolesId] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[RolId] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioxRoles] PRIMARY KEY CLUSTERED 
(
	[UsuarioIdxRolesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bodega] ON 

INSERT [dbo].[Bodega] ([BodegaId], [DescripcionBodega], [Activo]) VALUES (1, N'Sur', 1)
INSERT [dbo].[Bodega] ([BodegaId], [DescripcionBodega], [Activo]) VALUES (2, N'Norte', 1)
INSERT [dbo].[Bodega] ([BodegaId], [DescripcionBodega], [Activo]) VALUES (3, N'Cúcuta', 1)
INSERT [dbo].[Bodega] ([BodegaId], [DescripcionBodega], [Activo]) VALUES (4, N'Bucaramanga', 1)
INSERT [dbo].[Bodega] ([BodegaId], [DescripcionBodega], [Activo]) VALUES (5, N'Bogota', 1)
SET IDENTITY_INSERT [dbo].[Bodega] OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Apellido], [Cedula], [Telefono], [Direccion]) VALUES (1, N'Jairo', N'Sanabria', N'10614895', N'3044601189', N'Calle siempre viva')
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Guia] ON 

INSERT [dbo].[Guia] ([GuiaId], [ClienteId], [FechaEntrega], [BodegaId], [TipoGuiaId], [Consecutivo], [FechaRegistro], [NumeroGuia]) VALUES (1, 1, CAST(N'2023-08-24T00:00:00.000' AS DateTime), 4, 1, N'619JSM', CAST(N'2023-08-23T00:00:00.000' AS DateTime), N'1234567891')
INSERT [dbo].[Guia] ([GuiaId], [ClienteId], [FechaEntrega], [BodegaId], [TipoGuiaId], [Consecutivo], [FechaRegistro], [NumeroGuia]) VALUES (6, 1, CAST(N'2024-07-08T23:44:47.773' AS DateTime), 2, 1, N'333', CAST(N'2024-07-08T23:44:46.107' AS DateTime), N'z7lLcx4YNa')
INSERT [dbo].[Guia] ([GuiaId], [ClienteId], [FechaEntrega], [BodegaId], [TipoGuiaId], [Consecutivo], [FechaRegistro], [NumeroGuia]) VALUES (7, 1, CAST(N'2024-07-09T15:53:08.900' AS DateTime), 3, 1, N'619JSM', CAST(N'2024-07-09T15:53:07.957' AS DateTime), N'lHPUZ1wecd')
INSERT [dbo].[Guia] ([GuiaId], [ClienteId], [FechaEntrega], [BodegaId], [TipoGuiaId], [Consecutivo], [FechaRegistro], [NumeroGuia]) VALUES (8, 1, CAST(N'2024-07-09T15:56:45.977' AS DateTime), 4, 1, N'619JSM', CAST(N'2024-07-09T15:56:45.977' AS DateTime), N'798r5mfcla')
INSERT [dbo].[Guia] ([GuiaId], [ClienteId], [FechaEntrega], [BodegaId], [TipoGuiaId], [Consecutivo], [FechaRegistro], [NumeroGuia]) VALUES (9, 1, CAST(N'2024-07-09T15:57:54.377' AS DateTime), 2, 1, N'619JSM', CAST(N'2024-07-09T15:57:54.377' AS DateTime), N'PtQhtuQhLN')
SET IDENTITY_INSERT [dbo].[Guia] OFF
GO
SET IDENTITY_INSERT [dbo].[Guia_Producto] ON 

INSERT [dbo].[Guia_Producto] ([GuiaProductoId], [GuiaId], [ProductoId], [CantidadProducto], [DescripcionGuiaProducto], [FechaRegistro], [PrecioEnvio]) VALUES (3, 1, 2, 2, N'Buen Estado', CAST(N'2023-02-16T00:00:00.000' AS DateTime), CAST(3200.00 AS Decimal(18, 2)))
INSERT [dbo].[Guia_Producto] ([GuiaProductoId], [GuiaId], [ProductoId], [CantidadProducto], [DescripcionGuiaProducto], [FechaRegistro], [PrecioEnvio]) VALUES (4, 1, 2, 2, N'Buen Estado', CAST(N'2023-02-16T00:00:00.000' AS DateTime), CAST(32000.00 AS Decimal(18, 2)))
INSERT [dbo].[Guia_Producto] ([GuiaProductoId], [GuiaId], [ProductoId], [CantidadProducto], [DescripcionGuiaProducto], [FechaRegistro], [PrecioEnvio]) VALUES (5, 1, 3, 2, N'Buen Estado', CAST(N'2023-02-16T00:00:00.000' AS DateTime), CAST(56000.00 AS Decimal(18, 2)))
INSERT [dbo].[Guia_Producto] ([GuiaProductoId], [GuiaId], [ProductoId], [CantidadProducto], [DescripcionGuiaProducto], [FechaRegistro], [PrecioEnvio]) VALUES (6, 1, 4, 3, N'Buen Estado', CAST(N'2023-02-16T00:00:00.003' AS DateTime), CAST(30000.00 AS Decimal(18, 2)))
INSERT [dbo].[Guia_Producto] ([GuiaProductoId], [GuiaId], [ProductoId], [CantidadProducto], [DescripcionGuiaProducto], [FechaRegistro], [PrecioEnvio]) VALUES (7, 1, 5, 3, N'Buen Estado', CAST(N'2023-02-16T00:00:00.003' AS DateTime), CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[Guia_Producto] ([GuiaProductoId], [GuiaId], [ProductoId], [CantidadProducto], [DescripcionGuiaProducto], [FechaRegistro], [PrecioEnvio]) VALUES (9, 1, 7, 4, N'Buen Estado', CAST(N'2023-02-16T00:00:00.007' AS DateTime), CAST(40600.00 AS Decimal(18, 2)))
INSERT [dbo].[Guia_Producto] ([GuiaProductoId], [GuiaId], [ProductoId], [CantidadProducto], [DescripcionGuiaProducto], [FechaRegistro], [PrecioEnvio]) VALUES (10, 1, 8, 7, N'Buen Estado', CAST(N'2023-02-16T00:00:00.007' AS DateTime), CAST(41600.00 AS Decimal(18, 2)))
INSERT [dbo].[Guia_Producto] ([GuiaProductoId], [GuiaId], [ProductoId], [CantidadProducto], [DescripcionGuiaProducto], [FechaRegistro], [PrecioEnvio]) VALUES (11, 1, 9, 5, N'Buen Estado', CAST(N'2023-02-16T00:00:00.007' AS DateTime), CAST(42600.00 AS Decimal(18, 2)))
INSERT [dbo].[Guia_Producto] ([GuiaProductoId], [GuiaId], [ProductoId], [CantidadProducto], [DescripcionGuiaProducto], [FechaRegistro], [PrecioEnvio]) VALUES (12, 1, 10, 8, N'Buen Estado', CAST(N'2023-02-16T00:00:00.007' AS DateTime), CAST(43600.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Guia_Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([PersonaId], [Nombre], [Apellido], [Telefono]) VALUES (1, N'Jairo Steeven', N'Sanabria Medina', N'3044601189')
SET IDENTITY_INSERT [dbo].[Persona] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([ProductoId], [TipoProductoId], [DescripcionProducto], [Activo], [Precio]) VALUES (2, 5, N'Nevera', 1, CAST(3500000.00 AS Decimal(18, 2)))
INSERT [dbo].[Producto] ([ProductoId], [TipoProductoId], [DescripcionProducto], [Activo], [Precio]) VALUES (3, 2, N'froot loops', 1, CAST(20000.00 AS Decimal(18, 2)))
INSERT [dbo].[Producto] ([ProductoId], [TipoProductoId], [DescripcionProducto], [Activo], [Precio]) VALUES (4, 4, N'Sillas', 1, CAST(100000.00 AS Decimal(18, 2)))
INSERT [dbo].[Producto] ([ProductoId], [TipoProductoId], [DescripcionProducto], [Activo], [Precio]) VALUES (5, 6, N'Iphone 14 Pro Max', 1, CAST(5000000.00 AS Decimal(18, 2)))
INSERT [dbo].[Producto] ([ProductoId], [TipoProductoId], [DescripcionProducto], [Activo], [Precio]) VALUES (7, 8, N'Funko pop Naruto', 1, CAST(120000.00 AS Decimal(18, 2)))
INSERT [dbo].[Producto] ([ProductoId], [TipoProductoId], [DescripcionProducto], [Activo], [Precio]) VALUES (8, 9, N'Monitor 32 Pulgadas', 1, CAST(1250000.00 AS Decimal(18, 2)))
INSERT [dbo].[Producto] ([ProductoId], [TipoProductoId], [DescripcionProducto], [Activo], [Precio]) VALUES (9, 9, N'Monitor 27 Pulgadas', 1, CAST(9000000.00 AS Decimal(18, 2)))
INSERT [dbo].[Producto] ([ProductoId], [TipoProductoId], [DescripcionProducto], [Activo], [Precio]) VALUES (10, 8, N'Funko pop Academi my hero', 1, CAST(45000.00 AS Decimal(18, 2)))
INSERT [dbo].[Producto] ([ProductoId], [TipoProductoId], [DescripcionProducto], [Activo], [Precio]) VALUES (12, 10, N'Escrituras', 1, CAST(250000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RolId], [Nombre], [Activo]) VALUES (1, N'Administrador', 1)
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoGuia] ON 

INSERT [dbo].[TipoGuia] ([TipoGuiaId], [DescripcionTipoGuia], [Activo]) VALUES (1, N'Maritima', 1)
INSERT [dbo].[TipoGuia] ([TipoGuiaId], [DescripcionTipoGuia], [Activo]) VALUES (2, N'Terrestre', 1)
SET IDENTITY_INSERT [dbo].[TipoGuia] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoProducto] ON 

INSERT [dbo].[TipoProducto] ([TipoProductoId], [DescripcionTipoProducto], [Activo]) VALUES (1, N'Grano', 1)
INSERT [dbo].[TipoProducto] ([TipoProductoId], [DescripcionTipoProducto], [Activo]) VALUES (2, N'Cereal', 1)
INSERT [dbo].[TipoProducto] ([TipoProductoId], [DescripcionTipoProducto], [Activo]) VALUES (3, N'Aceite', 1)
INSERT [dbo].[TipoProducto] ([TipoProductoId], [DescripcionTipoProducto], [Activo]) VALUES (4, N'Madera', 1)
INSERT [dbo].[TipoProducto] ([TipoProductoId], [DescripcionTipoProducto], [Activo]) VALUES (5, N'Electrodomestivo', 1)
INSERT [dbo].[TipoProducto] ([TipoProductoId], [DescripcionTipoProducto], [Activo]) VALUES (6, N'Mobile', 1)
INSERT [dbo].[TipoProducto] ([TipoProductoId], [DescripcionTipoProducto], [Activo]) VALUES (8, N'Juguetes', 1)
INSERT [dbo].[TipoProducto] ([TipoProductoId], [DescripcionTipoProducto], [Activo]) VALUES (9, N'Pantalla', 1)
INSERT [dbo].[TipoProducto] ([TipoProductoId], [DescripcionTipoProducto], [Activo]) VALUES (10, N'Documentos', 1)
SET IDENTITY_INSERT [dbo].[TipoProducto] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([UsuarioId], [Password], [Nombre], [Activo], [FechaRegistro], [Bloqueado], [IntentosFallidos], [PersonaId]) VALUES (2, N'btWDPPNShuv4Zit7WUnw10K77D8=', N'jairo.sanabria', 1, CAST(N'2024-07-02T00:00:00.000' AS DateTime), 0, 0, 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[UsuarioxRoles] ON 

INSERT [dbo].[UsuarioxRoles] ([UsuarioIdxRolesId], [UsuarioId], [RolId]) VALUES (1, 2, 1)
SET IDENTITY_INSERT [dbo].[UsuarioxRoles] OFF
GO
ALTER TABLE [dbo].[Guia] ADD  CONSTRAINT [DF_Guia_NumeroGuia]  DEFAULT (N'newid()') FOR [NumeroGuia]
GO
ALTER TABLE [dbo].[Guia]  WITH CHECK ADD  CONSTRAINT [FK_Guia_Bodega] FOREIGN KEY([BodegaId])
REFERENCES [dbo].[Bodega] ([BodegaId])
GO
ALTER TABLE [dbo].[Guia] CHECK CONSTRAINT [FK_Guia_Bodega]
GO
ALTER TABLE [dbo].[Guia]  WITH CHECK ADD  CONSTRAINT [FK_Guia_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[Guia] CHECK CONSTRAINT [FK_Guia_Cliente]
GO
ALTER TABLE [dbo].[Guia]  WITH CHECK ADD  CONSTRAINT [FK_Guia_TipoGuia] FOREIGN KEY([TipoGuiaId])
REFERENCES [dbo].[TipoGuia] ([TipoGuiaId])
GO
ALTER TABLE [dbo].[Guia] CHECK CONSTRAINT [FK_Guia_TipoGuia]
GO
ALTER TABLE [dbo].[Guia_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Guia_Producto_Guia] FOREIGN KEY([GuiaId])
REFERENCES [dbo].[Guia] ([GuiaId])
GO
ALTER TABLE [dbo].[Guia_Producto] CHECK CONSTRAINT [FK_Guia_Producto_Guia]
GO
ALTER TABLE [dbo].[Guia_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Guia_Producto_Producto] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([ProductoId])
GO
ALTER TABLE [dbo].[Guia_Producto] CHECK CONSTRAINT [FK_Guia_Producto_Producto]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_TipoProducto] FOREIGN KEY([TipoProductoId])
REFERENCES [dbo].[TipoProducto] ([TipoProductoId])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_TipoProducto]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Persona] FOREIGN KEY([PersonaId])
REFERENCES [dbo].[Persona] ([PersonaId])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Persona]
GO
ALTER TABLE [dbo].[UsuarioxRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioxRoles_Roles] FOREIGN KEY([RolId])
REFERENCES [dbo].[Roles] ([RolId])
GO
ALTER TABLE [dbo].[UsuarioxRoles] CHECK CONSTRAINT [FK_UsuarioxRoles_Roles]
GO
ALTER TABLE [dbo].[UsuarioxRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioxRoles_Usuarios] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuarios] ([UsuarioId])
GO
ALTER TABLE [dbo].[UsuarioxRoles] CHECK CONSTRAINT [FK_UsuarioxRoles_Usuarios]
GO
USE [master]
GO
ALTER DATABASE [GestionLogisticaDB] SET  READ_WRITE 
GO

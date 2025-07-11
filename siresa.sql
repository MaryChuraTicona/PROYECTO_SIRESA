/****** Object:  Database [SIRESA]    Script Date: 27/06/2025 08:39:22 ******/
CREATE DATABASE [SIRESA]  (EDITION = 'GeneralPurpose', SERVICE_OBJECTIVE = 'GP_S_Gen5_1', MAXSIZE = 32 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS, LEDGER = OFF;
GO
ALTER DATABASE [SIRESA] SET COMPATIBILITY_LEVEL = 170
GO
ALTER DATABASE [SIRESA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SIRESA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SIRESA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SIRESA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SIRESA] SET ARITHABORT OFF 
GO
ALTER DATABASE [SIRESA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SIRESA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SIRESA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SIRESA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SIRESA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SIRESA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SIRESA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SIRESA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SIRESA] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [SIRESA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SIRESA] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [SIRESA] SET  MULTI_USER 
GO
ALTER DATABASE [SIRESA] SET ENCRYPTION ON
GO
ALTER DATABASE [SIRESA] SET QUERY_STORE = ON
GO
ALTER DATABASE [SIRESA] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  Table [dbo].[CriteriosBase]    Script Date: 27/06/2025 08:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CriteriosBase](
	[CriterioID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[NivelRiesgo] [nvarchar](50) NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CriterioID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CriteriosEvaluados]    Script Date: 27/06/2025 08:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CriteriosEvaluados](
	[CriterioID] [int] IDENTITY(1,1) NOT NULL,
	[FiscalizacionID] [int] NULL,
	[Criterio] [nvarchar](150) NULL,
	[Resultado] [nvarchar](20) NULL,
	[Observacion] [nvarchar](max) NULL,
	[Numero] [int] NULL,
	[NivelRiesgo] [nvarchar](10) NULL,
	[Evidencia] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[CriterioID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Denuncias]    Script Date: 27/06/2025 08:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Denuncias](
	[DenunciaID] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [varchar](8) NOT NULL,
	[Nombres] [nvarchar](150) NOT NULL,
	[Correo] [nvarchar](100) NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[RutaImagen] [nvarchar](300) NOT NULL,
	[FechaRegistro] [datetime] NULL,
	[Estado] [nvarchar](50) NULL,
	[UsuarioAtiendeID] [int] NULL,
	[Respuesta] [nvarchar](max) NULL,
	[RUC] [varchar](11) NULL,
	[NombreEstablecimiento] [nvarchar](150) NULL,
	[DireccionEstablecimiento] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[DenunciaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpleadosRegistrados]    Script Date: 27/06/2025 08:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpleadosRegistrados](
	[EmpleadoID] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompleto] [nvarchar](100) NULL,
	[DNI] [char](8) NULL,
	[Especialidad] [nvarchar](100) NULL,
	[RolID] [nvarchar](100) NULL,
	[SupervisorID] [int] NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaNacimiento] [date] NULL,
	[Edad] [int] NULL,
	[Correo] [varchar](100) NULL,
	[Telefono] [varchar](20) NULL,
	[Direccion] [varchar](200) NULL,
	[Activo] [bit] NULL,
	[UsuarioID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmpleadoID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[DNI] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquiposInspeccion]    Script Date: 27/06/2025 08:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquiposInspeccion](
	[EquipoID] [int] IDENTITY(1,1) NOT NULL,
	[FiscalizacionID] [int] NULL,
	[EmpleadoID] [int] NULL,
	[RolEnEquipo] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[EquipoID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Establecimientos]    Script Date: 27/06/2025 08:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Establecimientos](
	[EstablecimientoID] [int] IDENTITY(1,1) NOT NULL,
	[NombreComercial] [nvarchar](100) NULL,
	[Direccion] [nvarchar](150) NULL,
	[TipoNegocio] [nvarchar](100) NULL,
	[EstadoSanitario] [nvarchar](20) NULL,
	[FechaRegistro] [datetime] NULL,
	[UsuarioRegistroID] [int] NULL,
	[RUC] [nvarchar](11) NULL,
	[RazonSocial] [nvarchar](200) NULL,
	[EstadoContribuyente] [nvarchar](50) NULL,
	[CondicionContribuyente] [nvarchar](50) NULL,
	[Ubigeo] [nvarchar](6) NULL,
	[Estado] [bit] NULL,
	[Correo] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[EstablecimientoID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evidencias]    Script Date: 27/06/2025 08:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evidencias](
	[EvidenciaID] [int] IDENTITY(1,1) NOT NULL,
	[FiscalizacionID] [int] NULL,
	[URLFoto] [nvarchar](300) NULL,
	[Descripcion] [nvarchar](300) NULL,
	[FechaSubida] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[EvidenciaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Firmas]    Script Date: 27/06/2025 08:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Firmas](
	[FirmaID] [int] IDENTITY(1,1) NOT NULL,
	[Responsable] [nvarchar](100) NULL,
	[DNIResponsable] [char](8) NULL,
	[FirmaImagen] [varbinary](max) NULL,
	[Confirmacion] [bit] NULL,
	[FechaFirma] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[FirmaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fiscalizaciones]    Script Date: 27/06/2025 08:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fiscalizaciones](
	[FiscalizacionID] [int] IDENTITY(1,1) NOT NULL,
	[EstablecimientoID] [int] NULL,
	[FechaFiscalizacion] [datetime] NULL,
	[TipoFiscalizacion] [nvarchar](50) NULL,
	[EstadoFiscalizacion] [nvarchar](20) NULL,
	[Observaciones] [nvarchar](max) NULL,
	[FirmaID] [int] NULL,
	[Notificado] [bit] NULL,
	[FechaNotificacion] [datetime] NULL,
	[FechaEjecucion] [date] NULL,
	[ResultadoFiscalizacion] [nvarchar](100) NULL,
	[EquipoID] [int] NULL,
	[UsuarioRegistroID] [int] NOT NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[FiscalizacionID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistorialAccesos]    Script Date: 27/06/2025 08:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialAccesos](
	[AccesoID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[IP] [nvarchar](50) NULL,
	[Tipo] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[AccesoID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistorialCambios]    Script Date: 27/06/2025 08:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialCambios](
	[CambioID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[TablaAfectada] [nvarchar](100) NOT NULL,
	[IDReferencia] [int] NOT NULL,
	[TipoCambio] [nvarchar](20) NULL,
	[Detalle] [nvarchar](255) NULL,
	[FechaCambio] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CambioID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IpDenunciaRate]    Script Date: 27/06/2025 08:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IpDenunciaRate](
	[IP] [nvarchar](50) NOT NULL,
	[Cantidad] [int] NULL,
	[UltimoIntento] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IP] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedidasCorrectivas]    Script Date: 27/06/2025 08:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedidasCorrectivas](
	[MedidaID] [int] IDENTITY(1,1) NOT NULL,
	[FiscalizacionID] [int] NULL,
	[TipoMedida] [nvarchar](50) NULL,
	[DetalleMedida] [nvarchar](max) NULL,
	[FechaAplicacion] [datetime] NULL,
	[EstadoMedida] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[MedidaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 27/06/2025 08:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RolID] [int] NOT NULL,
	[NombreRol] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[RolID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 27/06/2025 08:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompleto] [nvarchar](100) NULL,
	[DNI] [char](8) NULL,
	[Correo] [nvarchar](100) NULL,
	[Telefono] [nvarchar](15) NULL,
	[Usuario] [nvarchar](50) NULL,
	[RolID] [int] NULL,
	[Activo] [bit] NULL,
	[EsEmpleado] [bit] NULL,
	[ClaveHash] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Usuario] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VerificacionesExternas]    Script Date: 27/06/2025 08:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VerificacionesExternas](
	[VerificacionID] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [nvarchar](50) NULL,
	[Valor] [nvarchar](100) NULL,
	[Resultado] [nvarchar](200) NULL,
	[FechaVerificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[VerificacionID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Denuncias] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[Denuncias] ADD  DEFAULT ('Pendiente') FOR [Estado]
GO
ALTER TABLE [dbo].[EmpleadosRegistrados] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[EmpleadosRegistrados] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Establecimientos] ADD  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[Evidencias] ADD  DEFAULT (getdate()) FOR [FechaSubida]
GO
ALTER TABLE [dbo].[Fiscalizaciones] ADD  DEFAULT ((0)) FOR [Notificado]
GO
ALTER TABLE [dbo].[Fiscalizaciones] ADD  DEFAULT ((1)) FOR [UsuarioRegistroID]
GO
ALTER TABLE [dbo].[Fiscalizaciones] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[HistorialAccesos] ADD  DEFAULT (getdate()) FOR [FechaHora]
GO
ALTER TABLE [dbo].[HistorialCambios] ADD  DEFAULT (getdate()) FOR [FechaCambio]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((0)) FOR [EsEmpleado]
GO
ALTER TABLE [dbo].[VerificacionesExternas] ADD  DEFAULT (getdate()) FOR [FechaVerificacion]
GO
ALTER TABLE [dbo].[CriteriosEvaluados]  WITH CHECK ADD FOREIGN KEY([FiscalizacionID])
REFERENCES [dbo].[Fiscalizaciones] ([FiscalizacionID])
GO
ALTER TABLE [dbo].[Denuncias]  WITH CHECK ADD  CONSTRAINT [FK_Denuncias_Usuarios] FOREIGN KEY([UsuarioAtiendeID])
REFERENCES [dbo].[Usuarios] ([UsuarioID])
GO
ALTER TABLE [dbo].[Denuncias] CHECK CONSTRAINT [FK_Denuncias_Usuarios]
GO
ALTER TABLE [dbo].[EmpleadosRegistrados]  WITH CHECK ADD FOREIGN KEY([SupervisorID])
REFERENCES [dbo].[Usuarios] ([UsuarioID])
GO
ALTER TABLE [dbo].[EquiposInspeccion]  WITH CHECK ADD FOREIGN KEY([EmpleadoID])
REFERENCES [dbo].[EmpleadosRegistrados] ([EmpleadoID])
GO
ALTER TABLE [dbo].[EquiposInspeccion]  WITH CHECK ADD FOREIGN KEY([FiscalizacionID])
REFERENCES [dbo].[Fiscalizaciones] ([FiscalizacionID])
GO
ALTER TABLE [dbo].[EquiposInspeccion]  WITH CHECK ADD  CONSTRAINT [FK_Equipo_Empleado] FOREIGN KEY([EmpleadoID])
REFERENCES [dbo].[EmpleadosRegistrados] ([EmpleadoID])
GO
ALTER TABLE [dbo].[EquiposInspeccion] CHECK CONSTRAINT [FK_Equipo_Empleado]
GO
ALTER TABLE [dbo].[EquiposInspeccion]  WITH CHECK ADD  CONSTRAINT [FK_Equipo_Fiscalizacion] FOREIGN KEY([FiscalizacionID])
REFERENCES [dbo].[Fiscalizaciones] ([FiscalizacionID])
GO
ALTER TABLE [dbo].[EquiposInspeccion] CHECK CONSTRAINT [FK_Equipo_Fiscalizacion]
GO
ALTER TABLE [dbo].[Establecimientos]  WITH CHECK ADD FOREIGN KEY([UsuarioRegistroID])
REFERENCES [dbo].[Usuarios] ([UsuarioID])
GO
ALTER TABLE [dbo].[Evidencias]  WITH CHECK ADD FOREIGN KEY([FiscalizacionID])
REFERENCES [dbo].[Fiscalizaciones] ([FiscalizacionID])
GO
ALTER TABLE [dbo].[Fiscalizaciones]  WITH CHECK ADD FOREIGN KEY([EstablecimientoID])
REFERENCES [dbo].[Establecimientos] ([EstablecimientoID])
GO
ALTER TABLE [dbo].[Fiscalizaciones]  WITH CHECK ADD FOREIGN KEY([FirmaID])
REFERENCES [dbo].[Firmas] ([FirmaID])
GO
ALTER TABLE [dbo].[Fiscalizaciones]  WITH CHECK ADD  CONSTRAINT [FK_Fiscalizacion_Equipo] FOREIGN KEY([EquipoID])
REFERENCES [dbo].[EquiposInspeccion] ([EquipoID])
GO
ALTER TABLE [dbo].[Fiscalizaciones] CHECK CONSTRAINT [FK_Fiscalizacion_Equipo]
GO
ALTER TABLE [dbo].[HistorialAccesos]  WITH CHECK ADD FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuarios] ([UsuarioID])
GO
ALTER TABLE [dbo].[HistorialCambios]  WITH CHECK ADD FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuarios] ([UsuarioID])
GO
ALTER TABLE [dbo].[MedidasCorrectivas]  WITH CHECK ADD FOREIGN KEY([FiscalizacionID])
REFERENCES [dbo].[Fiscalizaciones] ([FiscalizacionID])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([RolID])
REFERENCES [dbo].[Roles] ([RolID])
GO
ALTER DATABASE [SIRESA] SET  READ_WRITE 
GO

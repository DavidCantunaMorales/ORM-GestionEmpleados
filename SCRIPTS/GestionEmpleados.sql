USE [master]
GO
/****** Object:  Database [GestionEmpleados]    Script Date: 2/3/2024 11:18:26 ******/
CREATE DATABASE [GestionEmpleados]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Gestione', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Gestione.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Gestione_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Gestione_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [GestionEmpleados] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GestionEmpleados].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GestionEmpleados] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GestionEmpleados] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GestionEmpleados] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GestionEmpleados] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GestionEmpleados] SET ARITHABORT OFF 
GO
ALTER DATABASE [GestionEmpleados] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GestionEmpleados] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GestionEmpleados] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GestionEmpleados] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GestionEmpleados] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GestionEmpleados] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GestionEmpleados] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GestionEmpleados] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GestionEmpleados] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GestionEmpleados] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GestionEmpleados] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GestionEmpleados] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GestionEmpleados] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GestionEmpleados] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GestionEmpleados] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GestionEmpleados] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GestionEmpleados] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GestionEmpleados] SET RECOVERY FULL 
GO
ALTER DATABASE [GestionEmpleados] SET  MULTI_USER 
GO
ALTER DATABASE [GestionEmpleados] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GestionEmpleados] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GestionEmpleados] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GestionEmpleados] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GestionEmpleados] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GestionEmpleados] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'GestionEmpleados', N'ON'
GO
ALTER DATABASE [GestionEmpleados] SET QUERY_STORE = ON
GO
ALTER DATABASE [GestionEmpleados] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [GestionEmpleados]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/3/2024 11:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 2/3/2024 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento](
	[IdDep] [int] IDENTITY(1,1) NOT NULL,
	[NombreDep] [nvarchar](max) NULL,
	[DescripcionDep] [nvarchar](max) NULL,
 CONSTRAINT [PK_Departamento] PRIMARY KEY CLUSTERED 
(
	[IdDep] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 2/3/2024 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[IdEmp] [int] IDENTITY(1,1) NOT NULL,
	[IdDep] [int] NOT NULL,
	[IdHorario] [int] NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Apellido] [nvarchar](max) NULL,
	[Direccion] [nvarchar](max) NULL,
	[Telefono] [nvarchar](max) NULL,
	[Correo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[IdEmp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Horario]    Script Date: 2/3/2024 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horario](
	[IdHorario] [int] IDENTITY(1,1) NOT NULL,
	[HoraEntrada] [nvarchar](max) NULL,
	[HoraSalida] [nvarchar](max) NULL,
 CONSTRAINT [PK_Horario] PRIMARY KEY CLUSTERED 
(
	[IdHorario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proyecto]    Script Date: 2/3/2024 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proyecto](
	[IdProyecto] [int] IDENTITY(1,1) NOT NULL,
	[NombreProyecto] [nvarchar](max) NULL,
	[DescripcionProyecto] [nvarchar](max) NULL,
	[FechaInicio] [nvarchar](max) NULL,
	[FechaFin] [nvarchar](max) NULL,
 CONSTRAINT [PK_Proyecto] PRIMARY KEY CLUSTERED 
(
	[IdProyecto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProyectoEmpleado]    Script Date: 2/3/2024 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProyectoEmpleado](
	[IdProyectoEmp] [int] IDENTITY(1,1) NOT NULL,
	[IdEmpleado] [int] NOT NULL,
	[IdProyecto] [int] NOT NULL,
 CONSTRAINT [PK_ProyectoEmpleado] PRIMARY KEY CLUSTERED 
(
	[IdProyectoEmp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salario]    Script Date: 2/3/2024 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salario](
	[IdSalario] [int] IDENTITY(1,1) NOT NULL,
	[Monto] [float] NOT NULL,
	[IdEmp] [int] NOT NULL,
 CONSTRAINT [PK_Salario] PRIMARY KEY CLUSTERED 
(
	[IdSalario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supervisor]    Script Date: 2/3/2024 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supervisor](
	[IdSup] [int] IDENTITY(1,1) NOT NULL,
	[IdDep] [int] NOT NULL,
	[IdHorario] [int] NOT NULL,
	[IdProyecto] [int] NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Apellido] [nvarchar](max) NULL,
	[Direccion] [nvarchar](max) NULL,
	[Telefono] [nvarchar](max) NULL,
	[Correo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Supervisor] PRIMARY KEY CLUSTERED 
(
	[IdSup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Empleado_IdDep]    Script Date: 2/3/2024 11:18:27 ******/
CREATE NONCLUSTERED INDEX [IX_Empleado_IdDep] ON [dbo].[Empleado]
(
	[IdDep] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Empleado_IdHorario]    Script Date: 2/3/2024 11:18:27 ******/
CREATE NONCLUSTERED INDEX [IX_Empleado_IdHorario] ON [dbo].[Empleado]
(
	[IdHorario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProyectoEmpleado_IdEmpleado]    Script Date: 2/3/2024 11:18:27 ******/
CREATE NONCLUSTERED INDEX [IX_ProyectoEmpleado_IdEmpleado] ON [dbo].[ProyectoEmpleado]
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProyectoEmpleado_IdProyecto]    Script Date: 2/3/2024 11:18:27 ******/
CREATE NONCLUSTERED INDEX [IX_ProyectoEmpleado_IdProyecto] ON [dbo].[ProyectoEmpleado]
(
	[IdProyecto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Salario_IdEmp]    Script Date: 2/3/2024 11:18:27 ******/
CREATE NONCLUSTERED INDEX [IX_Salario_IdEmp] ON [dbo].[Salario]
(
	[IdEmp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Supervisor_IdDep]    Script Date: 2/3/2024 11:18:27 ******/
CREATE NONCLUSTERED INDEX [IX_Supervisor_IdDep] ON [dbo].[Supervisor]
(
	[IdDep] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Supervisor_IdHorario]    Script Date: 2/3/2024 11:18:27 ******/
CREATE NONCLUSTERED INDEX [IX_Supervisor_IdHorario] ON [dbo].[Supervisor]
(
	[IdHorario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Supervisor_IdProyecto]    Script Date: 2/3/2024 11:18:27 ******/
CREATE NONCLUSTERED INDEX [IX_Supervisor_IdProyecto] ON [dbo].[Supervisor]
(
	[IdProyecto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Departamento_IdDep] FOREIGN KEY([IdDep])
REFERENCES [dbo].[Departamento] ([IdDep])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Departamento_IdDep]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Horario_IdHorario] FOREIGN KEY([IdHorario])
REFERENCES [dbo].[Horario] ([IdHorario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Horario_IdHorario]
GO
ALTER TABLE [dbo].[ProyectoEmpleado]  WITH CHECK ADD  CONSTRAINT [FK_ProyectoEmpleado_Empleado_IdEmpleado] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleado] ([IdEmp])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProyectoEmpleado] CHECK CONSTRAINT [FK_ProyectoEmpleado_Empleado_IdEmpleado]
GO
ALTER TABLE [dbo].[ProyectoEmpleado]  WITH CHECK ADD  CONSTRAINT [FK_ProyectoEmpleado_Proyecto_IdProyecto] FOREIGN KEY([IdProyecto])
REFERENCES [dbo].[Proyecto] ([IdProyecto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProyectoEmpleado] CHECK CONSTRAINT [FK_ProyectoEmpleado_Proyecto_IdProyecto]
GO
ALTER TABLE [dbo].[Salario]  WITH CHECK ADD  CONSTRAINT [FK_Salario_Empleado_IdEmp] FOREIGN KEY([IdEmp])
REFERENCES [dbo].[Empleado] ([IdEmp])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Salario] CHECK CONSTRAINT [FK_Salario_Empleado_IdEmp]
GO
ALTER TABLE [dbo].[Supervisor]  WITH CHECK ADD  CONSTRAINT [FK_Supervisor_Departamento_IdDep] FOREIGN KEY([IdDep])
REFERENCES [dbo].[Departamento] ([IdDep])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Supervisor] CHECK CONSTRAINT [FK_Supervisor_Departamento_IdDep]
GO
ALTER TABLE [dbo].[Supervisor]  WITH CHECK ADD  CONSTRAINT [FK_Supervisor_Horario_IdHorario] FOREIGN KEY([IdHorario])
REFERENCES [dbo].[Horario] ([IdHorario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Supervisor] CHECK CONSTRAINT [FK_Supervisor_Horario_IdHorario]
GO
ALTER TABLE [dbo].[Supervisor]  WITH CHECK ADD  CONSTRAINT [FK_Supervisor_Proyecto_IdProyecto] FOREIGN KEY([IdProyecto])
REFERENCES [dbo].[Proyecto] ([IdProyecto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Supervisor] CHECK CONSTRAINT [FK_Supervisor_Proyecto_IdProyecto]
GO
USE [master]
GO
ALTER DATABASE [GestionEmpleados] SET  READ_WRITE 
GO

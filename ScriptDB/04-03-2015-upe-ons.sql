USE [master]
GO
/****** Object:  Database [NeuroEolica]    Script Date: 04/03/2015 12:59:16 ******/
CREATE DATABASE [NeuroEolica]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'xamp', FILENAME = N'F:\DB_USERS\data01\xamp.mdf' , SIZE = 1024000KB , MAXSIZE = UNLIMITED, FILEGROWTH = 102400KB )
 LOG ON 
( NAME = N'xamp_log', FILENAME = N'F:\DB_USERS\data02\xamp_log.ldf' , SIZE = 51200KB , MAXSIZE = 2048GB , FILEGROWTH = 10240KB )
GO
ALTER DATABASE [NeuroEolica] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NeuroEolica].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NeuroEolica] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NeuroEolica] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NeuroEolica] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NeuroEolica] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NeuroEolica] SET ARITHABORT OFF 
GO
ALTER DATABASE [NeuroEolica] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NeuroEolica] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [NeuroEolica] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NeuroEolica] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NeuroEolica] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NeuroEolica] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NeuroEolica] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NeuroEolica] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NeuroEolica] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NeuroEolica] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NeuroEolica] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NeuroEolica] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NeuroEolica] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NeuroEolica] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NeuroEolica] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NeuroEolica] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NeuroEolica] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NeuroEolica] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NeuroEolica] SET RECOVERY FULL 
GO
ALTER DATABASE [NeuroEolica] SET  MULTI_USER 
GO
ALTER DATABASE [NeuroEolica] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NeuroEolica] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NeuroEolica] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NeuroEolica] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'NeuroEolica', N'ON'
GO
USE [NeuroEolica]
GO
/****** Object:  User [ONS\breno.poli]    Script Date: 04/03/2015 12:59:17 ******/
CREATE USER [ONS\breno.poli] FOR LOGIN [ONS\breno.poli] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [ONS\breno.poli]
GO
/****** Object:  Table [dbo].[calibracao]    Script Date: 04/03/2015 12:59:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[calibracao](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[foiCalibrado] [int] NULL,
	[data] [datetime] NULL,
	[idParque] [bigint] NULL,
	[tipo] [varchar](2) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[direcaovento]    Script Date: 04/03/2015 12:59:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[direcaovento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idParque] [int] NOT NULL,
	[dia] [int] NULL,
	[mes] [int] NULL,
	[ano] [int] NULL,
	[diaPrevisto] [int] NULL,
	[direcao00] [varchar](10) NULL,
	[direcao01] [varchar](10) NULL,
	[direcao02] [varchar](10) NULL,
	[direcao03] [varchar](10) NULL,
	[direcao04] [varchar](10) NULL,
	[direcao05] [varchar](10) NULL,
	[direcao06] [varchar](10) NULL,
	[direcao07] [varchar](10) NULL,
	[direcao08] [varchar](10) NULL,
	[direcao09] [varchar](10) NULL,
	[direcao10] [varchar](10) NULL,
	[direcao11] [varchar](10) NULL,
	[direcao12] [varchar](10) NULL,
	[direcao13] [varchar](10) NULL,
	[direcao14] [varchar](10) NULL,
	[direcao15] [varchar](10) NULL,
	[direcao16] [varchar](10) NULL,
	[direcao17] [varchar](10) NULL,
	[direcao18] [varchar](10) NULL,
	[direcao19] [varchar](10) NULL,
	[direcao20] [varchar](10) NULL,
	[direcao21] [varchar](10) NULL,
	[direcao22] [varchar](10) NULL,
	[direcao23] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[parque]    Script Date: 04/03/2015 12:59:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[parque](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NULL,
	[siglaCPTEC] [varchar](50) NOT NULL,
	[siglaPrevEOL] [varchar](50) NOT NULL,
	[siglaGETOT] [varchar](50) NOT NULL,
	[numMaquinas] [int] NOT NULL,
	[potenciaMaxima] [real] NOT NULL,
	[latitude] [float] NULL,
	[longitude] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[parque_eolico_importacao]    Script Date: 04/03/2015 12:59:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[parque_eolico_importacao](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[idParque] [int] NOT NULL,
	[dia] [int] NULL,
	[mes] [int] NULL,
	[ano] [int] NULL,
	[hora] [int] NULL,
	[minuto] [int] NULL,
	[segundo] [int] NULL,
	[nMaqMedia] [int] NULL,
	[nMaqDesv_Pad] [varchar](40) NULL,
	[nMaqMinimo] [int] NULL,
	[nMaqMaximo] [int] NULL,
	[nMaqN_Validos] [int] NULL,
	[PotenciaMedia] [float] NULL,
	[PotenciaDesv_Pad] [varchar](40) NULL,
	[PotenciaMinimo] [varchar](40) NULL,
	[PotenciaMaximo] [varchar](40) NULL,
	[PotenciaN_Validos] [int] NULL,
	[VelocidadeMedia] [varchar](10) NULL,
	[VelocidadeDesv_Pad] [varchar](10) NULL,
	[VelocidadeMinimo] [varchar](10) NULL,
	[VelocidadeMaximo] [varchar](10) NULL,
	[VelocidadeN_Validos] [varchar](10) NULL,
	[TemperaturaMedia] [varchar](10) NULL,
	[TemperaturaDesv_Pad] [varchar](10) NULL,
	[TemperaturaMinimo] [varchar](10) NULL,
	[TemperaturaMaximo] [varchar](10) NULL,
	[TemperaturaN_Validos] [varchar](10) NULL,
	[PressaoMedia] [varchar](40) NULL,
	[PressaoDesv_Pad] [varchar](40) NULL,
	[PressaoMinimo] [varchar](40) NULL,
	[PressaoMaximo] [varchar](40) NULL,
	[PressaoN_Validos] [varchar](40) NULL,
	[DirecaoMedia] [varchar](40) NULL,
	[DirecaoDesv_Pad] [varchar](40) NULL,
	[DirecaoMinimo] [varchar](40) NULL,
	[DirecaoMaximo] [varchar](40) NULL,
	[DirecaoN_Validos] [varchar](40) NULL,
	[intervalo] [varchar](10) NULL,
 CONSTRAINT [PK__parque_e__3213E83F5D5DC694] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[potencia_media_hora_mes]    Script Date: 04/03/2015 12:59:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[potencia_media_hora_mes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[qtdDias] [int] NULL,
	[potenciaMedia] [varchar](1) NULL,
	[hora] [int] NULL,
	[mes] [int] NULL,
	[ano] [int] NULL,
	[desvioPadrao] [float] NOT NULL,
	[idParque] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[velocidadevento]    Script Date: 04/03/2015 12:59:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[velocidadevento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idParque] [int] NOT NULL,
	[dia] [int] NULL,
	[mes] [int] NULL,
	[ano] [int] NULL,
	[diaPrevisto] [int] NULL,
	[velocidade00] [varchar](10) NULL,
	[velocidade01] [varchar](10) NULL,
	[velocidade02] [varchar](10) NULL,
	[velocidade03] [varchar](10) NULL,
	[velocidade04] [varchar](10) NULL,
	[velocidade05] [varchar](10) NULL,
	[velocidade06] [varchar](10) NULL,
	[velocidade07] [varchar](10) NULL,
	[velocidade08] [varchar](10) NULL,
	[velocidade09] [varchar](10) NULL,
	[velocidade10] [varchar](10) NULL,
	[velocidade11] [varchar](10) NULL,
	[velocidade12] [varchar](10) NULL,
	[velocidade13] [varchar](10) NULL,
	[velocidade14] [varchar](10) NULL,
	[velocidade15] [varchar](10) NULL,
	[velocidade16] [varchar](10) NULL,
	[velocidade17] [varchar](10) NULL,
	[velocidade18] [varchar](10) NULL,
	[velocidade19] [varchar](10) NULL,
	[velocidade20] [varchar](10) NULL,
	[velocidade21] [varchar](10) NULL,
	[velocidade22] [varchar](10) NULL,
	[velocidade23] [varchar](10) NULL,
 CONSTRAINT [PK__velocida__3213E83F19DDC7A4] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[calibracao] ADD  DEFAULT ('0') FOR [foiCalibrado]
GO
ALTER TABLE [dbo].[calibracao] ADD  DEFAULT (NULL) FOR [data]
GO
ALTER TABLE [dbo].[calibracao] ADD  DEFAULT (NULL) FOR [idParque]
GO
ALTER TABLE [dbo].[calibracao] ADD  DEFAULT (NULL) FOR [tipo]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [dia]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [mes]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [ano]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [diaPrevisto]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao00]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao01]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao02]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao03]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao04]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao05]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao06]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao07]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao08]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao09]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao10]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao11]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao12]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao13]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao14]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao15]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao16]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao17]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao18]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao19]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao20]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao21]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao22]
GO
ALTER TABLE [dbo].[direcaovento] ADD  DEFAULT (NULL) FOR [direcao23]
GO
ALTER TABLE [dbo].[parque] ADD  DEFAULT (NULL) FOR [nome]
GO
ALTER TABLE [dbo].[parque] ADD  DEFAULT (NULL) FOR [latitude]
GO
ALTER TABLE [dbo].[parque] ADD  DEFAULT (NULL) FOR [longitude]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eoli__dia__0D44F85C]  DEFAULT (NULL) FOR [dia]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eoli__mes__0E391C95]  DEFAULT (NULL) FOR [mes]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eoli__ano__0F2D40CE]  DEFAULT (NULL) FOR [ano]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eol__hora__10216507]  DEFAULT (NULL) FOR [hora]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__minut__11158940]  DEFAULT (NULL) FOR [minuto]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__segun__1209AD79]  DEFAULT (NULL) FOR [segundo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__nMaqM__12FDD1B2]  DEFAULT (NULL) FOR [nMaqMedia]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__nMaqD__13F1F5EB]  DEFAULT (NULL) FOR [nMaqDesv_Pad]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__nMaqM__14E61A24]  DEFAULT (NULL) FOR [nMaqMinimo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__nMaqM__15DA3E5D]  DEFAULT (NULL) FOR [nMaqMaximo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__nMaqN__16CE6296]  DEFAULT (NULL) FOR [nMaqN_Validos]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Poten__17C286CF]  DEFAULT (NULL) FOR [PotenciaMedia]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Poten__18B6AB08]  DEFAULT (NULL) FOR [PotenciaDesv_Pad]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Poten__19AACF41]  DEFAULT (NULL) FOR [PotenciaMinimo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Poten__1A9EF37A]  DEFAULT (NULL) FOR [PotenciaMaximo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Poten__1B9317B3]  DEFAULT (NULL) FOR [PotenciaN_Validos]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Veloc__1C873BEC]  DEFAULT (NULL) FOR [VelocidadeMedia]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Veloc__1D7B6025]  DEFAULT (NULL) FOR [VelocidadeDesv_Pad]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Veloc__1E6F845E]  DEFAULT (NULL) FOR [VelocidadeMinimo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Veloc__1F63A897]  DEFAULT (NULL) FOR [VelocidadeMaximo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Veloc__2057CCD0]  DEFAULT (NULL) FOR [VelocidadeN_Validos]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Tempe__214BF109]  DEFAULT (NULL) FOR [TemperaturaMedia]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Tempe__22401542]  DEFAULT (NULL) FOR [TemperaturaDesv_Pad]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Tempe__2334397B]  DEFAULT (NULL) FOR [TemperaturaMinimo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Tempe__24285DB4]  DEFAULT (NULL) FOR [TemperaturaMaximo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Tempe__251C81ED]  DEFAULT (NULL) FOR [TemperaturaN_Validos]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Press__2610A626]  DEFAULT (NULL) FOR [PressaoMedia]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Press__2704CA5F]  DEFAULT (NULL) FOR [PressaoDesv_Pad]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Press__27F8EE98]  DEFAULT (NULL) FOR [PressaoMinimo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Press__28ED12D1]  DEFAULT (NULL) FOR [PressaoMaximo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Press__29E1370A]  DEFAULT (NULL) FOR [PressaoN_Validos]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Direc__2AD55B43]  DEFAULT (NULL) FOR [DirecaoMedia]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Direc__2BC97F7C]  DEFAULT (NULL) FOR [DirecaoDesv_Pad]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Direc__2CBDA3B5]  DEFAULT (NULL) FOR [DirecaoMinimo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Direc__2DB1C7EE]  DEFAULT (NULL) FOR [DirecaoMaximo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__Direc__2EA5EC27]  DEFAULT (NULL) FOR [DirecaoN_Validos]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  CONSTRAINT [DF__parque_eo__inter__2F9A1060]  DEFAULT (NULL) FOR [intervalo]
GO
ALTER TABLE [dbo].[potencia_media_hora_mes] ADD  DEFAULT (NULL) FOR [qtdDias]
GO
ALTER TABLE [dbo].[potencia_media_hora_mes] ADD  DEFAULT (NULL) FOR [potenciaMedia]
GO
ALTER TABLE [dbo].[potencia_media_hora_mes] ADD  DEFAULT (NULL) FOR [hora]
GO
ALTER TABLE [dbo].[potencia_media_hora_mes] ADD  DEFAULT (NULL) FOR [mes]
GO
ALTER TABLE [dbo].[potencia_media_hora_mes] ADD  DEFAULT (NULL) FOR [ano]
GO
ALTER TABLE [dbo].[potencia_media_hora_mes] ADD  DEFAULT ('0') FOR [desvioPadrao]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidadev__dia__3CF40B7E]  DEFAULT (NULL) FOR [dia]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidadev__mes__3DE82FB7]  DEFAULT (NULL) FOR [mes]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidadev__ano__3EDC53F0]  DEFAULT (NULL) FOR [ano]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__diaPr__3FD07829]  DEFAULT (NULL) FOR [diaPrevisto]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__40C49C62]  DEFAULT (NULL) FOR [velocidade00]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__41B8C09B]  DEFAULT (NULL) FOR [velocidade01]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__42ACE4D4]  DEFAULT (NULL) FOR [velocidade02]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__43A1090D]  DEFAULT (NULL) FOR [velocidade03]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__44952D46]  DEFAULT (NULL) FOR [velocidade04]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__4589517F]  DEFAULT (NULL) FOR [velocidade05]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__467D75B8]  DEFAULT (NULL) FOR [velocidade06]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__477199F1]  DEFAULT (NULL) FOR [velocidade07]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__4865BE2A]  DEFAULT (NULL) FOR [velocidade08]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__4959E263]  DEFAULT (NULL) FOR [velocidade09]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__4A4E069C]  DEFAULT (NULL) FOR [velocidade10]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__4B422AD5]  DEFAULT (NULL) FOR [velocidade11]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__4C364F0E]  DEFAULT (NULL) FOR [velocidade12]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__4D2A7347]  DEFAULT (NULL) FOR [velocidade13]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__4E1E9780]  DEFAULT (NULL) FOR [velocidade14]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__4F12BBB9]  DEFAULT (NULL) FOR [velocidade15]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__5006DFF2]  DEFAULT (NULL) FOR [velocidade16]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__50FB042B]  DEFAULT (NULL) FOR [velocidade17]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__51EF2864]  DEFAULT (NULL) FOR [velocidade18]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__52E34C9D]  DEFAULT (NULL) FOR [velocidade19]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__53D770D6]  DEFAULT (NULL) FOR [velocidade20]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__54CB950F]  DEFAULT (NULL) FOR [velocidade21]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__55BFB948]  DEFAULT (NULL) FOR [velocidade22]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  CONSTRAINT [DF__velocidad__veloc__56B3DD81]  DEFAULT (NULL) FOR [velocidade23]
GO
ALTER TABLE [dbo].[direcaovento]  WITH CHECK ADD FOREIGN KEY([idParque])
REFERENCES [dbo].[parque] ([id])
GO
ALTER TABLE [dbo].[direcaovento]  WITH CHECK ADD  CONSTRAINT [fk_id_parque] FOREIGN KEY([idParque])
REFERENCES [dbo].[parque] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[direcaovento] CHECK CONSTRAINT [fk_id_parque]
GO
ALTER TABLE [dbo].[parque_eolico_importacao]  WITH CHECK ADD  CONSTRAINT [FK__parque_eo__idPar__318258D2] FOREIGN KEY([idParque])
REFERENCES [dbo].[parque] ([id])
GO
ALTER TABLE [dbo].[parque_eolico_importacao] CHECK CONSTRAINT [FK__parque_eo__idPar__318258D2]
GO
ALTER TABLE [dbo].[parque_eolico_importacao]  WITH CHECK ADD  CONSTRAINT [parque_eolico_importacao_ibfk_1] FOREIGN KEY([idParque])
REFERENCES [dbo].[parque] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[parque_eolico_importacao] CHECK CONSTRAINT [parque_eolico_importacao_ibfk_1]
GO
ALTER TABLE [dbo].[potencia_media_hora_mes]  WITH CHECK ADD FOREIGN KEY([idParque])
REFERENCES [dbo].[parque] ([id])
GO
ALTER TABLE [dbo].[potencia_media_hora_mes]  WITH CHECK ADD  CONSTRAINT [potencia_media_hora_mes_ibfk_1] FOREIGN KEY([idParque])
REFERENCES [dbo].[parque] ([id])
GO
ALTER TABLE [dbo].[potencia_media_hora_mes] CHECK CONSTRAINT [potencia_media_hora_mes_ibfk_1]
GO
ALTER TABLE [dbo].[velocidadevento]  WITH CHECK ADD  CONSTRAINT [FK__velocidad__idPar__57A801BA] FOREIGN KEY([idParque])
REFERENCES [dbo].[parque] ([id])
GO
ALTER TABLE [dbo].[velocidadevento] CHECK CONSTRAINT [FK__velocidad__idPar__57A801BA]
GO
ALTER TABLE [dbo].[velocidadevento]  WITH CHECK ADD  CONSTRAINT [fk_id_parque_eolico] FOREIGN KEY([idParque])
REFERENCES [dbo].[parque] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[velocidadevento] CHECK CONSTRAINT [fk_id_parque_eolico]
GO
ALTER TABLE [dbo].[calibracao]  WITH CHECK ADD CHECK  (([tipo]='VP' OR [tipo]='TR' OR [tipo]='PP'))
GO
ALTER TABLE [dbo].[parque_eolico_importacao]  WITH CHECK ADD  CONSTRAINT [CK__parque_eo__inter__308E3499] CHECK  (([intervalo]='10min' OR [intervalo]='30min'))
GO
ALTER TABLE [dbo].[parque_eolico_importacao] CHECK CONSTRAINT [CK__parque_eo__inter__308E3499]
GO
USE [master]
GO
ALTER DATABASE [NeuroEolica] SET  READ_WRITE 
GO

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
/****** Object:  Table [dbo].[direcaovento]    Script Date: 23/02/2015 11:18:45 ******/
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
/****** Object:  Table [dbo].[parque]    Script Date: 23/02/2015 11:18:45 ******/
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
/****** Object:  Table [dbo].[parque_eolico_importacao]    Script Date: 23/02/2015 11:18:45 ******/
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
	[PotenciaMedia] [varchar](40) NULL,
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
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[potencia_media_hora_mes]    Script Date: 23/02/2015 11:18:45 ******/
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
/****** Object:  Table [dbo].[velocidadevento]    Script Date: 23/02/2015 11:18:45 ******/
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
	[velocidade00] [varchar](1) NULL,
	[velocidade01] [varchar](1) NULL,
	[velocidade02] [varchar](1) NULL,
	[velocidade03] [varchar](1) NULL,
	[velocidade04] [varchar](1) NULL,
	[velocidade05] [varchar](1) NULL,
	[velocidade06] [varchar](1) NULL,
	[velocidade07] [varchar](1) NULL,
	[velocidade08] [varchar](1) NULL,
	[velocidade09] [varchar](1) NULL,
	[velocidade10] [varchar](1) NULL,
	[velocidade11] [varchar](1) NULL,
	[velocidade12] [varchar](1) NULL,
	[velocidade13] [varchar](1) NULL,
	[velocidade14] [varchar](1) NULL,
	[velocidade15] [varchar](1) NULL,
	[velocidade16] [varchar](1) NULL,
	[velocidade17] [varchar](1) NULL,
	[velocidade18] [varchar](1) NULL,
	[velocidade19] [varchar](1) NULL,
	[velocidade20] [varchar](1) NULL,
	[velocidade21] [varchar](1) NULL,
	[velocidade22] [varchar](1) NULL,
	[velocidade23] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
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
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [dia]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [mes]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [ano]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [hora]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [minuto]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [segundo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [nMaqMedia]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [nMaqDesv_Pad]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [nMaqMinimo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [nMaqMaximo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [nMaqN_Validos]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [PotenciaMedia]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [PotenciaDesv_Pad]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [PotenciaMinimo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [PotenciaMaximo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [PotenciaN_Validos]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [VelocidadeMedia]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [VelocidadeDesv_Pad]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [VelocidadeMinimo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [VelocidadeMaximo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [VelocidadeN_Validos]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [TemperaturaMedia]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [TemperaturaDesv_Pad]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [TemperaturaMinimo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [TemperaturaMaximo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [TemperaturaN_Validos]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [PressaoMedia]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [PressaoDesv_Pad]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [PressaoMinimo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [PressaoMaximo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [PressaoN_Validos]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [DirecaoMedia]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [DirecaoDesv_Pad]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [DirecaoMinimo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [DirecaoMaximo]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [DirecaoN_Validos]
GO
ALTER TABLE [dbo].[parque_eolico_importacao] ADD  DEFAULT (NULL) FOR [intervalo]
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
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [dia]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [mes]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [ano]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [diaPrevisto]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade00]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade01]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade02]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade03]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade04]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade05]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade06]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade07]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade08]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade09]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade10]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade11]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade12]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade13]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade14]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade15]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade16]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade17]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade18]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade19]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade20]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade21]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade22]
GO
ALTER TABLE [dbo].[velocidadevento] ADD  DEFAULT (NULL) FOR [velocidade23]
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
ALTER TABLE [dbo].[parque_eolico_importacao]  WITH CHECK ADD FOREIGN KEY([idParque])
REFERENCES [dbo].[parque] ([id])
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
ALTER TABLE [dbo].[velocidadevento]  WITH CHECK ADD FOREIGN KEY([idParque])
REFERENCES [dbo].[parque] ([id])
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
ALTER TABLE [dbo].[parque_eolico_importacao]  WITH CHECK ADD CHECK  (([intervalo]='10min' OR [intervalo]='30min'))
GO
USE [master]s
GO
ALTER DATABASE [NeuroEolica] SET  READ_WRITE 
GO

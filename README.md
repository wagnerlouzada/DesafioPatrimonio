Patrimonio/Home
Neste teste utilizou-se o EF6, porém a utilização deste framework não é a opção que o autor prefere utilizar, pois diminui o controle sobre o código, o tutor prefere utilizar uma abordagem que não utilize ORMs, e a geração das diversas classes, controladores etc, seja feita manualmente.

Contudo como o mercado tem demonstrado preferÊncia pela utilização de patterns e ORMs, especialmente EF, Dapper, e similares, julgou-se mais adequado realizar o DESAFIO utilizando-se o EF.

O autor prefere utilizar ferramentas como o SqlKata, que permitem um reaproveitamento dos SQL STATEMENTS para diversos SGBDs, contudo sem gerar sobrecarga de processamento significativa.

Esta aplicação tem por objetivo medir o conhecimento e a habilidade do autor na implementação de API para manutenção de dados em um SGBD SQL-SERVER.

Os quesitos a serem obeservados parecem ser:

Conhecimento,
Habilidade,
Organização,
etc

Script para criação das tabelas:

USE [Patrimonio]
GO
ALTER TABLE [dbo].[Patrimonio] DROP CONSTRAINT [FK_Patrimonio_Marcas]
GO

DROP INDEX [IX_Patrimonio] ON [dbo].[Patrimonio]
GO

DROP INDEX [IX_Marcas] ON [dbo].[Marcas]
GO

DROP TABLE [dbo].[Patrimonio]
GO

DROP TABLE [dbo].[Marcas]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[MarcaId] [bigint] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NULL,
	[Descricao] [varchar](max) NULL,
 CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED 
(
	[MarcaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patrimonio](
	[Tombo] [bigint] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NULL,
	[Descricao] [varchar](max) NULL,
	[MarcaId] [bigint] NULL,
 CONSTRAINT [PK_Patrimonio] PRIMARY KEY CLUSTERED 
(
	[Tombo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_Marcas] ON [dbo].[Marcas]
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_Patrimonio] ON [dbo].[Patrimonio]
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Patrimonio]  WITH CHECK ADD  CONSTRAINT [FK_Patrimonio_Marcas] FOREIGN KEY([MarcaId])
REFERENCES [dbo].[Marcas] ([MarcaId])
GO
ALTER TABLE [dbo].[Patrimonio] CHECK CONSTRAINT [FK_Patrimonio_Marcas]
GO

USE CadastroDevedores


GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 08/05/2017 15:02:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[NomeCompleto] [varchar](255) NOT NULL,
	[DataNascimento] [datetime2](7) NOT NULL,
	[CPF] [varchar](11) NOT NULL,
	[Endereco] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pagamentos]    Script Date: 08/05/2017 15:02:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pagamentos](
	[PagamentoId] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[Valor] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK_Pagamentos] PRIMARY KEY CLUSTERED 
(
	[PagamentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vendas]    Script Date: 08/05/2017 15:02:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendas](
	[VendaId] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[Valor] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK_Vendas] PRIMARY KEY CLUSTERED 
(
	[VendaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Pagamentos]  WITH CHECK ADD  CONSTRAINT [FK_Pagamentos_Clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([ClienteId])
GO
ALTER TABLE [dbo].[Pagamentos] CHECK CONSTRAINT [FK_Pagamentos_Clientes]
GO
ALTER TABLE [dbo].[Vendas]  WITH CHECK ADD  CONSTRAINT [FK_Vendas_Clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([ClienteId])
GO
ALTER TABLE [dbo].[Vendas] CHECK CONSTRAINT [FK_Vendas_Clientes]
GO

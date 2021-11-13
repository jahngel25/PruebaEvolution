CREATE DATABASE PruebaEvolution
GO
CREATE TABLE [Usuario](
	[UsuID] [uniqueidentifier] NOT NULL,	
	[UsuNombre] [varchar](150),	
	[UsuPass] [varchar](250),
	[UsuEstado] [int],
	[UsuFechaCre] [datetime],
	[UsuFechaActu] [datetime]
 CONSTRAINT [PK__Usuario] PRIMARY KEY CLUSTERED 
(
	[UsuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [Producto](
	[ProID] [uniqueidentifier] NOT NULL,	
	[ProDesc] [varchar](150),	
	[ProValor] [decimal],
	[ProEstado] [int],
	[ProFechaCre] [datetime],
	[ProFechaActu] [datetime]
 CONSTRAINT [PK__Producto] PRIMARY KEY CLUSTERED 
(
	[ProID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [Pedido](
	[PedID] [uniqueidentifier] NOT NULL,	
	[PedUsu] [uniqueidentifier],
	[PedProdID] [uniqueidentifier],
	[PedVrUnit] [decimal],
	[PedCant] [int],
	[PedSubTot] [decimal],
	[PedIVA] [decimal],
	[PedTotal] [decimal],
	[PedEstado] [int],
	[PedFechaCre] [datetime],
	[PedFechaActu] [datetime]
 CONSTRAINT [PK__Pedido] PRIMARY KEY CLUSTERED 
(
	[PedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [Pedido] WITH CHECK ADD  CONSTRAINT [FK_Pedido.Producto] FOREIGN KEY([PedProdID])
REFERENCES [Producto] ([ProID])
ON DELETE CASCADE
GO
ALTER TABLE [Pedido] CHECK CONSTRAINT [FK_Pedido.Producto]
GO
ALTER TABLE [Pedido] WITH CHECK ADD  CONSTRAINT [FK_Pedido.Usuario] FOREIGN KEY([PedUsu])
REFERENCES [Usuario] ([UsuID])
ON DELETE CASCADE
GO
ALTER TABLE [Pedido] CHECK CONSTRAINT [FK_Pedido.Usuario]
GO




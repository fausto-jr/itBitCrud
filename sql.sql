USE [ItBitCrud]
GO

/****** Object:  Table [dbo].[Sex]    Script Date: 12/10/2021 15:44:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sex](
	[SexoId] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](15) NOT NULL
) ON [PRIMARY]
GO


USE [ItBitCrud]
GO

/****** Object:  Table [dbo].[User]    Script Date: 12/10/2021 15:46:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[DataNascimento] [date] NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Senha] [varchar](30) NOT NULL,
	[Ativo] [bit] NOT NULL,
	[SexoId] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-- PROCEDURES

--Add Record
CREATE PROCEDURE SP_User_Insert
@UsuarioId int,
@Nome varchar(200),
@DataNascimento date,
@Email varchar(100),
@Senha varchar(50),
@Ativo bit,
@SexoId int
AS
BEGIN
INSERT INTO [dbo].[User](Nome, DataNascimento, Email, Senha, Ativo, SexoId) 
VALUES (@Nome,@DataNascimento,@Email,@Senha,@Ativo,@SexoId)
end


--Display All Records
CREATE PROCEDURE SP_User_View
AS
BEGIN
SELECT * from [dbo].[User]
end

--Display All Records With Sex
CREATE PROCEDURE SP_User_View2
AS
BEGIN
SELECT [UsuarioId]
      ,[Nome]
      ,convert(varchar(10), [DataNascimento], 103) as DataNascimento
      ,[Email]
      ,[Senha]
      ,[Ativo]
      ,[User].[SexoId]
	  ,[Sex].[Descricao] FROM [dbo].[User]
	  INNER JOIN [dbo].[Sex] ON [User].[SexoId] = [Sex].[SexoId]
end
	
--Update Record
CREATE PROCEDURE SP_User_Update
@UsuarioId int,
@Nome varchar(200),
@DataNascimento date,
@Email varchar(100),
@Senha varchar(50),
@Ativo bit,
@SexoId int
AS
BEGIN
UPDATE [dbo].[User] 
SET 
Nome=@Nome,
DataNascimento=@DataNascimento,
Email=@Email,
Senha=@Senha,
Ativo=@Ativo,
SexoId=@SexoId 
WHERE 
UsuarioId = @UsuarioId
end


--Delete Records
CREATE PROCEDURE SP_User_Delete
@UsuarioId int
AS
BEGIN
DELETE from [dbo].[User] 
WHERE
UsuarioId = @UsuarioId
end


--Display All Sex Records
CREATE PROCEDURE SP_Sex_View
AS
BEGIN
SELECT * from [dbo].[Sex]
end

--Display Single Sex Records
CREATE PROCEDURE SP_Sex_View_Single
@SexoId int
AS
BEGIN
SELECT Descricao from [dbo].[Sex] WHERE SexoId = @SexoId
end
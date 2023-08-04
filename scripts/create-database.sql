USE master;
GO

IF NOT EXISTS(SELECT name FROM sys.databases WHERE name = 'SolucaoLancamentos')
    BEGIN
    CREATE DATABASE [SolucaoLancamentos];
        PRINT 'Banco de dados criado com sucesso.';
    END
ELSE
    BEGIN
        PRINT 'O banco de dados já existe.';
    END
GO

USE [SolucaoLancamentos];

IF NOT EXISTS (SELECT schema_name FROM information_schema.schemata WHERE schema_name = 'WM')
BEGIN
    EXEC('CREATE SCHEMA WM');
    PRINT 'Schema WM criado.';
END
ELSE
BEGIN
    PRINT 'Schema WM já existe.';
END

IF NOT EXISTS (SELECT schema_name FROM information_schema.schemata WHERE schema_name = 'RM')
BEGIN
    EXEC('CREATE SCHEMA RM');
    PRINT 'Schema RM criado.';
END
ELSE
BEGIN
    PRINT 'Schema RM já existe.';
END

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Lancamentos')
BEGIN
	CREATE TABLE [RM].[Lancamentos] 
	(
		[Id] INT IDENTITY(1,1) NOT NULL,
		[AggregateId] [UNIQUEIDENTIFIER] NOT NULL,
		[DataCriacao] [DATETIME] NOT NULL,
		[Saldo] [DECIMAL](10,2) NOT NULL
		CONSTRAINT PK_RM_Lancamentos PRIMARY KEY (Id)
	) 
    PRINT 'Tabela Lancamentos criada.';
END
ELSE
BEGIN
    PRINT 'A tabela Lancamentos já existe.';
END

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Events')
BEGIN
	CREATE TABLE [WM].[Events] 
	(
		[Id] INT IDENTITY(1,1) NOT NULL,
		[AggregateId] [UNIQUEIDENTIFIER] NOT NULL,
		[Data] [DATETIME] NOT NULL,
		[Evento] [VARCHAR](200) NOT NULL,
		[Dados] [VARCHAR](MAX) NOT NULL
		CONSTRAINT PK_WM_Events PRIMARY KEY (Id)
	) 
    PRINT 'Tabela Events criada.';
END
ELSE
BEGIN
    PRINT 'A tabela Events já existe.';
END

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'LancamentosEvento')
BEGIN
	CREATE TABLE [RM].[LancamentosEvento]
	(
		[Evento] VARCHAR(200) NOT NULL UNIQUE,
		[Descricao] VARCHAR(200)
	)

	INSERT INTO [RM].[LancamentosEvento] VALUES
	('LancamentoCriado', 'Criado'),
	('DebitoLancado', 'Debitado'),
	('CreditoLancado', 'Creditado')
	
    PRINT 'Tabela LancamentoEvento criada.';
END
ELSE
BEGIN
    PRINT 'A tabela LancamentoEvento já existe.';
END
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [tbFuncionario] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] VARCHAR(100) NULL,
    [SobreNome] VARCHAR(100) NULL,
    [CPF] VARCHAR(100) NULL,
    [Setor] varchar(50) NOT NULL,
    [SalarioBruto] decimal NOT NULL,
    [DataDeAdmissao] datetime NOT NULL,
    [PossuiDescontoPlanoDeSaude] bit NOT NULL,
    [PossuiDescontoPlanoDental] bit NOT NULL,
    [PossuiDescontoValeTransporte] bit NOT NULL,
    CONSTRAINT [PK_tbFuncionario] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210511013151_Initial', N'3.1.14');

GO


-- Criação do banco de dados
CREATE DATABASE AutoInventoryPro;
GO

USE AutoInventoryPro;
GO

-- -----------------------------------------------------
-- Tabela Fabricantes
-- -----------------------------------------------------
CREATE TABLE Fabricantes (
    FabricanteID INT NOT NULL PRIMARY KEY,
    Nome NVARCHAR(100) UNIQUE,
    PaisOrigem NVARCHAR(50),
    AnoFundacao INT,
    Website NVARCHAR(255),
    CriadoEm DATETIME NOT NULL,
    AlteradoEm DATETIME NULL, 
    Delecao_Logica BIT DEFAULT 0
);
GO

-- -----------------------------------------------------
-- Tabela Veiculos
-- -----------------------------------------------------
CREATE TABLE Veiculos (
    VeiculoID INT NOT NULL PRIMARY KEY,
    Modelo NVARCHAR(100),
    AnoFabricacao INT,
    Preco DECIMAL(10,2),
    TipoVeiculo INT,
    Descricao NVARCHAR(250),
    FabricanteID INT NOT NULL,
    CriadoEm DATETIME NOT NULL,
    AlteradoEm DATETIME NULL,
    Delecao_Logica BIT DEFAULT 0,
    FOREIGN KEY (FabricanteID) REFERENCES Fabricantes(FabricanteID) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

-- -----------------------------------------------------
-- Tabela Concessionarias
-- -----------------------------------------------------
CREATE TABLE Concessionarias (
    ConcessionariaID INT NOT NULL PRIMARY KEY,
    Nome NVARCHAR(100) UNIQUE,
    Endereco NVARCHAR(255),
    Cidade NVARCHAR(50),
    Estado NVARCHAR(50),
    CEP NVARCHAR(10),
    Telefone NVARCHAR(15),
    Email NVARCHAR(100),
    CapacidadeMaximaVeiculos INT,
    CriadoEm DATETIME NOT NULL,
    AlteradoEm DATETIME NULL,
    Delecao_Logica BIT DEFAULT 0
);
GO

-- -----------------------------------------------------
-- Tabela Clientes
-- -----------------------------------------------------
CREATE TABLE Clientes (
    ClienteID INT NOT NULL PRIMARY KEY,
    Nome NVARCHAR(100) UNIQUE,
    CPF NVARCHAR(11) UNIQUE,
    Telefone NVARCHAR(15),
    CriadoEm DATETIME NOT NULL,
    AlteradoEm DATETIME NULL,
    Delecao_Logica BIT DEFAULT 0
);
GO

-- -----------------------------------------------------
-- Tabela Vendas
-- -----------------------------------------------------
CREATE TABLE Vendas (
    VendaID INT NOT NULL PRIMARY KEY,
    DataVenda DATETIME,
    PrecoVenda DECIMAL(10,2),
    ProtocoloVenda NVARCHAR(20),
    VeiculoID INT NOT NULL,
    ConcessionariaID INT NOT NULL,
    ClienteID INT NOT NULL,
    CriadoEm DATETIME NOT NULL, 
    AlteradoEm DATETIME NULL,
    Delecao_Logica BIT DEFAULT 0,
    FOREIGN KEY (VeiculoID) REFERENCES Veiculos(VeiculoID) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (ConcessionariaID) REFERENCES Concessionarias(ConcessionariaID) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

-- -----------------------------------------------------
-- Tabela Usuarios
-- -----------------------------------------------------
CREATE TABLE Usuarios (
    UsuarioID INT NOT NULL PRIMARY KEY,
    NomeUsuario NVARCHAR(50),
    Senha NVARCHAR(255),
    Email NVARCHAR(100),
    NivelAcesso INT,
    CriadoEm DATETIME NOT NULL,
    AlteradoEm DATETIME NULL,
    Delecao_Logica BIT DEFAULT 0
);
GO

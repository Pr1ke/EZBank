CREATE DATABASE EZBank
GO

USE EZBank
GO

CREATE TABLE [Customer] (
  [CustomerId] integer PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255),
  [Surname] nvarchar(255),
  [Street] nvarchar(255),
  [HouseNo] nvarchar(255),
  [PostalCode] integer,
  [City] nvarchar(255),
  [Telephone] nvarchar(255),
  [EMail] nvarchar(255)
)
GO

CREATE TABLE [Account] (
  [AccountId] integer PRIMARY KEY,
  [IBAN] nvarchar(255),
  [CustomerId] integer,
  [Balance] money
)
GO

CREATE TABLE [Transaction] (
  [TransactionId] integer PRIMARY KEY IDENTITY(1, 1),
  [AccountId] integer,
  [User] nvarchar(255),
  [IBAN] nvarchar(255),
  [TransactionTypeId] integer,
  [Amount] money,
  [DeletedBy] nvarchar(255)
)
GO

CREATE TABLE [TransactionType] (
  [TransactionTypeId] integer PRIMARY KEY,
  [TransactionType] nvarchar(255)
)
GO

ALTER TABLE [Account] ADD CONSTRAINT [customer_account] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([CustomerId])
GO

ALTER TABLE [Transaction] ADD CONSTRAINT [transaction_transactionType] FOREIGN KEY ([TransactionTypeId]) REFERENCES [TransactionType] ([TransactionTypeId])
GO

ALTER TABLE [Transaction] ADD CONSTRAINT [accoung_transaction] FOREIGN KEY ([AccountId]) REFERENCES [Account] ([AccountId])
GO

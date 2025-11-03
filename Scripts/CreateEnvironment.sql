CREATE DataBase EZBank
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
  [CustomerId] integer
)
GO

CREATE TABLE [Transaction] (
  [TransactionId] integer PRIMARY KEY IDENTITY(1, 1),
  [AccountId] integer,
  [CreatedBy] nvarchar(255),
  [IBAN] nvarchar(255),
  [TransactionTypeId] integer,
  [Amount] money,
  [DeletedBy] nvarchar(255),
  [TransactionDate] date,
  [Purpose] nvarchar(255)
)
GO

CREATE TABLE [TransactionType] (
  [TransactionTypeId] integer PRIMARY KEY,
  [TransactionType] nvarchar(255),
  [IsSubtractive] bit
)
GO

ALTER TABLE [Account] ADD CONSTRAINT [customer_account] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([CustomerId])
GO

ALTER TABLE [Transaction] ADD CONSTRAINT [transaction_transactionType] FOREIGN KEY ([TransactionTypeId]) REFERENCES [TransactionType] ([TransactionTypeId])
GO

ALTER TABLE [Transaction] ADD CONSTRAINT [accoung_transaction] FOREIGN KEY ([AccountId]) REFERENCES [Account] ([AccountId])
GO


CREATE VIEW [dbo].[vwAccountBalance]
AS
SELECT        a.AccountId, SUM(CASE WHEN tt.IsSubtractive = 1 THEN - t .Amount ELSE t .Amount END) AS TotalBalance
FROM            dbo.Account AS a LEFT OUTER JOIN
                         dbo.[Transaction] AS t ON a.AccountId = t.AccountId LEFT OUTER JOIN
                         dbo.TransactionType AS tt ON t.TransactionTypeId = tt.TransactionTypeId
GROUP BY a.AccountId
GO

INSERT [dbo].[TransactionType] ([TransactionTypeId], [TransactionType], [IsSubtractive]) VALUES (1, N'Withdrawal', 1)
GO
INSERT [dbo].[TransactionType] ([TransactionTypeId], [TransactionType], [IsSubtractive]) VALUES (2, N'Deposit', 0)
GO
INSERT [dbo].[TransactionType] ([TransactionTypeId], [TransactionType], [IsSubtractive]) VALUES (3, N'Transfer', 1)
GO
INSERT [dbo].[TransactionType] ([TransactionTypeId], [TransactionType], [IsSubtractive]) VALUES (4, N'Incoming', 0)
GO

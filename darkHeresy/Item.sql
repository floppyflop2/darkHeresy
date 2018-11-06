CREATE TABLE [dbo].[Item]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [name] VARCHAR(50) NULL, 
    [cost] DECIMAL(18, 2) NULL, 
    [disponibility ] VARCHAR(50) NULL DEFAULT 'common'
)

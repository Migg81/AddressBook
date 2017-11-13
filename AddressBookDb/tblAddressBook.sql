CREATE TABLE [dbo].[tblAddressBook]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY , 
    [Name] NVARCHAR(50) NOT NULL, 
    [Address] TEXT NULL, 
    [Phone] NCHAR(15) NULL, 
    [Email] NVARCHAR(50) NULL
)
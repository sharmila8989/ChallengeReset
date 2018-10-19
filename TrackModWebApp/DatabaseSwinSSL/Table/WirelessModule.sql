CREATE TABLE [dbo].[WirelessModule]
(
	[MacAddress] NVARCHAR(50) NOT NULL, 
    [IssueDate] DATE NULL,
	[Id] NVARCHAR(50) NOT NULL,
	CONSTRAINT FK_StudentId FOREIGN KEY (Id)REFERENCES Student(Id),
	CONSTRAINT PK_WirelessModule PRIMARY KEY(MacAddress)
)

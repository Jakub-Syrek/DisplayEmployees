USE [master]
GO
DROP DATABASE [Firma1]
GO
CREATE DATABASE [Firma1]
GO
USE [Firma1]
DROP TABLE [dbo].[EmployeesFull]
GO
CREATE TABLE EmployeesFull
(
ID int identity primary key,
FullName nvarchar(50),
JoiningDate smalldatetime,
ReportingToID int 
)

GO

INSERT INTO [dbo].[EmployeesFull]
           ([FullName]
           ,[JoiningDate]
           ,[ReportingToID])
     VALUES
('Andera Guitierrez','2016-12-01 12:32:00','1'),
('Annis Giguere','2014-12-01 12:32:00','1'),
('Eulah Dempsey','2013-12-01 12:32:00','1'),
('Mai Predmore','2012-12-01 12:32:00','1'),
('Leo Pirkle','2011-12-01 12:32:00','2'),
('Taneka Zaremba','2010-12-01 12:32:00','2'),
('Lina Weil','2009-12-01 12:32:00','2'),
('Dorthey Leon','2014-12-01 12:32:00','3'),
('Milagros Ruggles','2012-12-01 12:32:00','3'),
('Adelia Lao','2010-12-01 12:32:00','3');


GO
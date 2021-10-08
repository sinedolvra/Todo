CREATE  DATABASE [TodoDb];
USE [TodoDb]
CREATE TABLE [TodoDb].[dbo].[Todos]
(
    [Id]                        VARCHAR(100) NOT NULL PRIMARY KEY,
    [Description]               VARCHAR(250),
    [Title]                     VARCHAR(250),
    [CreationDate]              DATETIME2,
    [Done]                      BINARY  
)
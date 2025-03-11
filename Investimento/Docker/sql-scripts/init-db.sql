IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Investimento')
BEGIN
    CREATE DATABASE Investimento;
END
GO

USE Investimento;
GO

IF NOT EXISTS (SELECT * FROM sys.syslogins WHERE name = 'user_api')
BEGIN
    CREATE LOGIN user_api WITH PASSWORD = 'P4ssW0rd';
END
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'user_api')
BEGIN
    CREATE USER user_api FOR LOGIN user_api;
END
GO

ALTER ROLE db_owner ADD MEMBER user_api;
GO
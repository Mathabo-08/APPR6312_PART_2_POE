-- This script deletes data in the correct order to respect foreign key constraints.

-- 1. Start with tables that have foreign keys referencing AspNetUsers and AspNetRoles.
DELETE FROM dbo.Incidents;
DELETE FROM dbo.AspNetUserTokens;
DELETE FROM dbo.AspNetUserRoles;
DELETE FROM dbo.AspNetUserLogins;
DELETE FROM dbo.AspNetUserClaims;
DELETE FROM dbo.AspNetRoleClaims;

-- 2. Now that the dependent records are gone, you can safely delete the users and roles themselves.
DELETE FROM dbo.AspNetUsers;
DELETE FROM dbo.AspNetRoles;

-- IMPORTANT: Do NOT delete from the __EFMigrationsHistory table.
-- This table tracks your database's structure and is needed by Entity Framework.

-- A DBCC CHECKIDENT is used to reseeding the Identity value in the table
DBCC CHECKIDENT ('dbo.Incidents', RESEED, 0);
DBCC CHECKIDENT ('dbo.AspNetUsers', RESEED, 0);
DBCC CHECKIDENT ('dbo.AspNetRoles', RESEED, 0);

PRINT 'All application data has been cleared and identity columns have been reset successfully.';
-- V4_Alter_Users_To_FullName.sql
-- Description: Alters the Users table to use a single FullName column instead of FirstName and LastName.

BEGIN TRANSACTION;

-- Step 1: Add the new FullName column
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Users' AND COLUMN_NAME = 'FullName')
BEGIN
    ALTER TABLE dbo.Users ADD FullName NVARCHAR(201) NULL;
END;
GO

-- Step 2: Migrate existing data from FirstName and LastName to FullName
-- This runs only if the FirstName column still exists
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Users' AND COLUMN_NAME = 'FirstName')
BEGIN
    EXEC('UPDATE dbo.Users SET FullName = LTRIM(RTRIM(ISNULL(FirstName, '''') + '' '' + ISNULL(LastName, ''''))) WHERE FullName IS NULL');
END;
GO

-- Step 3: Make the FullName column required after data migration
ALTER TABLE dbo.Users ALTER COLUMN FullName NVARCHAR(201) NOT NULL;
GO

-- Step 4: Drop the old FirstName and LastName columns
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Users' AND COLUMN_NAME = 'FirstName')
BEGIN
    ALTER TABLE dbo.Users DROP COLUMN FirstName;
END;
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Users' AND COLUMN_NAME = 'LastName')
BEGIN
    ALTER TABLE dbo.Users DROP COLUMN LastName;
END;
GO

COMMIT;
-- Inserts the foundational user roles into the Roles table if they do not already exist.

BEGIN TRANSACTION;

IF NOT EXISTS (SELECT 1 FROM Roles WHERE RoleName = 'Admin')
BEGIN
    INSERT INTO Roles (RoleName) VALUES ('Admin');
END;

IF NOT EXISTS (SELECT 1 FROM Roles WHERE RoleName = 'Volunteer')
BEGIN
    INSERT INTO Roles (RoleName) VALUES ('Volunteer');
END;

IF NOT EXISTS (SELECT 1 FROM Roles WHERE RoleName = 'Donor')
BEGIN
    INSERT INTO Roles (RoleName) VALUES ('Donor');
END;

COMMIT;
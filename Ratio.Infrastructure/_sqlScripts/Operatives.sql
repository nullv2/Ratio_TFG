CREATE TABLE Operatives (  
   Id UNIQUEIDENTIFIER PRIMARY KEY,  
   Name NVARCHAR(100) NOT NULL,  
   Movement INT NOT NULL,  
   ActionPointLimit INT NOT NULL,  
   Wounds INT NOT NULL,  
   [Save] INT NOT NULL  
);

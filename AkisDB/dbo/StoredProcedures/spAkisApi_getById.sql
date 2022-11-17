CREATE PROCEDURE [dbo].[spAkisApi_getById]
	@TableName varchar(80), 
	@Id int
AS
BEGIN
	DECLARE @query nvarchar(MAX);
	SET @query = CONCAT('SELECT * FROM ', @TableName, ' WHERE Id = ', @Id, ';');
	EXEC(@query);
END


CREATE PROCEDURE [dbo].[spAkisApi_getAll]
	@TableName varchar(80) 
AS
BEGIN
	DECLARE @query nvarchar(MAX);
	SET @query = CONCAT('SELECT * FROM ', @TableName,';');
	EXEC(@query);
END



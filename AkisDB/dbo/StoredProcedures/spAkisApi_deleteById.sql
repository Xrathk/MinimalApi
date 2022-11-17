CREATE PROCEDURE [dbo].[spAkisApi_deleteById]
	@TableName varchar(80),
	@Id int
AS
BEGIN
	DECLARE @query nvarchar(MAX);
	SET @query = CONCAT('DELETE FROM ', @TableName, ' WHERE Id = ', @Id, ';');
	EXEC(@query);
END
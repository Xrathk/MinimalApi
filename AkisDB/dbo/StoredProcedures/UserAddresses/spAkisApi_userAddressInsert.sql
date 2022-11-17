CREATE PROCEDURE [dbo].[spAkisApi_userAddressInsert]
	@PlanetId int,
	@Country nvarchar(90),
	@Address nvarchar(128),
	@AreaCode nvarchar(20),
	@UserInfoId int
AS
BEGIN
	INSERT INTO dbo.[UserAddresses] (PlanetId,Country,Address,AreaCode,UserInfoId)
	VALUES (@PlanetId,@Country,@Address,@AreaCode,@UserInfoId)
END

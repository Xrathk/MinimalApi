CREATE PROCEDURE [dbo].[spAkisApi_userAddressUpdate]
	@Id int,
	@PlanetId int,
	@Country nvarchar(90),
	@Address nvarchar(128),
	@AreaCode nvarchar(20),
	@UserInfoId int
AS
BEGIN
	UPDATE dbo.[UserAddresses] 
	SET PlanetId = @PlanetId, Country = @Country, Address = @Address, 
		AreaCode = @AreaCode, UserInfoId = @UserInfoId
	WHERE Id = @Id
END


--------------------------- TravelAwayDB Creation ----------------------------
CREATE DATABASE TravelAwayDB
GO
use TravelAwayDB
GO

------------------------- Roles Table --------------------------
CREATE TABLE Roles(
[RoleId] TINYINT CONSTRAINT pk_RoleId PRIMARY KEY IDENTITY,
[RoleName] VARCHAR(20) CONSTRAINT uq_RoleName UNIQUE
);

SET IDENTITY_INSERT Roles ON
INSERT INTO 
	Roles(RoleId,RoleName) 
	VALUES (1,'Customer')
INSERT INTO 
	Roles(RoleId,RoleName) 
	VALUES (2,'Employee')
SET IDENTITY_INSERT Roles OFF
GO

------------------------- Customer Table --------------------------
CREATE TABLE Customer(
[EmailId] VARCHAR(50) CONSTRAINT pk_EmailId PRIMARY KEY,
[RoleId] TINYINT CONSTRAINT fk_RoleId REFERENCES Roles(RoleId),
[FirstName] VARCHAR(50) CONSTRAINT chk_FirstName CHECK(NOT [FirstName] LIKE '% %') NOT NULL,
[LastName] VARCHAR(50) CONSTRAINT chk_LastName CHECK(NOT [LastName] LIKE '% %') NOT NULL,
[UserPassword] VARCHAR(15) CONSTRAINT chk_UserPassword CHECK(len([UserPassword])>=8 AND len([UserPassword])<=16) NOT NULL,
[Gender] CHAR CONSTRAINT chk_Gender CHECK(Gender='F' OR Gender='M') NOT NULL,
[ContactNumber] NUMERIC(10) CONSTRAINT chk_ContactNumber check([ContactNumber] NOT LIKE '0%' AND len([ContactNumber])=10) NOT NULL, --SQUARE BRACES
[DateOfBirth] DATE CONSTRAINT chk_DateOfBirth CHECK(DateOfBirth<GETDATE()) NOT NULL,
[Address] VARCHAR(250) NOT NULL
);

INSERT INTO 
	Customer(EmailId,UserPassword,RoleId,Gender,FirstName,LastName,ContactNumber,DateOfBirth,[Address]) 
	VALUES('aman@gmail.com','aman1234',1,'M','aman','goel',8909090909,'11/12/2000','mysore');
GO
INSERT INTO 
	Customer(EmailId,UserPassword,RoleId,Gender,FirstName,LastName,ContactNumber,DateOfBirth,[Address]) 
	VALUES('ayush@gmail.com','aman1234',2,'M','ayush','goel',8909090909,'11/12/2000','mysore');
GO

------------------------- Package Category Table --------------------------
CREATE TABLE PackageCategory(
[PackageCategoryId] INT CONSTRAINT pk_PackageCategoryId PRIMARY KEY IDENTITY(100,1),
[PackageCategoryName] VARCHAR(20) UNIQUE NOT NULL
);

INSERT INTO 
	PackageCategory(PackageCategoryName)
	VALUES('Adventure'),('Nature'),('Relegious'),('Village'),('Wildlife')
GO

------------------------- Packages Table --------------------------
CREATE TABLE Package(
[PackageId] INT CONSTRAINT pk_PackageId PRIMARY KEY IDENTITY(2000,1),
[PackageName] VARCHAR(30) UNIQUE NOT NULL,
[PackageCategoryId] INT CONSTRAINT fk_PackageCategoryId REFERENCES PackageCategory(PackageCategoryId),
[TypeOfPackage] VARCHAR(15) CONSTRAINT chk_TypeOfPackage CHECK(TypeOfPackage IN ('International','Domestic')),
[ImageUrl] VARCHAR(50)
);

INSERT INTO Package(PackageName,PackageCategoryId,TypeOfPackage, ImageUrl) VALUES('North east India',100,'Domestic','/assets/OIP1.jpg')
INSERT INTO Package(PackageName,PackageCategoryId,TypeOfPackage, ImageUrl) VALUES('Dubai',101,'International','/assets/OIP2.jpg')
INSERT INTO Package(PackageName,PackageCategoryId,TypeOfPackage, ImageUrl) VALUES('Goa',102,'Domestic','/assets/OIP3.jpg')

------------------------- Package Details Table--------------------------
CREATE TABLE PackageDetails(
[PackageDetailsId] INT CONSTRAINT pk_PaclageDetailsId PRIMARY KEY IDENTITY(900,1),
[PackageId] INT CONSTRAINT fk_PackageId REFERENCES Package(PackageId),
[PlacesToVisit] VARCHAR(500) NOT NULL,
[Description] VARCHAR(500) NOT NULL,
[NoOfDays] INT NOT NULL,
[NoOfNights] INT NOT NULL,
[Accomodation] VARCHAR(10) CONSTRAINT chk_Accomodation CHECK(Accomodation IN ('Available','Unavailable')),
[PricePerAdult] DECIMAL
);

INSERT INTO PackageDetails(PackageId,PlacesToVisit,Description,NoOfDays,NoOfNights,Accomodation,PricePerAdult) VALUES(2000,'Assam, Nagaland, Tripura, Manipur','Northeast India , officially the north eastern region , is the easternmost region of india representing both a geographic and political administrative division of the country',2,2,'Available',12000)
INSERT INTO PackageDetails(PackageId,PlacesToVisit,Description,NoOfDays,NoOfNights,Accomodation,PricePerAdult) VALUES(2001,'Bhurj Khalifa','Dubai is a city and emirate in the united arab emirates known for luxury shopping, ultramodern architecture and a lively nightlife scene',3,2,'Available',11100)
INSERT INTO PackageDetails(PackageId,PlacesToVisit,Description,NoOfDays,NoOfNights,Accomodation,PricePerAdult) VALUES(2002,'White Beach','Goa is a state in western India with coastlines stretching along the arabian sea',3,2,'Available',11100)

Go

---------------STORED PROCEDURES---------------

---------------REGISTER CUSTOMER---------------
Create PROCEDURE usp_RegisterCustomer
(
@EmailId VARCHAR(30),
@FirstName VARCHAR(20),
@LastName VARCHAR(20),
@Password VARCHAR(16),
@Gender CHAR,
@Contact NUMERIC(10),
@DOB DATE,
@Address VARCHAR(50)
)
AS BEGIN
DECLARE @RoleId CHAR(2),
@retval INT
BEGIN TRY
IF(LEN(@EmailId)<4 OR LEN(@EmailId) IS NULL)
SET @retval=-1
ELSE IF(LEN(@Password)<8 OR LEN(@Password)>16 OR (@Password IS NULL))
SET @retval=-2
ELSE IF(@DOB>=CAST(GETDATE() AS DATE) OR (@DOB IS NULL))
SET @retval=-3
ELSE IF(@FirstName LIKE('%[^a-zA-Z]%') OR LEN(@FirstName)=0)
SET @retval=-5
ELSE IF(@LastName LIKE ('%[^a-zA-Z]%') OR LEN(@LastName)=0)
SET @retval=-5
ELSE
BEGIN
SELECT @RoleId=RoleId FROM dbo.Roles WHERE RoleName='Customer'
INSERT INTO Customer VALUES
(@EmailId,@RoleId,@FirstName,@LastName,@Password,@Gender,@Contact,@DOB,@Address)
SET @retval=1
END
SELECT @retval
END TRY
BEGIN CATCH
SET @retval=-99
SELECT @retval, ERROR_LINE(),ERROR_MESSAGE()
END CATCH
END 
GO

------------------------------ sprint 2 -----------------------------------------

---------------Hotels---------------
CREATE TABLE Hotel(
[HotelId] INT CONSTRAINT pk_HotelId PRIMARY KEY IDENTITY(1000,1),
[HotelName] VARCHAR(20),
[HotelRating] INT NOT NULL ,
[SingleRoomPrice] MONEY,
[DoubleRoomPrice] MONEY,
[DeluxeeRoomPrice] MONEY,
[SuiteRoomPrice] MONEY,
[City] VARCHAR(20)
);

SET IDENTITY_INSERT Hotel ON
INSERT INTO Hotel(HotelId,HotelName,HotelRating,SingleRoomPrice,DoubleRoomPrice,DeluxeeRoomPrice,City) VALUES(1002,'Sea View ',4, 600,1400,3100,'Manipur')
INSERT INTO Hotel(HotelId,HotelName,HotelRating,SingleRoomPrice,DoubleRoomPrice,DeluxeeRoomPrice,City) VALUES(1003,'New Avenue',3, 1600,2500,5800,'Jaipur')
INSERT INTO Hotel(HotelId,HotelName,HotelRating,SingleRoomPrice,DoubleRoomPrice,DeluxeeRoomPrice,City) VALUES(1004,'Tajfront',3, 2900,4500,9800,'United Kingdom')
INSERT INTO Hotel(HotelId,HotelName,HotelRating,SingleRoomPrice,DoubleRoomPrice,DeluxeeRoomPrice,City) VALUES(1005,'Hotel Park',4,3500,5700,8800,'UAE')
INSERT INTO Hotel(HotelId,HotelName,HotelRating,SingleRoomPrice,DoubleRoomPrice,DeluxeeRoomPrice,City) VALUES(1006,'Dudai Hotel',4,3500,5700,6800,'UAE')

---------------Package Bookings---------------
CREATE TABLE BookPackage(
[EmailId] VARCHAR(50) CONSTRAINT fk_EmailId REFERENCES Customer(EmailId),
[BookingId] INT CONSTRAINT pk_BookingId PRIMARY KEY IDENTITY(4000,1),
[ContactNumber] NUMERIC(10) NOT NULL,
[Address] VARCHAR(100) NOT NULL,
[DateOfTravel] DATE NOT NULL ,
[NumberOfAdults] INT NOT NULL,
[NumberOfChildren] INT,
[Status] VARCHAR(10) NOT NULL CONSTRAINT chk_Status CHECK([Status] IN ('Booked','Confirmed')),
[PackageId] INT CONSTRAINT fk_packId REFERENCES PackageDetails(PackageDetailsId)
);

-----Added PackageId to BookPackage-----
INSERT INTO BookPackage(EmailId,ContactNumber,[Address],DateOfTravel,NumberOfAdults,NumberOfChildren,[Status],PackageId) VALUES('aman@gmail.com',9998887765,'310-Delhi','2024-11-21',2,0,'Booked',900)
INSERT INTO BookPackage(EmailId,ContactNumber,[Address],DateOfTravel,NumberOfAdults,NumberOfChildren,[Status],PackageId) VALUES('aman@gmail.com',9998887765,'310-Delhi','2024-11-21',2,0,'Booked',901)
INSERT INTO BookPackage(EmailId,ContactNumber,[Address],DateOfTravel,NumberOfAdults,NumberOfChildren,[Status],PackageId) VALUES('aman@gmail.com',9998887765,'310-Delhi','2024-11-21',2,0,'Booked',902)

---------------Accomodations---------------
CREATE TABLE Accomodation(
[AccomodationId] INT CONSTRAINT pk_AccomodationId PRIMARY KEY IDENTITY(1,1),
[BookingId] INT CONSTRAINT fk_BookingId REFERENCES BookPackage(BookingId),
[HotelName] VARCHAR(20),
[City] VARCHAR(30),
[NoOfRooms] INT NOT NULL,
[HotelRating] INT CONSTRAINT chk_HotelR CHECK(HotelRating>=1 and HotelRating<=5),
[Price] MONEY,
[RoomType] VARCHAR(20) CONSTRAINT chk_RoomType CHECK(RoomType='Single' OR RoomType='Double' OR RoomType='Deluxe' OR RoomType='Suite') NOT NULL
);

INSERT INTO Accomodation(BookingId,HotelName,City,NoOfRooms,HotelRating,Price,RoomType) VALUES(4000,'abc','Assam',2,4,10000,'Suite')






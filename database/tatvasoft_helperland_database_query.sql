create database HelperLandDatabase;
use HelperLandDatabase;
-- create table for all user

create table userTable ( ID int not null PRIMARY KEY identity(1,1), first_name nvarchar(50) not null, last_name nvarchar(50) not null, Email_address nvarchar(50) not null unique,
						phone_number varchar(10) not null unique, Pass nvarchar(100) not null,dob date not null, nationality nvarchar(20) not null,gender nvarchar(20) not null,
						user_role nvarchar(20) not null, user_status nvarchar(20) not null);


-- address table

create table addressTable ( ID int not null PRIMARY KEY identity(1,1), street_name nvarchar(20) not null, house_name nvarchar(20) not null, postal_code nvarchar(10) not null,city nvarchar(20) not null,phone_number varchar(10), user_id int foreign key references userTable(ID));

-- book service table 

create table serviceTable ( ID int not null PRIMARY KEY identity(1,1), starting_time time not null, duration int not null, requested_user_id int not null foreign key references userTable(ID),
							accept_service_provider_id int not null foreign key references userTable(ID), service_status nvarchar(10) not null, inside_cabinate bit not null,
							inside_firdge bit not null, inside_oven bit not null, laundary_wash bit not null,interior_window bit not null, have_a_pet bit not null, payment float not null,
							comment nvarchar(100) null,address_id int foreign key references addressTable(ID));

-- favourit & block service provider table

create table favBlockServiceProviderTable ( ID int not null PRIMARY KEY identity(1,1), customer_id int not null foreign key references userTable(ID), 
											favourite_service_provider_id int not null foreign key references userTable(ID),
											block_service_provider_id int not null foreign key references userTable(ID));


-- rating of service provider table 

create table ratingOfServiceProviderTable ( ID int not null PRIMARY KEY identity(1,1), service_provider_id int not null foreign key references userTable(ID),
											customer_id int not null foreign key references userTable(ID), ontime_rating int ,friendly_rating int, quality_rating int,
											average_rating int,Rating_date date, Rating_time time);

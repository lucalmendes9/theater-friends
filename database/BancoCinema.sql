use "master"
drop database ProjetoCinema
go

create database ProjetoCinema
go
use ProjetoCinema
go

set quoted_identifier on
go

create table Costumer(
id int primary key identity(1,1) not null,
"name" varchar(100) not null,
email varchar(50) unique not null,
"password" varchar(20) not null,
created_at date not null)
go

create table Employer(
id int primary key identity(1,1) not null,
"name" varchar(100) not null,
email varchar(50) unique not null,
"password" varchar(20) not null,
employer_role varchar(20),
hired_at date not null)
go

create table Localization(
id int primary key identity(1,1) not null,
phone varchar(20) not null,
"address" varchar(100) not null,
number int not null,
neighbourhood varchar(100) null,
city varchar(100) not null,
"state" varchar(50) not null)
go

create table Theaters(
id int primary key identity(1,1) not null,
"description" varchar(100) not null,
localization_id int foreign key references Localization(id) not null,
open_hour varchar(10) not null,
close_hour varchar(10) not null,
work_days int not null)
go

create table Rooms(
id int primary key identity(1,1) not null,
"name" varchar(30) not null,
seats int not null,
theaters_id int foreign key references Theaters(id) not null)
go

create table Movies(
id int primary key identity(1,1) not null,
"name" varchar(50) not null,
"description" varchar(max) null,
cover varbinary not null,
"type" varchar(50) not null,
"length" int not null, -- value for minutes, e.g.: 90 min for 1h30min
min_age int not null,
"language" varchar(20) not null,
subtitle bit null)
go

create table Exhibition(
id int primary key identity(1,1) not null,
room_id int foreign key references Rooms(id) not null,
movie_id int foreign key references Movies(id) not null)
go

create table Schedule_Exhibition(
id int primary key identity (1,1) not null,
price decimal(5,2) not null,
"start_date" date not null,
"end_date" date not null,
exhibition_id int foreign key references Exhibition(id) not null)
go

create table Payment(
id int primary key identity(1,1) not null,
"type" varchar(20) not null,
credit_card varchar(20) null,
parcels int null)
go

create table Request(
id int primary key identity(1,1) not null,
costumer_id int foreign key references Costumer(id) not null,
payment_id int foreign key references Payment(id) not null,
seat_number int not null,
number_tickets int not null,
total_pay decimal(10,2) not null,
schedule_exhibition_id int foreign key references Schedule_Exhibition(id) not null)
go






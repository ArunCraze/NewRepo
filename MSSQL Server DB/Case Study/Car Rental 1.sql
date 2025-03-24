create database Car_Rental

use car_rental

create table Vehicle(
vehicleID int primary key identity(1,1) not null,
make varchar(30),
model varchar(30),
year int,
dailyRate decimal(5,2),
status varchar(30) check(status in ('available','notavailable')),
passangerCapacity int,
engineCapacity decimal(5,2))

create table customer(
customer_id int primary key identity(10,1)not null,
first_name varchar(30)not null,
last_name varchar(30)not null,
email varchar(50)unique,
phoneNumber varchar(30)unique not null)

create table lease(
leaseID int primary key identity(1,1) not null,
startDate date not null,
endDate date not null,
type varchar(30) check(type in('DailyLease','MonthlyLease')),
vehicleID int not null,
foreign key(vehicleID) references vehicle(vehicleID),
customer_id int not null,
foreign key(customer_id) references customer(customer_id))

create table payment(
paymentID int primary key identity(100,1) not null,
leaseId int not null,
paymentDate date,
amount decimal(5,2),
foreign key(leaseID) references lease(leaseID))

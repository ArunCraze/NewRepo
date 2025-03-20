create database HMbank
use HMbank
create table Customers(
customer_id int identity(1,1) primary key not null,
first_name varchar(50) not null,
last_name varchar(50) not null,
DOB date not null,
email varchar(100) unique not null,
phone_number varchar(50)unique not null,
address varchar(100)not null
);
create table Accounts(
account_id int identity(1,1) primary key not null,
customer_id int,
Foreign Key(customer_id) references Customers(customer_id),
account_type varchar(25) check (account_type in ('savings', 'current', 'zero_balance')) NOT NULL,
balance decimal(15,2) default 00.0
);
create table Transactions(
transaction_id int identity(1,1) primary key not null,
account_id int,
Foreign key(account_id) references accounts(account_id),
transaction_type varchar(25) check(transaction_type in('deposit','withdrawl','transfer')) not null,
amount decimal(15,2) default 00.0,
transaction_date datetime not null
);
select * from Transactions
-- Insert at least 10 sample records into each of the following tables.
insert into customers values
('John', 'Doe', '1990-05-12', 'john.doe@example.com', '9876543210', '123 Main St, New York'),
('Jane', 'Smith', '1985-09-25', 'jane.smith@example.com', '9876543211', '456 Elm St, California'),
('Robert', 'Brown', '1992-11-17', 'robert.brown@example.com', '9876543212', '789 Oak St, Texas'),
('Emily', 'Davis', '1988-03-10', 'emily.davis@example.com', '9876543213', '321 Pine St, Florida'),
('Michael', 'Wilson', '1995-07-21', 'michael.wilson@example.com', '9876543214', '654 Maple St, Illinois'),
('Sarah', 'Taylor', '1989-12-05', 'sarah.taylor@example.com', '9876543215', '987 Birch St, Ohio'),
('David', 'Anderson', '1993-04-18', 'david.anderson@example.com', '9876543216', '147 Spruce St, Nevada'),
('Emma', 'Thomas', '1991-06-22', 'emma.thomas@example.com', '9876543217', '258 Cedar St, Georgia'),
('Daniel', 'White', '1994-09-30', 'daniel.white@example.com', '9876543218', '369 Walnut St, Virginia'),
('Olivia', 'Harris', '1996-11-12', 'olivia.harris@example.com', '9876543219', '753 Aspen St, Colorado');
insert into Accounts values 
(1, 'savings', 5000.00),
(2, 'current', 12000.00),
(3, 'zero_balance', 0.00),
(4, 'savings', 2500.50),
(5, 'current', 18000.75),
(6, 'savings', 0.00),
(7, 'current', 7500.00),
(8, 'zero_balance', 0.00),
(9, 'savings', 5400.00),
(10, 'current', 20000.00);
insert into Transactions values
(1, 'deposit', 2000.00, '2024-03-18 10:15:00'),
(2, 'withdrawl', 1500.00, '2024-03-18 12:30:00'),
(3, 'deposit', 500.00, '2024-03-18 14:45:00'),
(4, 'deposit', 1200.00, '2024-03-18 16:00:00'),
(5, 'withdrawl', 2500.00, '2024-03-18 18:20:00'),
(6, 'deposit', 3500.00, '2024-03-18 20:10:00'),
(7, 'deposit', 4000.00, '2024-03-18 21:30:00'),
(8, 'withdrawl', 600.00, '2024-03-18 22:45:00'),
(9, 'deposit', 2200.00, '2024-03-18 23:59:00'),
(10, 'withdrawl', 1800.00, '2024-03-19 01:15:00');





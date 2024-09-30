create database order_management;

create table customers(
	id uuid primary key default gen_random_uuid(),
	fullname varchar(255) unique,
	email varchar(255) unique,
	phone varchar(255),
	createdat date
);

create table products(
	id uuid primary key default gen_random_uuid(),
	name varchar(255) unique,
	price int,
	stockquantity int,
	createdat date
);

create table orders(
	id uuid primary key default gen_random_uuid(),
	customerid uuid references customers(id),
	totalamount int,
	orderdate date,
	status varchar(255),
	createdat date
);

create table orderitems(
	id uuid primary key default gen_random_uuid(),
	orderid uuid references orders(id),
	productid uuid references products(id),
	quantity int,
	price int,
	createdat date
);
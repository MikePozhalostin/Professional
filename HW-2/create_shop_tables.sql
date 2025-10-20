BEGIN TRANSACTION;

CREATE SCHEMA IF NOT EXISTS shop;

CREATE TABLE IF NOT EXISTS shop."Products"(
"ProductID" integer NOT NULL PRIMARY KEY,
"ProductName" text NOT NULL,
"Description" text,
"Price" float NOT NULL,
"QuantityInStock" integer NOT NULL
);

CREATE TABLE IF NOT EXISTS shop."Users"(
"UserID" integer NOT NULL PRIMARY KEY,
"UserName" text NOT NULL,
"Email" text,
"RegistrationDate" Date NOT NULL
);

CREATE TABLE IF NOT EXISTS shop."Orders"(
"OrderID" integer NOT NULL PRIMARY KEY,
"UserID" int NOT NULL,
"OrderDate" Date NOT NULL,
"Status" text NOT NULL
);

CREATE TABLE IF NOT EXISTS shop."OrderDetails"(
"OrderDetailID" integer NOT NULL PRIMARY KEY,
"OrderID" int NOT NULL,
"ProductID" int NOT NULL,
"Quantity" int NOT NULL,
"TotalCoast" float NOT NULL
);

ALTER TABLE shop."Orders" DROP CONSTRAINT IF EXISTS fk_order_user;
ALTER TABLE shop."Orders"
    ADD CONSTRAINT fk_order_user
	FOREIGN KEY ("UserID")
	REFERENCES shop."Users" ("UserID");

ALTER TABLE shop."OrderDetails" DROP CONSTRAINT IF EXISTS fk_orderdetails_order;
ALTER TABLE shop."OrderDetails"
    ADD CONSTRAINT fk_orderdetails_order
	FOREIGN KEY ("OrderID")
	REFERENCES shop."Orders" ("OrderID");

ALTER TABLE shop."OrderDetails" DROP CONSTRAINT IF EXISTS fk_orderdetails_product;
ALTER TABLE shop."OrderDetails"
    ADD CONSTRAINT fk_orderdetails_product
	FOREIGN KEY ("ProductID")
	REFERENCES shop."Products" ("ProductID");

COMMIT;
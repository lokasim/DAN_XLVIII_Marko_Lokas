IF DB_ID('PizzaRestoran') IS NULL
CREATE DATABASE PizzaRestoran
GO

USE PizzaRestoran

ALTER DATABASE PizzaRestoran COLLATE Croatian_CI_AS;
GO


-- Drop Foreign Keys
IF OBJECT_ID('tblOrder', 'U') IS NOT NULL 
	ALTER TABLE tblOrder DROP CONSTRAINT FK_Order_Guest;
IF OBJECT_ID('tblOrderItem', 'U') IS NOT NULL 
	ALTER TABLE tblOrderItem DROP CONSTRAINT FK_OrderItem_Product;
IF OBJECT_ID('tblOrderItem', 'U') IS NOT NULL 
	ALTER TABLE tblOrderItem DROP CONSTRAINT FK_OrderItem_Order;
IF OBJECT_ID('tblProduct', 'U') IS NOT NULL 
	ALTER TABLE tblProduct DROP CONSTRAINT FK_Product_Category;
IF OBJECT_ID('tblOrder', 'U') IS NOT NULL 
	ALTER TABLE tblOrder DROP CONSTRAINT FK_Order_OrderStatus;

--===================================================================

-- Drop Primary Keys
IF OBJECT_ID('tblProduct', 'U') IS NOT NULL 
	ALTER TABLE tblProduct DROP CONSTRAINT PK_Product;
IF OBJECT_ID('tblCategory', 'U') IS NOT NULL 
	ALTER TABLE tblCategory DROP CONSTRAINT PK_Category;
IF OBJECT_ID('tblGuest', 'U') IS NOT NULL 
	ALTER TABLE tblGuest DROP CONSTRAINT PK_Guest;
IF OBJECT_ID('tblOrder', 'U') IS NOT NULL 
	ALTER TABLE tblOrder DROP CONSTRAINT PK_Order;
IF OBJECT_ID('tblOrderItem', 'U') IS NOT NULL 
	ALTER TABLE tblOrderItem DROP CONSTRAINT PK_OrderItem;
IF OBJECT_ID('tblOrderStatus', 'U') IS NOT NULL 
	ALTER TABLE tblOrderStatus DROP CONSTRAINT PK_OrderStatus;

--===================================================================

-- Drop tables
IF OBJECT_ID('tblProduct', 'U') IS NOT NULL 
	DROP TABLE tblProduct;
IF OBJECT_ID('tblCategory', 'U') IS NOT NULL 
	DROP TABLE tblCategory;
IF OBJECT_ID('tblOrder', 'U') IS NOT NULL 
	DROP TABLE tblOrder;
IF OBJECT_ID('tblOrderItem', 'U') IS NOT NULL 
	DROP TABLE tblOrderItem;
IF OBJECT_ID('tblGuest', 'U') IS NOT NULL 
	DROP TABLE tblGuest;
IF OBJECT_ID('tblOrderStatus', 'U') IS NOT NULL 
	DROP TABLE tblOrderStatus;

--===================================================================

--Drop View
IF OBJECT_ID('vwMenu', 'V') IS NOT NULL 
	DROP VIEW vwMenu;
IF OBJECT_ID('vwOrder', 'V') IS NOT NULL 
	DROP VIEW vwOrder;
--==================================================================

-- Create tables
CREATE TABLE tblGuest(
	GuestID			int identity(1,1) NOT NULL,
	GuestName		nvarchar (70) NOT NULL,
	GuestSurname		nvarchar (70) NOT NULL,
	JMBG				char(13) NOT NULL,
	EMail				nvarchar(100) NOT NULL
	)
CREATE TABLE tblProduct(
	ProductID			int identity(1,1) NOT NULL,
	CategoryName		int NOT NULL,
	ProductName			nvarchar (50) NOT NULL,
	ProductDescription	nvarchar(200) NOT NULL, 
	PriceProduct		int NOT NULL
	)
CREATE TABLE tblCategory(
	CategoryID		int identity(1,1) NOT NULL,
	CategoryName	nvarchar (50) NOT NULL
	)
CREATE TABLE tblOrderStatus(
	OrderStatusID		int identity(1,1) NOT NULL,
	OrderStatus			nvarchar (15) NOT NULL
	)
CREATE TABLE tblOrder(
	OrderID				int identity(1,1) NOT NULL,
	DateTimeOrder		datetime NOT NULL,
	Guest				int NOT NULL,
	TotalPrice			int NOT NULL,
	OrderStatus			int NOT NULL,
	Archived			INT NOT NULL
	)
CREATE TABLE tblOrderItem(
	OrderItemID			int identity(1,1) NOT NULL,
	ProductName			int NOT NULL,
	ProductPrice		int NOT NULL,
	ProductQuantity		int NOT NULL,
	OrderName			int NOT NULL,
	OrderSum			int NOT NULL
	)
--===================================================================

-- Add constraints for PK
ALTER TABLE tblGuest 
	ADD CONSTRAINT PK_Guest
	PRIMARY KEY (GuestID)

ALTER TABLE tblProduct 
	ADD CONSTRAINT PK_Product
	PRIMARY KEY (ProductID)

ALTER TABLE tblCategory 
	ADD CONSTRAINT PK_Category
	PRIMARY KEY (CategoryID)

ALTER TABLE tblOrderStatus 
	ADD CONSTRAINT PK_OrderStatus
	PRIMARY KEY (OrderStatusID)

ALTER TABLE tblOrder 
	ADD CONSTRAINT PK_Order 
	PRIMARY KEY (OrderID)

ALTER TABLE tblOrderItem 
	ADD CONSTRAINT PK_OrderItem
	PRIMARY KEY (OrderItemID)
--===================================================================

-- Add constraints for FK
ALTER TABLE tblOrder 
	ADD CONSTRAINT FK_Order_Guest
	FOREIGN KEY (Guest) 
	REFERENCES tblGuest (GuestID)

ALTER TABLE tblOrderItem 
	ADD CONSTRAINT FK_OrderItem_Product
	FOREIGN KEY (ProductName) 
	REFERENCES tblProduct (ProductID)

ALTER TABLE tblOrderItem 
	ADD CONSTRAINT FK_OrderItem_Order
	FOREIGN KEY (OrderName) 
	REFERENCES tblOrder (OrderID)

ALTER TABLE tblOrder 
	ADD CONSTRAINT FK_Order_OrderStatus
	FOREIGN KEY (OrderStatus) 
	REFERENCES tblOrderStatus (OrderStatusID)

ALTER TABLE tblProduct 
	ADD CONSTRAINT FK_Product_Category
	FOREIGN KEY (CategoryName) 
	REFERENCES tblCategory (CategoryID)
--===================================================================

USE PizzaRestoran
GO
CREATE VIEW vwMenu AS
SELECT dbo.tblProduct.ProductID, dbo.tblProduct.CategoryName, dbo.tblProduct.ProductName, dbo.tblProduct.ProductDescription, dbo.tblProduct.PriceProduct, dbo.tblCategory.CategoryID, dbo.tblCategory.CategoryName AS Expr1
FROM   dbo.tblProduct INNER JOIN
       dbo.tblCategory ON dbo.tblProduct.CategoryName = dbo.tblCategory.CategoryID
GO

USE PizzaRestoran
GO
CREATE VIEW vwOrder AS
SELECT        dbo.tblOrderItem.OrderItemID, dbo.tblOrderItem.ProductName, dbo.tblOrderItem.ProductPrice, dbo.tblOrderItem.ProductQuantity, dbo.tblOrderItem.OrderName, dbo.tblOrder.OrderID, dbo.tblOrder.DateTimeOrder, 
                         dbo.tblOrder.Guest, dbo.tblOrder.TotalPrice, dbo.tblOrder.Archived, dbo.tblOrder.OrderStatus, dbo.tblGuest.GuestID, dbo.tblGuest.GuestName, dbo.tblGuest.GuestSurname, dbo.tblGuest.JMBG, dbo.tblGuest.EMail, 
                         dbo.tblOrderStatus.OrderStatusID, dbo.tblOrderStatus.OrderStatus AS Expr1, dbo.tblProduct.ProductID, dbo.tblProduct.ProductDescription, dbo.tblProduct.CategoryName, dbo.tblProduct.ProductName AS Expr2, 
                         dbo.tblProduct.PriceProduct, dbo.tblCategory.CategoryID, dbo.tblCategory.CategoryName AS Expr3, dbo.tblOrderItem.OrderSum
FROM            dbo.tblOrder INNER JOIN
                         dbo.tblGuest ON dbo.tblOrder.Guest = dbo.tblGuest.GuestID INNER JOIN
                         dbo.tblOrderItem ON dbo.tblOrder.OrderID = dbo.tblOrderItem.OrderName INNER JOIN
                         dbo.tblOrderStatus ON dbo.tblOrder.OrderStatus = dbo.tblOrderStatus.OrderStatusID INNER JOIN
                         dbo.tblProduct ON dbo.tblOrderItem.ProductName = dbo.tblProduct.ProductID INNER JOIN
                         dbo.tblCategory ON dbo.tblProduct.CategoryName = dbo.tblCategory.CategoryID
GO

INSERT INTO tblOrderStatus (OrderStatus)
	VALUES ('On hold')
INSERT INTO tblOrderStatus (OrderStatus)
	VALUES ('Approved')
INSERT INTO tblOrderStatus (OrderStatus)
	VALUES ('Rejected')

INSERT INTO tblCategory (CategoryName)
	VALUES ('PIZZA 30CM')
INSERT INTO tblCategory (CategoryName)
	VALUES ('SANDWICHES')
INSERT INTO tblCategory (CategoryName)
	VALUES ('PANCAKES')
INSERT INTO tblCategory (CategoryName)
	VALUES ('SPAGHETTI')
INSERT INTO tblCategory (CategoryName)
	VALUES ('Drinks')

INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('1', 'Pizza Margarita', 'cheese, ketchup, mushrooms, olives', 630)
INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('1', 'Pizza Kaprićoza', 'cheese, ketchup, ham, mushrooms', 700)
INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('1', 'Pizza Mađarica', 'cheese, ketchup, ham, mushrooms, pepperoni, sausages', 720)
INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('1', 'Pizza Novosađanka', 'cheese, ham, onion, paprika, bacon, corn, sour cream', 780)
INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('1', 'Pizza Vojvođanka', 'cheese, ketchup, ham, mushrooms, sausage, bacon', 780)

INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('2', 'Šunka', 'sour cream, ham, Trappist cheese, sez. salad', 130)
INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('2', 'Piletina', 'sour cream, chicken breast, Trappist cheese, season salad', 130)
INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('2', 'Pršuta', 'sour cream, prosciutto, Trappist cheese, season salad', 150)

INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('3', 'Mešana', 'cheese, mushrooms, sour cream, ham', 160)
INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('3', 'Kulen', 'cheese, ham, mushrooms, sour cream, kulen', 170)
INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('3', 'Lala', 'cheese, ham, mushrooms, sour cream, bacon, smoked ham', 180)

INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('4', 'Bolognese', '', 600)
INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('4', 'Milanese', '', 600)
INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('4', 'Carbonara', '', 600)

INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('5', 'Negazirana voda', 'Natural still water 0.33l', 90)
INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('5', 'Gazirana voda', 'Mineral Water 0.33l', 90)
INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('5', 'Limunada', 'Lemonade 0.30l', 120)
INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('5', 'Coca-Cola', '0.25l', 130)
INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('5', 'Fanta', '0.25l', 130)
INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('5', 'Sprite', '0.25l', 130)
INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('5', 'Schweppes', '0.25l', 130)
INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('5', 'Pivo', 'Beer 0.33l', 150)
INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('5', 'Belo Vino', 'White Vine 0.187l', 190)
INSERT INTO tblProduct(CategoryName, ProductName, ProductDescription, PriceProduct)
	VALUES ('5', 'Crno Vino', 'Red Vine 0.187l', 190)

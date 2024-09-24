-- 1. CREATE DATABASE
IF NOT EXISTS (
			SELECT name FROM sysdatabases WHERE name = 'soccerShose_db')
			CREATE DATABASE soccerShose_db;
GO
USE soccerShose_db;
-- 2. CREATE TABLE
CREATE TABLE category (
    categoryId     	INT             NOT NULL,
    name            VARCHAR(100)    NOT NULL,
    CONSTRAINT PK_category PRIMARY KEY (categoryId)
);
GO
CREATE TABLE product (
    productId		INT 		    NOT NULL,
    categoryId     	INT             NOT NULL,
    name 			VARCHAR(100) 	NOT NULL,
    description     VARCHAR(255)	NOT NULL,
    discount		DECIMAL(10, 2)	NULL,
    image			VARCHAR(50)		NOT NULL,
    quantity 		INT 			NOT NULL,
    sellingPrice	DECIMAL(10, 2)  NOT NULL,
    CONSTRAINT PK_product PRIMARY KEY (productId)
);
GO
CREATE TABLE tbl_order (
    orderId        	INT             NOT NULL,
    paymentMethod   VARCHAR(255)    NOT NULL,
    userId     		INT             NOT NULL,
    orderDate      	DATE            NOT NULL,
    deliveryDate   	DATE            NOT NULL,
    status          BIT				NOT NULL ,
    address         VARCHAR(255)    NOT NULL,
    CONSTRAINT PK_tbl_order PRIMARY KEY (orderId)
);
GO
CREATE TABLE order_detail (
    productId      	INT             NOT NULL,
    orderId        	INT             NOT NULL,
    discount        DECIMAL(10, 2)  NOT NULL,
    quantity   		INT             NOT NULL,
    totalBill	    DECIMAL(10, 2)  NOT NULL,
    CONSTRAINT PK_order_detail PRIMARY KEY (productId, orderId)
);
GO
CREATE TABLE cart (
    cartId         	INT             NOT NULL,
    userId         	INT             NOT NULL,
    productId      	INT             NOT NULL,
    quantity   		INT             NOT NULL,
    totalBill	    DECIMAL(10, 2)  NOT NULL,
    CONSTRAINT PK_cart primary key (cartId)
);
GO
CREATE TABLE role (
    roleId         	INT             NOT NULL,
    name            VARCHAR(50)     NOT NULL,
    CONSTRAINT PK_role PRIMARY KEY (roleId)
);
GO
CREATE TABLE Account (
    userId       INT               NOT NULL,
    roleId       INT               NOT NULL,
    username     VARCHAR(50)       NOT NULL UNIQUE,
    password     VARCHAR(255)      NOT NULL,
    CONSTRAINT PK_user PRIMARY KEY (userId)
);
GO
-- 3. RELATIONSHIP
ALTER TABLE product
    ADD CONSTRAINT FK_product_category FOREIGN KEY (categoryId) REFERENCES category (categoryId);

ALTER TABLE order_detail
    ADD CONSTRAINT FK_order_detail_oder FOREIGN KEY (orderId) REFERENCES tbl_order (orderId);
ALTER TABLE order_detail
    ADD CONSTRAINT FK_order_detail_product FOREIGN KEY (productId) REFERENCES product (productId);

ALTER TABLE cart
    ADD CONSTRAINT FK_cart_product FOREIGN KEY (productId) REFERENCES product (productId);
ALTER TABLE cart
    ADD CONSTRAINT FK_cart_account FOREIGN KEY (userId) REFERENCES Account (userId);

ALTER TABLE Account
    ADD CONSTRAINT FK_account_role FOREIGN KEY (roleId) REFERENCES role(roleId);

ALTER TABLE tbl_order
	ADD CONSTRAINT FK_order_account FOREIGN KEY (userId) REFERENCES Account (userId);

INSERT INTO role (roleId, name) VALUES (1, 'ROLE_ADMIN'), (2, 'ROLE_USER');
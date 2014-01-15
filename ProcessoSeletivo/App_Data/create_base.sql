CREATE TABLE Product (
  id INT  NOT NULL   IDENTITY ,
  Name VARCHAR(99)      ,
PRIMARY KEY(id));
GO

CREATE TABLE Category (
  id INT  NOT NULL   IDENTITY ,
  Category_id INT    ,
  Name VARCHAR(50)  NOT NULL    ,
PRIMARY KEY(id),
  FOREIGN KEY(Category_id)
    REFERENCES Category(id));
GO

CREATE TABLE Category_Product (
  id INT  NOT NULL   IDENTITY ,
  Product_id INT  NOT NULL  ,
  Category_id INT  NOT NULL    ,
PRIMARY KEY(id),
  FOREIGN KEY(Category_id)
    REFERENCES Category(id),
  FOREIGN KEY(Product_id)
    REFERENCES Product(id));
GO
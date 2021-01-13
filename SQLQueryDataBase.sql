

Create database MantenimientoDeUsuario
Go

Use MantenimientoDeUsuario
Go

CREATE TABLE Users
(
    Id           int primary key identity  not null,
    FullName     varchar (50) not null,
    BirtDay      date         not null,
    CardNumberId varchar (11) not null
)
Go

CREATE TABLE Products
(
    Id           int primary key identity  not null,
    Name_        varchar (25)    not null,
    Description_ varchar (300)   not null,
    Price        decimal (18, 2) not null,
    Quantity     int             not null
)
Go

CREATE TABLE Invoices
(
    Id         int primary key identity  not null,
    DateIssued date not null,
    User_      int  not null,
    FOREIGN KEY (User_) REFERENCES Users (Id)
)
Go

CREATE TABLE InvoiceDetails
(
    Id       int primary key identity  not null,
    Quantity int not null,
    Invoice  int not null,
    User_    int not null,
    Product  int not null,
    FOREIGN KEY (Invoice) REFERENCES Invoices (Id),
    FOREIGN KEY (User_) REFERENCES Users (Id),
    FOREIGN KEY (Product) REFERENCES Products (Id)
)
Go



-- procedimientos almacenado de usuario

create proc ShowUsers
as
begin

    select 
    Id as [ID],
    FullName as [NOMBRE COMPLETO], 
    BirtDay as [DÍA DE NACIMIENTO],
    CardNumberId as [CÉDULA] From Users

end
GO

create proc ShowUsersId
@Id int
as
begin

    select 
    Id as [ID],
    FullName as [NOMBRE COMPLETO], 
    BirtDay as [DÍA DE NACIMIENTO],
    CardNumberId as [CÉDULA] From Users where Id = @Id

end
GO

create proc CreateUsers
@FullName varchar(50),
@BirtDay Date,
@CardNumberId varchar(11)
as
begin

    insert into Users values (@FullName, @BirtDay, @CardNumberId)

end
GO

create proc UpdateUsers
@Id int,
@FullName varchar(50),
@BirtDay Date,
@CardNumberId varchar(11)
as
begin

    update Users set 
        FullName = @FullName,
        BirtDay = @BirtDay,
        CardNumberId = @CardNumberId
        where Id = @Id;

end
GO

create proc DeleteUsers
@Id int
as
begin

    Delete Users where Id = @Id;

end
GO



-- procedimientos almacenado de producto

create proc ShowProducts
as
begin

    select Id as ID ,
           Name_  as  NOMBRE   ,
           Description_ as DESCRIPCIÓN,
           Price  as PRECIO,
           Quantity as CANTIDAD  From Products

end
GO

create proc ShowProductsId
@Id int
as
begin

    select Id as ID ,
           Name_  as  NOMBRE,
           Description_ as DESCRIPCIÓN,
           Price  as PRECIO,
           Quantity as CANTIDAD  From Products where Id = @Id

end
GO

create proc CreateProducts
@Name varchar(25),
@Description varchar(300),
@Price decimal(18,2),
@Quantity int
as
begin

    insert into Products values (@Name, @Description, @Price, @Quantity)

end
GO

create proc UpdateProducts
@Id int,
@Name varchar(25),
@Description varchar(300),
@Price decimal(18,2),
@Quantity int
as
begin

    update Products set 
        Name_ = @Name,
        Description_ = @Description,
        Price = @Price,
        Quantity = @Quantity
        where Id = @Id;

end
GO

create proc DeleteProducts
@Id int
as
begin

    Delete Products where Id = @Id;

end
GO



-- procedimientos almacenado de factura

create proc ShowInvoices
as
begin

    select Invoices.Id as ID ,
           DateIssued  as  [FECHA DE EMISIÓN],
           Users.Id as [USUARIO ID],
           Users.FullName as [NOMBRE COMPLETO]
           From Invoices join Users on Invoices.User_ = Users.Id

end
GO

create proc ShowInvoicesId
@Id int
as
begin

        select Invoices.Id as ID ,
                   DateIssued  as  [FECHA DE EMISIÓN],
                   Users.Id as [USUARIO ID],
                   Users.FullName as [NOMBRE COMPLETO]
                   From Invoices join Users on Invoices.User_ = Users.Id
         where  Invoices.Id = @Id

end
GO

create proc CreateInvoices
@DateIssued Date,
@User_ int
as
begin

    insert into Invoices values (@DateIssued, @User_)

end
GO



-- procedimientos almacenado de detalle de factura

create proc ShowInvoiceDetail
as
begin

    select InvoiceDetails.Id as ID ,
           InvoiceDetails.Quantity  as CANTIDAD,

           Invoice   as [FACTURA ID],
           Invoices.DateIssued as   [FECHA DE EMISIÓN],

           InvoiceDetails.User_  as [USUARIO ID],
           Users.FullName as [NOMBRE COMPLETO],

           Product as [PRODUCTO ID],
           Products.Name_ as PRODUCTO,           
           Products.Price as PRECIO

           From InvoiceDetails join Invoices     on InvoiceDetails.Invoice     = Invoices.Id
                               join Users         on InvoiceDetails.User_      = Users.Id
                               join Products      on InvoiceDetails.Product    = Products.Id

end
GO

create proc ShowInvoiceDetailId
@Id int
as
begin

    select InvoiceDetails.Id as ID ,
           InvoiceDetails.Quantity  as CANTIDAD,

           Invoice   as [FACTURA ID],
           Invoices.DateIssued as   [FECHA DE EMISIÓN],

           InvoiceDetails.User_  as [USUARIO ID],
           Users.FullName as [NOMBRE COMPLETO],

           Product as [PRODUCTO ID],
           Products.Name_ as PRODUCTO,           
           Products.Price as PRECIO

           From InvoiceDetails join Invoices     on InvoiceDetails.Invoice     = Invoices.Id
                               join Users         on InvoiceDetails.User_      = Users.Id
                               join Products      on InvoiceDetails.Product    = Products.Id
         where InvoiceDetails.User_ = @Id

end
GO

create proc CreateInvoiceDetail
@Quantity int,
@Invoice  int,
@User     int,
@Product  int
as
begin

    insert into InvoiceDetails values (@Quantity, @Invoice,@User,@Product)

end
GO

create proc UpdateInvoiceDetail
@Id int,
@Quantity int,
@Product  int
as
begin

    update InvoiceDetails set Quantity = @Quantity, Product = @Product where Id = @Id

end
GO



--- datos para usuario

insert into Users values 
('Juan Manuel De Los Santos Castillo',	'1/15/2021','12345678912'),
('Angel Antonio Acosta Frias',	        '1/22/2021','37481739283'),
('Steven Inoa Delgado',	                '1/15/2021','12345632536'),
('Ramon Matías Mella',	                '1/8/2021 ','37483927483')
GO

--- datos para producto

insert into Products values 
('Arroz',	            '1 kilo',	        3.50,	35 ),
('Café soluble',	    '200 gramos',	    21.99,	56 ),
('Frijol',	            '2 kilos',	        14.00,	100),
('Sopa',	            'sobres',           1.69,	10 ),
('Huevos',	            '30 unidades',	    10.40,	32 ),
('Harina de trigo',	    '4 kilos',	        6.19,	23 ),
('Azúcar',	            '2 kilos',	        18.40,	12 ),
('Jamón',	            '1 kilo',	        37.00,	34 ),
('Carne molida',	    '1 kilo',	        25.90,	15 ),
('JUEGO PIN-PON',	    'Desarrollador',	5.00,	2  ),
('luis eduardo frias',	'fdsf',	            10.30,	2  ),
('bzczxbc',	            'dasfda',	        4.25,	3  ),
('JUEGO PIN-PON',	    'fdsf',	            56.60,	4  ),
('bzczxbc',	            'Desarrollador',	55.10,	2  )
GO

--- datos para factura

insert into Invoices values 
('12/12/2020',  1),
('11/11/2020',  2),
('10/10/2020',  3),
('9/9/2020',    4)
GO

--- datos para detalle de factura

insert into InvoiceDetails values 
(5	,1	,1	,3),
(10	,1	,1	,4),
(2	,1	,1	,5),
(4	,1	,1	,6),
(3	,2	,2	,6),
(6	,2	,2	,7),
(7	,2	,2	,8),
(19	,3	,3	,6),
(1	,3	,3	,4),
(7	,3	,3	,7),
(6	,4	,4	,6),
(5	,4	,4	,4)
GO
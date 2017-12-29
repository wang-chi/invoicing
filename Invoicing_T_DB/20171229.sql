CREATE DATABASE TmpDB;
USE invoicing

--角色資料表
CREATE TABLE roles
(
	r_id nchar(5) NOT NULL,
	r_name nvarchar(20) NOT NULL
	primary key(r_id)
);
SELECT r_id, r_name FROM roles;
INSERT INTO roles (r_id, r_name)VALUES('R0006',N'資材人員');
INSERT INTO roles (r_id, r_name)VALUES('R0007',N'點貨人員');


--員工資料表
CREATE TABLE member
(
	m_id nchar(6) NOT NULL,
	m_name nvarchar(20) NOT NULL,
	m_pwd nvarchar(40) NOT NULL,
	m_state bit NOT NULL,
	m_sex varchar(1) NOT NULL,
	r_id nchar(5) NOT NULL,
	m_phone char(10) NOT NULL,
	m_email varchar(40) NOT NULL,
	createdate datetime NOT NULL,
	update_time datetime NOT NULL

primary key(m_id),
FOREIGN KEY (r_id) REFERENCES roles(r_id)
);
SELECT * FROM member;

--新增員工
INSERT INTO member (m_id,m_name,m_pwd, m_state,m_sex,r_id,m_phone,m_email,createdate,update_time) 
VALUES ('nutc02', N'蕭國萱', 'nutc02', 'TRUE', 'F', 'R0002', '0984575152', 'fhui@gmail.com', GETDATE(),GETDATE());

--權限資料表
DROP TABLE auth;
CREATE TABLE auth
(
	a_id nchar(5) NOT NULL,
	a_name nvarchar(20) NOT NULL,
	a_page nvarchar(40) NOT NULL,
	primary key(a_id)
);
SELECT a_id, a_name, a_page FROM auth;
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0001', 'member_manage', N'帳號管理');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0002', 'member_edit', N'帳號管理:修改刪除');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0003', 'member_new', N'帳號管理:新增');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0004', 'supplier_manage', N'供應商管理');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0005', 'supplier_edit', N'供應商管理:修改刪除');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0006', 'supplier_new', N'供應商管理:新增');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0007', 'client_manage', N'客戶管理');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0008', 'client_edit', N'客戶管理:修改刪除');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0009', 'client_new', N'客戶管理:新增');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0010', 'product_manage', N'商品管理');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0011', 'product_edit', N'商品管理:修改刪除');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0012', 'product_new', N'商品管理:新增');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0013', 'company_manage', N'公司管理');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0014', 'company_edit', N'公司管理:修改刪除');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0015', 'company_new', N'公司管理:新增');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0016', 'group_manage', N'角色管理');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0017', 'group_edit', N'角色管理:修改刪除');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0018', 'group_new', N'角色管理:新增');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0019', 'auth_manage', N'權限管理');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0020', 'auth_edit', N'權限管理:修改刪除');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0021', 'auth_new', N'權限管理:新增');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0022', 'employ_manage', N'員工管理');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0023', 'employ_edit', N'員工管理:修改刪除');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0024', 'employ_new', N'員工管理:新增');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0025', 'product_type_manage', N'商品類別管理');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0026', 'product_type_edit', N'商品類別管理:修改刪除');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0027', 'product_type_new', N'商品類別管理:新增');


--角色權限資料表
DROP TABLE roles_auth;
CREATE TABLE roles_auth
(
	ra_id nchar(5) NOT NULL,
	r_id nchar(5) NOT NULL,
	a_id nchar(5) NOT NULL,
	viewmode bit NOT NULL,
	primary key(ra_id),
	FOREIGN KEY (r_id) REFERENCES roles(r_id),
	FOREIGN KEY (a_id) REFERENCES auth(a_id)
);

SELECT * FROM roles_auth;
DECLARE @_MAX INT, @_i INT, @_auth INT
DECLARE @_roles NVARCHAR(5)
SET @_roles = 'R0007' --1~7
SET @_auth = 49 --起始值1/25/49/73
SET @_i = 1
SET @_MAX = 25 --權限數量-1
WHILE (@_i<@_MAX)
BEGIN
	IF @_i<10
		INSERT INTO roles_auth VALUES(CONCAT('RA1',@_auth), @_roles, CONCAT('A000',@_i), '1'); --R0001會計人員/A0001帳號管理
	ELSE
		INSERT INTO roles_auth VALUES(CONCAT('RA1',@_auth), @_roles, CONCAT('A00',@_i), '1'); --R0001會計人員/A0001帳號管理
	SET @_i = @_i+1
	SET @_auth = @_auth +1
END

--權限Code
SELECT ra.r_id, a.a_name,a_page ,ra.viewmode
FROM roles_auth ra, auth a
WHERE  ra.a_id = a.a_id AND ra.r_id = 'R0001'

--分公司資料表
DROP TABLE company;
CREATE TABLE company
(
com_id nchar(5) NOT NULL,
com_name nvarchar(20) NOT NULL,
com_address nvarchar(40) NOT NULL,
com_un nvarchar(8) NOT NULL,
com_agent nvarchar(20) NOT NULL,
com_tel nchar(10) NOT NULL,
com_fax nchar(10) NOT NULL,
createdate datetime NOT NULL,
update_time datetime NOT NULL
primary key(com_id)
);
SELECT * FROM company;
INSERT INTO company(com_id, com_name, com_address, com_un, com_agent, com_tel, com_fax, createdate, update_time)
VALUES('COM01', N'祥益公司', N'台中市西屯區台灣大道三段129號', '52010101', N'陳惠安', '0424248965', '0424367845', GETDATE(), GETDATE());

--客戶資料表
DROP TABLE client;
CREATE TABLE client
(
c_id nchar(5) NOT NULL,
c_name nvarchar(20) NOT NULL,
c_address nvarchar(40) NOT NULL,
c_phone nchar(10) NOT NULL,
c_email varchar(40) NOT NULL,
createdate datetime NOT NULL,
update_time datetime NOT NULL
primary key(c_id)
);
SELECT * FROM client;
INSERT INTO client(c_id, c_name, c_address, c_phone, c_email, createdate, update_time)
VALUES('C0001', N'陳香如', N'台北市信義區中山路129號', '0912854789', 'book@gmail.com', GETDATE(), GETDATE())

--廠商資料表
DROP TABLE supplier;
CREATE TABLE supplier
(
s_id nchar(5) NOT NULL,
s_name nvarchar(20) NOT NULL,
s_address nvarchar(40) NOT NULL,
s_phone nchar(10) NOT NULL,
s_email nvarchar(40) NOT NULL,
createdate datetime NOT NULL,
update_time datetime NOT NULL
primary key(s_id)
);
SELECT * FROM supplier;
INSERT INTO supplier(s_id, s_name, s_address, s_phone, s_email,createdate, update_time)
VALUES('S0001', N'祥益公司', N'台中市西屯區台灣大道三段129號','0424248965', 'S0001@gmail.com',GETDATE(), GETDATE());


--商品類別表
DROP TABLE product_type;
CREATE TABLE product_type
(
pt_id nchar(5) NOT NULL,
pt_name nvarchar(20) NOT NULL

primary key(pt_id)
);


--商品資料表
CREATE TABLE product
(
p_id nchar(5) NOT NULL,
pt_id nchar(5) NOT NULL,
p_name nvarchar(20) NOT NULL

primary key(p_id),
FOREIGN KEY (pt_id) REFERENCES product_type(pt_id)
);
--進貨價格表
CREATE TABLE supplier_price
(
sp_id nchar(5)  NOT NULL,
p_id  nchar(5)  NOT NULL,
s_id nchar(5) NOT NULL,
price float NOT NULL,
createdate datetime NOT NULL

primary key(sp_id),
FOREIGN KEY (p_id) REFERENCES product(p_id),
FOREIGN KEY (s_id) REFERENCES supplier(s_id)
);
--銷貨價格表
CREATE TABLE client_price
(
cp_id nchar(5)  NOT NULL,
p_id  nchar(5)  NOT NULL,
c_id nchar(5) NOT NULL,
price float NOT NULL,
createdate datetime NOT NULL

primary key(cp_id),
FOREIGN KEY (p_id) REFERENCES product(p_id),
FOREIGN KEY (c_id) REFERENCES client(c_id)
);
--進貨單資料表
CREATE TABLE purchases
(
pur_id nchar(5)  NOT NULL,
s_id  nchar(5)  NOT NULL,
m_id nchar(5) NOT NULL,
accept bit NOT NULL,
deliverydate datetime NOT NULL,
createdate datetime NOT NULL,
update_time datetime NOT NULL

primary key(pur_id),
FOREIGN KEY (s_id) REFERENCES supplier(s_id),
FOREIGN KEY (m_id) REFERENCES member(m_id)
);
--進貨單內容資料表
CREATE TABLE purchases_info
(
purin_id nchar(7)  NOT NULL,
pur_id nchar(5)  NOT NULL,
p_id  nchar(5)  NOT NULL,
m_number nchar(5)  NOT NULL,
purin_price float NOT NULL,
purin_qty int NOT NULL,
createdate datetime NOT NULL,
update_time datetime NOT NULL

primary key(purin_id),
FOREIGN KEY (pur_id) REFERENCES purchases(pur_id),
FOREIGN KEY (p_id) REFERENCES product(p_id)
);
--退貨單資料表
CREATE TABLE sup_returns
(
supre_id nchar(5)  NOT NULL,
pur_id nchar(5)  NOT NULL,
purin_id nchar(7)  NOT NULL,
m_number nchar(5)  NOT NULL,
supre_qty int NOT NULL,
createdate datetime NOT NULL

primary key(supre_id),
FOREIGN KEY (pur_id) REFERENCES purchases(pur_id),
FOREIGN KEY (purin_id) REFERENCES purchases_info(purin_id)
);
--訂貨單資料表
CREATE TABLE orders
(
or_id nchar(5)  NOT NULL,
c_id  nchar(5)  NOT NULL,
createdate datetime NOT NULL,
update_time datetime NOT NULL

primary key(or_id),
FOREIGN KEY (c_id) REFERENCES client(c_id)
);
--訂貨單資料表
CREATE TABLE orders_info
(
in_id nchar(5)  NOT NULL,
or_id nchar(5)  NOT NULL,
p_id  nchar(5)  NOT NULL,
in_price float NOT NULL,
in_qty int NOT NULL,
createdate datetime NOT NULL,
update_time datetime NOT NULL

primary key(in_id),
FOREIGN KEY (or_id) REFERENCES orders(or_id),
FOREIGN KEY (p_id) REFERENCES product(p_id)
);
--出貨單資料表
CREATE TABLE ship
(
sh_id  nchar(5)  NOT NULL,
or_id nchar(5)  NOT NULL,
sh_check bit NOT NULL,
shipdate datetime NOT NULL,
createdate datetime NOT NULL

primary key(sh_id),
FOREIGN KEY (or_id) REFERENCES orders(or_id)
);
--退貨處理資料表
CREATE TABLE cli_returns
(
clire_id nchar(5)  NOT NULL,
or_id nchar(5)  NOT NULL,
in_id  nchar(5)  NOT NULL,
clire_qty int NOT NULL,
createdate datetime NOT NULL,

primary key(in_id),
FOREIGN KEY (or_id) REFERENCES orders(or_id),
FOREIGN KEY (in_id) REFERENCES orders_info(in_id)
);
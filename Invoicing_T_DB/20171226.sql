CREATE DATABASE TmpDB;
USE TmpDB;

--角色資料表
CREATE table roles
(
r_id nchar(5) NOT NULL,
r_name nvarchar(20) NOT NULL

primary key(r_id)
);
--員工資料表
CREATE table member
(
m_id nchar(5) NOT NULL,
m_name nvarchar(20) NOT NULL,
m_pwd nvarchar(8) NOT NULL,
m_sex varchar(1) NOT NULL,
r_id nchar(5) NOT NULL,
m_phone char(10) NOT NULL,
m_email varchar(40) NOT NULL,
createdate datetime NOT NULL,
update_time datetime NOT NULL

primary key(m_id),
FOREIGN KEY (r_id) REFERENCES roles(r_id)
);
--權限資料表
CREATE table auth
(
a_id nchar(5) NOT NULL,
a_name nvarchar(20) NOT NULL

primary key(a_id)
);
--角色權限資料表
CREATE table role_auth
(
ra_id nchar(5) NOT NULL,
r_id nchar(5) NOT NULL,
a_id nchar(5) NOT NULL,
viewmode bit NOT NULL

primary key(ra_id),
FOREIGN KEY (r_id) REFERENCES roles(r_id),
FOREIGN KEY (a_id) REFERENCES auth(a_id)
);
--分公司資料表
CREATE table company
(
com_id nchar(5) NOT NULL,
com_name nvarchar(20) NOT NULL,
com_address nvarchar(40) NOT NULL,
com_un varchar(8) NOT NULL,
com_agent nvarchar(20) NOT NULL,
com_tel char(10) NOT NULL,
com_fax char(10) NOT NULL,
createdate datetime NOT NULL,
update_time datetime NOT NULL

primary key(com_id)
);
--客戶資料表
CREATE table client
(
c_id nchar(5) NOT NULL,
c_name nvarchar(20) NOT NULL,
c_address nvarchar(40) NOT NULL,
c_phone char(10) NOT NULL,
c_email varchar(40) NOT NULL,
createdate datetime NOT NULL,
update_time datetime NOT NULL

primary key(c_id)
);
--廠商資料表
CREATE table supplier
(
s_id nchar(5) NOT NULL,
s_name nvarchar(20) NOT NULL,
s_address nvarchar(40) NOT NULL,
s_phone char(10) NOT NULL,
s_email varchar(40) NOT NULL,
createdate datetime NOT NULL,
update_time datetime NOT NULL

primary key(s_id)
);
--商品類別表
CREATE table product_type
(
pt_id nchar(5) NOT NULL,
pt_name nvarchar(20) NOT NULL

primary key(pt_id)
);
--商品資料表
CREATE table product
(
p_id nchar(5) NOT NULL,
pt_id nchar(5) NOT NULL,
p_name nvarchar(20) NOT NULL

primary key(p_id),
FOREIGN KEY (pt_id) REFERENCES product_type(pt_id)
);
--進貨價格表
CREATE table supplier_price
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
CREATE table client_price
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
CREATE table purchases
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
CREATE table purchases_info
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
CREATE table sup_returns
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
CREATE table orders
(
or_id nchar(5)  NOT NULL,
c_id  nchar(5)  NOT NULL,
createdate datetime NOT NULL,
update_time datetime NOT NULL

primary key(or_id),
FOREIGN KEY (c_id) REFERENCES client(c_id)
);
--訂貨單資料表
CREATE table orders_info
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
CREATE table ship
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
CREATE table cli_returns
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
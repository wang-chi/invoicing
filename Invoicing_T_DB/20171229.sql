CREATE DATABASE TmpDB;
USE invoicing

--�����ƪ�
CREATE TABLE roles
(
	r_id nchar(5) NOT NULL,
	r_name nvarchar(20) NOT NULL
	primary key(r_id)
);
SELECT r_id, r_name FROM roles;
INSERT INTO roles (r_id, r_name)VALUES('R0006',N'����H��');
INSERT INTO roles (r_id, r_name)VALUES('R0007',N'�I�f�H��');


--���u��ƪ�
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

--�s�W���u
INSERT INTO member (m_id,m_name,m_pwd, m_state,m_sex,r_id,m_phone,m_email,createdate,update_time) 
VALUES ('nutc02', N'���긩', 'nutc02', 'TRUE', 'F', 'R0002', '0984575152', 'fhui@gmail.com', GETDATE(),GETDATE());

--�v����ƪ�
DROP TABLE auth;
CREATE TABLE auth
(
	a_id nchar(5) NOT NULL,
	a_name nvarchar(20) NOT NULL,
	a_page nvarchar(40) NOT NULL,
	primary key(a_id)
);
SELECT a_id, a_name, a_page FROM auth;
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0001', 'member_manage', N'�b���޲z');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0002', 'member_edit', N'�b���޲z:�ק�R��');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0003', 'member_new', N'�b���޲z:�s�W');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0004', 'supplier_manage', N'�����Ӻ޲z');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0005', 'supplier_edit', N'�����Ӻ޲z:�ק�R��');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0006', 'supplier_new', N'�����Ӻ޲z:�s�W');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0007', 'client_manage', N'�Ȥ�޲z');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0008', 'client_edit', N'�Ȥ�޲z:�ק�R��');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0009', 'client_new', N'�Ȥ�޲z:�s�W');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0010', 'product_manage', N'�ӫ~�޲z');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0011', 'product_edit', N'�ӫ~�޲z:�ק�R��');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0012', 'product_new', N'�ӫ~�޲z:�s�W');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0013', 'company_manage', N'���q�޲z');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0014', 'company_edit', N'���q�޲z:�ק�R��');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0015', 'company_new', N'���q�޲z:�s�W');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0016', 'group_manage', N'����޲z');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0017', 'group_edit', N'����޲z:�ק�R��');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0018', 'group_new', N'����޲z:�s�W');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0019', 'auth_manage', N'�v���޲z');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0020', 'auth_edit', N'�v���޲z:�ק�R��');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0021', 'auth_new', N'�v���޲z:�s�W');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0022', 'employ_manage', N'���u�޲z');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0023', 'employ_edit', N'���u�޲z:�ק�R��');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0024', 'employ_new', N'���u�޲z:�s�W');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0025', 'product_type_manage', N'�ӫ~���O�޲z');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0026', 'product_type_edit', N'�ӫ~���O�޲z:�ק�R��');
INSERT INTO auth (a_id, a_name, a_page) VALUES ('A0027', 'product_type_new', N'�ӫ~���O�޲z:�s�W');


--�����v����ƪ�
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
SET @_auth = 49 --�_�l��1/25/49/73
SET @_i = 1
SET @_MAX = 25 --�v���ƶq-1
WHILE (@_i<@_MAX)
BEGIN
	IF @_i<10
		INSERT INTO roles_auth VALUES(CONCAT('RA1',@_auth), @_roles, CONCAT('A000',@_i), '1'); --R0001�|�p�H��/A0001�b���޲z
	ELSE
		INSERT INTO roles_auth VALUES(CONCAT('RA1',@_auth), @_roles, CONCAT('A00',@_i), '1'); --R0001�|�p�H��/A0001�b���޲z
	SET @_i = @_i+1
	SET @_auth = @_auth +1
END

--�v��Code
SELECT ra.r_id, a.a_name,a_page ,ra.viewmode
FROM roles_auth ra, auth a
WHERE  ra.a_id = a.a_id AND ra.r_id = 'R0001'

--�����q��ƪ�
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
VALUES('COM01', N'���q���q', N'�x������ٰϥx�W�j�D�T�q129��', '52010101', N'���f�w', '0424248965', '0424367845', GETDATE(), GETDATE());

--�Ȥ��ƪ�
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
VALUES('C0001', N'�����p', N'�x�_���H�q�Ϥ��s��129��', '0912854789', 'book@gmail.com', GETDATE(), GETDATE())

--�t�Ӹ�ƪ�
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
VALUES('S0001', N'���q���q', N'�x������ٰϥx�W�j�D�T�q129��','0424248965', 'S0001@gmail.com',GETDATE(), GETDATE());


--�ӫ~���O��
DROP TABLE product_type;
CREATE TABLE product_type
(
pt_id nchar(5) NOT NULL,
pt_name nvarchar(20) NOT NULL

primary key(pt_id)
);


--�ӫ~��ƪ�
CREATE TABLE product
(
p_id nchar(5) NOT NULL,
pt_id nchar(5) NOT NULL,
p_name nvarchar(20) NOT NULL

primary key(p_id),
FOREIGN KEY (pt_id) REFERENCES product_type(pt_id)
);
--�i�f�����
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
--�P�f�����
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
--�i�f���ƪ�
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
--�i�f�椺�e��ƪ�
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
--�h�f���ƪ�
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
--�q�f���ƪ�
CREATE TABLE orders
(
or_id nchar(5)  NOT NULL,
c_id  nchar(5)  NOT NULL,
createdate datetime NOT NULL,
update_time datetime NOT NULL

primary key(or_id),
FOREIGN KEY (c_id) REFERENCES client(c_id)
);
--�q�f���ƪ�
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
--�X�f���ƪ�
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
--�h�f�B�z��ƪ�
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
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
SELECT m.m_id,ra.r_id, a.a_name,a_page ,ra.viewmode
FROM member m, roles_auth ra, auth a
WHERE  ra.a_id = a.a_id AND ra.r_id = m.r_id AND m.m_id = 'nutc01'
ORDER BY m.m_id

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
INSERT INTO product_type(pt_id, pt_name) VALUES('PT001',N'���Ϋ~');
INSERT INTO product_type(pt_id, pt_name) VALUES('PT002',N'�Ͳ��ƥ�');
INSERT INTO product_type(pt_id, pt_name) VALUES('PT003',N'�s�y�ƥ�');
INSERT INTO product_type(pt_id, pt_name) VALUES('PT004',N'�ͬ��Ϋ~');

USE invoicing

--�ӫ~��ƪ�
DROP TABLE product;
CREATE TABLE product
(
p_id nchar(5) NOT NULL,
pt_id nchar(5) NOT NULL,
p_name nvarchar(20) NOT NULL,
p_price int NOT NULL,
primary key(p_id),
FOREIGN KEY (pt_id) REFERENCES product_type(pt_id)
);
INSERT INTO product(p_id, pt_id, p_name, p_price) VALUES('P0001','PT002',N'�쪫��', '30');
INSERT INTO product(p_id, pt_id, p_name, p_price) VALUES('P0002','PT004',N'���M','20');
INSERT INTO product(p_id, pt_id, p_name, p_price) VALUES('P0003','PT004',N'�ȪM','5');

--�i�f�����
DROP TABLE supplier_price;
CREATE TABLE supplier_price
(
sp_id nchar(7)  NOT NULL,
p_id  nchar(5)  NOT NULL,
s_id nchar(5) NOT NULL,
price float NOT NULL,
createdate datetime NOT NULL

primary key(sp_id),
FOREIGN KEY (p_id) REFERENCES product(p_id),
FOREIGN KEY (s_id) REFERENCES supplier(s_id)
);
--�P�f�����
DROP TABLE client_price;
CREATE TABLE client_price
(
cp_id nchar(7)  NOT NULL,
p_id  nchar(5)  NOT NULL,
c_id nchar(5) NOT NULL,
price float NOT NULL,
createdate datetime NOT NULL

primary key(cp_id),
FOREIGN KEY (p_id) REFERENCES product(p_id),
FOREIGN KEY (c_id) REFERENCES client(c_id)
);
--�i�f���ƪ�
DROP TABLE purchases
CREATE TABLE purchases
(
pur_id nchar(5)  NOT NULL,
s_id  nchar(5)  NOT NULL,--�����ӽs��
m_id nchar(6) NOT NULL,--���u�s��
accept bit NOT NULL,--�禬
deliverydate datetime NOT NULL,
createdate datetime NOT NULL,
update_time datetime NOT NULL
primary key(pur_id),
FOREIGN KEY (s_id) REFERENCES supplier(s_id),
FOREIGN KEY (m_id) REFERENCES member(m_id)
);
--�i�f�椺�e��ƪ�
DROP TABLE purchases_info;
CREATE TABLE purchases_info
(
purin_id nchar(7)  NOT NULL,
pur_id nchar(5)  NOT NULL,
p_id  nchar(5)  NOT NULL,
m_id nchar(6)  NOT NULL,--���u
purin_price float NOT NULL,--�i�f���
purin_qty int NOT NULL,--�i�f�ƶq
purin_check_qty int NOT NULL, --�w�禬�ƶq
createdate datetime NOT NULL,
update_time datetime NOT NULL
primary key(purin_id),
FOREIGN KEY (pur_id) REFERENCES purchases(pur_id),
FOREIGN KEY (p_id) REFERENCES product(p_id)
);
--�i�f�h�f���ƪ�
DROP TABLE purchases_returns;
CREATE TABLE purchases_returns
(
pr_id nchar(5)  NOT NULL,--�h�f��s��
pur_id nchar(5)  NOT NULL,--�i�f��s��
m_id nchar(6)  NOT NULL,
createdate datetime NOT NULL,
update_time datetime NOT NULL
primary key(pr_id),
FOREIGN KEY (pur_id) REFERENCES purchases(pur_id)
);
--�h�f�椺�e��ƪ�
DROP TABLE purchases_returns_info;
CREATE TABLE purchases_returns_info
(
pri_id nchar(7)  NOT NULL,--�h�f���e�s��
pr_id nchar(5)  NOT NULL,--�h�f��s��
p_id  nchar(5)  NOT NULL,--�ӫ~�s��
m_id nchar(6)  NOT NULL,--���u
prin_qty int NOT NULL,--�h�f�ƶq
createdate datetime NOT NULL,
update_time datetime NOT NULL
primary key(pri_id),
FOREIGN KEY (pr_id) REFERENCES purchases_returns(pr_id),
FOREIGN KEY (p_id) REFERENCES product(p_id)
);


--�q�f���ƪ�
CREATE TABLE orders
(
or_id nchar(5)  NOT NULL,
c_id  nchar(5)  NOT NULL,
m_id nchar(6) NOT NULL,
accept bit NOT NULL,
deliverydate datetime NOT NULL,
createdate datetime NOT NULL,
update_time datetime NOT NULL

primary key(or_id),
FOREIGN KEY (c_id) REFERENCES client(c_id),
FOREIGN KEY (m_id) REFERENCES member(m_id)
);
--�q�f���ƪ�
DROP TABLE orders_info;
CREATE TABLE orders_info
(
orin_id nchar(7)  NOT NULL,
or_id nchar(5)  NOT NULL,
p_id  nchar(5)  NOT NULL,
m_id nchar(6)  NOT NULL,
orin_price float NOT NULL,
orin_qty int NOT NULL,
createdate datetime NOT NULL,
update_time datetime NOT NULL

primary key(orin_id),
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

select * 
from roles_auth ra , auth a
where ra.r_id='R0001' and
 ra.a_id = a.a_id

 select * from roles_auth

update roles_auth set viewmode=''


--BOM
 CREATE TABLE  PARTLIST 
     ( PART     VARCHAR(8),
       SUBPART  VARCHAR(8),
       QUANTITY INTEGER )
--Single level explosion
   
   WITH RPL (PART, SUBPART, QUANTITY) AS
        (  SELECT ROOT.PART, ROOT.SUBPART, ROOT.QUANTITY
              FROM PARTLIST ROOT
              WHERE ROOT.PART = '01'
          UNION ALL
           SELECT CHILD.PART, CHILD.SUBPART, CHILD.QUANTITY
              FROM RPL PARENT, PARTLIST CHILD
              WHERE PARENT.SUBPART = CHILD.PART
         )
   SELECT DISTINCT PART, SUBPART, QUANTITY
     FROM RPL
     ORDER BY PART, SUBPART, QUANTITY

--Summarized explosion
   WITH RPL (PART, SUBPART, QUANTITY) AS
        (  SELECT ROOT.PART, ROOT.SUBPART, ROOT.QUANTITY
              FROM PARTLIST ROOT
              WHERE ROOT.PART = '01'
          UNION ALL
           SELECT PARENT.PART, CHILD.SUBPART, PARENT.QUANTITY*CHILD.QUANTITY
              FROM RPL PARENT, PARTLIST CHILD
              WHERE PARENT.SUBPART = CHILD.PART
         )
   SELECT PART, SUBPART, SUM(QUANTITY) AS "Total QTY Used"
     FROM RPL
     GROUP BY PART, SUBPART
     ORDER BY PART, SUBPART

	 --Controlling depth
	    WITH RPL ( LEVEL, PART, SUBPART, QUANTITY)
     AS ( SELECT 1, ROOT.PART, ROOT.SUBPART, ROOT.QUANTITY
             FROM PARTLIST ROOT
             WHERE ROOT.PART = '01'
           UNION ALL
          SELECT PARENT.LEVEL+1, CHILD.PART, CHILD.SUBPART, CHILD.QUANTITY
             FROM RPL PARENT, PARTLIST CHILD
             WHERE PARENT.SUBPART = CHILD.PART
             AND PARENT.LEVEL < 2
         )
   SELECT PART, LEVEL, SUBPART, QUANTITY
     FROM RPL
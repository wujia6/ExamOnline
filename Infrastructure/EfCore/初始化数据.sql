--初始化权限
select * from Permissions
insert into Permissions (Remarks,LevelID,TypeAt,Named,Command) values
	('暂无',0,21,'系统管理','sys'),			--1
	('暂无',0,21,'班级管理','cls'),			--2
	('暂无',0,21,'教师管理','thr'),			--3
	('暂无',0,21,'学生管理','stu'),			--4
	('暂无',0,21,'考试管理','exam'),			--5
	('暂无',1,22,'站点设置','settings'),		--6
	('暂无',1,22,'开发者设置','developer'),	--7
	('暂无',1,22,'权限设置','permission'),		--8
	('暂无',1,22,'角色设置','role'),			--9
	('暂无',1,22,'菜单设置','menu'),			--10
	('暂无',1,22,'报表设置','report'),			--11
	('暂无',6,23,'站点设置预留','action1'),
	('暂无',6,23,'站点设置预留','action2'),
	('暂无',7,23,'开发者设置预留','action1'),
	('暂无',7,23,'开发者设置预留','action2'),
	('暂无',8,23,'编辑','edit'),
	('暂无',8,23,'删除','remove'),
	('暂无',8,23,'浏览','browse'),
	('暂无',9,23,'新增','add'),
	('暂无',9,23,'编辑','edit'),
	('暂无',9,23,'删除','remove'),
	('暂无',9,23,'浏览','browse'),
	('暂无',10,23,'新增','add'),
	('暂无',10,23,'编辑','edit'),
	('暂无',10,23,'删除','remove'),
	('暂无',10,23,'浏览','browse'),
	('暂无',11,23,'导出','export'),
	('暂无',11,23,'浏览','browse')

--初始化角色
select * from Roles
insert into Roles(Remarks,[Name],Code) values('暂无','管理员','admin'),('暂无','教师','teacher'),('暂无','学生','student')

--初始化角色授权
select * from RoleAuthorizes
insert into RoleAuthorizes values
('暂无',4,1),('暂无',4,2),('暂无',4,3),('暂无',4,4),('暂无',4,5),('暂无',4,6),('暂无',4,7),('暂无',4,8),('暂无',4,9),('暂无',4,10),
('暂无',4,11),('暂无',4,12),('暂无',4,13),('暂无',4,14),('暂无',4,15),('暂无',4,16),('暂无',4,17),('暂无',4,18),('暂无',4,19),('暂无',4,20),
('暂无',4,21),('暂无',4,22),('暂无',4,23),('暂无',4,24),('暂无',4,25),('暂无',4,26),('暂无',4,27),('暂无',4,28)

--初始化菜单
select * from Menus
insert into Menus(Remarks,Title,Enabled,PathUrl) values ('暂无','首页',1,'/Home/Index'),('暂无','关于',1,'/Home/AboutMe')

--初始化用户
select * from Users
insert into Users (Remarks,Account,Pwd,[Name],Gender,Age,Tel,CreateDate,UserType) values('暂无','sysadmin','a1234567','吴嘉',0,38,'18673968186',getdate(),'admin')

--初始化用户角色
select * from UserRoles
insert into UserRoles(Remarks,UserInfomationID,RoleInfomationID) values('暂无',2,4)
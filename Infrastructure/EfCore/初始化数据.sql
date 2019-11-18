--初始化菜单
select * from Menus
insert into Menus 
	(Remarks,ParentId,MenuType,Title,Controller,[Action])
values
	('暂无',0,20,'首页','Home','Index'),
	('暂无',0,21,'系统管理','Home','Index'),
	('暂无',0,21,'班级管理','Class','Index'),
	('暂无',0,21,'教师管理','Teacher','Index'),
	('暂无',0,21,'学生管理','Student','Index'),
	('暂无',0,21,'考试管理','Examination','Index'),
	('暂无',0,21,'试卷管理','Answer','Index'),
	('暂无',0,21,'题库管理','Question','Index')

--初始化角色
select * from Roles
insert into Roles(Remarks,[Name],Code) values('暂无','管理员','admin'),('暂无','教师','teacher'),('暂无','学生','student')

--初始化角色菜单
select * from RoleMenus
insert into RoleMenus(Remarks,RoleInfomationID,MenuInfomationID) 
values ('暂无',1,1),('暂无',1,2),('暂无',1,3),('暂无',1,4),('暂无',1,5),('暂无',1,6),('暂无',1,7),('暂无',1,8),--admin
		('暂无',2,1),('暂无',2,3),('暂无',2,5),('暂无',2,6),('暂无',2,7),('暂无',2,8),--teacher
		('暂无',3,1),('暂无',1,6)--student

--初始化用户
select * from Users
insert into Users (Remarks,Account,Pwd,[Name],Gender,Age,Tel,CreateDate,UserType) 
values('暂无','sysadmin','a1234567','吴嘉',0,38,'18673968186',getdate(),'admin')

--初始化用户角色
select * from UserRoles
insert into UserRoles(Remarks,UserInfomationID,RoleInfomationID) values('暂无',1,1)
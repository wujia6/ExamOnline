
--1.修改数据库为单用户模式
alter database ExamDb set single_user with rollback  immediate ; 
--2.修改排序规则
alter database ExamDb collate Chinese_PRC_CI_AS ; 
--3.重新设置为多用户模式
alter database ExamDb  set multi_user; 
go
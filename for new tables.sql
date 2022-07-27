
Drop table client_tutorial

USE codeDB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create table client_tutorial(

 id  INT            IDENTITY (1, 1) PRIMARY KEY,
 client_id int not NULL ,
 tutorial_id int default NULL 

 CONSTRAINT FK_client_client_id FOREIGN KEY (client_id)  REFERENCES client(client_id)

)
GO
Select *  from client_tutorial

Insert into client_tutorial (client_id,tutorial_id)
VALUES('4','1')

Select*from client



Create table tutorial_comments(

 id  INT            IDENTITY (1, 1) PRIMARY KEY,
 client_id int default NULL ,
 tutorial_id int default NULL,
 tutorial_comment nvarchar(1500),
 tutorial_comment_timestamp DATETIME,

 CONSTRAINT FK_tutorial_comments_tutorial_id FOREIGN KEY (tutorial_id)  REFERENCES tutorial(tutorial_id)

);
GO

Insert into tutorial_comments(client_id,tutorial_id,tutorial_comment,tutorial_comment_timestamp
)
Values ('4','1','wow Anmol Singh liked this tutorial!!1','09/16/2010 05:00:00')

select * from tutorial_comments

drop table tutorial_comments
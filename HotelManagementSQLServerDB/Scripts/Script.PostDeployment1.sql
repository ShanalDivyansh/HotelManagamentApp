﻿/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

if not exists (select 1 from dbo.RoomType)
begin 
    insert into dbo.RoomType(Title,Description,Price)
    values ('King size bed', 'A room with a window and a king size bed',100),
     ('Two queen size beds', 'A room with a window and two queen size beds',125),
     ('Executive Suite', 'A large room with an ocean view , two rooms and each with a king size bed and windows',220)

end

if not exists (select 1 from dbo.Rooms)
begin 
    declare @roomId1 int;
    declare @roomId2 int;
    declare @roomId3 int;

    select @roomId1 = Id from dbo.RoomType where Title = 'King size bed';
    select @roomId2 = Id from dbo.RoomType where Title = 'Two queen size beds';
    select @roomId3 = Id from dbo.RoomType where Title = 'Executive Suite';

    insert into dbo.Rooms (RoomNumber,RoomTypeID)
    values ('101',@roomId1),
    ('102',@roomId1),
    ('103',@roomId1),
    ('104',@roomId1),
    ('105',@roomId1),
    ('201',@roomId2),
    ('202',@roomId2),
    ('203',@roomId2),
    ('301',@roomId3)
end 
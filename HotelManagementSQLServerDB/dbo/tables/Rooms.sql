CREATE TABLE [dbo].[Rooms]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RoomNumber] VARCHAR(10) NOT NULL, 
    [RoomTypeID] INT NOT NULL, 
    CONSTRAINT [FK_Rooms_RoomType] FOREIGN KEY (RoomTypeID) REFERENCES [RoomType](Id)
)

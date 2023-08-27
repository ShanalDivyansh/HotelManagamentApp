CREATE TABLE [dbo].[Bookings]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RoomsId] INT NOT NULL, 
    [GuestsId] INT NOT NULL, 
    [StartDate] DATETIME2 NOT NULL, 
    [EndDate] DATETIME2 NOT NULL, 
    [CheckedIn] BIT NOT NULL DEFAULT 0, 
    [TotalCost] MONEY NOT NULL, 
    CONSTRAINT [FK_Bookings_Rooms] FOREIGN KEY (RoomsId) REFERENCES Rooms(Id), 
    CONSTRAINT [FK_Bookings_Guests] FOREIGN KEY (GuestsId) REFERENCES Guests(Id)
)

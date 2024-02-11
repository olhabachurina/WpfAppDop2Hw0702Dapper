CREATE TABLE Puzzles (
    PuzzleID INT PRIMARY KEY,
    Text NVARCHAR(MAX) NOT NULL,
    Answer NVARCHAR(MAX) NOT NULL,
    DifficultyLevel INT
);
INSERT INTO Puzzles (PuzzleID, Text, Answer, DifficultyLevel)
VALUES
    (1, 'Что это такое: круглое, с дыркой в середине, и называется как у моряков?', 'Бублик', 2),
    (2, 'Что происходит дважды в неделю, а один раз в году?', 'Буква "е"', 3);
    CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL,
    ContactInfo NVARCHAR(255)
);


INSERT INTO Users (UserID, Username, ContactInfo)
VALUES
    (1, 'user1', 'user1@example.com'),
    (2, 'user2', 'user2@example.com');


CREATE TABLE SolvedPuzzles (
    SolvedPuzzleID INT PRIMARY KEY,
    UserID INT,
    PuzzleID INT,
    SolvedOn DATETIME,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (PuzzleID) REFERENCES Puzzles(PuzzleID)
);


INSERT INTO SolvedPuzzles (SolvedPuzzleID, UserID, PuzzleID, SolvedOn)
VALUES
    (1, 1, 1, '2024-02-10 08:30:00'),
    (2, 2, 3, '2024-02-11 10:15:00');
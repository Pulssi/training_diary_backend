DROP TABLE IF EXISTS "Weight", "Meal", "GymSet", "GymMove", "Person";

CREATE TABLE GymMove (
	IdGymMove int IDENTITY(1,1) PRIMARY KEY,
	MoveName varchar(100) NOT NULL,
	MoveDescription varchar(255)
);

CREATE TABLE Person (
	IdPerson int IDENTITY(1,1) PRIMARY KEY,
	UserName varchar(25) NOT NULL,
	Email varchar(50) NOT NULL
);

CREATE TABLE GymSet (
	IdGymSet int IDENTITY(1,1) PRIMARY KEY,
	IdGymMove int FOREIGN KEY REFERENCES GymMove(IdGymMove) NOT NULL,
	IdPerson int FOREIGN KEY REFERENCES Person(IdPerson) NOT NULL,
	Repetitions int NOT NULL,
	SetWeight float NOT NULL,
	Timestamp datetime NOT NULL
);

CREATE TABLE Weight (
	IdWeight int IDENTITY(1,1) PRIMARY KEY,
	IdPerson int FOREIGN KEY REFERENCES Person(IdPerson) NOT NULL,
	Amount float NOT NULL,
	Timestamp datetime NOT NULL
);

CREATE TABLE Meal (
	IdMeal int IDENTITY(1,1) PRIMARY KEY,
	IdPerson int FOREIGN KEY REFERENCES Person(IdPerson) NOT NULL,
	MealName varchar(100) NOT NULL,
	MealDescription varchar(255),
	Calories float NOT NULL,
	Carbs float,
	Fats float,
	Proteins float,
	Timestamp datetime NOT NULL
);

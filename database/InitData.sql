INSERT INTO Person 
VALUES
	('TestUserOne', 'testuserone@gmail.com'),
	('TestUserTwo', 'testusertwo@gmail.com'),
	('TestUserThree', 'testuserthree@gmail.com'),
	('TestUserFour', 'testuserfour@gmail.com');

INSERT INTO Meal 
VALUES
	(1, 'Breakfast', NULL, 324, null, null, null, GETDATE()),
	(2, 'Breakfast', NULL, 224, null, null, null, GETDATE()),
	(3, 'Breakfast', NULL, 124, null, null, null, GETDATE()),
	(4, 'Breakfast', NULL, 235, null, null, null, GETDATE());

INSERT INTO Weight
VALUES
	(1, 84, GETDATE()),
	(2, 94, GETDATE()),
	(3, 83, GETDATE()),
	(4, 88, GETDATE());

INSERT INTO GymMove
VALUES
	('Bench Press', 'Normal bench press with barbell'),
	('Squat', 'Normal squat with barbell behind the head on neck/upper back'),
	('Deadlift', 'Normal deadlift from the ground'),
	('Shoulder Press', 'Normal shoulder press with a barbell');

INSERT INTO GymSet
VALUES
	(1, 1, 6, 60, GETDATE()),
	(1, 1, 6, 70, GETDATE()),
	(1, 1, 6, 80, GETDATE()),
	(1, 1, 4, 90, GETDATE()),
	(2, 2, 6, 80, GETDATE()),
	(2, 2, 6, 100, GETDATE()),
	(2, 2, 2, 120, GETDATE()),
	(3, 3, 5, 160, GETDATE()),
	(4, 4, 6, 60, GETDATE());
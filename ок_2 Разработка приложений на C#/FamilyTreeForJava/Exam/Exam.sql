-- Создание таблицы "animals"
DROP TABLE IF EXISTS animals;
CREATE TABLE animals (
 id SERIAL PRIMARY KEY,
 type_animal VARCHAR(10)
);

INSERT INTO animals (type_animal)
VALUES
('dog'),
('cat'),
('hamster'),
('horse'),
('camel'),
('donkey');

-- Создание таблицы "pets"
DROP TABLE IF EXISTS pets;
CREATE TABLE pets (
 id SERIAL PRIMARY KEY,
 name VARCHAR(15),
 birthday DATE,
 commands VARCHAR(255),
 type_id BIGINT UNSIGNED,
 FOREIGN KEY (type_id) REFERENCES animals (id) ON DELETE CASCADE ON UPDATE CASCADE
);

INSERT INTO pets (name, birthday, commands, type_id)
VALUES
('Fido', '2020-01-01', 'sit, stay, fetch', 1),
('Whiskers', '2019-05-15', 'sit, pounce', 2),
('Hammy', '2021-03-10', 'roll, hide', 3),
('Buddy', '2018-12-10', 'sit, paw, bark', 1),
('Smudge', '2020-02-20', 'sit, pounce, scratch', 2),
('Peanut', '2021-08-01', 'roll, spin', 3),
('Bella', '2019-11-11', 'sit, pounce, scratch', 1),
('Oliver', '2020-06-30', 'sit, pounce, scratch', 2);

-- Создание таблицы "pack_animals"
DROP TABLE IF EXISTS pack_animals;
CREATE TABLE pack_animals (
 id SERIAL PRIMARY KEY,
 name VARCHAR(15),
 birthday DATE,
 commands VARCHAR(255),
 type_id BIGINT UNSIGNED,
 FOREIGN KEY (type_id) REFERENCES animals (id) ON DELETE CASCADE ON UPDATE CASCADE
);

INSERT INTO pack_animals (name, birthday, commands, type_id)
VALUES
('Thunder', '2015-07-21', 'trot, canter, gallop', 4),
('Sandy', '2016-11-03', 'walk, carry load', 5),
('Eeyore', '2017-09-18', 'walk, carry load, bray', 6),
('Storm', '2014-05-05', 'trot, canter', 4),
('Dune', '2018-12-12', 'walk, sit', 5),
('Burro', '2019-01-23', 'walk, bray, kick', 6),
('Blaze', '2016-02-29', 'trot, jump, gallop', 4),
('Sahara', '2015-08-14', 'walk, run', 5);

-- Выбор данных о верблюдах, объединенные с лошадьми и ослами
SELECT * FROM pack_animals
JOIN animals ON pack_animals.type_id = animals.id
WHERE type_id = 4 OR type_id = 6;

SELECT *, (SELECT type_animal FROM animals WHERE type_id = animals.id) as `type_animal`
FROM pack_animals
WHERE type_id = 4 OR type_id = 6;

-- Создание новое таблицы для животных в возрасте от 1 до 3 лет
DROP TABLE IF EXISTS young_animals;
CREATE TEMPORARY TABLE young_animals
SELECT name, pack_animals.birthday as birthday, TIMESTAMPDIFF(YEAR, birthday, NOW()) as year, ROUND(TIMESTAMPDIFF(MONTH, birthday, NOW())/12) as month FROM pack_animals
JOIN animals ON pack_animals.type_id = animals.id
WHERE TIMESTAMPDIFF(YEAR, birthday, NOW()) BETWEEN 2 AND 5;

-- Создание временной таблицы, объединенная с исходными таблицами
SELECT name, birthday FROM young_animals
UNION ALL
SELECT name, birthday FROM pack_animals
UNION ALL
SELECT name, birthday FROM pets;
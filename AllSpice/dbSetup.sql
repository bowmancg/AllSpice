-- Active: 1682460182546@@SG-codeworks-7498-mysql-master.servers.mongodirector.com@3306@sandbox
CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    recipes(
        id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
        title VARCHAR(50) NOT NULL,
        instructions VARCHAR(255) NOT NULL,
        img VARCHAR(255) NOT NULL,
        category VARCHAR(50) NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8mb4 COMMENT '';

DELETE FROM accounts WHERE id = '';

INSERT INTO
    recipes (
        title,
        instructions,
        img,
        category,
        creatorId
    )
VALUES (
        'Pancetta Arrabiata',
        'A spicy, creamy dish with chicken, penne, and pancetta.',
        'https://imgs.search.brave.com/K8Iq9oUlMYWUIg3aTJeuOBq1lpVoYWDct5WWoVhIaM8/rs:fit:1024:1024:1/g:ce/aHR0cHM6Ly9pMC53/cC5jb20vZWFzeWZh/bWlseXJlY2lwZXMu/Y29tL3dwLWNvbnRl/bnQvdXBsb2Fkcy8y/MDIxLzA0L0l0YWxp/YW4tQ2hpY2tlbi1Q/YXN0YS1SZWNpcGUt/MTAyNHgxMDI0Lmpw/Zw',
        'Italian',
        '64498cc78b77a7e9c3c3441f'
    );

SELECT
    rec.id,
    rec.title,
    creator.name
FROM recipes rec
    JOIN accounts creator ON creator.id = rec.creatorId
WHERE rec.category = 'Italian';

SELECT rec.*, creator.*
FROM recipes rec
    JOIN accounts creator ON creator.id = rec.creatorId;

CREATE TABLE
    ingredients(
        id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
        name VARCHAR(50) NOT NULL,
        quantity VARCHAR(50) NOT NULL,
        recipeId INT NOT NULL,
        FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
    ) default charset utf8mb4 COMMENT '';

INSERT INTO
    ingredients (name, quantity, recipeId)
VALUES ('chicken', '20 oz.', 1);

SELECT
    ing.*,
    rec.*
FROM
    recipes rec
    JOIN ingredients ing ON ing.recipeId = rec.id
    WHERE ing.recipeId = recipeId;

ALTER TABLE ingredients
ADD
COLUMN createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
ADD
COLUMN updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP;

CREATE TABLE
    favorites(
        id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
        accountId VARCHAR(255) NOT NULL,
        recipeId INT NOT NULL,
        FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
        FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
    ) default charset utf8mb4 COMMENT '';

INSERT INTO
    favorites (accountId, recipeId)
VALUES ('64498cc78b77a7e9c3c3441f', 1);

SELECT
fav.*,
fav.id favoriteId
FROM favorites fav;

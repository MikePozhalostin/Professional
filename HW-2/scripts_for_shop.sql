-- Добавление нового продукта
INSERT INTO shop."Products"("ProductID", "ProductName", "Description", "Price", "QuantityInStock")
VALUES (1, 'Кроссовки', 'Кроссовки для бега', '2500', '10');

-- Обновление цены продукта
UPDATE shop."Products" SET "Price" = 3500
WHERE "ProductID" = 1;


-- Заполнение данных для подсчётов

-- Продукты
INSERT INTO shop."Products"("ProductID", "ProductName", "Description", "Price", "QuantityInStock")
VALUES (2, 'Джемпер', 'Джемпер осенний', '7500', '10');

INSERT INTO shop."Products"("ProductID", "ProductName", "Description", "Price", "QuantityInStock")
VALUES (3, 'Штаны', 'Штаны осенние', '5000', '10');

INSERT INTO shop."Products"("ProductID", "ProductName", "Description", "Price", "QuantityInStock")
VALUES (4, 'Шнурки', 'Шнурки', '200', '20');

INSERT INTO shop."Products"("ProductID", "ProductName", "Description", "Price", "QuantityInStock")
VALUES (5, 'Напульсник', 'Напульсник', '500', '5');

INSERT INTO shop."Products"("ProductID", "ProductName", "Description", "Price", "QuantityInStock")
VALUES (6, 'Шапка', 'Шапка', '1000', '10');

INSERT INTO shop."Products"("ProductID", "ProductName", "Description", "Price", "QuantityInStock")
VALUES (7, 'Кепка', 'Кепка', '1200', '3');

-- Покупатель
INSERT INTO shop."Users"("UserID", "UserName", "RegistrationDate")
VALUES (21, 'Константин', CURRENT_DATE);

-- Заказы
INSERT INTO shop."Orders"("OrderID", "UserID", "OrderDate", "Status")
VALUES (1, 21, CURRENT_DATE, 'DONE');

INSERT INTO shop."Orders"("OrderID", "UserID", "OrderDate", "Status")
VALUES (2, 21, CURRENT_DATE, 'DONE');

INSERT INTO shop."OrderDetails"("OrderDetailID", "OrderID", "ProductID", "Quantity", "TotalCoast")
VALUES (1, 1, 1, 2, 5000);

INSERT INTO shop."OrderDetails"("OrderDetailID", "OrderID", "ProductID", "Quantity", "TotalCoast")
VALUES (2, 2, 2, 1, 7500);

--

-- Выбор всех заказов определенного пользователя
SELECT * FROM shop."Orders"
WHERE "UserID" = 21;

-- Расчет общей стоимости заказов пользователя
SELECT SUM(det."TotalCoast")
FROM shop."OrderDetails" as det
INNER JOIN shop."Orders" as ord on ord."OrderID" = det."OrderID"
WHERE ord."UserID" = 21;

-- Подсчёт товаров на складе
SELECT SUM("QuantityInStock") FROM shop."Products";

-- Получение 5 самых дорогих товаров
SELECT "ProductName", "Price"
FROM shop."Products"
ORDER BY "Price" DESC
LIMIT 5;

-- Список товаров с низким запасом
SELECT * FROM shop."Products"
WHERE "QuantityInStock" < 5;

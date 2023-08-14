# Mindbox.FigureCalculator

# Задание 1:
### Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам. 

### *Дополнительно к работоспособности оценим:*
* Юнит-тесты
* Легкость добавления других фигур
* Вычисление площади фигуры без знания типа фигуры в compile-time
* Проверку на то, является ли треугольник прямоугольным
---

# Задание 2:
В базе данных MS SQL Server есть продукты и категории. 
Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. 
Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». 
Если у продукта нет категорий, то его имя все равно должно выводиться.

## Решение
~~~~sql
SELECT p.Name as 'Product name', c.Name as 'Category name'
FROM ProductsCategories as pc
JOIN Categories as c
On c.Id = pc.CategoryId
RIGHT JOIN Products as p
ON p.Id = pc.ProductId
~~~~
## Описание
Исходя из задания понятно, что используется связь многие-ко-многим, то есть нужна таблица для связи.
Итого у нас 3 таблицы:
### *Products*
|  Id  | Name |
| ---- |:----:|

### *Categories*
|  Id  | Name |
| ---- |:----:|

### *ProductsCategories*
|  Id  |  ProductId  |  CategoryId  |
| ---- |:-----------:| ------------:|

То есть нам нужно содержание таблицы связи, но с именами продуктов и категорий.  
Делаем Join таблиц, и обращаем внимание на условие:
> **"Если у продукта нет категорий, то его имя все равно должно выводиться."**

Это значит, что нужно использовать RIGHT JOIN для таблицы Products.
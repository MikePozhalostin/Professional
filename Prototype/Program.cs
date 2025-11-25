using Prototype.Models;

// Оригинальный объект машина 
var originalCar = new CarWithModel("d112fg", 1993, 100, "Japan", "Toyota");

// Первое клонирование
var cloneCar = originalCar.MyClone();

// Изменение всех параметров, кроме года выпуска
cloneCar.Number = "a111ff";
cloneCar.Mileage = 1111111;
cloneCar.Model = "Dodge";
cloneCar.Contry = "America";

// Второе клонирование
var americanClone = (CarWithModel)cloneCar.Clone();
// Изменение года производства
americanClone.Year = 1999;

Console.WriteLine($"Original Japan car: {originalCar}");
Console.WriteLine($"American clone car: {cloneCar}");
Console.WriteLine($"American clone car with change year: {americanClone}");

// IMyCloneable<T>
// Преимущества:
// 1. Возвращает объект конкретного типа, без приведения.
// 2. Можно добавлять собственные параметры и логику.
// Недостатки:
// Дополнительная реализация в каждом классе.

// ICloneable
// Преимущества:
// 1. Позволяет использовать полиморфизм: переменная типа ICloneable может хранить любой клонируемый объект.
// Недостатки
// 1. Возвращает object, что приводит к необходимости приведения типов.
// 2. Не определяет, какое копирование выполнять — глубокое или поверхностное.
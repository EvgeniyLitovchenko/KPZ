# Принципи програмування в проєкті

## SOLID
### S — Single Responsibility Principle (SRP)
+ Клас [Animal](./Clases/Animal.cs) відповідає за зберігання даних про тварину (назва, вид, вік, тип дієти) та її поведінку.
+ Клас [Enclosure](./Clases/Enclosure.cs) відповідає за управління вольєром і списком тварин у ньому.
+ Клас [ZooInventory](./Clases/ZooInventory.cs) відповідає за інвентаризацію, об’єднуючи тварин, вольєри, працівників і корм
+ Клас [Food](./Clases/Food.cs) відповідає лише за управління типом і кількістю корму.

### O — Open/Closed Principle (OCP)
+ Абстрактний клас [Animal](./Clases/Animal.cs) дозволяє додавати нові види тварин (наприклад, [Lion](./Clases/Lion.cs), [Elephant](./Clases/Elephant.cs)) без зміни його коду.

### L - Liskov Substitution Principle (LSP)
+ Похідні класи [Lion](./Clases/Lion.cs) і [Elephant](./Clases/Elephant.cs) реалізують [IAnimal](./Clases/Interfaces/IAnimal.cs)  і можуть використовуватися замість базового типу [Animal](./Clases/Animal.cs)
+ У методі [AddAnimal](/Clases/Enclosure.cs#L16-L24) класу [Enclosure](./Clases/Enclosure.cs) використовується інтерфейс [IAnimal](./Clases/Interfaces/IAnimal.cs), що дозволяє працювати з будь-якою твариною

### D — Dependency Inversion Principle (DIP)
+ Клас [ZooInventory](./Clases/ZooInventory.cs) залежить від інтерфейсів, а не від конкретних класів.
+ Клас [Enclosure](./Clases/Enclosure.cs) також залежить від інтерфейсу [IAnimal](./Clases/Interfaces/IAnimal.cs), а не від конкретних реалізацій

## YAGNI (You Ain’t Gonna Need It)
+ У коді немає зайвих методів чи класів, які не виконують реальної функціональності.

## DRY (Don't Repeat Yourself)
+ У методі [AddFood](/Clases/ZooInventory.cs#L16-L27) класу [ZooInventory](./Clases/ZooInventory.cs) логіка додавання корму уникає дублювання. Якщо корм певного типу вже існує, його кількість оновлюється через виклик [UseFood(-food.Quantity)](/Clases/ZooInventory.cs#L42-L45), замість створення нового об’єкта чи дублювання логіки

## Composition Over Inheritance
+ Клас [Enclosure](./Clases/Enclosure.cs) використовує композицію, містячи список [IAnimal](./Clases/Interfaces/IAnimal.cs), замість того, щоб успадковувати від якогось класу, пов’язаного з тваринами.
+ Клас [ZooInventory](./Clases/ZooInventory.cs) також використовує композицію, об’єднуючи списки [IAnimal](./Clases/Interfaces/IAnimal.cs), [IEnclosure](./Clases/Interfaces/IEnclosure.cs), [IEmployee](./Clases/Interfaces/IEmployee.cs) і [IFood](./Clases/Interfaces/IFood.cs).

## Fail Fast
+ У методі [AddAnimal](/Clases/Enclosure.cs#L18-L21) класу [Enclosure](./Clases/Enclosure.cs) перевіряється місткість вольєра на початку, і якщо вона перевищена, метод повертає false.
+ У методі [AddAnimal](/Clases/ZooInventory.cs#L23-L26) класу [ZooInventory](./Clases/ZooInventory.cs) помилка обробляється одразу, виводячи повідомлення.
+ У методі [UseFood](/Clases/Food.cs#L12-L16) класу [Food](./Clases/Food.cs) перевіряється, чи достатньо корму, перед зміною кількості.
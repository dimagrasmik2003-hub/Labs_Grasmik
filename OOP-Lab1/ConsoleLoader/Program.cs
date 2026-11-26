using Model;

//Создание двух списков персон
PersonList firstList = new PersonList();
PersonList secondList = new PersonList();

//Создание трех персон и добавление их в первый список
Person firstPerson1 = new Person("Иван", "Иванов", 25, Gender.Male);
Person firstPerson2 = new Person("Анна", "Петрова", 22, Gender.Female);
Person firstPerson3 = new Person("Сергей", "Сидоров", 30, Gender.Male);

//Добавление персон в первый список
firstList.AddPerson(firstPerson1);
firstList.AddPerson(firstPerson2);
firstList.AddPerson(firstPerson3);

//Создание трех персон и добавление их во второй список
Person secondPerson1 = new Person("Мария", "Герасимова", 28, Gender.Female);
Person secondPerson2 = new Person("Дмитрий", "Кондратьев", 35, Gender.Male);
Person secondPerson3 = new Person("Елена", "Соловьёва", 26, Gender.Female);

//Добавление персон во второй список
secondList.AddPerson(secondPerson1);
secondList.AddPerson(secondPerson2);
secondList.AddPerson(secondPerson3);

// Вывод в консоль содержимого первого списка персон
PrintPersonList(firstList, "Первый список персон:");

// Вывод в консоль содержимого первого списка персон
PrintPersonList(secondList, "Второй список персон:");

//Вывод в консоль сообщения
WaitForKeyPress();

//Создание новой персоны и добавление её в первый список
Console.WriteLine();
Person newPerson = new Person(
	"Елена", "Морозова", 27, Gender.Female);
firstList.AddPerson(newPerson);

// Вывод в консоль содержимого первого списка персон
PrintPersonList(firstList, "Первый список персон:");

//Вывод в консоль сообщения
WaitForKeyPress();

//Поиск в первом списке второй персоны и добавление её в конец второго списка
Person copiedPerson = firstList.GetPersonAt(1);
secondList.AddPerson(copiedPerson);

//Проверка, что один и тот же объект находится в обоих списках
Console.WriteLine();
Console.WriteLine(
	$"Общий объект: {copiedPerson.FirstName} {copiedPerson.Surname}");
Console.WriteLine(
	"Один и тот же объект находится в обоих списках: " +
	object.ReferenceEquals(firstList.GetPersonAt(1), secondList.GetPersonAt(3)));

//Вывод в консоль сообщения
WaitForKeyPress();

//Удаление второй персоны из первого списка
Person delPerson = firstList.GetPersonAt(1);
firstList.RemovePerson(delPerson);

//Проверка, что удаленный объект из первого списка не был удален из второго списка
Console.WriteLine();
Console.WriteLine(
	$"Персона, удаленная из первого списка: " +
	$"{copiedPerson.FirstName} {copiedPerson.Surname}");
Console.WriteLine(
	"Количество персон в первом списке: " +
	firstList.Count);
Console.WriteLine(
	"Количество персон во втором списке: " +
	secondList.Count);
Console.WriteLine(
	$"Объект в конце второго списка: " +
	$"{secondList.GetPersonAt(3).FirstName} {secondList.GetPersonAt(3).Surname}");
Console.WriteLine(
	"Объект из первого списка не был удален из второго списка: " +
	object.ReferenceEquals(copiedPerson, secondList.GetPersonAt(3)));

//Вывод в консоль сообщения
WaitForKeyPress();

//Очистка второго списка
secondList.Clear();

//Проверка, что один и тот же объект находится в обоих списках
Console.WriteLine();
Console.WriteLine("Второй список персон:");
if (secondList.Count == 0)
{
	Console.WriteLine("Персоны не добавлены. Второй список пуст");
}

// Демонстрация чтения и вывода персоны 
Console.WriteLine();
Console.WriteLine("Демонстрация работы методов класса Person:");
Console.WriteLine();

Person inputPerson = new Person(
	"Тест", "Тестов", 20, Gender.Male);

// Чтение данных персоны с клавиатуры
inputPerson.ReadFromConsole();

// Вывод введённых данных
Console.WriteLine();
Console.WriteLine("Введённые данные персоны:");
inputPerson.Print();

// Ожидание завершения программы
WaitForKeyPress();

// Создание случайной персоны
Console.WriteLine();
Console.WriteLine("Создание случайной персоны:");
Person randomPerson = Person.GetRandomPerson();

// Вывод случайно созданной персоны
randomPerson.Print();

// Завершение программы
Console.WriteLine();
Console.WriteLine("Нажмите Enter для завершения программы.");
Console.ReadLine();

Console.ReadLine();

/// <summary>
/// Выводит в консоль содержимое списка персон с указанным заголовком
/// </summary>
/// <param name="list">Список персон для вывода</param>
/// <param name="header">Заголовок, отображаемый перед списком</param>
static void PrintPersonList(PersonList list, string header)
{
	Console.WriteLine(header);
	for (int i = 0; i < list.Count; i++)
	{
		Person person = list.GetPersonAt(i);
		Console.WriteLine(
			$"Имя: {person.FirstName}, " +
			$"Фамилия: {person.Surname}, " +
			$"Возраст: {person.Age}, " +
			$"Пол: {person.Gender}");
	}
}

/// <summary>
/// Выводит сообщение и ждёт нажатия любой клавиши для продолжения
/// </summary>
static void WaitForKeyPress()
{
	Console.WriteLine();
	Console.WriteLine("Нажмите любую клавишу для продолжения");
	Console.ReadKey();
	Console.WriteLine();
}

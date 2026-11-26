using Model;

PersonList firstList = new PersonList();
PersonList secondList = new PersonList();

Person firstPerson1 = new Person("Иван", "Иванов", 25, Gender.Male);
Person firstPerson2 = new Person("Анна", "Петрова", 22, Gender.Female);
Person firstPerson3 = new Person("Сергей", "Сидоров", 30, Gender.Male);

firstList.AddPerson(firstPerson1);
firstList.AddPerson(firstPerson2);
firstList.AddPerson(firstPerson3);

Person secondPerson1 = new Person("Мария", "Герасимова", 28, Gender.Female);
Person secondPerson2 = new Person("Дмитрий", "Кондратьев", 35, Gender.Male);
Person secondPerson3 = new Person("Елена", "Соловьёва", 26, Gender.Female);

secondList.AddPerson(secondPerson1);
secondList.AddPerson(secondPerson2);
secondList.AddPerson(secondPerson3);

PrintPersonList(firstList, "Первый список персон:");
PrintPersonList(secondList, "Второй список персон:");

WaitForKeyPress();

Console.WriteLine();
Person newPerson = new Person(
	"Елена", "Морозова", 27, Gender.Female);
firstList.AddPerson(newPerson);
PrintPersonList(firstList, "Первый список персон:");

WaitForKeyPress();

Person copiedPerson = firstList.GetPersonAt(1);
secondList.AddPerson(copiedPerson);

Console.WriteLine();
Console.WriteLine(
	$"Общий объект: {copiedPerson.FirstName} {copiedPerson.Surname}");
Console.WriteLine(
	"Один и тот же объект находится в обоих списках: " +
	object.ReferenceEquals(firstList.GetPersonAt(1), secondList.GetPersonAt(3)));

WaitForKeyPress();

Person delPerson = firstList.GetPersonAt(1);
firstList.RemovePerson(delPerson);

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

WaitForKeyPress();

secondList.Clear();
Console.WriteLine();
Console.WriteLine("Второй список персон:");
if (secondList.Count == 0)
{
	Console.WriteLine("Персоны не добавлены. Второй список пуст");
}

Console.WriteLine();
Console.WriteLine("Демонстрация работы методов класса Person:");

Person inputPerson = new Person(
	"Тест", "Тестов", 20, Gender.Male);

ReadPersonFromConsole(inputPerson);
Console.WriteLine();
Console.WriteLine("Введённые данные персоны:");
PrintPerson(inputPerson);

WaitForKeyPress();

Console.WriteLine();
Console.WriteLine("Создание случайной персоны:");
Person randomPerson = Person.GetRandomPerson();

PrintPerson(randomPerson);

Console.WriteLine();
Console.WriteLine("Нажмите Enter для завершения программы.");
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
		PrintPerson(person);
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

/// <summary>
/// Выводит информацию об одной персоне на экран
/// </summary>
/// <param name="person">Выводимая персона</param>
static void PrintPerson(Person person)
{
	Console.WriteLine(
		$"Имя: {person.FirstName}, " +
		$"Фамилия: {person.Surname}, " +
		$"Возраст: {person.Age}, " +
		$"Пол: {person.Gender}");
}

/// <summary>
/// Считывает данные персоны с клавиатуры
/// </summary>
/// <param name="person">Персона, в которую записываются данные</param>
static void ReadPersonFromConsole(Person person)
{
	Console.Write("Введите имя: ");
	person.FirstName = Console.ReadLine() ?? string.Empty;
	Console.Write("Введите фамилию: ");
	person.Surname = Console.ReadLine() ?? string.Empty;
	Console.Write("Введите возраст: ");
	person.Age = int.Parse(Console.ReadLine() ?? string.Empty);
	Console.Write("Введите пол (Male/Female): ");
	person.Gender = Enum.Parse<Gender>(Console.ReadLine() ?? string.Empty);
}

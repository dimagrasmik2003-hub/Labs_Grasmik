using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	/// <summary>
	/// Представляет персону с основными сведениями о ней
	/// </summary>
	public class Person
	{
		/// <summary>
		/// Имя персоны
		/// </summary>
		private string _firstName = string.Empty;

		/// <summary>
		/// Фамилия персоны
		/// </summary>
		private string _surname = string.Empty;

		/// <summary>
		/// Возраст персоны
		/// </summary>
		private int _age;

		/// <summary>
		/// Возвращает или задает имя персоны
		/// </summary>
		public string FirstName
		{
			get { return _firstName; }
			//TODO: validation
			set { _firstName = value; }
		}

		/// <summary>
		/// Возвращает или задает фамилию персоны
		/// </summary>
		public string Surname
		{
			get { return _surname; }
			//TODO: validation
			set { _surname = value; }
		}

		/// <summary>
		/// Возвращает или задает возраст персоны
		/// </summary>
		public int Age
		{
			get { return _age; }
			set
			{
				//TODO: validation

				if (value >= 0)
				{
					_age = value;
				}
			}
		}

		/// <summary>
		/// Возвращает или задает пол персоны
		/// </summary>
		public Gender Gender { get; set; }

		/// <summary>
		/// Создаёт персону с заданными данными
		/// </summary>
		/// <param name="firstName">Имя персоны</param>
		/// <param name="surname">Фамилия персоны</param>
		/// <param name="age">Возраст персоны</param>
		/// <param name="gender">Пол персоны</param>
		public Person(string firstName, string surname, int age, Gender gender)
		{
			FirstName = firstName;
			Surname = surname;
			Age = age;
			Gender = gender;
		}

		//TODO: refactor
		/// <summary>
		/// Считывает данные персоны с клавиатуры
		/// </summary>
		public void ReadFromConsole()
		{
			Console.Write("Введите имя: ");
			FirstName = Console.ReadLine() ?? string.Empty;
			Console.Write("Введите фамилию: ");
			Surname = Console.ReadLine() ?? string.Empty;
			Console.Write("Введите возраст: ");
			Age = int.Parse(Console.ReadLine() ?? string.Empty);
			Console.Write("Введите пол (Male/Female): ");
			Gender = Enum.Parse<Gender>(Console.ReadLine() ?? string.Empty);
		}

		//TODO: refactor
		/// <summary>
		/// Выводит информацию о персоне на экран
		/// </summary>
		public void Print()
		{
			Console.WriteLine($"Имя: {FirstName}");
			Console.WriteLine($"Фамилия: {Surname}");
			Console.WriteLine($"Возраст: {Age}");
			Console.WriteLine($"Пол: {Gender}");
		}

		/// <summary>
		/// Минимальный возраст для случайной генерации
		/// </summary>
		private const int MinRandomAge = 0;

		/// <summary>
		/// Максимальный возраст для случайной генерации
		/// </summary>
		private const int MaxRandomAge = 123;

		/// <summary>
		/// Создаёт случайную персону
		/// </summary>
		/// <returns>Случайно созданная персона</returns>
		public static Person GetRandomPerson()
		{
			string[] maleNames = { "Иван", "Сергей", "Дмитрий" };
			string[] femaleNames = { "Анна", "Мария", "Елена" };

			string[] maleSurnames = { "Иванов", "Петров", "Сидоров" };
			string[] femaleSurnames = { "Иванова", "Петрова", "Сидорова" };

			Random random = Random.Shared;

			Gender gender = random.Next(2) == 0
				? Gender.Male
				: Gender.Female;

			string[] names = gender == Gender.Male ? maleNames : femaleNames;
			string[] surnames = gender == Gender.Male ? maleSurnames : femaleSurnames;

			string firstName = names[random.Next(names.Length)];
			string surname = surnames[random.Next(surnames.Length)];

			int age = random.Next(MinRandomAge, MaxRandomAge);

			return new Person(firstName, surname, age, gender);
		}
	}
}

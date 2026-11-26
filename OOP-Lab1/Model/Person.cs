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
		/// //TODO: RSDN
		private string _surName = string.Empty;

		/// <summary>
		/// Возраст персоны
		/// </summary>
		private int _age;

		//TODO: remove
		/// <summary>
		/// Пол персоны
		/// </summary>
		private Gender _gender;

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
		public string SurName
		{
			get { return _surName; }
			//TODO: validation
			set { _surName = value; }
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

		//TODO: refactor
		/// <summary>
		/// Возвращает или задает пол персоны
		/// </summary>
		public Gender Gender
		{
			get { return _gender; }
			set { _gender = value; }
		}

		/// <summary>
		/// Создаёт персону с заданными данными
		/// </summary>
		/// <param name="firstName">Имя персоны</param>
		/// <param name="surName">Фамилия персоны</param>
		/// <param name="age">Возраст персоны</param>
		/// <param name="gender">Пол персоны</param>
		public Person(string firstName, string surName, int age, Gender gender)
		{
			FirstName = firstName;
			SurName = surName;
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
			SurName = Console.ReadLine() ?? string.Empty;
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
			Console.WriteLine($"Фамилия: {SurName}");
			Console.WriteLine($"Возраст: {Age}");
			Console.WriteLine($"Пол: {Gender}");
		}

		/// <summary>
		/// Создаёт случайную персону
		/// </summary>
		/// <returns>Случайно созданная персона</returns>
		public static Person GetRandomPerson()
		{
			string[] maleNames = { "Иван", "Сергей", "Дмитрий" };
			string[] femaleNames = { "Анна", "Мария", "Елена" };

			string[] maleSurNames = { "Иванов", "Петров", "Сидоров" };
			string[] femaleSurNames = { "Иванова", "Петрова", "Сидорова" };

			Random random = Random.Shared;

			Gender gender = random.Next(2) == 0
				? Gender.Male
				: Gender.Female;

			string firstName;
			//TODO: RSDN
			string surName;

			if (gender == Gender.Male)
			{
				firstName = maleNames[random.Next(maleNames.Length)];
				surName = maleSurNames[random.Next(maleSurNames.Length)];
			}
			else
			{
				firstName = femaleNames[random.Next(femaleNames.Length)];
				surName = femaleSurNames[random.Next(femaleSurNames.Length)];
			}

			//TODO: to const
			int age = random.Next(18, 71);

			return new Person(firstName, surName, age, gender);
		}
	}
}

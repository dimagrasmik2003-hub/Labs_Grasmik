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
		private string _surName = string.Empty;

		/// <summary>
		/// Возраст персоны
		/// </summary>
		private int _age;

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
			set { _firstName = value; }
		}

		/// <summary>
		/// Возвращает или задает фамилию персоны
		/// </summary>
		public string SurName
		{
			get { return _surName; }
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
				if (value >= 0)
				{
					_age = value;
				}
			}
		}

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
	}
}

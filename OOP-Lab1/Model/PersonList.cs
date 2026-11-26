using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	/// <summary>
	/// Представляет список персон с динамическим увеличением массива
	/// </summary>
	public class PersonList
	{
		/// <summary>
		/// Начальная вместимость массива персон
		/// </summary>
		private const int DefaultCapacity = 10;

		/// <summary>
		/// Шаг увеличения и уменьшения вместимости массива
		/// </summary>
		private const int ResizeStep = 10;

		/// <summary>
		/// Хранит массив персон
		/// </summary>
		private Person[] _persons;

		/// <summary>
		/// Хранит текущее количество персон в списке
		/// </summary>
		private int _count;

		/// <summary>
		/// Создаёт пустой список с начальной вместимостью 10 элементов
		/// </summary>
		public PersonList()
		{
			_persons = new Person[DefaultCapacity];
			_count = 0;
		}

		/// <summary>
		/// Добавляет персону в конец списка
		/// При необходимости увеличивает вместимость массива на ResizeStep
		/// </summary>
		/// <param name="person">Персона, которую необходимо добавить</param>
		public void AddPerson(Person person)
		{
			if (_count == _persons.Length)
			{
				Person[] personsNew = new Person[_persons.Length + ResizeStep];

				for (int i = 0; i < _count; i++)
				{
					personsNew[i] = _persons[i];
				}

				_persons = personsNew;
			}

			_persons[_count] = person;
			_count++;
		}

		/// <summary>
		/// Удаляет указанную персону из списка
		/// </summary>
		/// <param name="person">Персона, которую необходимо удалить</param>
		public void RemovePerson(Person person)
		{
			int index = GetPersonIndex(person);
			if (index >= 0)
			{
				RemovePersonAt(index);
			}
		}

		/// <summary>
		/// Удаляет персону по указанному индексу
		/// </summary>
		/// <param name="index">Индекс удаляемой персоны</param>
		public void RemovePersonAt(int index)
		{
			if (index < 0 || index >= _count)
			{
				throw new ArgumentOutOfRangeException("index");
			}

			for (int i = index; i < _count - 1; i++)
			{
				_persons[i] = _persons[i + 1];
			}

			_count--;
			_persons[_count] = null;
		}

		/// <summary>
		/// Ищет персону по указанному индексу
		/// </summary>
		/// <param name="index">Индекс разыскиваемой персоны</param>
		/// <returns>Персона по указанному индексу</returns>
		public Person GetPersonAt(int index)
		{
			if (index < 0 || index >= _count)
			{
				throw new ArgumentOutOfRangeException("index");
			}

			return _persons[index];
		}

		/// <summary>
		/// Ищет индекс персоны в списке
		/// </summary>
		/// <param name="person">Персона, индекс которой нужно найти</param>
		/// <returns>Индекс персоны или -1, если персона не найдена</returns>
		public int GetPersonIndex(Person person)
		{
			for (int i = 0; i < _count; i++)
			{
				if (_persons[i] == person)
				{
					return i;
				}
			}

			return -1;
		}

		/// <summary>
		/// Очищает список персон
		/// </summary>
		public void Clear()
		{
			Array.Clear(_persons, 0, _count);
			_count = 0;
		}

		/// <summary>
		/// Возвращает количество персон в списке
		/// </summary>
		public int Count
		{
			get { return _count; }
		}
	}
}

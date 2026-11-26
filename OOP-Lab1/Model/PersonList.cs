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
		//TODO: to array +
		/// <summary>
		/// Начальная вместимость массива персон
		/// </summary>
		private const int _default = 10;

		/// <summary>
		/// Шаг увеличения и уменьшения вместимости массива
		/// </summary>
		private const int _resize = 10;

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
			// Создаёт массив начальной вместимости
			_persons = new Person[_default];
			// Обнуляет счётчик персон
			_count = 0;
		}

		/// <summary>
		/// Добавляет персону в конец списка
		/// При необходимости увеличивает вместимость массива на ResizeStep
		/// </summary>
		/// <param name="person">Персона, которую необходимо добавить</param>
		public void AddPerson(Person person)
		{
			// Проверяет, заполнен ли массив полностью.
			if (_count == _persons.Length)
			{
				// Создаёт новый массив увеличенной вместимости
				Person[] personsNew = new Person[_persons.Length + _resize];

				// Копирует существующие элементы в новый массив
				for (int i = 0; i < _count; i++)
				{
					// Переносит персону из старого массива в новый
					personsNew[i] = _persons[i];
				}

				// Подменяет старый массив новым
				_persons = personsNew;
			}

			// Записывает персону в первую свободную ячейку
			_persons[_count] = person;
			// Увеличивает счётчик персон на единицу
			_count++;
		}

		/// <summary>
		/// Удаляет указанную персону из списка
		/// </summary>
		/// <param name="person">Персона, которую необходимо удалить</param>
		public void RemovePerson(Person person)
		{
			// Находит индекс персоны в массиве
			int index = GetPersonIndex(person);
			// Проверяет, что персона найдена (индекс не отрицательный)
			if (index >= 0)
			{
				// Удаляет персону по найденному индексу
				RemovePersonAt(index);
			}
		}

		/// <summary>
		/// Удаляет персону по указанному индексу
		/// </summary>
		/// <param name="index">Индекс удаляемой персоны</param>
		public void RemovePersonAt(int index)
		{
			// Проверяет, что индекс находится в допустимых границах
			if (index < 0 || index >= _count)
			{
				// Бросает исключение при недопустимом индексе
				throw new ArgumentOutOfRangeException("index");
			}

			// Сдвигает все элементы после удаляемого на одну позицию влево
			for (int i = index; i < _count - 1; i++)
			{
				// Копирует следующий элемент в текущую ячейку
				_persons[i] = _persons[i + 1];
			}

			// Уменьшает счётчик персон на единицу
			_count--;
			// Обнуляет ссылку в освободившейся последней ячейке
			_persons[_count] = null;
		}

		/// <summary>
		/// Ищет персону по указанному индексу
		/// </summary>
		/// <param name="index">Индекс разыскиваемой персоны</param>
		/// <returns>Персона по указанному индексу</returns>
		public Person GetPersonAt(int index)
		{
			// Проверяет, что индекс находится в допустимых границах
			if (index < 0 || index >= _count)
			{
				// Бросает исключение при недопустимом индексе
				throw new ArgumentOutOfRangeException("index");
			}

			// Возвращает персону из массива по указанному индексу
			return _persons[index];
		}

		/// <summary>
		/// Ищет индекс персоны в списке
		/// </summary>
		/// <param name="person">Персона, индекс которой нужно найти</param>
		/// <returns>Индекс персоны или -1, если персона не найдена</returns>
		public int GetPersonIndex(Person person)
		{
			// Перебирает все занятые ячейки массива
			for (int i = 0; i < _count; i++)
			{
				// Проверяет совпадение ссылок на одну и ту же персону
				if (_persons[i] == person)
				{
					// Возвращает найденный индекс
					return i;
				}
			}

			// Возвращает -1, если персона не найдена
			return -1;
		}

		/// <summary>
		/// Очищает список персон
		/// </summary>
		public void Clear()
		{
			// Обнуляет ссылки на персон во всех занятых ячейках массива
			Array.Clear(_persons, 0, _count);
			// Сбрасывает счётчик персон в ноль
			_count = 0;
		}

		/// <summary>
		/// Возвращает количество персон в списке
		/// </summary>
		public int Count
		{
			// Возвращает текущее количество персон
			get { return _count; }
		}
	}
}

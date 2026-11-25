using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	/// <summary>
	/// Представляет список персон
	/// </summary>
	public class PersonList
	{
		/// <summary>
		/// Хранит список персон
		/// </summary>
		private List<Person> _persons = new List<Person>();

		/// <summary>
		/// Добавляем персону в список
		/// </summary>
		/// <param name="person">Добавляемая персона</param>
		public void AddPerson(Person person)
		{
			_persons.Add(person);
		}

		/// <summary>
		/// Удаляем персону из списка
		/// </summary>
		/// <param name="person">Удаляемая персона</param>
		public void RemovePerson(Person person)
		{
			_persons.Remove(person);
		}

		/// <summary>
		/// Удаляет персону по указанному индексу
		/// </summary>
		/// <param name="index">Индекс удаляемой персоны</param>
		public void RemovePersonAt(int index)
		{
			_persons.RemoveAt(index);
		}

		/// <summary>
		/// Ищет персону по указанному индексу
		/// </summary>
		/// <param name="index">Индекс разыскиваемой персоны</param>
		public Person GetPersonAt(int index)
		{
			return _persons[index];
		}

		/// <summary>
		/// Ищет индекс персоны в списке
		/// </summary>
		/// <param name="person">Персона, индекс которой нужно найти</param>
		public int GetPersonIndex(Person person)
		{
			return _persons.IndexOf(person);
		}

		/// <summary>
		/// Очищает список персон
		/// </summary>
		public void Clear()
		{
			_persons.Clear();
		}

		/// <summary>
		/// Возвращает количество персон в списке
		/// </summary>
		public int Count
		{
			get { return _persons.Count; }
		}
	}
}

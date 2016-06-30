using System.Collections;
using System.Collections.Generic;

namespace ToDoApp1
{
	public class NList<T> : IReadOnlyList<T> 
	{
		private readonly List<T> _internalList;

		public NList(List<T> internalList)
		{
			this._internalList = internalList;
		}

		public NList()
		{
			this._internalList = new List<T>();
		}

		public NList(IEnumerable<T> source)
		{
			this._internalList = new List<T>(source);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _internalList.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public NList<T> AddItem(T item)
		{
			_internalList.Add(item);

			return new NList<T>(_internalList);
		}

		public void Add(T item)
		{
			_internalList.Add(item);
		}

		public void Clear()
		{
			this._internalList.Clear();
		}

		public bool Contains(T item)
		{
			return _internalList.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			_internalList.CopyTo(array, arrayIndex);
		}

		public bool Remove(T item)
		{
			return _internalList.Remove(item);
		}

		public int Count => _internalList.Count;

		public bool IsReadOnly => false;

		public int IndexOf(T item)
		{
			throw new System.NotImplementedException();
		}

		public void Insert(int index, T item)
		{
			this._internalList.Insert(index, item);
		}

		public void RemoveAt(int index)
		{
			this._internalList.RemoveAt(index);
		}

		public T this[int index]
		{
			get { return this._internalList[index]; }
			set { this._internalList[index] = value; }
		}

		
	} // class
} // namespace
namespace AutoParkConsole.Classes
{
	class MyQueue<T>
	{
		T[] _Queue;
		int _Capacity;
		int _LastIndex;

		public MyQueue()
		{
			_Capacity = 5;
			_Queue = new T[_Capacity];
			_LastIndex = 0;
		}
		public MyQueue(int capacity)
		{
			_Queue = new T[capacity];
			_Capacity = capacity;
			_LastIndex = 0;
		}

		public MyQueue(T[] queue)
		{
			_Queue = queue;
			_Capacity = _Queue.Length;
			_LastIndex = _Queue.Length - 1;
		}

		void Resize()
		{
			T[] newQueue = null;

			newQueue = new T[_Capacity * 2];
			for (int counter = 0; counter < _Queue.Length; counter++)
			{
				newQueue[counter] = _Queue[counter];
			}

			_Queue = newQueue;
			_Capacity *= 2;
		}

		public void Enqueue(T element)
		{
			if (_Capacity - 1 == _LastIndex)
			{
				Resize();
			}

			_Queue.SetValue(element, _LastIndex);
			_LastIndex++;
		}

		public T Dequeue()
		{
			T elementToDequeue = _Queue[0];
			for (int counter = 1; counter <= _LastIndex; counter++)
			{
				_Queue[counter - 1] = _Queue[counter];
			}

			return elementToDequeue;
		}

		public void Clear()
		{
			_Queue = new T[_Capacity];
		}

		public bool Contains(T element)
		{
			for (int counter = 0; counter < _Queue.Length; counter++)
			{
				if (_Queue[counter].Equals(element))
				{
					return true;
				}
			}

			return false;
		}

		public int Count()
		{
			return _LastIndex;
		}
	}
}

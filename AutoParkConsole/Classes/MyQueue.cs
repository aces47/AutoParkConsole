namespace AutoParkConsole.Classes
{
	internal class MyQueue<T>
	{
		private T[] _queue;
		private int _capacity;
		private int _lastIndex;
		private int _firstIndex;

		public MyQueue()
		{
			_capacity = 5;
			_queue = new T[_capacity];
			_lastIndex = 0;
			_firstIndex = 0;
		}
		public MyQueue(int capacity)
		{
			_queue = new T[capacity];
			_capacity = capacity;
			_lastIndex = 0;
			_firstIndex = 0;
		}

		public MyQueue(T[] queue)
		{
			_queue = queue;
			_capacity = _queue.Length;
			_lastIndex = _queue.Length - 1;
			_firstIndex = 0;
		}

		void Resize()
		{
			T[] newQueue = null;

			newQueue = new T[_capacity * 2];
			for (int counter = 0; counter < _queue.Length; counter++)
			{
				newQueue[counter] = _queue[counter];
			}

			_queue = newQueue;
			_capacity *= 2;
		}

		public void Enqueue(T element)
		{
			if (_capacity - 1 == _lastIndex)
			{
				Resize();
			}

			_queue.SetValue(element, _lastIndex);
			_lastIndex++;
		}

		public T Dequeue()
		{
			if (_firstIndex != _lastIndex)
			{
				T elementToDequeue = _queue[_firstIndex];
				_firstIndex++;

				return elementToDequeue;
			}

			return default;
		}

		public void Clear()
		{
			_queue = new T[_capacity];
			_lastIndex = 0;
			_firstIndex = 0;
		}

		public bool Contains(T element)
		{
			for (int counter = _firstIndex; counter < _lastIndex; counter++)
			{
				if (_queue[counter].Equals(element))
				{
					return true;
				}
			}

			return false;
		}

		public int Count()
		{
			return _lastIndex - _firstIndex;
		}
	}
}

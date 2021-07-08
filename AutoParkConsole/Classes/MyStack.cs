using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
	internal class MyStack<T>
	{
		T[] _stack;
		int _capacity;
		int _lastIndex;

		public MyStack()
		{
			_capacity = 5;
			_stack = new T[_capacity];
			_lastIndex = 0;
		}

		public MyStack(int capacity)
		{
			_capacity = capacity;
			_stack = new T[_capacity];
			_lastIndex = 0;
		}

		public MyStack(T[] stack)
		{
			_stack = stack;
			_capacity = stack.Length;
			_lastIndex = _capacity - 1;
		}

		private void Resize()
		{
			T[] newStack = null;

			newStack = new T[_capacity * 2];
			for (int counter = 0; counter < _stack.Length; counter++)
			{
				newStack[counter] = _stack[counter];
			}

			_stack = newStack;
			_capacity *= 2;

		}
		public void Push(T element)
		{
			if (_capacity - 1 == _lastIndex)
			{
				Resize();
			}
			_stack.SetValue(element, _lastIndex);
			_lastIndex++;
		}

		public T Pop()
		{
			if (_lastIndex > 0)
			{
				T elementToPop = _stack[_lastIndex - 1];
				_stack.SetValue(null, _lastIndex);
				_lastIndex--;

				return elementToPop;
			}

			return default(T);
		}

		public void Clear()
		{
			_stack = new T[_capacity];
			_lastIndex = 0;
		}

		public int Count()
		{
			return _lastIndex;
		}
	}
}

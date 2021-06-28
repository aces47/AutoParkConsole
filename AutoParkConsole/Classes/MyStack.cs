using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
	class MyStack<T>
	{
		T[] _Stack;
		int _Capacity;
		int _LastIndex;

		public MyStack()
		{
			_Capacity = 5;
			_Stack = new T[_Capacity];
			_LastIndex = 0;
		}

		public MyStack(int capacity)
		{
			_Capacity = capacity;
			_Stack = new T[_Capacity];
			_LastIndex = 0;
		}

		public MyStack(T[] stack)
		{
			_Stack = stack;
			_Capacity = stack.Length;
			_LastIndex = _Capacity - 1;
		}

		void Resize()
		{
			T[] newStack = null;

			newStack = new T[_Capacity * 2];
			for (int counter = 0; counter < _Stack.Length; counter++)
			{
				newStack[counter] = _Stack[counter];
			}

			_Stack = newStack;
			_Capacity *= 2;

		}
		public void Push(T element)
		{
			if (_Capacity - 1 == _LastIndex)
			{
				Resize();
			}
			_Stack.SetValue(element, _LastIndex);
			_LastIndex++;
		}

		public T Pop()
		{
			if(_LastIndex>0)
			{
				T elementToPop = _Stack[_LastIndex -1 ];
				_Stack.SetValue(null, _LastIndex);
				_LastIndex--;

				return elementToPop;
			}

			return default(T);
		}

		public void Clear()
		{
			_Stack = new T[_Capacity];
			_LastIndex = 0;
		}

		public int Count()
		{
			return _LastIndex + 1;
		}
	}
}

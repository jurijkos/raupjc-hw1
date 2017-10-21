using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonzolnaAplikacija2
{
    class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        private int _cout;
        public IntegerList()
        {
            
            _internalStorage = new int[4];
            _cout = 0;
            
        }
        public IntegerList(int initialSize)
        {
            _internalStorage = new int[initialSize];
            _cout = 0;
        }
        public int Count => _cout;

        public void Add(int item)
        {
            if(_cout < _internalStorage.Length)
            {
                _internalStorage[_cout] = item;
                _cout++;
            }
            else
            {

                int[] _copyOfInternalStorage = new int[_internalStorage.Length * 2];
                for (int i = 0; i < _internalStorage.Length ; i++)
                {
                    _copyOfInternalStorage[i] = _internalStorage[i];
                }
                _internalStorage = _copyOfInternalStorage;

            }
        }

        public void Clear()
        {
            _internalStorage = new int[4];
            _cout = 0;
        }

        public bool Contains(int item)
        {
            foreach (var value in _internalStorage)
            {
                if (value == item)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetElement(int index)
        {
            if(index >= 0 && index < _cout)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
          
            }
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < Count; i++)
            {
                if(item == GetElement(i))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(int item)
        {
            for (int i = 0; i < Count; i++)
            {
                if(item == _internalStorage[i])
                {
                    for (int j = i; j < _internalStorage.Length - 1; j++)
                    {
                        _internalStorage[j] = _internalStorage[j + 1];
                    }
                    _cout--;
                    return true;
                }
            }
            return false;
            
        }

        public bool RemoveAt(int index)
        {
            if(index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
            for (int j = index; j < _internalStorage.Length - 1; j++)
            {
                _internalStorage[j] = _internalStorage[j + 1];
            }
            _cout--;
            return true;

        }
    }
}

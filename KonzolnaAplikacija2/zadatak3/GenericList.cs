﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak3
{
    class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;
        private int _cout;
        public GenericList()
        {

            _internalStorage = new X[4];
            _cout = 0;

        }
        public GenericList(int initialSize)
        {
            _internalStorage = new X[initialSize];
            _cout = 0;
        }
        public int Count => _cout;

        int IGenericList<X>.Count => throw new NotImplementedException();

        public void Add(X item)
        {
            if (_cout < _internalStorage.Length)
            {
                _internalStorage[_cout] = item;
                _cout++;
            }
            else
            {

                X[] _copyOfInternalStorage = new X[_internalStorage.Length * 2];
                for (int i = 0; i < _internalStorage.Length; i++)
                {
                    _copyOfInternalStorage[i] = _internalStorage[i];
                }
                _internalStorage = _copyOfInternalStorage;

            }
        }

        public void Clear()
        {
            _internalStorage = new X[4];
            _cout = 0;
        }

        public bool Contains(X item)
        {
            foreach (var value in _internalStorage)
            {
                if (value.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public X GetElement(int index)
        {
            if (index >= 0 && index < _cout)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException();

            }
        }

        public IEnumerator<X> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (item.Equals(GetElement(i)))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(X item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (item.Equals(_internalStorage[i]))
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
            if (index < 0 || index >= Count)
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }
    }
}

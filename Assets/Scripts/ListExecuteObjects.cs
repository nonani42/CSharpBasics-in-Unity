using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ballgame
{
    public sealed class ListExecuteObjects : IEnumerator, IEnumerable  
    {
        private IExecute[] _executiveObjects;
        private int _index = -1;

        public object Current => _executiveObjects[_index];
        public int Length => _executiveObjects.Length;

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MoveNext()
        {
            if(_index == Length - 1)
            {
                Reset();
                return false;
            }
            _index++;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }

        public void AddExecuteObject(IExecute execute)
        {
            if (_executiveObjects == null)
            {
                _executiveObjects = new[]
                {
                    execute
                };
                return;
            }
            Array.Resize(ref _executiveObjects, Length + 1);
            _executiveObjects[Length - 1] = execute;
        }

        public IExecute this[int index]
        {
            get
            {
                return _executiveObjects[index];
            }
            set
            {
                _executiveObjects[index] = value;
            }
        }
    }
}

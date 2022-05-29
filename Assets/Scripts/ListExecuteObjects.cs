using System;
using System.Collections;
using UnityEngine;

namespace Ballgame
{
    public sealed class ListExecuteObjects : IEnumerator, IEnumerable  
    {
        private IExecute[] _interactiveObjects;
        private int _index = -1;

        public object Current => _interactiveObjects[_index];
        public int Length => _interactiveObjects.Length;

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator() //зачем, если уже прописан GetEnumerator()?
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
            if(_interactiveObjects == null)
            {
                _interactiveObjects = new[]
                {
                    execute
                };
                return;
            }
            Array.Resize(ref _interactiveObjects, Length + 1);
            _interactiveObjects[Length - 1] = execute;
        }

        public IExecute this[int index]
        {
            get
            {
                return _interactiveObjects[index];
            }
            set
            {
                _interactiveObjects[index] = value;
            }
        }
    }
}

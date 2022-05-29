using System;
using System.Collections;
using UnityEngine;

namespace Ballgame
{
    public class ListBonusObjects : IEnumerator, IEnumerable
    {
        private Bonus[] _bonusObjects;
        private int _index = -1;

        public object Current => _bonusObjects[_index];
        public int Length => _bonusObjects.Length;

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
            if (_index == Length - 1)
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

        public void AddBonusObject(Bonus bonus)
        {
            if (_bonusObjects == null)
            {
                _bonusObjects = new[]
                {
                    bonus
                };
                return;
            }
            Array.Resize(ref _bonusObjects, Length + 1);
            _bonusObjects[Length - 1] = bonus;
        }

        public Bonus this[int index]
        {
            get
            {
                return _bonusObjects[index];
            }
            set
            {
                _bonusObjects[index] = value;
            }
        }
    }
}

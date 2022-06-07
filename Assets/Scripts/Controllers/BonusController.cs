using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ballgame
{
    public abstract class BonusController : IExecute
    {
        public Transform _transform;
        protected Color _color;

        public abstract void Update();

    }
}

using UnityEngine;

namespace Ballgame
{
    public class InputController: IExecute
    {
        private readonly Unit _player;

        private float horizontal;
        private float vertical;

        public InputController(Unit player)
        {
            _player = player;
        }

        public void Update()
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            _player.Move(horizontal, 0f, vertical);

            if (Input.GetKeyDown(KeyCode.K))
            {
                //(_player as Player).Save();
                _player.Save();
            }
        }
    }
}

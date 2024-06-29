using System;

namespace StartGameJam.Scripts
{
    public interface IPlayer
    {
        public event Action OnDeathEnd;

        public void InvokeDeath();
    }
}
using Avastrad.Storages;
using StartGameJam.Scripts.Core;

namespace StartGameJam.Scripts
{
    public class PlayerGameData
    {
        private readonly GameConfig _gameConfig;
        private readonly IntStorage _healthPoints;

        public IReadOnlyStorage<int> HealthPoints => _healthPoints; 
        
        public PlayerGameData(GameConfig gameConfig)
        {
            _gameConfig = gameConfig;
            _healthPoints = new IntStorage(_gameConfig.HeartsCount, _gameConfig.HeartsCount);
        }

        public void TakeDamage()
            => _healthPoints.ChangeCurrentValue(-1);
    }
}
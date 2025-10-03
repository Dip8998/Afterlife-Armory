using AfterlifeArmory.Player;
using AfterlifeArmory.Utilities;
using UnityEngine;

namespace AfterlifeArmory.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        public PlayerService PlayerService { get; private set; }

        [SerializeField] private PlayerScriptableObject playerScriptableObject;

        protected override void Awake()
        {
            base.Awake();   
            PlayerService = new PlayerService(playerScriptableObject);
        }

        private void Update()
        {
            PlayerService?.UpdatePlayer();
        }
    }
}

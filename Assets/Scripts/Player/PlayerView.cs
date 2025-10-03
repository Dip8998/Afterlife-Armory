using UnityEngine;

namespace AfterlifeArmory.Player
{
	public class PlayerView : MonoBehaviour
	{
		private PlayerController playerController;

        public void SetPlayerController(PlayerController playerController)
		{
			this.playerController = playerController;
		}
	}
}

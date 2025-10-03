using UnityEngine;

namespace AfterlifeArmory.Player
{
	public class PlayerController
	{
		private PlayerView player;
		private PlayerScriptableObject playerScriptableObject;

		public PlayerController(PlayerScriptableObject playerScriptableObject)
		{
			this.playerScriptableObject = playerScriptableObject;
			InitializeView();
		}

		public void InitializeView()
		{
			player = Object.Instantiate(playerScriptableObject.PlayerPrefab);
			player.transform.position = playerScriptableObject.SpawnPosition;
			player.transform.rotation = Quaternion.Euler(playerScriptableObject.SpawnRotation);
			player.SetPlayerController(this);
		}
	}
}

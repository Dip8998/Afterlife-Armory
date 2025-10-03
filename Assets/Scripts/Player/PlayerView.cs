using AfterlifeArmory.Cam;
using UnityEngine;

namespace AfterlifeArmory.Player
{
	public class PlayerView : MonoBehaviour
	{
		private PlayerController playerController;
		private CharacterController characterController;
        private Camera cam;

		public CharacterController CharacterController => characterController;
		public Camera Cam => cam;

        private void Start()
        {
			characterController = GetComponent<CharacterController>();
            cam = Camera.main;
        }

        public void SetPlayerController(PlayerController playerController)
		{
			this.playerController = playerController;
		}
	}
}

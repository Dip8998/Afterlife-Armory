using AfterlifeArmory.Cam;
using UnityEngine;
using UnityEngine.InputSystem.XR;

namespace AfterlifeArmory.Player
{
	public class PlayerController
	{
		private PlayerView player;
		private PlayerScriptableObject playerScriptableObject;
		private Vector3 velocity;

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
            CameraController camera = Camera.main.GetComponent<CameraController>();
            camera.SetTarget(player.transform);
        }

        public void UpdatePlayer()
		{
			PlayerMovement();
		}

        private void PlayerMovement()
        { 
			Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
			Quaternion yaw = Quaternion.Euler(0f, player.Cam.transform.eulerAngles.y, 0f);
			Vector3 camF = (yaw * Vector3.forward);
			Vector3 camR = (yaw * Vector3.right);
			Vector3 moveDir = (camF * moveInput.z + camR * moveInput.x).normalized;

			float speed = playerScriptableObject.MoveSpeed;

            Vector3 horizontal = moveDir * speed;
            player.CharacterController.Move((horizontal + Vector3.up * velocity.y) * Time.deltaTime);

            if (!RotateTowardsMouse() && moveDir.sqrMagnitude > 0.01f)
            {
                float targetAngle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg;
                player.transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            }
        }

        private bool RotateTowardsMouse()
        {
            Ray ray = player.Cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                Vector3 target = hit.point;
                Vector3 lookDir = target - player.transform.position;
                lookDir.y = 0f;

                if (lookDir.sqrMagnitude > 0.01f)
                {
                    Quaternion targetRot = Quaternion.LookRotation(lookDir);
                    player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRot, Time.deltaTime * playerScriptableObject.RotationSpeed);
                    return true;
                }
            }
            return false;
        }
    }
}

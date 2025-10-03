using System;
using UnityEngine;

namespace AfterlifeArmory.Cam
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Vector3 cameraOffset;

        private Transform playerTarget;

        private void LateUpdate()
        {
            ApplyCameraTransform();
        }

        private void ApplyCameraTransform()
        {
            if (playerTarget != null)
            {
                transform.position = playerTarget.position + cameraOffset;
                transform.LookAt(playerTarget.position + Vector3.up * 1.5f);
            }
        }

        public void SetTarget(Transform target)
        {
            playerTarget = target;
        }
    }
}
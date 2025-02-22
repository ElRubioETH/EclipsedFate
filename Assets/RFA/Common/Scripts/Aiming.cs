using UnityEngine;

namespace Retro.ThirdPersonCharacter
{
    public class Aiming : MonoBehaviour
    {
        public float turnspeed = 15;
        public Camera physicalCamera; // Thêm biến để chứa Physical Camera

        private void Start()
        {
            if (physicalCamera == null)
            {
                physicalCamera = GetComponentInChildren<Camera>(); // Tìm Camera trong con của nhân vật
            }
        }

        private void LateUpdate()
        {
            if (physicalCamera == null) return;

            float yawCamera = physicalCamera.transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnspeed * Time.deltaTime);
        }
    }
}

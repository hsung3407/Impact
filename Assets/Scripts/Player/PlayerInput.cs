using UnityEngine;

namespace Player
{
    public class PlayerInput
    {
        public Vector3 GetDirection()
        {
            var dir = Vector3.zero;
            if(Input.GetKey(KeyCode.W)) dir.z += 1;
            if(Input.GetKey(KeyCode.S)) dir.z -= 1;
            if(Input.GetKey(KeyCode.D)) dir.x += 1;
            if(Input.GetKey(KeyCode.A)) dir.x -= 1;
            return dir.normalized;
        }
    }
}
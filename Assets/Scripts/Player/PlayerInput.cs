using UnityEngine;

namespace Player
{
    public class PlayerInput
    {
        public Vector3 Direction { get; private set; } = Vector3.zero;

        public void UpdateInput()
        {
            var dir = Vector3.zero;
            if(Input.GetKey(KeyCode.W)) dir.z += 1;
            if(Input.GetKey(KeyCode.S)) dir.z -= 1;
            if(Input.GetKey(KeyCode.D)) dir.x += 1;
            if(Input.GetKey(KeyCode.A)) dir.x -= 1;
            dir = dir.normalized;
            var alpha = Mathf.Clamp01(5f * Time.deltaTime / Vector3.Distance(Direction, dir));
            Direction = Vector3.Lerp(Direction, dir, alpha);
        }
    }
}
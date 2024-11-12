using UnityEngine;

namespace Player.Mover
{
    public class DefaultMover : MoverBase
    {
        public override void Move(Vector3 dir, Transform tr, Animator anim)
        {
            anim.SetFloat("VMove", dir.z);
            anim.SetFloat("HMove", dir.x);
            tr.position += dir * (speed * Time.deltaTime);
        }
    }
}
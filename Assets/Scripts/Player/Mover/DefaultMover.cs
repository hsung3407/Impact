using System;
using System.Globalization;
using UnityEngine;

namespace Player.Mover
{
    public class DefaultMover : BaseMover
    {
        [SerializeField] private float rotateSpeed = 180f;

        public override void Move(Vector3 dir, Transform tr, Animator anim)
        {
            tr.position += dir * (speed * Time.deltaTime);

            var dot = Vector3.Dot(transform.forward, dir);
            var acos = Mathf.Acos(Mathf.Clamp(dot, -1f, 1f));
            if (float.IsNaN(acos)) acos = 0;
            anim.SetFloat("VMove", dir.sqrMagnitude);
            anim.SetFloat("HMove", 0);

            if (dir == Vector3.zero) return;
            var degree = Mathf.Rad2Deg * acos;
            var rotation = Quaternion.LookRotation(dir);
            var alpha = Mathf.Clamp01((rotateSpeed * Time.deltaTime) / degree);
            tr.rotation = Quaternion.Lerp(transform.rotation, rotation, alpha);
        }
    }
}
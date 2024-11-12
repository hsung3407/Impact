using UnityEngine;
using UnityEngine.Serialization;

namespace Player.Mover
{
    public abstract class MoverBase : MonoBehaviour
    {
        [SerializeField] protected float speed;
        /// <returns>Player Look Direction </returns> <returns> Move Ratio</returns>
        public abstract void Move(Vector3 dir, Transform tr, Animator anim);
    }
}
using UnityEngine;

namespace Player.Mover
{
    public interface IMover
    {
        /// <returns>Player Look Direction </returns> <returns> Move Ratio</returns>
        public (Vector3, float) Move(Vector3 dir, Transform tr);
    }
}
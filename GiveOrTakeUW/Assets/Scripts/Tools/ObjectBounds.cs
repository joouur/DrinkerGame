using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace GameDrinker.Tools
{
    public class ObjectBounds : MonoBehaviour
    {
        #region Data
        public enum WaysToDetermineBounds
        {
            Undefined,
            Collider,
            Collider2D,
            Renderer
        }

        public WaysToDetermineBounds BoundsBase;

        public Vector3 Size
        { get; set; }
        #endregion

        #region Bound Functionability
        /// <summary>
        /// Define bounds if this class is inherited or added.
        /// </summary>
        protected virtual void Reset()
        {
            DefineBoundsChoice();
        }

        /// <summary>
        /// Determine Bounds automatically.
        /// Use with this order -> Renderer, Collider or Collider2D
        /// If none is found set as Undefined;
        /// </summary>
        protected virtual void DefineBoundsChoice()
        {
            BoundsBase = WaysToDetermineBounds.Undefined;
            if (GetComponent<Renderer>() != null)
                BoundsBase = WaysToDetermineBounds.Renderer;
            if (GetComponent<Collider>() != null)
                BoundsBase = WaysToDetermineBounds.Collider;
            if (GetComponent<Collider2D>() != null)
                BoundsBase = WaysToDetermineBounds.Collider2D;
        }

        /// <summary>
        /// Return bounds of object, based on the definition
        /// </summary>
        /// <returns>Bounds</returns>
        /// TODO: Test for Collider3D and Collider2D (Render Works)
        public virtual Bounds GetBounds()
        {
            if (BoundsBase == WaysToDetermineBounds.Renderer)
            {
                if (GetComponent<Renderer>() == null)
                    throw new Exception("Pool Object " + gameObject.name + " has a Renderer based bounds, but no renderer could be found");
                return GetComponent<Renderer>().bounds;
            }
            if (BoundsBase == WaysToDetermineBounds.Collider)
            {
                if (GetComponent<Collider>() == null)
                    throw new Exception("Pool Object " + gameObject.name + " has a Collider based bounds, but no Collider could be found");
                return GetComponent<Collider>().bounds;
            }
            if (BoundsBase == WaysToDetermineBounds.Collider2D)
            {
                if (GetComponent<Collider2D>() == null)
                    throw new Exception("Pool Object " + gameObject.name + " has a Collider2D based bounds, but no Collider2D could be found");
                return GetComponent<Collider2D>().bounds;
            }
            return new Bounds(Vector3.zero, Vector3.zero);
        }
        #endregion
    }
}
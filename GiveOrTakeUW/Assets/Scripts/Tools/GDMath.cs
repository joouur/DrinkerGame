using UnityEngine;
using System.Collections;

namespace GameDrinker.Tools
{
    public static class GDMath
    {
        /// <summary>
        /// Changes Vector3 passed with random x,y,z values
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <param name="refVec3"></param>
        public static void Random3dVec(float low, float high, ref Vector3 refVec3)
        {
            float randomX = Random.Range(low, high);
            float randomY = Random.Range(low, high);
            float randomZ = Random.Range(low, high);

            Vector3 randomVector = new Vector3(randomX, randomY, randomZ);
            refVec3 = randomVector;
        }
        /// <summary>
        /// return Vector3 with Random x,y,z values
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public static Vector3 Random3dVec(float low, float high)
        {
            float randomX = Random.Range(low, high);
            float randomY = Random.Range(low, high);
            float randomZ = Random.Range(low, high);
            return new Vector3(randomX, randomY, randomZ);
        }

        /// <summary>
        /// set ref Y position 
        /// randomize xz and keep y same
        /// return vector 3
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <param name="vectorY"></param>
        /// <returns></returns>
        public static Vector3 Random3dVec(float low, float high, ref float vectorY)
        {
            float randomX = Random.Range(low, high);
            float randomZ = Random.Range(low, high);
            return new Vector3(randomX, vectorY, randomZ);
        }

        public static Vector3 Random3dVec(Vector3 minimum, Vector3 maximum)
        {
            return new Vector3(UnityEngine.Random.Range(minimum.x, maximum.x),
                                             UnityEngine.Random.Range(minimum.y, maximum.y),
                                             UnityEngine.Random.Range(minimum.z, maximum.z));
        }
        /// <summary>
        /// Changes vector2 passed with random x and y values
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <param name="refVec2"></param>
        public static void Random2dVec(float low, float high, ref Vector2 refVec2)
        {
            float randomX = Random.Range(low, high);
            float randomY = Random.Range(low, high);
            Vector2 randomVector = new Vector2(randomX, randomY);
            refVec2 = randomVector;
        }
        /// <summary>
        /// returns new vector2 with random x and y
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public static Vector2 Random2dVec(float low, float high)
        {
            float randomX = Random.Range(low, high);
            float randomY = Random.Range(low, high);
            return new Vector2(randomX, randomY);
        }
        /// <summary>
        ///  returns new vector2 with random x value and passed y value
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <param name="vectorY"></param>
        /// <returns></returns>
        public static Vector2 Random2dVec(float low, float high, float vectorY)
        {
            float randomX = Random.Range(low, high);
            float randomY = Random.Range(low, high);
            return new Vector2(randomX, vectorY + randomY);
        }
        /// <summary>
        /// converts a vector3 to vector2
        /// </summary>
        /// <param name="vec3"></param>
        /// <returns></returns>
        public static Vector2 ConvertVector3(Vector3 vec3)
        {
            return new Vector2(vec3.x, vec3.y);
        }
        /// <summary>
        /// cconverts vector2 to vector3
        /// </summary>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static Vector3 ConvertVector2(Vector2 vec2)
        {
            return new Vector3(vec2.x, vec2.y, 0f);
        }
        /// <summary>
        /// returns the total sum of all Ints inside the array passed
        /// </summary>
        /// <param name="arrOfInts"></param>
        /// <returns></returns>
        public static int sum(int[] arrOfInts)
        {
            int total = 0;
            foreach (int x in arrOfInts)
                total += x;
            return total;
        }
        /// <summary>
        /// returns a random number from 1 to the int passed
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int Dice(int max)
        {
            return Random.Range(1, max);
        }
        /// <summary>
        /// returns true or false depending the int passed
        /// is greater than a random number between 1 and 100
        /// </summary>
        /// <param name="percent"></param>
        /// <returns></returns>
        public static bool chance(int percent)
        {
            return (Random.Range(0, 100) <= percent);
        }
        /// <summary>
        /// runs a while loop from "to" to "from" and increments
        /// by the amountToApproach
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="amountToApproach"></param>
        public static void approachValues(int from, int to, int amountToApproach)
        {
            while (from < to)
                from += amountToApproach;
        }
        /// <summary>
        /// Rotates a Vector3 around a pivot. Note this takes 3 Vector3's
        /// One is the point, another is the pivot, the last is the angle to rotate
        /// </summary>
        /// <param name="point"></param>
        /// <param name="Pivot"></param>
        /// <param name="angles"></param>
        /// <returns></returns>
        public static Vector3 RotateVector3AroundPivot(Vector3 point, Vector3 pivot, float angle)
        {
            angle = angle * (Mathf.PI / 180f);
            var rotatedX = Mathf.Cos(angle) * (point.x - pivot.x) - Mathf.Sin(angle) * (point.y - pivot.y) + pivot.x;
            var rotatedY = Mathf.Sin(angle) * (point.x - pivot.x) + Mathf.Cos(angle) * (point.y - pivot.y) + pivot.y;
            return new Vector3(rotatedX, rotatedY, 0);
        }

    }
}


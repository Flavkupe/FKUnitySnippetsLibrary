

using UnityEngine;

// TODO: Add this one

namespace FKUnitySnippets.Curves
{
    public class CatmullRomSpline
    {
        private Vector3[] points;

        public CatmullRomSpline(Vector3[] points)
        {
            this.points = points;
        }

        public Vector3 GetPoint(float t)
        {
            int numSections = points.Length - 3;
            int currPoint = Mathf.Min(Mathf.FloorToInt(t * numSections), numSections - 1);
            float u = t * numSections - currPoint;

            Vector3 a = points[currPoint];
            Vector3 b = points[currPoint + 1];
            Vector3 c = points[currPoint + 2];
            Vector3 d = points[currPoint + 3];

            return 0.5f * (
                (-a + 3f * b - 3f * c + d) * (u * u * u) +
                (2f * a - 5f * b + 4f * c - d) * (u * u) +
                (-a + c) * u +
                2f * b
            );
        }
    }
}
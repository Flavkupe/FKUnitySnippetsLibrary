using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace FKUnitySnippets.Curves
{
    public class CatmullRomSpline
    {
        private List<Vector3> _points = new();

        public int PointCount => _points.Count;

        public CatmullRomSpline(IEnumerable<Vector3> points)
        {
            this._points = points.ToList();
        }

        public void AddPoint(Vector3 point)
        {
            _points.Add(point);
        }

        public Vector3 GetPoint(float t)
        {
            int numSections = _points.Count - 3;
            int currPoint = Mathf.Min(Mathf.FloorToInt(t * numSections), numSections - 1);
            float u = t * numSections - currPoint;

            Vector3 a = _points[currPoint];
            Vector3 b = _points[currPoint + 1];
            Vector3 c = _points[currPoint + 2];
            Vector3 d = _points[currPoint + 3];

            return 0.5f * (
                (-a + 3f * b - 3f * c + d) * (u * u * u) +
                (2f * a - 5f * b + 4f * c - d) * (u * u) +
                (-a + c) * u +
                2f * b
            );
        }
    }
}
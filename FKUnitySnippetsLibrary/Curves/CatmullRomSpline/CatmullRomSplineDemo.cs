using FKUnitySnippets.Curves;
using UnityEngine;
using System.Linq;

public class CatmullRomSplineDemo : MonoBehaviour
{
    [SerializeField]
    private Transform[] _controlPoints;

    [SerializeField]
    private GameObject _pointPrefab;

    [SerializeField]
    private GameObject _object;

    [SerializeField]
    private float _speed = 1.0f;

    private CatmullRomSpline _spline;

    private float _t = 0.0f;

    private void Start()
    {
        var points = _controlPoints.Select(cp => cp.position);
        _spline = new CatmullRomSpline(points);
    }

    public void AddPoint(Vector3 point)
    {
        point = new Vector3(point.x, point.y, 0.0f);
        _spline.AddPoint(point);
        var newPoint = Instantiate(_pointPrefab, this.transform, true);
        newPoint.transform.position = point;

        var text = _spline.PointCount.ToString();
        newPoint.GetComponentInChildren<TextMesh>().text = text;
        newPoint.name = text;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            AddPoint(point);
            _t = 0.0f;
            return;
        }

        // divide by point count so that the speed is normalized as more points are
        // added; otherwise adding more points causes the object to move faster since the
        // interpolation is still between 0.0 to 1.0.
        _t += (_speed * Time.deltaTime) / (_spline.PointCount - 2);
        if (_t > 1.0f)
        {
            _t = 0.0f;
        }

        _object.transform.position = _spline.GetPoint(_t);
    }
}

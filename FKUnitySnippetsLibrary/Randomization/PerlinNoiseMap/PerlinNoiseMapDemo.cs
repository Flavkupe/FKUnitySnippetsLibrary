using UnityEngine;

namespace FKUnitySnippets.Randomization
{
    public class PerlinNoiseMapDemo : MonoBehaviour
    {
        [SerializeField]
        private GameObject _tilePrefab;

        private Transform _tiles;

        [SerializeField]
        private int _mapWidth = 100;

        [SerializeField]
        private int _mapHeight = 100;

        [SerializeField]
        private float _scale = 1.0f;

        [SerializeField]
        private float _offsetX = 0.0f;

        [SerializeField]
        private float _offsetY = 0.0f;

        [SerializeField]
        private float _threshold = 0.5f;

        private float[,] _map;

        public void Generate()
        {
            _map = new PerlinNoiseMap(_mapWidth, _mapHeight, _scale, _offsetX, _offsetY).Map;

            if (_tiles != null)
            {
                Destroy(_tiles.gameObject);
            }

            _tiles = new GameObject("Tiles").transform;

            for (var x = 0; x < _mapWidth; x++)
            {
                for (var y = 0; y < _mapWidth; y++)
                {
                    if (_map[x, y] < _threshold)
                    {
                        var tile = Instantiate(_tilePrefab, _tiles, true);
                        tile.transform.localPosition = new Vector3(x, y, 0.0f);
                    }
                }
            }

            // this is here so that the tiles are deleted when switching to another demo
            _tiles.SetParent(transform);

            // NOTE: these transforms are just so that it fits nicely into the view for the demo
            _tiles.position = new Vector3(-2.5f, -1.0f, 0.0f);
            _tiles.localScale = new Vector3(0.05f, 0.05f, 1.0f);
        }
    }
}
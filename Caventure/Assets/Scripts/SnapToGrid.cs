using UnityEngine;

[ExecuteInEditMode]
public class SnapToGrid : MonoBehaviour
{
    public bool IsFloor;
    private Grid _grid;
    private Grid Grid
    {
        get
        {
            if (_grid == null)
            {
                _grid = GameObject.Find("Grid").GetComponent<Grid>();
            }
            return _grid;
        }
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (transform.hasChanged)
        {
            Grid.SnapObjectToGrid(transform);
        }
#endif
    }

    private void Awake()
    {
        if (IsFloor)
        {
            Grid.AddObjectToGridPositions(transform);
        }
    }
}

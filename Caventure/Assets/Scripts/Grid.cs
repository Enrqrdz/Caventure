using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteInEditMode]
public class Grid : MonoBehaviour
{
    [SerializeField] private float Size = 1f;
    [SerializeField] private float Height = .5f;
    public Dictionary<int,Transform> WalkableTransforms = new Dictionary<int, Transform>();

    public float GetSize() => Size;
    public float GetHeight() => Height;

    public void SnapObjectToGrid(Transform target_, bool isFloor_ = false) 
	    => target_.position = GetNearestPointOnGrid(target_.position);

    private Vector3 GetNearestPointOnGrid(Vector3 position_)
    {
	    var transformPosition = transform.position;
		position_ -= transformPosition;

		int xCount = Mathf.RoundToInt(position_.x / Size);
		int yCount = Mathf.RoundToInt(position_.y / Height);
		int zCount = Mathf.RoundToInt(position_.z / Size);

		Vector3 result = new Vector3(xCount * Size, yCount * Height, zCount * Size);
		result += transformPosition;
		return result;
	}
    
    public void AddObjectToGridPositions(Transform object_)
    {
	    var hashCode = GetPositionHash(object_.position);
	    WalkableTransforms[hashCode] = object_;
    }

    public static int GetPositionHash(Vector3 position_)
    {
	    return position_.GetHashCode();
    }
}


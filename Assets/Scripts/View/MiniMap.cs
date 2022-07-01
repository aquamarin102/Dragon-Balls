using UnityEngine;

public sealed class MiniMap : MonoBehaviour
{
    private Transform _playerPos;
    void Start()
    {
        _playerPos = Camera.main.transform;
        transform.parent = null;
        transform.rotation = Quaternion.Euler(90f,0,0);
        transform.position = _playerPos.position + new Vector3(0, 10, 0);

        var rt = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");

        GetComponent<Camera>().targetTexture = rt;
    }

    private void LateUpdate()
    {
        var newPosition = _playerPos.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(90,_playerPos.eulerAngles.y, 0);
    }
}

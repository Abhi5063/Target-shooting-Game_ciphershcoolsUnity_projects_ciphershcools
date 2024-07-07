using UnityEngine;

public class ShipMAnager : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject,2f);
    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}

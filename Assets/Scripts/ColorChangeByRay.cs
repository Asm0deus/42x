using UnityEngine;

public class ColorChangeByRay : MonoBehaviour
{
    [SerializeField] private LayerMask _overlayObjectMask;

    private ColorChanger _currentObject;

    void Update()
    {
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        
        if (Physics.Raycast(ray, out hitInfo, 10, _overlayObjectMask))
        {
            if (_currentObject != null && _currentObject.gameObject != hitInfo.collider.gameObject)
            {
                _currentObject.setStandartMaterial();
            }

            _currentObject = hitInfo.collider.GetComponent<ColorChanger>();
            _currentObject.setNewMaterial();
        }
        else
        {
            if (_currentObject != null) _currentObject.setStandartMaterial();
        }
    }
}

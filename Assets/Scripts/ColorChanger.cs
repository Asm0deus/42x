using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Material _selectedMaterial;

    private Renderer _renderer;
    private Material _standardMaterial;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _standardMaterial = _renderer.material;
    }

    public void setStandartMaterial()
    {
        _renderer.material = _standardMaterial;
    }

    public void setNewMaterial()
    {
        _renderer.material = _selectedMaterial;
    }
}

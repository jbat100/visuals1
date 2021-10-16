using UnityEngine;

public class CrystalController : MonoBehaviour
{
    [SerializeField] private Material _crystalMaterial;

    [SerializeField, Range(0,1)] private float _depth = 0.5f;
    [SerializeField, Range(0,1)] private float _intensity = 0.5f;
    [SerializeField, Range(0,1)] private float _hue = 0.5f;
    [SerializeField, Range(0,1)] private float _disonnance = 0.5f;
    
    private MaterialFloatPropertyController _topLine;
    private MaterialFloatPropertyController _bottomLine;
    private MaterialColorPropertyController _baseColor;
    private MaterialColorPropertyController _topColor;
    private MaterialColorPropertyController _bottomColor;
    
    protected void Awake()
    {
        _topLine = new MaterialFloatPropertyController(_crystalMaterial, "TopLine");
        _bottomLine = new MaterialFloatPropertyController(_crystalMaterial, "BottomLine");
        _baseColor = new MaterialColorPropertyController(_crystalMaterial, "BaseColor");
        _topColor = new MaterialColorPropertyController(_crystalMaterial, "TopColor");
        _bottomColor = new MaterialColorPropertyController(_crystalMaterial, "BottomColor");
    }

    protected void OnEnable()
    {
        _topLine.Initialize();
        _bottomLine.Initialize();
        _baseColor.Initialize();
        _topColor.Initialize();
        _bottomColor.Initialize();
    }

    public void SetSpeed(float speed)
    {
        _bottomLine.Modulate(speed * 5);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : MonoBehaviour
{
    [SerializeField] private Material _crystalMaterial;

    [SerializeField, Range(0,1)] private float _depth = 0.5f;
    [SerializeField, Range(0,1)] private float _intensity = 0.5f;
    [SerializeField, Range(0,1)] private float _hue = 0.5f;
    [SerializeField, Range(0,1)] private float _disonnance = 0.5f;

    public abstract class MaterialPropertyController<T>
    {
        protected readonly Material _material;
        protected readonly string _name;
        protected readonly int _id;
        protected T _reference;
        
        protected MaterialPropertyController(Material material, string name)
        {
            _material = material;
            _name = name;
            _id = Shader.PropertyToID(name);
        }

        public void Initialize() => _reference = Get();

        public abstract void Set(T current); 
        
        public abstract T Get();

        public abstract void Modulate(float scale);
    }

    public class MaterialFloatPropertyController : MaterialPropertyController<float>
    {
        public override float Get() => _material.GetFloat(_id);
        public override void Set(float val) => _material.SetFloat(_id, val);
        public override void Modulate(float scale) => _material.SetFloat(_id, _reference * scale);

        public MaterialFloatPropertyController(Material material, string name) : base(material, name)
        {
        }
    }
    
    public class MaterialColorPropertyController : MaterialPropertyController<Color>
    {
        public override Color Get() => _material.GetColor(_id);
        public override void Set(Color val) => _material.SetColor(_id, val);
        public override void Modulate(float scale) => _material.SetColor(_id, _reference * scale);

        public MaterialColorPropertyController(Material material, string name) : base(material, name)
        {
        }
    }
    
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

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BusketController : MonoBehaviour
{
    private Animator animator;
    private float _blend;
    private GameObject dethTrigger;
    [SerializeField] private GameObject _disapVFX;
    [SerializeField] private GameObject star;
    private Vector3 _pos;
    [SerializeField] private SpriteRenderer[] _rings;
    private Color _color;
    public Vector3 pos { get { return _pos; } }
    private int _randInt;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    void Start()
    {
        _randInt = Random.Range(0, 5);//20%Chanse
        _pos = transform.position;
        _blend = 0f;
        dethTrigger = GameObject.FindGameObjectWithTag("death");
        Vector3 v = new Vector3(0, transform.position.y-5f, 0);
        dethTrigger.transform.position = v;
        _color = new Color(.6f, .6f, .6f, 1f);
        if (_randInt == 1) star.SetActive(true);
    }
    public async void BlenderAnim(float blend)
    {
        _blend = blend;
        await Task.Delay(300);
        _blend = 0;
    }
    public void SetGrayBasketring()
    {
        foreach (SpriteRenderer _rings in _rings)
        {
            _rings.color = _color;
        }
    }
    //Âûחûגאועסÿ c AnimationEvent 
    public async void DisapearDestroy()
    {
        _disapVFX.SetActive(true);
        await Task.Delay(800);
        Destroy(gameObject);
    }

    void Update()
    {
        animator.SetFloat("Blend", _blend);
    }
}

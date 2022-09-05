using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    [SerializeField] private GameObject _disapVFX;
    [SerializeField] private GameObject star;
    [SerializeField] private GameObject circleVert;
    [SerializeField] private GameObject circleHoriz;
    [SerializeField] private GameObject circleCol;
    [SerializeField] private SpriteRenderer[] _rings;
    private GameObject dethTrigger;
    private Vector3 _pos;
    private Color _color;
    private int _randIntSpawnStar;
    private int _randIntAnim;
    private int _randIntCol;
    private Animator animat;
    private BasketSpawner _basketSpawner;
    private Vector2 _curPosBask;
    private Vector2 _zeroPosBask;
    public Vector3 pos { get { return _pos; } }
    void Start()
    {
        animat = GetComponent<Animator>();
        _basketSpawner = FindObjectOfType<BasketSpawner>();
        _curPosBask = transform.position;
        _zeroPosBask = _basketSpawner.pointsSpawn[0];
        _randIntSpawnStar = Random.Range(0, 5);//20%Chanse
        _randIntAnim = Random.Range(0, 5);//20%Chanse
        _randIntCol = Random.Range(0, 5);//20%Chanse
        _pos = transform.position;
        dethTrigger = GameObject.FindGameObjectWithTag("death");
        Vector3 v = new Vector3(0, transform.position.y-5f, 0);
        dethTrigger.transform.position = v;
        _color = new Color(.6f, .6f, .6f, 1f);
        if (_randIntSpawnStar == 1) star.SetActive(true);
        if (_curPosBask != _zeroPosBask)
        {
            if (_randIntAnim == 1)
            {
                circleVert.SetActive(true);
                animat.SetBool("isVertical", true);
            }
            if (_randIntAnim == 2)
            {
                circleHoriz.SetActive(true);
                animat.SetBool("isHorizontal", true);
            }
            if (_randIntCol == 1)
            {
                circleCol.SetActive(true);
            }

        }
    }
    public void BlenderAnim(float blend)
    {
        animat.SetFloat("blend", blend);
    }
    public void StopAnims()
    {
        animat.SetBool("isVertical", false);
        animat.SetBool("isHorizontal", false);
        circleVert.SetActive(false);
        circleHoriz.SetActive(false);
        circleCol.SetActive(false);
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
}

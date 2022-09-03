using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D col;
    private Vector3 _posBaskcur;
    private Vector3 _posBaskprev;
    private int _scoreSustr;
    private int _score;
    private Transform _border;
    private string _announText;
    [SerializeField] private ProgressManager progressManager;
    [SerializeField] private BasketSpawner basketSpawner;
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private GameObject fingerMove;
    [HideInInspector] public UiController uiController;
    [HideInInspector] public bool isFlying;
    [HideInInspector] public LookAtFinger lookAtFinger;
    [HideInInspector] public BusketController busketController;
    [HideInInspector] public Vector3 pos { get { return transform.position; } }
    void Awake()
    {
        uiController = progressManager.uiController;
        _border = GameObject.FindGameObjectWithTag("border").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }
    private void Start()
    {
        Begin();
        _scoreSustr = 1;
    }
    private async void Begin()
    {
        await Task.Delay(500);
        _posBaskprev = basketSpawner.basketSpawn[0].transform.position;
        gameObject.transform.position = new Vector2(_posBaskprev.x, _posBaskprev.y + 1.5f);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        fingerMove.transform.position = new Vector2(_posBaskprev.x - .5f, _posBaskprev.y - 1.8f);
        fingerMove.SetActive(true);
    }

    public void Push(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public void ActivateRb()
    {
        //rb = gameObject.AddComponent<Rigidbody2D>();
        //rb.isKinematic = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject col = collision.gameObject;
        switch (col.tag)
        {
            case "pullPoint":
                busketController = col.GetComponentInParent<BusketController>();
                lookAtFinger = col.GetComponentInParent<LookAtFinger>();
                PreparePulling();
                _posBaskcur = busketController.pos;
                _posBaskprev = basketSpawner.basketSpawn[basketSpawner.basketSpawn.Count - 2].transform.position;
                if (_posBaskprev != _posBaskcur)
                {
                    _scoreSustr++;
                    _score +=_scoreSustr;
                    basketSpawner.PointsOfset();
                    progressManager.AddScore(_score);
                    _border.position = new Vector3(0, transform.position.y, 0);
                    if (_scoreSustr == 1) _announText = "+ " + _scoreSustr.ToString();
                    else _announText = "PERFECT + " + _scoreSustr.ToString();
                    uiController.AnnounceActivate(_announText, _posBaskcur);
                    busketController.SetGrayBasketring();
                }
                busketController.BlenderAnim(2.5f);
                break;
            case "death":
                gameObject.tag = "dead";
                cam.Follow = null;
                uiController.Lose();
                break;
            case "lowBasket":
                busketController.BlenderAnim(-2.5f);
                break;
            case "BasketRing":
                _scoreSustr = 0;
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "pullPoint":
                Pulling();
                break;
        }
    }
    private async void PreparePulling()
    {
        uiController.LogoGameActive();
        await Task.Delay(500);
        isFlying = false;
        DesactivateRb();
        print(isFlying);
    }
    private void Pulling()
    {
        isFlying = true;
        ActivateRb();
        print(isFlying);
    }
    public void DesactivateRb()
    {
        //rb.velocity = Vector3.zero;
        //rb.angularVelocity = 0f;
        //Destroy(rb);
        //gameObject.transform.SetParent(busketController.GetComponent<Transform>());
        
        //rb.isKinematic = true;
    }
}

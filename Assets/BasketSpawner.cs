using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BasketSpawner : MonoBehaviour
{
    public List<Vector2> pointsSpawn;
    public List<GameObject> basketSpawn;
    private BorderHandler _borderHandler;
    private Vector2 _leftP;
    private Vector2 _rightP;
    private Vector2 _upP;
    private Vector2 _downP;
    private int _i;
    private int _j;
    [SerializeField] private GameObject basketPref;
    void Start()
    {
        SpawnP();
        _j = 2;
    }
    private async void SpawnP()
    {
        pointsSpawn = new List<Vector2>();
        await Task.Delay(100);
        _borderHandler = gameObject.GetComponentInParent<BorderHandler>();

        _leftP = _borderHandler.leftBorder.transform.localPosition;
        _rightP = _borderHandler.rightBorder.transform.localPosition;
        _upP = _borderHandler.upBorderPoint;
        _downP = _borderHandler.downBorderPoint;
        var offsetX = Vector2.Distance(_leftP, _rightP)/3.5f;
        var offsetY = Vector2.Distance(_upP, _downP);
        pointsSpawn.Add(new Vector2(_leftP.x + offsetX, _leftP.y-offsetY/8));
        pointsSpawn.Add(new Vector2(_rightP.x - offsetX, _rightP.y - offsetY/24));

        basketSpawn.Add(Instantiate(basketPref, pointsSpawn[0], Quaternion.identity));
        basketSpawn.Add(Instantiate(basketPref, pointsSpawn[1], Quaternion.identity));
    }
    public async void PointsOfset()
    {
        var ofs = 2f * (pointsSpawn[_i + 1].y - pointsSpawn[_i].y);
        pointsSpawn.Add(new Vector2(pointsSpawn[_i].x, pointsSpawn[_i].y + ofs));
        pointsSpawn.Add(new Vector2(pointsSpawn[_i + 1].x, pointsSpawn[_i + 1].y + ofs));
        basketSpawn[_j - 2].GetComponent<Animator>().SetBool("isDisapear", true);
        basketSpawn.Add(Instantiate(basketPref, pointsSpawn[_j], Quaternion.identity));
        await Task.Delay(100);
        basketSpawn[_j - 2].GetComponent<Animator>().SetBool("isDisapear", false);
        _i += 2;
        _j++;
    }
    
    void Update()
    {
        
    }
}

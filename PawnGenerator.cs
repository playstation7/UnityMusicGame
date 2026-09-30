using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PawnGenerator : MonoBehaviour
{
    
    [SerializeField] GameObject _shortPawn;
    [SerializeField] GameObject _longPawn;
    [SerializeField] Queue<GameObject> _pawns = new Queue<GameObject>(5);
    [SerializeField] float _yPos;
    [SerializeField] Transform _notes;
    WeightedType[] _weightedTypes;
    float _startPos;
    float _endPos;

    private void Awake()
    {
        _weightedTypes = LevelSelector.Instance.levelDetail.weightedTypes;
        for (int i = 0; i < 30; i++)
        {
            GameObject pawn;
            switch (GetRandomWeightedPrefab(_weightedTypes)) 
            {
                
                case PawnTypes.ShortPawn:
                    pawn = Instantiate(_shortPawn,_notes);
                    pawn.SetActive(false);
                    _pawns.Enqueue(pawn); break;
                case PawnTypes.LongPawn:
                    pawn = Instantiate(_longPawn, _notes);
                    pawn.SetActive(false);
                    _pawns.Enqueue(pawn); break;
            }
        }
        _startPos = GameSettings.startPosSpawn;
        _endPos = GameSettings.endPosSpawn;
        StartCoroutine("Generate");
    }


    IEnumerator Generate() 
    {

        while (true) 
        {
            GameObject gameObj = _pawns.Dequeue();
            gameObj.SetActive(true);
            gameObj.GetComponent<PawnController>().startPos = new Vector3(_startPos, _yPos, 0f);
            gameObj.GetComponent<PawnController>().targetPos = new Vector3(_endPos, _yPos, 0f);
            _pawns.Enqueue(gameObj);
            yield return new WaitForSeconds(2f);
           

        }
    }



    private PawnTypes GetRandomWeightedPrefab(WeightedType[] prefabs)
    {
        float totalWeight = 0f;

        foreach (var item in prefabs)
            totalWeight += item.weight;

        float randomValue = Random.Range(0, totalWeight);
        float cumulativeWeight = 0f;

        foreach (var item in prefabs)
        {
            cumulativeWeight += item.weight;
            if (randomValue <= cumulativeWeight)
                return item.type;
        }

        // fallback (на случай ошибки)
        return prefabs[0].type;
    }







    //    public GameObject[] buttons;
    //    public GameObject[] longButtons;
    //    public GameObject[] centrals;
    //    public Transform parentCanvas;
    //    public Queue<GameObject> shortPawns;
    //    public Queue<GameObject> longPawns;
    //    public float[] spectrum;
    //    public AudioSource audioSource;
    //    float startPos;
    //    float endPos;

    //    public static UnityAction<float> scaleSeter;
    //    private void Awake()
    //    {
    //        startPos = GameSettings.startPosSpawn;
    //        endPos = GameSettings.endPosSpawn;



    //    }
    //    private void Update()
    //    {
    //        PoolManager.delayDecrease(Time.deltaTime);
    //        spectrum = new float[64];
    //        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
    //        float scale = spectrum.Sum(); 


    //        if (scale > 0.3f) 
    //        {
    //            GenerateInternal();
    //        }
    //        scaleSeter.Invoke(scale);


    //    }

    //    void GenerateInternal() 
    //    {
    //        float delayTime = 0.5f;
    //        GameObject[] objes = buttons;
    //        if (Random.Range(0, 10) == 0)
    //        {
    //            objes = longButtons;
    //            delayTime = 2.5f;
    //        }
    //        GameObject gj;
    //        switch (PoolManager.getFreePool())
    //        {

    //            case 0:
    //                gj = Instantiate(objes[0], parentCanvas);

    //                gj.GetComponent<PawnController>().startPos = new Vector3(startPos, -60f, 0f);
    //                gj.GetComponent<PawnController>().targetPos = new Vector3(endPos, -60f, 0f);
    //                centrals[0].GetComponent<CenterController>().pawns.Enqueue(gj);
    //                PoolManager.upPoolDelay = delayTime;
    //                PoolManager.delayDecrease(-0.2f);
    //                break;
    //            case 1:
    //                gj = Instantiate(objes[1], parentCanvas);
    //                gj.GetComponent<PawnController>().startPos = new Vector3(startPos, -190f, 0f);
    //                gj.GetComponent<PawnController>().targetPos = new Vector3(endPos, -190f, 0f);
    //                centrals[1].GetComponent<CenterController>().pawns.Enqueue(gj);
    //                PoolManager.leftPoolDelay = delayTime;
    //                PoolManager.delayDecrease(-0.2f);
    //                break;
    //            case 2:
    //                gj = Instantiate(objes[2], parentCanvas);
    //                gj.GetComponent<PawnController>().startPos = new Vector3(startPos, -320f, 0f);
    //                gj.GetComponent<PawnController>().targetPos = new Vector3(endPos, -320f, 0f);
    //                centrals[2].GetComponent<CenterController>().pawns.Enqueue(gj);
    //                PoolManager.rightPoolDelay = delayTime;
    //                PoolManager.delayDecrease(-0.2f);
    //                break;
    //            case 3:
    //                gj = Instantiate(objes[3], parentCanvas);
    //                gj.GetComponent<PawnController>().startPos = new Vector3(startPos, -450f, 0f);
    //                gj.GetComponent<PawnController>().targetPos = new Vector3(endPos, -450f, 0f);
    //                centrals[3].GetComponent<CenterController>().pawns.Enqueue(gj);
    //                PoolManager.downPoolDelay = delayTime;
    //                PoolManager.delayDecrease(-0.2f);
    //                break;
    //            case -1:
    //                break;
    //        }






    //}


    //    class PoolManager : MonoBehaviour
    //    {
    //        public static float upPoolDelay = 0f;
    //        public static float leftPoolDelay = 0f;
    //        public static float rightPoolDelay = 0f;
    //        public static float downPoolDelay = 0f;

    //        public static void delayDecrease(float deltaTime)
    //        {
    //            upPoolDelay = Mathf.Clamp(upPoolDelay - deltaTime, 0f, float.MaxValue);
    //            leftPoolDelay = Mathf.Clamp(leftPoolDelay - deltaTime, 0f, float.MaxValue);
    //            rightPoolDelay = Mathf.Clamp(rightPoolDelay - deltaTime, 0f, float.MaxValue);
    //            downPoolDelay = Mathf.Clamp(downPoolDelay - deltaTime, 0f, float.MaxValue);
    //        }


    //        public static int getFreePool()
    //        {
    //            List<int> freePoolsIndex = new List<int>();
    //            if (upPoolDelay == 0f) freePoolsIndex.Add(0);
    //            if (leftPoolDelay == 0f) freePoolsIndex.Add(1);
    //            if (rightPoolDelay == 0f) freePoolsIndex.Add(2);
    //            if (downPoolDelay == 0f) freePoolsIndex.Add(3);
    //            return freePoolsIndex.Count > 0 ? freePoolsIndex[Random.Range(0, freePoolsIndex.Count)] : -1;

    //        }
    //    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;


class GameSettings : MonoBehaviour
{
    public static float spawnDelay = 0.1f;
    public static float longPawnActivateTime = 0.8f;
    public static float pawnSpeed = 0.1f;//0.1f
    public static float startPosSpawn = 3300f;
    public static float endPosSpawn = -3300f;
    public static int MaxPeopleCrowd = 20;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class Wings : MonoBehaviour
{
    [SerializeField] private MMFeedbacks flapFeedback;
    //[SerializeField] private MMFeedbacks flapFeedback2;
    Player player;
    MenuManager menuManager;
    private int duration;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        menuManager = FindObjectOfType<MenuManager>();
        CheckUpgradeState(SaveManager.Instance.Load().wings);
    }
    void Start()
    {
        menuManager.SpawnWingsIcon();
    }

    void Update()
    {
        player.MoveToFlyingPoint();
    }
    void CheckUpgradeState(int wings)
    {
        for (int i = 0; i < 4; i++)
        {
            if (wings == i)
            {
                duration = 7 + (i * 3);
            }
        }
    }
    public void PlayFlapVFX()
    {
        flapFeedback?.PlayFeedbacks();
        //flapFeedback2?.PlayFeedbacks();
    }

    public int GetDuration()
    {
        return duration;
    }
    public void DestroyWings()
    {
        player.WingsOff();
        menuManager.DestroyWingsIcon();
        Destroy(gameObject, 0.1f);
    }
}

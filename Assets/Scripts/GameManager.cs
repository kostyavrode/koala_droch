using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    MENU=0,
    PLAYING=1,
    SHOP=2
}
public class GameManager : MonoBehaviour
{
    public Rotator rotator;
    public Animator animator;
    public GameObject ballThrower;
    public Transform playerTransform;
    private Vector3 playerStartPosition;
    private void Awake()
    {
        playerStartPosition = playerTransform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartRunGame();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            StopRunGame();
        }
    }
    public void StopRunGame()
    {
        animator.SetBool("isRun", false);
        playerTransform.position = playerStartPosition;
        rotator.enabled = false;
        ballThrower.SetActive(false);
    }
    public void StartRunGame()
    {
        animator.SetBool("isRun",true);
        StartCoroutine(WaitToStartMove());
    }
    public IEnumerator WaitToStartMove()
    {
        yield return new WaitForSeconds(1);
        rotator.enabled = true;
        ballThrower.SetActive(true);
    }
}

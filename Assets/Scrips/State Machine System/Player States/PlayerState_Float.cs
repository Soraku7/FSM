using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/StateMachine/PlayerState/Float" , fileName = "PlayerState_Float")]
public class PlayerState_Float : PlayerState
{
    [SerializeField] VoidEventChannel playerDefeatEventChannel;
    [SerializeField] private float floatingSpeed = 0.5f;
    [SerializeField] private Vector3 floatingPositionOffset;
    [SerializeField] private Vector3 vfxOffset;
    [SerializeField] private ParticleSystem vfx;
    Vector3 floatingPosition;
    public override void Enter()
    {
        base.Enter();

        playerDefeatEventChannel.Broadcast();
        Transform playerTransform = player.transform;
        Vector3 vfxPosition = playerTransform.position + new Vector3(playerTransform.localScale.x * vfxOffset.x, vfxOffset.y);

        Instantiate(vfx, vfxPosition, Quaternion.identity, playerTransform);

        floatingPosition = player.transform.position + floatingPositionOffset;
    }

    public override void LogicUpdate()
    {
        Transform playerTransform  = player.transform;

        if (Vector3.Distance(playerTransform.position, floatingPosition) > floatingSpeed * Time.deltaTime)
        {
            playerTransform.position = Vector3.MoveTowards(playerTransform.position, floatingPosition, floatingSpeed * Time.deltaTime);
        }
        else
        {
            floatingPosition += (Vector3)Random.insideUnitCircle;
        }
    }
}

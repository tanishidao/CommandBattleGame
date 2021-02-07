using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class DollyCameraManager : MonoBehaviour
{
    public GameMainManager gameMainManager;
    public CinemachineDollyCart CinemachineDollyCart;
    public CinemachineVirtualCamera CinemachineVirutualCamera;
    public CinemachineSmoothPath[] playerSmoothPaths = new CinemachineSmoothPath[3];
    public float CameraSpeed = 10f;

    public bool IsMoving = false;
    public bool IsMoveEnd = false;

    private Vector3 currentCameraLocalEulerAngeles;

    private void Awake()
    {
        currentCameraLocalEulerAngeles = CinemachineVirutualCamera.transform.localEulerAngles;
    }

    public void StatrtCameraAction(int characterPos)
    {
        IsMoving = true;
        IsMoveEnd = false;
        CinemachineDollyCart.m_Speed = CameraSpeed;
        CinemachineDollyCart.m_Path = playerSmoothPaths[characterPos];
    }
    //camera終了
    public void EndCameraAction()
    {
        if(CinemachineVirutualCamera.transform.localEulerAngles != currentCameraLocalEulerAngeles)
        {
            CinemachineVirutualCamera.transform.localEulerAngles = currentCameraLocalEulerAngeles;
        }
        CinemachineDollyCart.m_Speed = 0f;
        CinemachineDollyCart.m_Position = 0f;
        IsMoving = false;
    }
    //カメラ移動
    public IEnumerator WaitCameraEnd()
    {
        yield return new WaitWhile(() => CinemachineDollyCart.m_Position != CinemachineDollyCart.m_Path.PathLength);
        yield return new WaitUntil(() => CinemachineDollyCart.m_Position == CinemachineDollyCart.m_Path.PathLength);
        IsMoveEnd = true;
    }
    public void AttackCameraRotate()
    {
        var attackerCameraRotate = CinemachineVirutualCamera.transform.localEulerAngles;
        attackerCameraRotate.y = -180f;
        CinemachineVirutualCamera.transform.localEulerAngles = attackerCameraRotate;

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainManager : MonoBehaviour
{
    public enum State
    {
        Init,
        Start,
        Command,
       CameraAction,
        Action,
        Result,
    }
    public State GameState = State.Init;

    public GameParamUIPresenter gameParamUIPresenter;/// <summary>
    /// 名前間違えてるけどなんかこれでいいかも、呼び出しの際間違えずに！！！
    /// </summary>

    public CharacterParamManager[] CharacterParamManagers = new CharacterParamManager[3];

    public WaitGaugeViewer waitGaugeViewer;

    private CharacterParam[] characterParams = new CharacterParam[3];

    private int fastCharacterPos = 0;
    
    public CharacterParamManager EnemyCharacterParamManager = null;

    public DollyCameraManager DollyCameraManager;

    private void Update()
    {
       if(EnemyCharacterParamManager.CharacterHP < 0)
        {
            GameState = State.Result;
        }

        switch (GameState)
        {
            case State.Init:
                for (int i = 0; i < 3; i++)
                {
                    if (CharacterParamManagers[i] != null)
                    {
                        CharacterParamManagers[i].CharacterParam.CharacterPos = i;
                        characterParams[i] = CharacterParamManagers[i].CharacterParam;
                    }
                }
                gameParamUIPresenter.SetCharacterparamViewer(characterParams);
                GameState = State.Start;
                break;
            case State.Start:
                for (int i = 0; i < 3; i++)
                {
                    if (gameParamUIPresenter.CenterUIViewer.CheckCenterUIVisible(gameParamUIPresenter.WaitGaugeViewer.GetWaitGaugeRate(i)))
                    {
                        fastCharacterPos = i;
                        gameParamUIPresenter.CenterUIViewer.SetCenterUIVisible(true);
                        GameState = State.Command;
                    }

                }


                GameState = State.Command;
                break;
            case State.Command:
                gameParamUIPresenter.CenterUIViewer.SetCharacterActionButtons(characterParams[fastCharacterPos],
                    () =>
                    {
                        gameParamUIPresenter.WaitGaugeViewer.ResetWaitGaugeRate(fastCharacterPos);
                        GameState = State.CameraAction;
                    });
           
                break;
              case State.CameraAction:
                //カメラが動いてなかったら動かす
                if(!DollyCameraManager.IsMoving)
                {
                    DollyCameraManager.StatrtCameraAction(fastCharacterPos);
                    StartCoroutine(DollyCameraManager.WaitCameraEnd());
                }
                //カメラの動き終わったらGamestateを進める
                if(DollyCameraManager.IsMoveEnd)
                {
                   if(characterParams[fastCharacterPos].CharacterType == CharacterParam.GameCharacterType.Attacker)
                    {
                        Debug.Log("当たったかー");
                        DollyCameraManager.AttackCameraRotate();
                        GameState =State.Action;
                    }
                }

                GameState = State.Action;
                break;

            case State.Action:
              



                GameState = State.Start;
                break;
            case State.Result:
                Debug.Log("YOU WIN");
                break;
        }
    }
}

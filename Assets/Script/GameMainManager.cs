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
    private void Update()
    {
        switch (GameState)
        {
            case State.Init:
                for (int i = 0; i < 3; i++)
                {
                    if (CharacterParamManagers[i] != null)
                    {
                        characterParams[i] = CharacterParamManagers[i].CharacterParam;
                    }
                }
                gameParamUIPresenter.SetCharacterparamViewer(characterParams);
                GameState = State.Start;
                break;
            case State.Start:
                GetComponent<WaitGaugeViewer>();

                for (int i = 0; i < 3; i++)
                {
                    if (gameParamUIPresenter.CenterUIViewer.CheckCenterUIVisible(gameParamUIPresenter.WaitGaugeViewer.GetWaitGaugeRate(i)))
                    {
                        fastCharacterPos = i;
                        gameParamUIPresenter.CenterUIViewer.SetCenterUIVisible(true);
                        GameState = State.Command;
                    }
                   


                }

                
               GetComponent< WaitGaugeViewer>();
                
                //for (int i = 0;i < GetWaitGaugeRate[i]; i++)
                //{
                    
                //        CenterUIViewer.CheckCenterUIVisible(bool active);
                //            bool active = true;

                    

                //}



                GameState = State.Command;
                break;
            case State.Command:
                gameParamUIPresenter.CenterUIViewer.SetCharacterActionButtons(characterParams[fastCharacterPos],
                    ()=> gameParamUIPresenter.WaitGaugeViewer.ResetWaitGaugeRate(fastCharacterPos));
                GameState = State.Action;
                break;
            case State.Action:
                GameState = State.Start;
                break;
            case State.Result:
              
                break;
        }
    }
}

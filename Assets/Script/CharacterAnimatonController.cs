using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatonController : MonoBehaviour
{
    public Animator CharacterAnimator = null;

    private const string GotoMoveAnimationName = "GotoMove";

    private const string ReturnMoveAnimationName = "ReturnMove";

    private const string AttackAnimationName = "Attack";

    private const string IdleAnimationName = "Idle";

    public Transform CharacterRoot = null;

    public Transform AttackRoot = null;

    public CharacterParamManager characterParamManager = null;

    public CharacterParamManager Enemy = null;
    public CharacterParamManager targetCharacterParamManager = null;


    //<summary>
    /// <summary>
    /// 操作するキャラクタータイプ
    /// </summary>
    /// 
    public enum CharacterType
    {
        Invalide,
        Attacker,
        SpellCaster,
        Healer,
    }
    public CharacterType characterType = CharacterAnimatonController.CharacterType.Invalide;

    public object Damage { get; private set; }

    public void Awake()
    {
        CharacterAnimator = GetComponent<Animator>();

        CharacterParamManager Player = GetComponent<CharacterParamManager>();

    }
    public void StartAction()
    {

        StartCoroutine(StartAttackAnimation(2));

    }

    public IEnumerator StartAttackAnimation(int attackId)
    {
        if (characterType == CharacterType.Attacker)//charactorがアタッカーならば攻撃し、帰ってくる
        {
            yield return StartCoroutine(StartMove());
            yield return StartCoroutine(StartAnimation(attackId));
            yield return StartCoroutine(ReturnMove());
        }
        else
        {
            yield return StartCoroutine(StartAnimation(attackId));

        }

    }
    IEnumerator StartMove()
    {
        var distance_two = Vector3.Distance(transform.position, AttackRoot.position);
        var elapsedTime = 0f;
        var waitTime = 1f;
        SetAttackAnimation(1);
        while (elapsedTime < waitTime)
        {
            this.transform.position = Vector3.Lerp(transform.position, AttackRoot.position, (elapsedTime / waitTime) / distance_two);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator StartAnimation(int attackNo)///IEnumとcoroutineはセット
    {
        SetAttackAnimation(attackNo);
        ///attackNoが宣言（int)した
        if (characterType == CharacterType.Attacker)
        {
            yield return new WaitWhile(() => CharacterAnimator.GetCurrentAnimatorStateInfo(0).IsName(GotoMoveAnimationName));///待つ対象がIs.Name(GOto)になるはず        ///animatorStateはCharacterAnimator内にあるGetCurrentAnimatorStateInfとする
        }

        yield return new WaitWhile(() => CharacterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1f &&
        CharacterAnimator.GetCurrentAnimatorStateInfo(0).IsName(AttackAnimationName));///()がanimatorState内のnotmalizedTiemとし1f以下の場合、かつanimatorStateの名前がttackAnimationNameの場合の時、待つ、繰り替えす。
        CharacterAnimator.SetInteger(AttackAnimationName, 0);///CharacterAnimator内のSetIntegerが
    }

    IEnumerator ReturnMove()
    {
        var distane_two = Vector3.Distance(transform.position, CharacterRoot.position);
        var elapsedTime = 0f;
        float waitTime = 1f;
        while (this.transform != CharacterRoot && elapsedTime < waitTime)
        {
            this.transform.position = Vector3.Lerp(transform.position, CharacterRoot.position, (elapsedTime / waitTime) / distane_two);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    public void SetAttackAnimation(int attackNo)
    {
        Debug.Log(attackNo);
        if (CharacterAnimator == null)
        {
            return;
        }
        CharacterAnimator.SetInteger(AttackAnimationName, attackNo);
    }

    public void Hit()
    {


        Debug.Log("あたった");

        ///相手のCharacterManagerを取得して相手のcharacterああああ
        targetCharacterParamManager = AttackRoot.transform.parent.GetComponentInChildren<CharacterParamManager>();

        var damage = characterParamManager.CharacterAttack;

        if (characterParamManager.ButtonNo == 1)
        {
            damage *= 10;
            characterParamManager.CharacterMP -= 10;
        }

        if(characterType == CharacterType.Healer|| characterParamManager.ButtonNo == 3)
        {
            damage *= -10;
            characterParamManager.CharacterMP -= 10;
        }

        targetCharacterParamManager.Damage(damage);


    }

}

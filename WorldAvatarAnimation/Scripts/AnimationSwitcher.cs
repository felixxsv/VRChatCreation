
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class AnimationSwitcher : UdonSharpBehaviour
{
    [Header("------------------------------------------------------------------")]
    [Header("■■■　アニメーション切り替えスイッチ　■■■")]
    [Header("------------------------------------------------------------------")]
    
    [Space(20)]

    [Header("AnimationはKuutaオブジェクトにアニメーターを入れてね！")]

    [Space(10)]

    [Header("アバターを入れてね！")]
    [SerializeField] private GameObject avatar;

    [Header("アニメーションの最大数を入力してね！")]
    [SerializeField] private int maxNumberOfAnimation = 10;

    [Header("アニメーションの初期値を入力してね！")]
    [SerializeField]private int defaultAnimationNumber = 0;

    private Animator animator;
    private int n;

    void Start()
    {
        this.n = this.defaultAnimationNumber;
        this.animator = this.avatar.GetComponent<Animator>();
        this.animator.SetInteger("animationNumber", this.n);
    }

    public override void Interact()
    {
        toggleAnimation();
        Debug.Log(this.n);
    }

    void toggleAnimation()
    {
        if(this.n < maxNumberOfAnimation - 1)
        {
            this.n++;
            this.animator.SetInteger("animationNumber", this.n);
        }else
        {
            this.n = 0;
            this.animator.SetInteger("animationNumber", this.n);
        }
    }
}

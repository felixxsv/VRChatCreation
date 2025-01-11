
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
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
    [UdonSynced] private int n = 0;

    void Start()
    {
        if (Networking.IsOwner(this.gameObject))
        {
            this.n = this.defaultAnimationNumber;
            RequestSerialization();
        }
        if (this.avatar == null)
        {
            Debug.LogError("Avatar is not assigned!");
            return;
        }
        this.animator = this.avatar.GetComponent<Animator>();
        if (this.animator == null)
        {
            Debug.LogError("Animator component not found!");
            return;
        }
        this.animator.SetInteger("animationNumber", this.n);
    }

    public override void Interact()
    {
        if (!Networking.IsOwner(this.gameObject))
        {
            Networking.SetOwner(Networking.LocalPlayer, this.gameObject);
        }
        countingNumber();
        RequestSerialization();
        toggleAnimation();
        Debug.Log(this.n);
    }

    public override void OnDeserialization()
    {
        //同期変数を受信した側でも更新する
        toggleAnimation();
    }

    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        if (Networking.IsOwner(this.gameObject))
        {
            RequestSerialization();
        }
    }

        void countingNumber()
    {
        if(this.n < maxNumberOfAnimation - 1)
        {
            this.n++;
        }
        else
        {
            this.n = 0;
        }
    }

    void toggleAnimation()
    {
        this.animator.SetInteger("animationNumber", this.n);
    }
}

using Lofle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{

    public enum eSprite
    {
        Idle,
        Run_L,
        Run_R,
        Clean_L,
        Clean_R,
        Hit
    }

    [SerializeField]
    private Rigidbody2D _rigidbody = null;


    [SerializeField]
    private GameObject _spriteIdle = null;
    [SerializeField]
    private GameObject _spriteRun_L = null;
    [SerializeField]
    private GameObject _spriteRun_R = null;
    [SerializeField]
    private GameObject _spriteClean_L = null;
    [SerializeField]
    private GameObject _spriteClean_R = null;
    [SerializeField]
    private GameObject _spriteHit = null;

    bool Hiting = false;
    float delta = 0.0f;


    private StateMachine<PlayerObject> _stateMachine = null;


    [SerializeField]
    private float _speed = 2.0f;


    //사운드


    private AudioSource Hitaudio;
    public AudioClip HitSound;

    private AudioSource runaudio;
    public AudioClip runSound;

    private AudioSource Cleanaudio;
    public AudioClip CleanSound;


    void Start()
    {
        this.Cleanaudio = this.gameObject.AddComponent<AudioSource>();
        this.Cleanaudio.clip = this.CleanSound;
        this.Cleanaudio.loop = false;

        this.Hitaudio = this.gameObject.AddComponent<AudioSource>();
        this.Hitaudio.clip = this.HitSound;
        this.Hitaudio.loop = true;

        this.runaudio = this.gameObject.AddComponent<AudioSource>();
        this.runaudio.clip = this.runSound;
        this.runaudio.loop = true;

    }
    //=======================================조작==================================================
    private void OnEnable()
    {
        _stateMachine = new StateMachine<PlayerObject>(this);
        StartCoroutine(_stateMachine.Coroutine<IdleState>());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Hiting = true;
        }
    }



    private void Move(bool bLeft)
    {
        Vector3 moveVelocity = Vector3.zero;
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
        }
        transform.position += moveVelocity * _speed * Time.deltaTime;

    }


    private void HideAllsptrite() // 숨김
    {
        _spriteIdle.SetActive(false);
        _spriteRun_L.SetActive(false);
        _spriteRun_R.SetActive(false);
        _spriteClean_L.SetActive(false);
        _spriteClean_R.SetActive(false);
        _spriteHit.SetActive(false);

    }

    private void Showsprite(eSprite type)
    {
        HideAllsptrite();   // 끈 후 작동

        switch (type)
        {
            case eSprite.Idle:
                _spriteIdle.SetActive(true);
                break;
            case eSprite.Run_L:
                _spriteRun_L.SetActive(true);
                break;
            case eSprite.Run_R:
                _spriteRun_R.SetActive(true);
                break;
            case eSprite.Clean_L:
                _spriteClean_L.SetActive(true);
                break;
            case eSprite.Clean_R:
                _spriteClean_R.SetActive(true);
                break;
            case eSprite.Hit:
                _spriteHit.SetActive(true);
                break;

        }
    }

    //======================================== 상태 전환 =====================================================

    private class IdleState : State<PlayerObject>
    {
        protected override void Begin()
        {
            Owner.Showsprite(eSprite.Idle);
        }

        protected override void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                Invoke<RunState>();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Invoke<CleanState>();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                Invoke<CleanState>();
            }

            //Hit 넣어야함
            if (Owner.Hiting == true)
                Invoke<AttackState>();

        }

        protected override void End()
        {

        }
    }
    private class RunState : State<PlayerObject>
    {
        protected override void Begin()
        {
            Owner.runaudio.Play();
        }

        protected override void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Owner.Showsprite(eSprite.Run_L);
                Owner.Move(true);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                Owner.Showsprite(eSprite.Run_R);
                Owner.Move(false);

            }
            else
            {
                Invoke<IdleState>();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Invoke<CleanState>();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                Invoke<CleanState>();
            }

            //Hit 넣어야함
            if (Owner.Hiting == true)
                Invoke<AttackState>();
        }

        protected override void End()
        {
            Owner.runaudio.Pause();
        }
    }

    private class CleanState : State<PlayerObject>
    {
        protected override void Begin()
        {
            Owner.Cleanaudio.Play();
        }

        protected override void Update()
        {
            if (Input.GetKey(KeyCode.Q))
            {
                Owner.Showsprite(eSprite.Clean_L);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                Owner.Showsprite(eSprite.Clean_R);

            }
            else
            {
                Invoke<IdleState>();
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Invoke<RunState>();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Invoke<RunState>();
            }

            //Hit 넣어야함
            if (Owner.Hiting == true)
                Invoke<AttackState>();
        }

        protected override void End()
        {

        }
    }

    private class AttackState : State<PlayerObject>
    {
        protected override void Begin()
        {
            Owner.Showsprite(eSprite.Hit);
            Owner.Hitaudio.Play();
        }

        protected override void Update()
        {
            //Hit 넣어야함

            Owner.delta += Time.deltaTime;


            if (Owner.delta > 3.0f)
            {
                Owner.delta = 0.0f;
               // Owner.gameObject.transform.position =new Vector3(0.0f, -2.74f, 0.0f);
                Owner.Hiting = false;
                Owner.Hitaudio.Pause();

                Invoke<IdleState>();
            }


        }
        protected override void End()
        {

        }
    }
}

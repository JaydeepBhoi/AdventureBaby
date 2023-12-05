using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SoundScript : MonoBehaviour {


	//public static AudioSource sound;
    public static AudioClip Bg_Sound;
	public static AudioClip jump_Sound;
    public static AudioClip Coins_Sound;
    public static AudioClip BrickDestroy_Sound;
    public static AudioClip Bullet_Sound;
    public static AudioClip Die_Sound;
    public static AudioClip TurtleJump_1;
    public static AudioClip TurtleJump_2;
    public static AudioClip Gun_Get;
    public static AudioClip Energy_Sound;


    public static AudioClip Brick_Sound;
	public static AudioClip CoinsStone_Sound;
	public static AudioClip Flower_Sound;
	public static AudioClip CoinEarned_Sound;
	public static AudioClip EnemyDie_Sound;
	public static AudioClip Firework_Sound;
    public static AudioSource source;

    public static SoundScript inst;

    public static int turn;
	public static bool hitOnce;

	// Use this for initialization
	void Start () 
	{
        //		Debug.Log("Turn"+turn);


        if (inst == null)
        {
            DontDestroyOnLoad(gameObject);

        }

        BrickDestroy_Sound = Resources.Load<AudioClip>("Brickbreak");
        Coins_Sound = Resources.Load<AudioClip>("Coin_Brick");
        jump_Sound = Resources.Load<AudioClip>("Jump");
        Bullet_Sound = Resources.Load<AudioClip>("Bullet_Sound");
        Die_Sound = Resources.Load<AudioClip>("Die_Sound");
        TurtleJump_1 = Resources.Load<AudioClip>("TurtleJump_1");
        TurtleJump_2 = Resources.Load<AudioClip>("TurtleJump_2");
        Gun_Get = Resources.Load<AudioClip>("Gun_Get");
        Energy_Sound = Resources.Load<AudioClip>("Energy_Sound");
        //tntBlast = Resources.Load<AudioClip>("Blast");
        source = GetComponent<AudioSource>();


        //hitOnce = true;
		//sound=GetComponent<AudioSource>();

        
	}
	
	// Update is called once per frame
	void Update ()
	{

	}


    public static void playsound(string clip)
    {

        switch (clip)
        {

            case "jump_Sound":

                source.PlayOneShot(jump_Sound);
                break;

            case "Coins_Sound":

                source.PlayOneShot(Coins_Sound);
                break;
            case "BrickDestroy_Sound":

                source.PlayOneShot(BrickDestroy_Sound);
                break;
            case "Bullet_Sound":

                source.PlayOneShot(Bullet_Sound);
                break;
            case "Die_Sound":

                source.PlayOneShot(Die_Sound);
                break;
            case "TurtleJump_1":

                source.PlayOneShot(TurtleJump_1);
                break;
            case "TurtleJump_2":

                source.PlayOneShot(TurtleJump_2);
                break;

            case "Gun_Get":

                source.PlayOneShot(Gun_Get);
                break;

            case "Energy_Sound":

                source.PlayOneShot(Energy_Sound);
                break;


        }

    }


}

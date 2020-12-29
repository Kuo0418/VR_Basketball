using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("分數介面")]
    public Text textScore;
    [Header("分數")]
    public int Score;
    [Header("投進的分數")]
    public int scoreIn = 2;
    [Header("進球音效")]
    public AudioClip soundIn;

    private AudioSource aud;

    private void Awake()
    {
        //音效來源 = 取得元件<音效來源>()
        aud = GetComponent<AudioSource>();
    }

    //OTE條件：
    //兩個碰撞物件其中一個必須勾選IsTrigger
    //要偵測此腳本子物件是否產生碰撞
    //必須添加鋼體 Rigidbody
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "籃球")
        {
            AddScore();
        }

        //如果碰撞的根物件名為Player
        if (other.transform.root.name == "Player")
        {
            //玩家進入三分區域，投進分數改為三分
            scoreIn = 3;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.name ==  "Player")
        {
            //投進分數改為兩分
            scoreIn = 2;
        }
    }

    /// <summary>
    /// 加分數
    /// </summary>
    private void AddScore()
    {
        Score += 2;                                      //分數遞增
        textScore.text = "分數：" + Score;    //更新介面
        aud.PlayOneShot(soundIn, Random.Range(1f, 2f));     //音效來源.播放一次(音效片段，音量)
    }
}

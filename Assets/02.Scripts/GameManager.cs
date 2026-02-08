using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timerText;
    public Text pointText;
    float time = 30.0f;
    int point = 0;

    public GameObject generator; // Generator 오브젝트를 가지 와서 직접 SetParameter 를 작동시키기 위한 변수

    void Start()
    {
        if (generator == null)
        {
            var ig = FindObjectOfType<ItemGenerator>();
            if (ig != null) generator = ig.gameObject;
        }
    }

    public void GetApple() {
        point += 100;
    }

    public void GetBomb() {
        point /= 2;
    }

    // Update is called once per frame
    void Update()
    {
        // 시간 관리
        // time -= Time.deltaTime;
        // if (timerText != null)
        //     timerText.text = time.ToString();
        // 점수 관리
        // if (pointText != null)
        //     pointText.text = point.ToString() + " Point";

        this.time -= Time.deltaTime;
        if (this.generator != null)
        {
            var ig = this.generator.GetComponent<ItemGenerator>();
            if (this.time < 0) {
                this.time = 0;
                ig.SetParameter(10000.0f, 0, 0f);
            } else if (0 <= this.time && this.time < 5) {
                ig.SetParameter(0.7f, 3, -0.04f);
            } else if (5 <= this.time && this.time < 10) {
                ig.SetParameter(0.5f, 6, -0.05f);
            } else if (10 <= this.time && this.time < 20) {
                ig.SetParameter(0.8f, 3, -0.04f);
            } else if (20 <= this.time && this.time < 30) {
                ig.SetParameter(1.0f, 2, -0.03f);
            }
        }
        if (this.timerText != null)
            this.timerText.text = ((int)this.time).ToString();
        if (this.pointText != null)
            this.pointText.text = this.point.ToString() + " point";
    }
}

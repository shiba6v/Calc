using UnityEngine;
using System.Collections;
using System;

public class segRay : MonoBehaviour {
    public GameObject sevenSeg;

    //シリアライズフィールドで全部書く
    //pをあつめる。


    [SerializeField]
    sevenSeg[] _sevenSeg1;
    [SerializeField]
    sevenSeg[] _sevenSeg2;
    [SerializeField]
    sevenSeg[] _sevenSeg3;
    [SerializeField]
    sevenSeg[] _sevenSeg4;

    bool[] _seg1 = new bool[7];
    bool[] _seg2 = new bool[7];
    bool[] _seg3 = new bool[7];
    bool[] _seg4 = new bool[7];

    int s1;
    int s2;
    int s3;
    int s4;

	public int numberInDisplay;
	bool[,] segCharacter;

	// Use this for initialization
	void Start () {
        /*
		segCharacter = new bool[4, 7];//digit num
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 7; j++) {
				segCharacter [i, j] = false;
			}
		}
  */      
		this.numberInDisplay = -1;
	}
	
	// Update is called once per frame
    void Update () {
        StartCoroutine(GetCoroutine());

        /*
		if (Input.GetMouseButtonDown (0)) {

			Vector3 pos = Input.mousePosition;
			Ray ray = Camera.main.ScreenPointToRay (pos);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 100f)) {
				
				GameObject obj = hit.collider.gameObject;
				sevenSeg seg = obj.GetComponent<sevenSeg>();
				Debug.Log("digit: " + this.get
                Digit(obj.name) + " num: " + this.getNum(obj.name));

				int digit = this.getDigit (obj.name);
				int num = this.getNum (obj.name);
                if(seg != null)
                {

                    if (!seg.p) {

                        segCharacter [digit, num] = true;
                        seg.push ();

                    } else {

                        segCharacter [digit, num] = false;
                        seg.unPush ();

                    }
                       
                }
				this.numberInDisplay = 0;
				for (int i = 0; i < 4; i++) {
					bool[] tmpCh = new bool[7];
					//for(int j = 0; j < tmpCh.Length; j++) tmpCh[j] = false;

					bool onceTrue = false;

					for (int j = 0; j < tmpCh.Length; j++) {
						tmpCh [j] = segCharacter [i, j];
						if (tmpCh [j])
							onceTrue = true;
					}
					
					int tmp = this.getValueFromSeg (tmpCh);
					if (tmp == -1) {
						if (onceTrue)
							numberInDisplay = -1;
						break;
					}
					this.numberInDisplay += tmp * (int)Math.Pow(10, i);
					Debug.Log (tmp + "--t" + (int)Math.Pow(10, i));

				}

				Debug.Log (this.numberInDisplay);
			}
   
		}
  */      

    }

    IEnumerator GetCoroutine()
    {
        if (Input.GetMouseButtonDown (0))
        {

            Vector3 pos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay (pos);
            RaycastHit hit;

            if (Physics.Raycast (ray, out hit, 100f)) {

                GameObject obj = hit.collider.gameObject;
                if(obj.GetComponent<sevenSeg>() != null)
                {
                    obj.GetComponent<sevenSeg>().Toggle();
                }
            }

            yield return null;
            for(int i= 0; i<7; i++)
            {
                _seg1[i]= _sevenSeg1[i].p; 
            }
            for(int i= 0; i<7; i++)
            {
                _seg2[i]= _sevenSeg2[i].p; 
            }
            for(int i= 0; i<7; i++)
            {
                _seg3[i]= _sevenSeg3[i].p; 
            }
            for(int i= 0; i<7; i++)
            {
                _seg4[i]= _sevenSeg4[i].p; 
            }

            s1 = getValueFromSeg(_seg1);
            s2 = getValueFromSeg(_seg2);
            s3 = getValueFromSeg(_seg3);
            s4 = getValueFromSeg(_seg4);

            if(s1 != -1 && s2 != -1 && s3 != -1 && s4 != -1)
            {
                numberInDisplay = s4 *1000 + s3*100 + s2*10 + s1;
            }
            else if(s1 != -1 && s2 != -1 && s3 != -1)
            {
                numberInDisplay = s3*100 + s2*10 + s1;
            }
            else if(s1 != -1 && s2 != -1)
            {
                numberInDisplay = s2*10 + s1;
            }
            else if(s1 != -1)
            {
                numberInDisplay = s1;
            }
            else
            {
                numberInDisplay = -1;
            }

        }




    }


	int getValueFromSeg(bool[] seg) {
		if (seg [0] && seg [1] && seg [2] && !seg [3] && seg [4] && seg [5] && seg [6])
			return 0;
		else if (seg [0] && seg [1] && !seg [2] && !seg [3] && !seg [4] && !seg [5] && !seg [6])
			return 1;
		else if (seg [0] && !seg [1] && seg [2] && seg [3] && seg [4] && !seg [5] && seg [6])
			return 2;
		else if (seg [0] && seg [1] && seg [2] && seg [3] && seg [4] && !seg [5] && !seg [6])
			return 3;
		else if (seg [0] && seg [1] && !seg [2] && seg [3] && !seg [4] && seg [5] && !seg [6])
			return 4;
		else if (!seg [0] && seg [1] && seg [2] && seg [3] && seg [4] && seg [5] && !seg [6])
			return 5;
		else if (!seg [0] && seg [1] && seg [2] && seg [3] && seg [4] && seg [5] && seg [6])
			return 6;
		else if (seg [0] && seg [1] && seg [2] && !seg [3] && !seg [4] && seg [5] && !seg [6])
			return 7;
		else if (seg [0] && seg [1] && seg [2] && seg [3] && seg [4] && seg [5] && seg [6])
			return 8;
		else if (seg [0] && seg [1] && seg [2] && seg [3] && seg [4] && seg [5] && !seg [6])
			return 9;
		else
			return -1;
	}

	int getNum(string str) {
		int num;

		char[] ch = str.ToCharArray ();
		char c = ch [8];

		if (c == '0')
			num = 0;
		else if (c == '1')
			num = 1;
		else if (c == '2')
			num = 2;
		else if (c == '3')
			num = 3;
		else if (c == '4')
			num = 4;
		else if (c == '5')
			num = 5;
		else num = 6;

		return num;
	}

	int getDigit(string str) {
		int num;

		char[] ch = str.ToCharArray ();
		char c = ch [5];

		if (c == '1')
			num = 0;
		else if (c == '2')
			num = 1;
		else if (c == '3')
			num = 2;
		else num = 3;

		return num;
	}


}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TxtManager : MonoBehaviour
{
    enum Language{
        English,
        Test_Kor,
    }
    public TextAsset txt;
    string[,] Sentence;
    int rowSize, colSize;

    public TextMeshProUGUI Text;

    //public Text Name;
    //public Text chat;
    public int currentLine = 0;

    private bool next = false;
    private bool can_talk = true;

    public int SetL = 0; // ENG default 변수명 임시임 나중에 생각해보기기
    
    void Start()
    {
        //Name.GetComponent<Text>();
        //chat.GetComponent<Text>();

        string currentText = txt.text.Trim(); 
        string[] lines = currentText.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries); 
        
        rowSize = lines.Length;
        colSize = lines[0].Split('\t').Length;

        Sentence = new string[rowSize, colSize];


        for (int i = 0; i < rowSize; i++)
        {
            string[] columns = lines[i].Split('\t');
            for (int j = 0; j < colSize; j++)
            {
                if (j < columns.Length)
                {
                    Sentence[i, j] = columns[j];
                }
                else
                {
                    Sentence[i, j] = "";
                }
                Debug.Log(i + "," + j + "," + Sentence[i, j]);
            }
        }
        //strar_chat();
    }

    void strar_chat(){
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (currentLine < rowSize)
        {
            //Name.text = Sentence[currentLine, 1];
            //chat.text = Sentence[currentLine, 2];
        }

        /*
        if(Sentence[currentLine,3]=="1"){
            re.SetActive(true);
        }
        */
        if(Sentence[currentLine+1,2]!="end"){
            currentLine++;
        }
    }

    IEnumerator next_scence(){
        yield return new WaitForSeconds(2);
        //Loading.SetActive(true);
    }
    IEnumerator next_talk(){
        yield return new WaitForSeconds(2);
        DisplayNextSentence();
        yield return new WaitForSeconds(2);
        can_talk = true;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)  && can_talk)
        {
            DisplayNextSentence();
        }

        Text.text = Sentence[1, SetL];
    }

    public void ENGButton()
    {
        SetLanguage(0);
    }
    public void KORButton()
    {
        SetLanguage(1);
    }

    private void SetLanguage(int language)
    {
        switch(language)
        {
            case 0:
                SetL = 0;
                break;
            case 1:
                SetL = 1;
                break;
        }
    }
}
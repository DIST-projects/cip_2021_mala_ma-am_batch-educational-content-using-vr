using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject giraffe, lion, elephant, monkey, big1, big2, small1, small2;
    Vector2 giraffeInitialPos, lionInitialPos, elephantInitialPos, monkeyInitialPos;
    public AudioSource source;
    public AudioClip[] correct;
    public AudioClip incorrect;
    public AudioClip win;
    bool giraffeCorrect= false,lionCorrect= false,elephantCorrect= false,monkeyCorrect = false;
    // Start is called before the first frame update
    void Start()
    {
        giraffeInitialPos=giraffe.transform.position;
        lionInitialPos=lion.transform.position;
        elephantInitialPos=elephant.transform.position;
        monkeyInitialPos=monkey.transform.position;
    }

    public void DragGiraffe()
    {
        giraffe.transform.position=Input.mousePosition;
    }
    public void DropGiraffe()
    {
        float Distance1=Vector3.Distance(giraffe.transform.position,big1.transform.position);
        float Distance2=Vector3.Distance(giraffe.transform.position,big2.transform.position);
        if(Distance1<50){
        giraffe.transform.position=big1.transform.position;
        source.clip=correct[Random.Range(0,correct.Length)];
        source.Play();
        giraffeCorrect=true;
        }
        else if(Distance2<50){
        giraffe.transform.position=big2.transform.position;
        source.clip=correct[Random.Range(0,correct.Length)];
        source.Play();
        giraffeCorrect=true;
        }
        else{
        giraffe.transform.position=giraffeInitialPos;
        source.clip=incorrect;
        source.Play();
        }
    }

    public void DragElephant()
    {
        elephant.transform.position=Input.mousePosition;
    }
    public void DropElephant()
    {
        float Distance1=Vector3.Distance(elephant.transform.position,big1.transform.position);
        float Distance2=Vector3.Distance(elephant.transform.position,big2.transform.position);
        if(Distance1<50){
        elephant.transform.position=big1.transform.position;
        source.clip=correct[Random.Range(0,correct.Length)];
        source.Play();
        elephantCorrect=true;
        }
        else if(Distance2<50){
        elephant.transform.position=big2.transform.position;
        source.clip=correct[Random.Range(0,correct.Length)];
        source.Play();
        elephantCorrect=true;
        }
        else{
        elephant.transform.position=elephantInitialPos;
        source.clip=incorrect;
        source.Play();
        }
    }

    public void DragLion()
    {
        lion.transform.position=Input.mousePosition;
    }
    public void DropLion()
    {
        float Distance1=Vector3.Distance(lion.transform.position,small1.transform.position);
        float Distance2=Vector3.Distance(lion.transform.position,small2.transform.position);
        if(Distance1<50){
        lion.transform.position=small1.transform.position;
        source.clip=correct[Random.Range(0,correct.Length)];
        source.Play();
        lionCorrect=true;
        }
        else if(Distance2<50){
        lion.transform.position=small2.transform.position;
        source.clip=correct[Random.Range(0,correct.Length)];
        source.Play();
        lionCorrect=true;
        }
        else{
        lion.transform.position=lionInitialPos;
        source.clip=incorrect;
        source.Play();
        }
    }

    public void DragMonkey()
    {
        monkey.transform.position=Input.mousePosition;
    }
    public void DropMonkey()
    {
        float Distance1=Vector3.Distance(monkey.transform.position,small1.transform.position);
        float Distance2=Vector3.Distance(monkey.transform.position,small2.transform.position);
        if(Distance1<50){
        monkey.transform.position=small1.transform.position;
        source.clip=correct[Random.Range(0,correct.Length)];
        source.Play();
        monkeyCorrect=true;
        }
        else if(Distance2<50){
        monkey.transform.position=small2.transform.position;
        source.clip=correct[Random.Range(0,correct.Length)];
        source.Play();
        monkeyCorrect=true;
        }
        else{
        monkey.transform.position=monkeyInitialPos;
        source.clip=incorrect;
        source.Play();
        }
    }
    void Update()
    {
        if(giraffeCorrect && elephantCorrect && lionCorrect && monkeyCorrect)
        {
            Debug.Log("You Win!!");
            // source.clip=win;
            // source.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    public GameObject elephant,lion,tiger,monkey,giraffe,sparrow,peacock,parrot,eagle,duck,animal,bird,elephantdest,liondest,tigerdest,monkeydest,giraffedest,sparrowdest,peacockdest,parrotdest,eagledest,duckdest;
    Vector2 elephantip,lionip,tigerip,monkeyip,giraffeip,sparrowip,peacockip,parrotip,eagleip,duckip;
    public GameObject panel;
    public AudioSource source;
    public Transform dest;
    public AudioClip elephant_s,lion_s,tiger_s,monkey_s,giraffe_s,sparrow_s,peacock_s,parrot_s,eagle_s,duck_s;
    // public AudioClip win;
    public float moveSpeed;
    private int flag;
    int count=0;
    void Start()
    {
        elephantip=elephant.transform.position;
        lionip=lion.transform.position;
        tigerip=tiger.transform.position;
        monkeyip=monkey.transform.position;
        giraffeip=giraffe.transform.position;
        sparrowip=sparrow.transform.position;
        peacockip=peacock.transform.position;
        parrotip=parrot.transform.position;
        eagleip=eagle.transform.position;
        duckip=duck.transform.position;
    }

    void DrawLine(Vector3 start, Vector3 end)
         {
             GameObject myLine = new GameObject();
             myLine.transform.position = start;
             myLine.AddComponent<LineRenderer>();
             LineRenderer lr = myLine.GetComponent<LineRenderer>();
             Color c1 = Color.red;
             //Color c1 = new Color(1, 1, 1, 0);
             lr.material = new Material(Shader.Find("Sprites/Default"));
             //lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
             lr.SetColors(c1, c1);
             lr.SetWidth(0.1f, 0.1f);
             lr.SetPosition(0, start);
             lr.SetPosition(1, end);
             //GameObject.Destroy(myLine, duration);
         }
    public void clickGiraffe()
    {
        //giraffe.transform.position=giraffedest.transform.position;
        flag = 1;
        //cube.transform.position = Vector3.MoveTowards(cube.transform.position,dest.position,moveSpeed * Time.deltaTime);       
        source.clip=giraffe_s;
        source.Play();
        count++;
        DrawLine(animal.transform.position,giraffedest.transform.position);
    }
    public void clickElephant()
    {
        flag = 2;
        //elephant.transform.position=elephantdest.transform.position;
        source.clip=elephant_s;
        source.Play();
        count++;
        DrawLine(animal.transform.position,elephantdest.transform.position);
    }
    public void clickLion()
    {
        flag=3;
        //lion.transform.position=liondest.transform.position;
        source.clip=lion_s;
        source.Play();
        count++;
        DrawLine(animal.transform.position,liondest.transform.position);
    }
    public void clickTiger()
    {
        flag=4;
        //tiger.transform.position=tigerdest.transform.position;
        source.clip=tiger_s;
        source.Play();
        count++;
        DrawLine(animal.transform.position,tigerdest.transform.position);
    }
    public void clickMonkey()
    {
        flag=5;
        //monkey.transform.position=monkeydest.transform.position;
        source.clip=monkey_s;
        source.Play();
        count++;
        DrawLine(animal.transform.position,monkeydest.transform.position);
    }
    public void clickSparrow()
    {
        flag=6;
        //sparrow.transform.position=sparrowdest.transform.position;
        source.clip=sparrow_s;
        source.Play();
        count++;
        DrawLine(bird.transform.position,sparrowdest.transform.position);
    }
    public void clickPeacock()
    {
        flag=7;
        //peacock.transform.position=peacockdest.transform.position;
        source.clip=peacock_s;
        source.Play();
        count++;
        DrawLine(bird.transform.position,peacockdest.transform.position);
    }
    public void clickParrot()
    {
        flag=8;
        //parrot.transform.position=parrotdest.transform.position;
        source.clip=parrot_s;
        source.Play();
        count++;
        DrawLine(bird.transform.position,parrotdest.transform.position);
    }
    public void clickEagle()
    {
        flag=9;
        //eagle.transform.position=eagledest.transform.position;
        source.clip=eagle_s;
        source.Play();
        count++;
        DrawLine(bird.transform.position,eagledest.transform.position);
    }
    public void clickDuck()
    {
        flag=10;
        //duck.transform.position=duckdest.transform.position;
        source.clip=duck_s;
        source.Play();
        count++;
        DrawLine(bird.transform.position,duckdest.transform.position);
    }




void Update(){
        if(count>9){
        Debug.Log("Well Done!!");
        panel.SetActive(true);
        }
        if(flag == 1){
            giraffe.transform.position = Vector3.MoveTowards(giraffe.transform.position,giraffedest.transform.position,moveSpeed * Time.deltaTime);
        }
        if(flag == 2)
        elephant.transform.position = Vector3.MoveTowards(elephant.transform.position,elephantdest.transform.position,moveSpeed * Time.deltaTime);
        if(flag == 3)
        lion.transform.position = Vector3.MoveTowards(lion.transform.position,liondest.transform.position,moveSpeed * Time.deltaTime);
        if(flag == 4)
        tiger.transform.position = Vector3.MoveTowards(tiger.transform.position,tigerdest.transform.position,moveSpeed * Time.deltaTime);
        if(flag == 5)
        monkey.transform.position = Vector3.MoveTowards(monkey.transform.position,monkeydest.transform.position,moveSpeed * Time.deltaTime);
        if(flag == 6)
        sparrow.transform.position = Vector3.MoveTowards(sparrow.transform.position,sparrowdest.transform.position,moveSpeed * Time.deltaTime);
        if(flag == 7)
        peacock.transform.position = Vector3.MoveTowards(peacock.transform.position,peacockdest.transform.position,moveSpeed * Time.deltaTime);
        if(flag == 8)
        parrot.transform.position = Vector3.MoveTowards(parrot.transform.position,parrotdest.transform.position,moveSpeed * Time.deltaTime);
        if(flag == 9)
        eagle.transform.position = Vector3.MoveTowards(eagle.transform.position,eagledest.transform.position,moveSpeed * Time.deltaTime);
        if(flag == 10)
        duck.transform.position = Vector3.MoveTowards(duck.transform.position,duckdest.transform.position,moveSpeed * Time.deltaTime);

    }
   } 
    


    // public void Dragelephant()
    // {
    //     elephant.transform.position=Input.mousePosition;
    // }
    // public void Dropelephant()
    // {
    //     float Distance=Vector2.Distance(elephant.transform.position,animal.transform.position);
    //     if(Distance<30){
    //     elephant.transform.position=elephantdest.transform.position;
    //     count++;
    //     source.clip=correct;
    //         source.Play();
    //     }
    //     else{
    //     elephant.transform.position=elephantip;
    //     source.clip=incorrect;
    //         source.Play();
    //     }
    // }
    // public void Draglion()
    // {
    //     lion.transform.position=Input.mousePosition;
    // }
    // public void Droplion()
    // {
    //     float Distance=Vector2.Distance(lion.transform.position,animal.transform.position);
    //     if(Distance<30){
    //     lion.transform.position=liondest.transform.position;
    //     count++;
    //     source.clip=correct;
    //         source.Play();
    //     }
    //     else{
    //     lion.transform.position=lionip;
    //     source.clip=incorrect;
    //         source.Play();
    //     }
    // }
    // public void Dragtiger()
    // {
    //     tiger.transform.position=Input.mousePosition;
    // }
    // public void Droptiger()
    // {
    //     float Distance=Vector2.Distance(tiger.transform.position,animal.transform.position);
    //     if(Distance<80){
    //     tiger.transform.position=tigerdest.transform.position;
    //     count++;
    //     source.clip=correct;
    //         source.Play();
    //     }
    //     else{
    //     tiger.transform.position=tigerip;
    //     source.clip=incorrect;
    //         source.Play();
    //     }
    // }
    // public void Dragmonkey()
    // {
    //     monkey.transform.position=Input.mousePosition;
    // }
    // public void Dropmonkey()
    // {
    //     float Distance=Vector2.Distance(monkey.transform.position,animal.transform.position);
    //     if(Distance<80){
    //     monkey.transform.position=monkeydest.transform.position;
    //     count++;
    //     source.clip=correct;
    //         source.Play();
    //     }
    //     else{
    //     monkey.transform.position=monkeyip;
    //     source.clip=incorrect;
    //         source.Play();
    //     }
    // }
    // public void Draggiraffe()
    // {
    //     giraffe.transform.position=Input.mousePosition;
    // }
    // public void Dropgiraffe()
    // {
    //     float Distance=Vector2.Distance(giraffe.transform.position,animal.transform.position);
    //     if(Distance<80){
    //     giraffe.transform.position=giraffedest.transform.position;
    //     count++;
    //     source.clip=incorrect;
    //         source.Play();
    //     }
    //     else{
    //     giraffe.transform.position=giraffeip;
    //     source.clip=correct;
    //         source.Play();
    //     }
    // }
    // public void Dragsparrow()
    // {
    //     sparrow.transform.position=Input.mousePosition;
    // }
    // public void Dropsparrow()
    // {
    //     float Distance=Vector2.Distance(sparrow.transform.position,bird.transform.position);
    //     if(Distance<30){
    //     sparrow.transform.position=sparrowdest.transform.position;
    //     count++;
    //     source.clip=incorrect;
    //         source.Play();
    //     }
    //     else{
    //     sparrow.transform.position=sparrowip;
    //     source.clip=correct;
    //         source.Play();
    //     }
    // }
    // public void Dragpeacock()
    // {
    //     peacock.transform.position=Input.mousePosition;
    // }
    // public void Droppeacock()
    // {
    //     float Distance=Vector2.Distance(peacock.transform.position,bird.transform.position);
    //     if(Distance<50){
    //     peacock.transform.position=peacockdest.transform.position;
    //     count++;
    //     source.clip=correct;
    //         source.Play();
    //     }
    //     else{
    //     peacock.transform.position=peacockip;
    //     source.clip=incorrect;
    //         source.Play();
    //     }
    // }
    // public void Drageagle()
    // {
    //     eagle.transform.position=Input.mousePosition;
    // }
    // public void Dropeagle()
    // {
    //     float Distance=Vector2.Distance(eagle.transform.position,bird.transform.position);
    //     if(Distance<200){
    //     eagle.transform.position=eagledest.transform.position;
    //     count++;
    //     source.clip=correct;
    //         source.Play();
    //     }
    //     else{
    //     eagle.transform.position=eagleip;
    //     source.clip=incorrect;
    //         source.Play();
    //     }
    // }
    // public void Dragparrot()
    // {
    //     parrot.transform.position=Input.mousePosition;
    // }
    // public void Dropparrot()
    // {
    //     float Distance=Vector2.Distance(parrot.transform.position,bird.transform.position);
    //     if(Distance<30){
    //     parrot.transform.position=parrotdest.transform.position;
    //     count++;
    //     source.clip=correct;
    //         source.Play();
    //     }
    //     else{
    //     parrot.transform.position=parrotip;
    //     source.clip=incorrect;
    //         source.Play();
    //     }
    // }
    // public void Dragduck()
    // {
    //     duck.transform.position=Input.mousePosition;
    // }
    // public void Dropduck()
    // {
    //     float Distance=Vector2.Distance(duck.transform.position,bird.transform.position);
    //     if(Distance<30){
    //     duck.transform.position=duckdest.transform.position;
    //     count++;
    //     source.clip=correct;
    //         source.Play();
    //     }
    //     else{
    //     duck.transform.position=duckip;
    //     source.clip=incorrect;
    //         source.Play();
    //     }
    // }
    

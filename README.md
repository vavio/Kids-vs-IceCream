#Kids vs IceCream!
![Screenshot](http://i.imgur.com/zlLlCwF.png)

##Опис на апликацијата и кратко упатство за користење

Проектот претставува имплементација на играта [*Kids vs I
ceCream*](www.kongregate.com/games/HotAirRaccoon/kids-vs-ice-cream "Kids vs IceCream") во која играчот е задолжен да ги “убие” сите дечиња кои се обидуваат да стигнат до неговиот камион со сладолед. Целта на играта е да се убијат што е можно повеќе дечиња. Оружјето од колата пука една топка сладолед со секој лев клик на маусот (и со задржување на кликот). Оваа игра е организирана во повеќе нивоа со различна тежина.  

Постојат повеќе видови човечиња:  

- ![White Kid](http://i.imgur.com/SB9MB74.png)*White kid* се движи најспоро и за неговата смрт е потребна само една топка од сладолед.  
- ![Ginger Kid](http://i.imgur.com/heshPzn.png)*Ginger kid* се движи малце побрзо и се потребни 3 топки за неговата смрт  
- ![Black Kid](http://i.imgur.com/3c1kx3Q.png)*Black kid* се движи најбрзо и се потребни 5 топки сладолед за да се убие
  
Со зголемување на нивото, играта станува се поинтензивна. На пример, по осмото ниво бројот на топки за убивање на децата станува поголем, но и рандом одреден: за white kid е 1-5,  за ginger kid е 3-8 и за black kid е од 5 до 10 топки сладолед. Исто така брзината со која се движат децата станува и поголема (исто така рандом одредена).
![Game Over](http://i.imgur.com/znkfhKG.png)  
Играчот губи кога едно дете ќе стигне до камионот со сладолед. При губење на играта, се отвора прозорец за запишување на вашето име, за да се забележи вашиот број на убиени деца.  
![Game Over Form](http://i.imgur.com/gZIkPZZ.png)  
Потоа се отвора и нова форма каде може да се одбере дали да почнете со нова игра, да се вратите во главното мени или да ја ислучите играта.  
  
Во главното мени може да го прочитате основното упатство за играта  
![High Score](http://i.imgur.com/j4oxHyK.png)  
или пак да ги погледнете најдобрите играчи.


##Опис на решението на апликацијата
###Interface `IMovingObject`  
Во овој интерфејс се наведени сите методи кои што треба да се имплементираат за оние елементи од играта кои што ни се во движење 

----------
  
###class `Car`  
Се чуваат податоци за телото од колата
###class `Bullet`  
Се чуваат податоци за **една** топка сладолед (куршум) и содржи методи за манипулација  
###class `Cloud`  
Се чуваат податоци за **еден** облак и содржи методи за манипулација  
###class `House`  
Се чуваат податоци за **една** куќа и содржи методи за манипулација  
###class `Kid`  
Се чуваат податоци за **едно** дете и содржи методи за манипулација  
###class `Player`  
Се чуваат податоци за **еден** играч  
###class `Sound`  
Се чуваат податоци за музиката и нејзино свирење  
###class `Weapon`  
Се чуваат податоци за оружјето и се врши ротација на самото оружје преку метод во оваа класа  
###class `Wheels`  
Се чуваат податоци за колцата и дали тие се во движење или не се   

----------

###class `BulletsDoc`  
Се чуваат податоци за **сите** топки сладолед кои се испукани  
###class `CarDoc`  
Се чуваат податоци за колата  
###class `CloudsDoc`  
Се чуваат податоци за **сите** облаци кои моментално се на екранот  
###class `HousesDoc`  
Се чуваат податоци за **сите** куќи кои моментално се на екранот  
###class `KidsDoc`  
Се чуваат податоци за **сите** деца кои што треба да си убиеме  
###class `LevelsDoc`  
Се чуваат податоци за нивоата од играта  
###class `PlayersDoc`  
Се чуваат податоци за **сите** играчи посебно  

----------

###class `Vector2D`  
Имплементација на математички вектор и методи кои што ни се потребни за да се манипулира со истиот  
###class `VMath`  
Статична класа која што ни содржи методи за да проверуваме дали имаме пресек со дете-кола или куршум-дете  

----------

###class `EnterNameWindow`  
Класа за формата за внесување на името на играчот  
###class `Form1`  
Класа за главната форма од играта  
###class `GameOverWindow`    
Класа за формата кога играта губиме (детето стасало до нашата кола)  
###class `GameWindow`  
Класа за формата кога стартуваме нова игра  
###class `HighScoreWindow`  
Класа за формата Најдобри играчи  
###class `HowToPlayWindow`  
Класа за формата која ни објаснува како се игра  
###class `NextLevelWindow`  
Класа за формата која што ни се појавува кога сме ги убиле сите деца од одредено ниво


##Опис на една функција  
```csharp
public int Hit(BulletsDoc bDoc)
{
    int ret = 0;
    this.Kids.Sort();
    bDoc.Bullets.Sort();
    for (int i = this.Kids.Count - 1; i >= 0; --i)
    {
        bool flag = false;
        for (int j = bDoc.Bullets.Count - 1; j >= 0; --j )
            if (this.Kids[i].Hit(bDoc.Bullets[j]))
            {
                bDoc.Bullets.RemoveAt(j);
                flag = true;
                Kids[i].X -= 20; //Pushback
                break;
            }
        if (flag)
        {
            if(this.Kids[i].isDead())
            {
                this.Kids.RemoveAt(i);
                ret++;
            }
        }
    }
    return ret;
}
```  
Најпрво децата и куршумите ги сортираме по нивните соодветни `X` вредности. Потоа за секое дете (се формира четириаголник од квадрадот кој го опфаќа детето т.е *`AABB (Axis-Aligned Bounding Box)`*) и за секој куршум (формираме мала отсечка од претходната позиција и моменталната позиција) проверуваме дали тие се сечат во функцијата која ```public bool Hit(Bullet b)``` која е дефинирана во ```class Kid```. Ако имаме пресек тогаш знаменцето ```bool flag``` се поставува на ```true``` и го враќаме детенцето поназад (за да се добие PushBack ефект). Исто така на детенцето му се одзема еден живот и куршумот кој го поминал тестот на пресек се бриши од листата за да не можи да се користи понатаму. На крајо со знаменцето `flag` проверуваме дали детенцето има преостанати животи. Ако нема тогаш детенцето е "убиено" и се брише од листата на деца кои се преостанати живи. Променливата ```int ret``` се користи за да ни кажи во оваа фаза од играта (кога го правиме тестот за пресек) колку од сите деца биле "убиени". Таа информација се враќа како повратна вредност од методот каде се користи за се зголеми моменталниот број на убиени деца.  

##Изработиле  
1. Валентин Амбароски 121231  
2. Викторија Анчевска 121136

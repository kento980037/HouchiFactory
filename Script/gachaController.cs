using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class gachaController : MonoBehaviour
{
    public GameObject text_coin;
    public GameObject text_alldia;
    int allmoney;
    int alldia;

    public GameObject text_exgacharank1;
    public GameObject text_exgacharank2;
    public GameObject text_exgacharank3;
    public GameObject collectiontellButton;
    public GameObject text_collectiontell;
    public GameObject image_collection;
    public GameObject image_new;
    public Sprite[] collectionSprite;
    int random1=0;
    int random2=0;
    int num_collection;
    int i;
    int j;

    // Start is called before the first frame update
    void Start()
    {
        allmoney=PlayerPrefs.GetInt("allmoney",0);
        text_coin.GetComponent<Text> ().text=""+allmoney;
        alldia=PlayerPrefs.GetInt("alldia",0);
        text_alldia.GetComponent<Text> ().text=""+alldia;

        collectiontellButton.SetActive(false);
        for(i=0;i<30;i++)
        {
            j=PlayerPrefs.GetInt("collection"+(i+1),0);
            if(j==1||j==3)
            {
                collectiontellButton.SetActive(true);
                image_collection.GetComponent<Image>().sprite=collectionSprite[i];
                if(j==1)
                {
                    image_new.SetActive(true);
                }
                j=2;
                PlayerPrefs.SetInt("collection"+(i+1),j);
                func_collectiontell(i+1);
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void func_collectiontell(int number)//numberは１〜３０
    {
        if(number==1)
        {
            text_collectiontell.GetComponent<Text>().text="【作業服】★\n工場で働く人は作業服が基本である。オシャレな人にとってはダサいと感じるかもしれないが、安全面や動かしさすさに配慮された最適な服装であることを忘れてはならない。とは言っても、もう少しオシャレな作業服があってもいいと個人的にはおもう。";
        }
        else if(number==2)
        {
            text_collectiontell.GetComponent<Text>().text="【ヘルメット】★\n工場内では常に危険なことが起こる可能性がある。例えば、ロボットやクレーンが誤作動をおこし、重いものが落下してくるかもしれない。それが頭に当たったとき衝撃を緩和するのがヘルメットである。また、これをかぶっているとやってる感が出る。";
        }
        else if(number==3)
        {
            text_collectiontell.GetComponent<Text>().text="【作業靴】★\n工場内は作業靴を履く。工場内では、重い荷物が足元に落ちたり、釘などの尖ったものを踏んだりし、怪我をすることがある。このようなことを防ぐために履くのが作業靴である。そのため、靴の中に鉄板や合成樹脂があったり、耐火性に優れてたり、薬品に強いものもある。すごいね。";
        }
        else if(number==4)
        {
            text_collectiontell.GetComponent<Text>().text="【保護メガネ】★\n工場内では保護メガネをかけることがある。金属のかけらや、危険な液体が目に入るのを防ぐのが目的である。個人的には作業服はダサいが、保護メガネは結構カッコいいと思います。";
        }
        else if(number==5)
        {
            text_collectiontell.GetComponent<Text>().text="【監視カメラ】★\nここ何十年で街のいたる所に監視カメラが設置されたが、工場内も例外ではない。荷物や資材の盗難の防止や記録だけでなく、ワーカーの作業を監視・記録することも目的である。「見られてる」と思うとちょっと働きづらいですね。";
        }
        else if(number==6)
        {
            text_collectiontell.GetComponent<Text>().text="【空調】★\n工場内は作業内容にもよるが熱がこもりやすく、夏場は特に従業員の熱中症が心配である。そこで、そのような工場は大型の空調をつけていることが多い。空調ないと夏とか暑くてやってられないよな！";
        }
        else if(number==7)
        {
            text_collectiontell.GetComponent<Text>().text="【ヒーター】★\n冬などは工場内がとても冷えることがある。そこで大型のヒーターを設置しているところもある。寒いと手が凍ってやってられないもんな。";
        }
        else if(number==8)
        {
            text_collectiontell.GetComponent<Text>().text="【クリーンルーム】★\n不純物やゴミが入らないように管理された部屋。半導体や自動車など精密な製品、食品などの衛生面に注意しなければならない製品を製造する際はクリーンルームを設置することがある。クリーンルームに入るときはクリーンウェアを着なくてはならずとても暑苦しい。";
        }
        else if(number==9)
        {
            text_collectiontell.GetComponent<Text>().text="【フライス盤】★★\nフライスと呼ばれる工具を回転させ、平面、局面、溝、ネジ、歯車などを削り出す工作機械。高度経済成長期のときには、「旋盤」「ボール盤」と並び、生産現場では３種の神器と言われていた。カッコいい！";
        }
        else if(number==10)
        {
            text_collectiontell.GetComponent<Text>().text="【ボール盤】★★\nドリルを用いて穴あけ加工をする工作機械。高度経済成長期のときには、「旋盤」「フライス盤」と並び、生産現場では３種の神器と言われていた。カッコいい！";
        }
        else if(number==11)
        {
            text_collectiontell.GetComponent<Text>().text="【旋盤】★★\n回転する素材に刃物をあて、これを送りながら加工する工作機械。円筒削り、中ぐり、ねじ切りなど多くの回転加工ができる。高度経済成長期のときには、「旋盤」「フライス盤」と並び、生産現場では３種の神器と言われていた。カッコいい！";
        }
        else if(number==12)
        {
            text_collectiontell.GetComponent<Text>().text="【グラインダー】★★\n砥石を回転させて工作物の研磨、切削、研削などを行う工作機械。今回のは手軽に使えるディスクグラインダーと呼ばれ手軽に使えるタイプ。通称「サンダー」。痺れるね。";
        }
        else if(number==13)
        {
            text_collectiontell.GetComponent<Text>().text="【ラップ盤】★★\nフライス盤などで精密に加工された素材の表面をさらに平坦に仕上げる最終表面処理機械。定盤の上にラップ剤を散布し加工物の表面を押し付けてこする。これでツルツルのすべすべ。";
        }
        else if(number==14)
        {
            text_collectiontell.GetComponent<Text>().text="【スポット溶接機】★★\n溶接する金属母材の上下から電極をあて大量の電流の流し、加熱し、冷却、母材を最凝固して2つの母材を溶接する圧接法。他の溶接法と比べると火花があまり散らないため手軽であり、また、見た目もきれいに仕上がる。ただし、強度に難あり。";
        }
        else if(number==15)
        {
            text_collectiontell.GetComponent<Text>().text="【フォークリフト】★★\n人が持ち上げられないような重い荷物を運ぶための車両。１トン以上の荷物を乗せて運転する際は、フォークリフト運転技能講習修了証を取得しなければ運転することはできない。これを取ればキミも晴れて「フォークリフトオペレーター」だ！";
        }
        else if(number==16)
        {
            text_collectiontell.GetComponent<Text>().text="【ハンダ付け機】★★★\nハンダによって金属をつなぎ合わせる「ハンダ付け」を自動化した機械。ハンダ付けは、溶けたハンダが固まることでくっつくのではなく、金属との合金層ができることで接着しているため、コテ先が高温なほど言い訳ではなく、２５０度あたりが一番接合強度が高い。";
        }
        else if(number==17)
        {
            text_collectiontell.GetComponent<Text>().text="【ベルトコンベア】★★★\n人手を使わずにモノを運ぶことのできる機械。生産現場で使用されるようになったのは１９１３年のフォードモーターの工場と言われており、大量生産の流れ作業「ライン生産方式」を効率化し、飛躍的な生産能率の工場と原価の引き下げを実現した。。";
        }
        else if(number==18)
        {
            text_collectiontell.GetComponent<Text>().text="【プレス機】★★★\n薄い板金素材を上から下方向に強い圧力を加え、機械に装着した金型の形状に変形させることのできる機械。多くの場合1つの材料を加工するのにかかる時間は数秒で、低コストで大量生産に向いている。自動車や家電にも使われており、現代のモノづくりには必要不可欠である。";
        }
        else if(number==19)
        {
            text_collectiontell.GetComponent<Text>().text="【外観検査装置】★★★\n傷などの外観上の欠陥、つまり不良品を検出する装置。多くはカメラによる画像から不良品を識別する形式で、機械を使うことで生産ライン上に組み込むことができ、生産効率を落とさなくて済む。最近はAI技術を使っているとか。。。";
        }
        else if(number==20)
        {
            text_collectiontell.GetComponent<Text>().text="【ロボットアーム】★★★\n人間の腕のようなロボット。汎用性が非常に高く、搬送から溶接や塗装、組立まで幅広いこなすオールラウンダー。ビジュアルもカッコよく、工場内ではモテモテに違いない。ずるい。";
        }
        else if(number==21)
        {
            text_collectiontell.GetComponent<Text>().text="【射出成形機】★★★\nプラスチックを溶かし、型に流し込み、固める(冷却)、取り出すといった工程を１台で処理することができる工作機械。プラスチック製品を短時間で大量に作ることができ、まさに「工場」というカンジ。";
        }
        else if(number==22)
        {
            text_collectiontell.GetComponent<Text>().text="【マシニングセンタ】★★★★\nコンピュータ制御による「工具自動交換機能」を備える工作機械。工具をコンピューターで自動的に交換しながら加工することができ、生産効率が大幅に上昇した。現代のモノづくりの根幹をになっていると言ってもいい。イケメンである。";
        }
        else if(number==23)
        {
            text_collectiontell.GetComponent<Text>().text="【ターニングセンタ】★★★★\nマシニングセンタと同様、コンピュータ制御による「工具自動交換機能」を備える工作機械であるが、ターニングセンタは軸物の旋削加工ができる。すなわち材料が回転する加工も自由に行えるのだ。すごいね。";
        }
        else if(number==24)
        {
            text_collectiontell.GetComponent<Text>().text="【ワイヤー放電加工機】★★★★\nワイヤーを放電させ、その熱によって素材を切断する工作機械。加工時間はかかるが、金属を複雑な形状に加工するときに便利である。痺れるぜ。";
        }
        else if(number==25)
        {
            text_collectiontell.GetComponent<Text>().text="【レーザー加工機】★★★★\n加工素材にレーザー光を照射し、気化・燃焼・溶解することで加工する工作機械。コンピュータでレーザー光の出力・照射密度・照射時間をきめ細かく制御できるため、様々な素材に対し、多様で精緻な加工を簡便かつ短時間で出来る。アツい！。";
        }
        else if(number==26)
        {
            text_collectiontell.GetComponent<Text>().text="【3Dプリンター】★★★★\nデータをもとに一層ずつ積み重ねて立体物を作る装置。現在の3Dプリンターでは樹脂から金属まで様々素材が使われて、様々なものが作れるが、登場初期は生産時間やコストの面から何かの試作として使われることが多かった。しかし、今後成長が見込まれる。";
        }
        else if(number==27)
        {
            text_collectiontell.GetComponent<Text>().text="【タイのタピオカミルクティー】★★★★★\nアプリ「タピのみ」に登場するコレクションの1つ。タイのタピオカは日本のタピオカよりも含まれる糖分が多い傾向がある。一杯に角砂糖２５個分の糖分が入っているのだとか。。。";
        }
        else if(number==28)
        {
            text_collectiontell.GetComponent<Text>().text="【ドライブレコーダー】★★★★★\nアプリ「VSあおり運転」に登場するコレクションの1つ。あおり運転対策としてドライブレコーダーは有効である。最近では前方だけでなく後方を撮影できるタイプもある。";
        }
        else if(number==29)
        {
            text_collectiontell.GetComponent<Text>().text="【定規】★★★★★\nアプリ「さんかくひマスター」に登場するコレクションの1つ。直線や角を書くときに使われるのは定規、長さをはかるときに使われるのは物差し、というように用途により呼び名が異なるが、大した違いではないと思います。";
        }
        else if(number==30)
        {
            text_collectiontell.GetComponent<Text>().text="【AI】★★★★★\n少し前に機械学習技術が飛躍的に発展し、最近A技術として様々な分野で使われるようになってきた。工場内でも例外でなく、ロボットで複雑な動きが可能となったり、資材発注・在庫管理を最適化したり、製品の品質の向上、設備の状況の把握・入れ替え判断ができる。";
        }
    }

    public void gacha(int rank)//rank=1だとノーマル
    {
        random1=Random.Range(0,100);//0~99を出力
        if(rank==1)
        {
            allmoney=PlayerPrefs.GetInt("allmoney",0);
            if(allmoney>=1000)
            {
                //ガチャを引く
                allmoney-=1000;
                PlayerPrefs.SetInt("allmoney",allmoney);
                if(random1<60)
                {
                    random2=Random.Range(0,8);
                    num_collection=PlayerPrefs.GetInt("collection"+(random2+1),0);
                    num_collection++;
                    PlayerPrefs.SetInt("collection"+(random2+1),num_collection);
                    PlayerPrefs.Save();
                }
                else if(random1<95)
                {
                    random2=Random.Range(0,7);
                    num_collection=PlayerPrefs.GetInt("collection"+(random2+9),0);
                    num_collection++;
                    PlayerPrefs.SetInt("collection"+(random2+9),num_collection);
                    PlayerPrefs.Save();
                }
                else
                {
                    random2=Random.Range(0,6);
                    num_collection=PlayerPrefs.GetInt("collection"+(random2+16),0);
                    num_collection++;
                    PlayerPrefs.SetInt("collection"+(random2+16),num_collection);
                    PlayerPrefs.Save();
                }
                SceneManager.LoadScene("gachaeffectScene");
            }
            else
            {
                text_exgacharank1.GetComponent<Text> ().text="所持金が足りません。";
            }
        }
        else if(rank==2)
        {
            allmoney=PlayerPrefs.GetInt("allmoney",0);
            if(allmoney>=500000)
            {
                //ガチャを引く
                allmoney-=500000;
                PlayerPrefs.SetInt("allmoney",allmoney);
                if(random1<63)
                {
                    random2=Random.Range(0,6);
                    num_collection=PlayerPrefs.GetInt("collection"+(random2+16),0);
                    num_collection++;
                    PlayerPrefs.SetInt("collection"+(random2+16),num_collection);
                    PlayerPrefs.Save();
                }
                else if(random1<99)
                {
                    random2=Random.Range(0,5);
                    num_collection=PlayerPrefs.GetInt("collection"+(random2+22),0);
                    num_collection++;
                    PlayerPrefs.SetInt("collection"+(random2+22),num_collection);
                    PlayerPrefs.Save();
                }
                else
                {
                    random2=Random.Range(0,4);
                    num_collection=PlayerPrefs.GetInt("collection"+(random2+27),0);
                    num_collection++;
                    PlayerPrefs.SetInt("collection"+(random2+27),num_collection);
                    PlayerPrefs.Save();
                }
                SceneManager.LoadScene("gachaeffectScene");
            }
            else
            {
                text_exgacharank2.GetComponent<Text> ().text="所持金が足りません。";
            }
        }
        else if(rank==3)
        {
            alldia=PlayerPrefs.GetInt("alldia",0);
            if(alldia>=5)
            {
                //ガチャを引く
                alldia-=5;
                PlayerPrefs.SetInt("alldia",alldia);
                if(random1<80)
                {
                    random2=Random.Range(0,5);
                    num_collection=PlayerPrefs.GetInt("collection"+(random2+22),0);
                    num_collection++;
                    PlayerPrefs.SetInt("collection"+(random2+22),num_collection);
                    PlayerPrefs.Save();
                }
                else
                {
                    random2=Random.Range(0,4);
                    num_collection=PlayerPrefs.GetInt("collection"+(random2+27),0);
                    num_collection++;
                    PlayerPrefs.SetInt("collection"+(random2+27),num_collection);
                    PlayerPrefs.Save();
                }
                SceneManager.LoadScene("gachaeffectScene");
            }
            else
            {
                text_exgacharank3.GetComponent<Text> ().text="ダイヤが足りません。";   
            }
        }
    }
}

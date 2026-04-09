using System.Text.Json;
using Microsoft.Maui.Storage;

namespace GANDANAPP;

public partial class MainPage : ContentPage
{
    // 즐겨찾기 저장용 키
    private const string WordFavoritesPreferenceKey = "favorite_word_keys_v1";
    private const string GrammarFavoritesPreferenceKey = "favorite_grammar_keys_v1";
    private const string PatternFavoritesPreferenceKey = "favorite_pattern_keys_v1";
    private const string CopyrightNotice = "© 2026 박찬솔. All Rights Reserved.";

    // ============================
    // 한자 리스트
    // ============================
    private readonly List<WordItem> _words = new()
    {
        new WordItem("학생", "学生", "がくせい"),
        new WordItem("친구", "友達", "ともだち"),
        new WordItem("선생님", "先生", "せんせい"),
        new WordItem("학교", "学校", "がっこう"),
        new WordItem("회사", "会社", "かいしゃ"),
        new WordItem("가족", "家族", "かぞく"),
        new WordItem("시계", "時計", "とけい"),
        new WordItem("이름", "名前", "なまえ"),
        new WordItem("책", "本", "ほん"),
        new WordItem("전화", "電話", "でんわ"),

        new WordItem("자동차", "車", "くるま"),
        new WordItem("사진", "写真", "しゃしん"),
        new WordItem("책상", "机", "つくえ"),
        new WordItem("의자", "椅子", "いす"),
        new WordItem("가방", "鞄", "かばん"),
        new WordItem("우산", "傘", "かさ"),
        new WordItem("열쇠", "鍵", "かぎ"),
        new WordItem("옷", "服", "ふく"),
        new WordItem("신발", "靴", "くつ"),
        new WordItem("지갑", "財布", "さいふ"),
        new WordItem("일", "仕事", "しごと"),
        new WordItem("요리", "料理", "りょうり"),
        new WordItem("공부", "勉強", "べんきょう"),
        new WordItem("영화", "映画", "えいが"),
        new WordItem("음악", "音楽", "おんがく"),

        new WordItem("아침", "朝", "あさ"),
        new WordItem("내일", "明日", "あした"),
        new WordItem("낮", "昼", "ひる"),
        new WordItem("저녁", "晩", "ばん"),
        new WordItem("오늘", "今日", "きょう"),
        new WordItem("어제", "昨日", "きのう"),
        new WordItem("집", "家", "いえ"),
        new WordItem("시간", "時間", "じかん"),
        new WordItem("일본", "日本", "にほん"),
        new WordItem("한국", "韓国", "かんこく"),
        new WordItem("방", "部屋", "へや"),
        new WordItem("차", "お茶", "おちゃ"),
        new WordItem("가게", "店", "みせ"),
        new WordItem("음식", "食べ物", "たべもの"),
        new WordItem("음료", "飲み物", "のみもの"),

        new WordItem("물", "水", "みず"),
        new WordItem("과일", "果物", "くだもの"),
        new WordItem("물고기", "魚", "さかな"),
        new WordItem("고기", "肉", "にく"),
        new WordItem("야채", "野菜", "やさい"),
        new WordItem("날씨", "天気", "てんき"),
        new WordItem("산", "山", "やま"),
        new WordItem("비", "雨", "あめ"),
        new WordItem("하늘", "空", "そら"),
        new WordItem("바다", "海", "うみ"),

        new WordItem("먹다", "食べる", "たべる"),
        new WordItem("씻다", "洗う", "あらう"),
        new WordItem("마시다", "飲む", "のむ"),
        new WordItem("자다", "寝る", "ねる"),
        new WordItem("일어나다", "起きる", "おきる"),
        new WordItem("사다", "買う", "かう"),
        new WordItem("끝나다", "終わる", "おわる"),
        new WordItem("팔다", "売る", "うる"),
        new WordItem("일하다", "働く", "はたらく"),
        new WordItem("시작하다", "始まる", "はじまる"),

        new WordItem("가다", "行く", "いく"),
        new WordItem("기다리다", "待つ", "まつ"),
        new WordItem("오다", "来る", "くる"),
        new WordItem("부르다", "呼ぶ", "よぶ"),
        new WordItem("놀다", "遊ぶ", "あそぶ"),
        new WordItem("보다", "見る", "みる"),
        new WordItem("생각하다", "考える", "かんがえる"),
        new WordItem("듣다, 묻다", "聞く", "きく"),
        new WordItem("말하다", "言う", "いう"),
        new WordItem("대답하다", "答える", "こたえる"),
        new WordItem("만들다", "作る", "つくる"),
        new WordItem("읽다", "読む", "よむ"),
        new WordItem("사용하다", "使う", "つかう"),
        new WordItem("보내다, 배웅하다", "送る", "おくる"),
        new WordItem("쓰다, 적다", "書く", "かく"),

        new WordItem("하다", "する", "する"),
        new WordItem("이야기하다", "話す", "はなす"),
        new WordItem("타다", "乗る", "のる"),
        new WordItem("(탈것에서) 내리다", "降りる", "おりる"),
        new WordItem("만나다", "会う", "あう"),
        new WordItem("노래하다", "歌う", "うたう"),
        new WordItem("줍다", "拾う", "ひろう"),
        new WordItem("배우다", "習う", "ならう"),
        new WordItem("앉다", "座る", "すわる"),
        new WordItem("버리다", "捨てる", "すてる"),
        new WordItem("입다", "着る", "きる"),
        new WordItem("살다", "住む", "すむ"),
        new WordItem("벗다", "脱ぐ", "ぬぐ"),
        new WordItem("쉬다", "休む", "やすむ"),
        new WordItem("나가다(나오다)", "出る", "でる"),

        new WordItem("화내다", "怒る", "おこる"),
        new WordItem("잊다", "忘れる", "わすれる"),
        new WordItem("빌리다", "借りる", "かりる"),
        new WordItem("고르다, 선택하다", "選ぶ", "えらぶ"),
        new WordItem("외우다", "覚える", "おぼえる"),
        new WordItem("자르다", "切る", "きる"),
        new WordItem("알다", "知る", "しる"),
        new WordItem("들어가다(오다)", "入る", "はいる"),
        new WordItem("돌아가다(오다)", "帰る", "かえる"),
        new WordItem("달리다", "走る", "はしる"),

        new WordItem("좋아하다", "好きだ", "すきだ"),
        new WordItem("자신있다", "得意だ", "とくいだ"),
        new WordItem("싫어하다", "嫌いだ", "きらいだ"),
        new WordItem("잘하다", "上手だ", "じょうずだ"),
        new WordItem("못하다", "下手だ", "へただ"),
        new WordItem("서투르다, 거북하다", "苦手だ", "にがてだ"),
        new WordItem("한가하다", "暇だ", "ひまだ"),
        new WordItem("유명하다", "有名だ", "ゆうめいだ"),
        new WordItem("친절하다", "親切だ", "しんせつだ"),
        new WordItem("건강하다", "元気だ", "げんきだ"),

        new WordItem("안된다", "駄目だ", "だめだ"),
        new WordItem("편리하다", "便利だ", "べんりだ"),
        new WordItem("예쁘다, 깨끗하다", "綺麗だ", "きれいだ"),
        new WordItem("조용하다", "静かだ", "しずかだ"),
        new WordItem("번화하다", "賑やかだ", "にぎやかだ"),
        new WordItem("불편하다", "不便だ", "ふべんだ"),
        new WordItem("간단하다", "簡単だ", "かんたんだ"),
        new WordItem("힘들다, 큰일이다", "大変だ", "たいへんだ"),
        new WordItem("괜찮다", "大丈夫だ", "だいじょうぶだ"),
        new WordItem("화려하다", "派手だ", "はでだ"),
        new WordItem("걱정이다", "心配だ", "しんぱいだ"),
        new WordItem("소용없다", "無駄だ", "むだだ"),
        new WordItem("같다", "同じだ", "おなじだ"),
        new WordItem("수수하다", "地味だ", "じみだ"),
        new WordItem("성실하다", "真面目だ", "まじめだ"),

        new WordItem("좋다, 충분하다", "結構だ", "けっこうだ"),
        new WordItem("중요하다, 소중하다", "大切だ", "たいせつだ"),
        new WordItem("실례하다, 무례하다", "失礼だ", "しつれいだ"),
        new WordItem("튼튼하다", "丈夫だ", "じょうぶだ"),
        new WordItem("중요하다, 소중하다", "大事だ", "だいじだ"),
        new WordItem("편하다", "楽だ", "らくだ"),
        new WordItem("무리다", "無理だ", "むりだ"),
        new WordItem("특별하다", "特別だ", "とくべつだ"),
        new WordItem("풍부하다, 풍요롭다", "豊かだ", "ゆたかだ"),
        new WordItem("훌륭하다", "立派だ", "りっぱだ"),
        new WordItem("여러가지다", "色々だ", "いろいろだ"),
        new WordItem("근사하다, 멋지다", "素敵だ", "すてきだ"),
        new WordItem("지루하다", "退屈だ", "たいくつだ"),
        new WordItem("유감이다, 아쉽다", "残念だ", "ざんねんだ"),
        new WordItem("충분하다", "十分だ", "じゅうぶんだ")
    };

    // ============================
    // 문법 모드용 데이터 (PDF 보강)
    // ============================
    private readonly List<GrammarItem> _grammarItems = new()
    {
        // --- 기초: 품사 개관 ---
        new GrammarItem(
            "기초",
            "품사 큰 그림",
            "명사 / い형용사 / な형용사 / 동사를 먼저 구분",
            "일본어 초반 문법은 먼저 품사를 구분하고, 그 다음 조사와 활용을 붙이는 구조로 보면 정리가 쉽다.\n\n" +
            "• 명사: 学生, 本, 水\n" +
            "• い형용사: 高い, おいしい\n" +
            "• な형용사: 静かだ, 便利だ\n" +
            "• 동사: 行く, 食べる\n\n" +
            "문장 기본 뼈대는 보통 '명사 + 조사 + 동사' 또는 '명사 + は + 형용사/명사 + です'로 잡으면 된다."
        ),

        new GrammarItem(
            "기초",
            "문법을 볼 때 먼저 잡아야 할 틀",
            "품사 축 / 말투 축 / 시간 축 / 기능 축",
            "【품사 축】 명사 / い형용사 / な형용사 / 동사\n" +
            "【말투 축】 보통체 / 정중체\n" +
            "【시간·판단 축】 현재·미래 / 과거 / 긍정 / 부정\n" +
            "【기능 축】 연결 / 부탁 / 진행 / 허가 / 금지 / 희망 / 경험 / 권유\n\n" +
            "핵심: 동사가 변형되는 이유는 화자가 문장에서 추가하고 싶은 기능이 생겼기 때문이다.\n" +
            "정중하게 → ます형, 안 한다고 → ない형, 이어서 → て형, 과거 → た형"
        ),

        // --- 조사 ---
        new GrammarItem(
            "조사",
            "は vs が",
            "は는 주제, が는 주어/강조/새 정보",
            "• 私は学生です。 → 나는 학생입니다.\n" +
            "• 誰が来ましたか。 → 누가 왔습니까?\n" +
            "• 犬が好きです。 → 강아지를 좋아합니다.\n\n" +
            "처음엔 '은/는 = は, 이/가 = が'로 외우면 되지만, 시험에서는 '강조', '새 정보', '좋아하다/이해하다/할 수 있다' 같은 표현에서 が가 자주 나온다."
        ),

        new GrammarItem(
            "조사",
            "に vs で",
            "に는 도착점/시간, で는 행동 장소",
            "• 学校に行きます。 → 학교에 갑니다.\n" +
            "• 学校で勉強します。 → 학교에서 공부합니다.\n" +
            "• 7時に起きます。 → 7시에 일어납니다.\n\n" +
            "핵심:\n" +
            "• 이동의 목적지 = に\n" +
            "• 행동이 실제로 벌어지는 장소 = で\n" +
            "• 시간점 = に"
        ),

        new GrammarItem(
            "조사",
            "を / へ / と / から / まで",
            "목적어·방향·동반·기점·종점 조사 모음",
            "• 映画を見ます。 → 영화를 봅니다. (목적어)\n" +
            "• 日本へ行きます。 → 일본으로 갑니다. (방향)\n" +
            "• 友達と行きます。 → 친구와 갑니다. (동반)\n" +
            "• 9時から5時まで働きます。 → 9시부터 5시까지 일합니다.\n\n" +
            "주의: へ는 방향, に는 도착점. 의미가 겹칠 때도 있지만,\n" +
            "  家へ帰ります (방향 강조) / 家に帰ります (도착 강조)"
        ),

        new GrammarItem(
            "조사",
            "も / しか / だけ",
            "~도 / ~밖에(+부정) / ~만",
            "• 私も学生です。 → 나도 학생입니다.\n" +
            "• 水しか飲みません。 → 물밖에 마시지 않습니다.\n" +
            "• 水だけ飲みます。 → 물만 마십니다.\n\n" +
            "しか는 반드시 부정형과 함께 쓴다.\n" +
            "だけ는 긍정·부정 모두 가능."
        ),

        // --- 형용사 ---
        new GrammarItem(
            "형용사",
            "い형용사 vs な형용사",
            "끝이 い라고 다 い형용사 아님",
            "い형용사:\n" +
            "• 高いです → 높습니다\n" +
            "• 高い山 → 높은 산\n" +
            "• 高くないです → 높지 않습니다\n\n" +
            "な형용사:\n" +
            "• 静かです → 조용합니다\n" +
            "• 静かな部屋 → 조용한 방\n" +
            "• 静かではありません → 조용하지 않습니다\n\n" +
            "한 줄 공식:\n" +
            "• い형용사는 い가 직접 변함\n" +
            "• な형용사는 뒤의 です/ではありません 쪽이 변함"
        ),

        new GrammarItem(
            "형용사",
            "자주 틀리는 단어",
            "きれい, 好き, 上手는 특히 조심",
            "• きれい는 끝이 い여도 な형용사\n" +
            "  - きれいです / きれいな部屋\n\n" +
            "• 好き / 嫌い / 上手 / 下手 는 의미상 동사처럼 보여도 문법상 な형용사 계열\n" +
            "  - 犬が好きです。\n" +
            "  - 歌が上手です。\n\n" +
            "• 有名(ゆうめい)도 な형용사\n" +
            "  - 有名な人 / 有名ではない"
        ),

        new GrammarItem(
            "형용사",
            "형용사 활용표",
            "현재/과거/부정/명사수식 4종",
            "【い형용사 — 高い】\n" +
            "• 현재 긍정: 高いです\n" +
            "• 현재 부정: 高くないです\n" +
            "• 과거 긍정: 高かったです\n" +
            "• 과거 부정: 高くなかったです\n" +
            "• 명사 수식: 高い山\n" +
            "• 연결형: 高くて\n" +
            "• 부사형: 高く\n" +
            "• 가정형: 高ければ\n\n" +
            "【な형용사 — 静か】\n" +
            "• 현재 긍정: 静かです\n" +
            "• 현재 부정: 静かではありません\n" +
            "• 과거 긍정: 静かでした\n" +
            "• 과거 부정: 静かではありませんでした\n" +
            "• 명사 수식: 静かな部屋\n" +
            "• 연결형: 静かで\n" +
            "• 부사형: 静かに\n" +
            "• 가정형: 静かなら"
        ),

        new GrammarItem(
            "형용사",
            "형용사 て형 연결",
            "い→くて / な→で 로 이어 말하기",
            "두 형용사를 연결할 때:\n\n" +
            "【い형용사】い → くて\n" +
            "• 安くておいしいです。 → 싸고 맛있습니다.\n" +
            "• 大きくてきれいな家 → 크고 예쁜 집\n\n" +
            "【な형용사】な → で\n" +
            "• 静かで広い部屋 → 조용하고 넓은 방\n" +
            "• 便利できれいです。\n\n" +
            "• いい(좋다)는 예외: いい → よくて\n" +
            "  - 天気がよくて気持ちいいです。"
        ),

        // --- 동사 기초 ---
        new GrammarItem(
            "동사",
            "1그룹 / 2그룹 / 3그룹",
            "동사 그룹을 알아야 ます형, て형, た형이 안 꼬임",
            "1그룹 (5단동사):\n" +
            "• 書く, 飲む, 話す, 買う, 帰る\n" +
            "• 마지막 글자가 여러 단으로 바뀜\n\n" +
            "2그룹 (1단동사):\n" +
            "• 食べる, 見る, 起きる, 寝る\n" +
            "• 보통 る를 떼고 활용\n\n" +
            "3그룹 (불규칙):\n" +
            "• する, 来る(くる)\n" +
            "• 불규칙이라 통암기\n\n" +
            "함정: 帰る(かえる), 走る(はしる), 入る(はいる)는 る로 끝나도 1그룹!"
        ),

        new GrammarItem(
            "동사 활용",
            "ます형 4종 세트",
            "ます / ません / ました / ませんでした",
            "형태:\n" +
            "• ～ます = 합니다\n" +
            "• ～ません = 하지 않습니다\n" +
            "• ～ました = 했습니다\n" +
            "• ～ませんでした = 하지 않았습니다\n\n" +
            "예시:\n" +
            "• 見ます / 見ません / 見ました / 見ませんでした\n" +
            "• 来ます(きます) / 来ました(きました)\n\n" +
            "포인트:\n" +
            "ます형은 현재뿐 아니라 미래 의미도 포함할 수 있다."
        ),

        new GrammarItem(
            "동사 활용",
            "1그룹 あ단 / い단 / え단 / お단",
            "ない형은 あ단, ます형은 い단, 가능은 え단, 의지는 お단",
            "1그룹 동사는 마지막 う단을 바꿔서 활용한다.\n\n" +
            "• ない형 = あ단 + ない\n" +
            "  - 書く → 書かない / 買う → 買わない (う→わ 예외)\n\n" +
            "• ます형 = い단 + ます\n" +
            "  - 書く → 書きます / 飲む → 飲みます\n\n" +
            "• 가능형 = え단 + る\n" +
            "  - 書く → 書ける / 飲む → 飲める\n\n" +
            "• 의지형 = お단 + う\n" +
            "  - 書く → 書こう / 飲む → 飲もう\n\n" +
            "시험용 압축: ない=あ단, ます=い단, 가능=え단, 의지=お단"
        ),

        new GrammarItem(
            "동사 활용",
            "ない형 (부정형)",
            "~하지 않다 / ~안 하다",
            "【1그룹】어미를 あ단 + ない\n" +
            "• 書く → 書かない\n" +
            "• 読む → 読まない\n" +
            "• 買う → 買わない (う는 わ로!)\n\n" +
            "【2그룹】る → ない\n" +
            "• 食べる → 食べない\n" +
            "• 見る → 見ない\n\n" +
            "【3그룹】\n" +
            "• する → しない\n" +
            "• 来る → 来ない(こない)\n\n" +
            "정중체: ～ません\n" +
            "보통체: ～ない"
        ),

        // --- て형 ---
        new GrammarItem(
            "동사 활용",
            "て형 규칙",
            "て형은 동사 끝에 따라 모양이 갈린다",
            "기본 규칙:\n" +
            "• う / つ / る → って\n" +
            "  - 買う → 買って / 待つ → 待って / 帰る → 帰って\n\n" +
            "• む / ぶ / ぬ → んで\n" +
            "  - 飲む → 飲んで / 遊ぶ → 遊んで\n\n" +
            "• く → いて  (예외: 行く → 行って)\n" +
            "  - 書く → 書いて\n\n" +
            "• ぐ → いで\n" +
            "  - 泳ぐ → 泳いで\n\n" +
            "• す → して\n" +
            "  - 話す → 話して\n\n" +
            "• 2그룹: る → て  (食べる → 食べて)\n" +
            "• 3그룹: する → して / 来る → 来て(きて)"
        ),

        new GrammarItem(
            "동사 활용",
            "て형의 쓰임",
            "연결 / 부탁 / 진행 / 허가 / 금지",
            "て형은 제일 많이 돌려 쓰는 연결형이다.\n\n" +
            "• 연결: ご飯を食べて、学校へ行きます。\n" +
            "  → 밥을 먹고, 학교에 갑니다.\n\n" +
            "• 부탁: 水を飲んでください。\n" +
            "  → 물을 마셔 주세요.\n\n" +
            "• 진행: 本を読んでいます。\n" +
            "  → 책을 읽고 있습니다.\n\n" +
            "• 허가: 入ってもいいです。\n" +
            "  → 들어가도 됩니다.\n\n" +
            "• 금지: ここで写真を撮ってはいけません。\n" +
            "  → 여기서 사진을 찍으면 안 됩니다.\n\n" +
            "중요: 飲んでください의 で는 て형 일부다. だ형과 혼동 금지!"
        ),

        new GrammarItem(
            "동사 활용",
            "って / んで 정체",
            "뜻 차이가 아니라 동사 끝글자 규칙",
            "• って → 1그룹 끝이 う/つ/る일 때\n" +
            "  - 買って, 待って, 帰って\n\n" +
            "• んで → 1그룹 끝이 む/ぶ/ぬ일 때\n" +
            "  - 飲んで, 遊んで, 死んで\n\n" +
            "포인트: 뜻 때문에 って와 んで가 갈리는 게 아니라,\n" +
            "어떤 동사냐에 따라 모양만 달라질 뿐이다.\n" +
            "둘 다 결국 て형이라서 기본 느낌은 ~하고 / ~해서."
        ),

        new GrammarItem(
            "동사 활용",
            "た형 규칙",
            "과거형 / 완료형의 기본",
            "て형과 거의 짝처럼 움직인다.\n\n" +
            "• う / つ / る → った  (買った, 待った)\n" +
            "• む / ぶ / ぬ → んだ  (飲んだ, 遊んだ)\n" +
            "• く → いた  (書いた) / 예외: 行った\n" +
            "• ぐ → いだ  (泳いだ)\n" +
            "• す → した  (話した)\n" +
            "• 2그룹: 食べた, 見た\n" +
            "• 3그룹: した, 来た(きた)\n\n" +
            "た형 쓰임:\n" +
            "• 보통체 과거: 昨日本を読んだ。\n" +
            "• ～たことがある: 경험\n" +
            "• ～たり～たりする: 나열\n" +
            "• ～た方がいい: 조언"
        ),

        // --- 12과 ---
        new GrammarItem(
            "12과",
            "12과 핵심 질문 패턴",
            "何をしますか / 何をしましたか",
            "• 今日は何をしますか。\n" +
            "  → 오늘은 무엇을 합니까?\n" +
            "• 友達と一緒に映画を見ます。\n" +
            "  → 친구와 함께 영화를 봅니다.\n\n" +
            "• 昨日は何をしましたか。\n" +
            "  → 어제는 무엇을 했습니까?\n" +
            "• 図書館で勉強をしました。\n" +
            "  → 도서관에서 공부를 했습니다.\n\n" +
            "포인트:\n" +
            "• 今日は → 현재/미래 의미의 ます형\n" +
            "• 昨日は → 과거 의미의 ました"
        ),

        new GrammarItem(
            "12과",
            "12과 조사 압축",
            "へ / で / に / と / を 정리",
            "• 日本へ行きます。 → 방향\n" +
            "• 学校で勉強します。 → 장소\n" +
            "• 6時に起きました。 → 시간\n" +
            "• 友達と一緒に映画を見ます。 → 함께\n" +
            "• 映画を見ます。 → 목적어\n\n" +
            "추가 함정:\n" +
            "• 何も + 부정 = 아무것도 ~하지 않다\n" +
            "  - 昨日は何も食べませんでした。\n" +
            "• どこへも + 부정 = 아무데도 ~하지 않다\n" +
            "  - 日曜日はどこへも行きませんでした。"
        ),

        // --- 13과 ---
        new GrammarItem(
            "13과",
            "～がほしいです",
            "원하는 물건 표현: ~을/를 갖고 싶다",
            "• 新しいパソコンがほしいです。\n" +
            "  → 새 컴퓨터를 갖고 싶습니다.\n\n" +
            "구조: 명사 + が + ほしいです\n" +
            "부정: ほしくないです\n\n" +
            "주의: ほしい는 い형용사로 활용한다.\n" +
            "• ほしかったです (과거)\n" +
            "• ほしくなかったです (과거 부정)"
        ),

        new GrammarItem(
            "13과",
            "～たいです",
            "하고 싶은 행동 표현: ~하고 싶다",
            "형태: ます형 어간 + たいです\n\n" +
            "• 日本へ行きたいです。\n" +
            "  → 일본에 가고 싶습니다.\n\n" +
            "활용 (い형용사처럼):\n" +
            "• 行きたくないです (가고 싶지 않다)\n" +
            "• 行きたかったです (가고 싶었다)\n\n" +
            "주의: たい는 화자 자신의 희망에만 사용.\n" +
            "타인은 → ～たがっています"
        ),

        new GrammarItem(
            "13과",
            "～に行きます / 来ます",
            "목적을 나타내는 に: ~하러 가다/오다",
            "형태: ます형 어간 + に + 行きます/来ます\n\n" +
            "• 映画を見に行きます。 → 영화를 보러 갑니다.\n" +
            "• 買い物に行きます。 → 쇼핑하러 갑니다.\n\n" +
            "명사의 경우:\n" +
            "• 食事に行きましょう。 → 식사하러 갑시다."
        ),

        // --- 14과 ---
        new GrammarItem(
            "14과",
            "～てください",
            "정중한 부탁 / 지시 표현",
            "형태: て형 + ください\n\n" +
            "• 電話番号を教えてください。\n" +
            "  → 전화번호를 알려 주세요.\n" +
            "• ここに名前を書いてください。\n" +
            "  → 여기에 이름을 써 주세요.\n\n" +
            "부정 부탁:\n" +
            "• ない형 + でください\n" +
            "  - ここで写真を撮らないでください。\n" +
            "  → 여기서 사진을 찍지 말아 주세요."
        ),

        new GrammarItem(
            "14과",
            "～ています (진행/상태)",
            "지금 하고 있는 동작 / 결과 상태",
            "형태: て형 + います\n\n" +
            "【진행】\n" +
            "• 今何をしていますか。 → 지금 뭐 하고 있어요?\n" +
            "• 手紙を書いています。 → 편지를 쓰고 있습니다.\n\n" +
            "【결과 상태】\n" +
            "• 窓が開いています。 → 창문이 열려 있습니다.\n\n" +
            "【습관/반복】\n" +
            "• 毎朝ジョギングをしています。\n\n" +
            "구분:\n" +
            "• 読みました = 읽었습니다(완료)\n" +
            "• 読んでいます = 읽고 있습니다(진행)"
        ),

        new GrammarItem(
            "14과",
            "～てもいいです / ～てはいけません",
            "허가와 금지 표현",
            "【허가】て형 + もいいです\n" +
            "• ここで写真を撮ってもいいですか。\n" +
            "  → 여기서 사진 찍어도 됩니까?\n\n" +
            "【금지】て형 + はいけません\n" +
            "• ここでタバコを吸ってはいけません。\n" +
            "  → 여기서 담배를 피우면 안 됩니다."
        ),

        // --- 15과 ---
        new GrammarItem(
            "15과",
            "～てから",
            "~한 후에 / ~하고 나서",
            "형태: て형 + から\n\n" +
            "• ご飯を食べてから、出かけます。\n" +
            "  → 밥을 먹은 후에 외출합니다.\n\n" +
            "비교: ～て (단순 연결) vs ～てから (순서 강조)\n" +
            "• 手を洗って食べます。 (가벼운 연결)\n" +
            "• 手を洗ってから食べます。 (순서 강조)"
        ),

        new GrammarItem(
            "15과",
            "～なければなりません",
            "~해야 합니다 (의무)",
            "형태: ない형에서 い → ければなりません\n\n" +
            "• 薬を飲まなければなりません。\n" +
            "  → 약을 먹어야 합니다.\n\n" +
            "구어 축약: ～なきゃ\n" +
            "  - 行かなきゃ → 가야 해\n\n" +
            "비슷한 표현: ～ないといけません"
        ),

        new GrammarItem(
            "15과",
            "～なくてもいいです",
            "~하지 않아도 됩니다",
            "형태: ない형에서 い → くてもいいです\n\n" +
            "• 明日は来なくてもいいです。\n" +
            "  → 내일은 오지 않아도 됩니다.\n\n" +
            "대비:\n" +
            "• ～なければなりません = 해야 한다 (의무)\n" +
            "• ～なくてもいいです = 안 해도 된다 (면제)"
        ),

        // --- 16과 ---
        new GrammarItem(
            "16과",
            "～ながら",
            "동시 진행: ~하면서",
            "형태: ます형 어간 + ながら\n\n" +
            "• 音楽を聞きながら歩きます。\n" +
            "  → 음악을 들으면서 걷습니다.\n\n" +
            "주의: て형이 아니라 ます형 어간이다.\n" +
            "聞いてながら(✗) / 聞きながら(✓)\n\n" +
            "뒤쪽 동사가 주된 동작, 앞쪽이 부수적 동작."
        ),

        new GrammarItem(
            "16과",
            "～たことがあります",
            "경험 표현: ~한 적이 있다",
            "형태: た형 + ことがあります\n\n" +
            "• 日本に行ったことがあります。\n" +
            "  → 일본에 간 적이 있습니다.\n\n" +
            "부정:\n" +
            "• 一度も行ったことがありません。\n" +
            "  → 한 번도 간 적이 없습니다."
        ),

        new GrammarItem(
            "16과",
            "～たり～たりします",
            "여러 동작 나열: ~하거나 ~하거나 합니다",
            "형태: た형 + り + た형 + り + します\n\n" +
            "• 日曜日は本を読んだり映画を見たりします。\n" +
            "  → 일요일에는 책을 읽거나 영화를 보거나 합니다.\n\n" +
            "형용사도 가능:\n" +
            "• 天気は暑かったり寒かったりします。\n\n" +
            "포인트: 대표적 행동 2~3개만 나열, 나머지는 함축."
        ),

        new GrammarItem(
            "16과",
            "～のが好き / 上手 / 下手",
            "동사를 명사화해서 형용사에 연결",
            "형태: 동사 사전형 + の + が + 好き/上手...\n\n" +
            "• 歌を歌うのが好きです。\n" +
            "  → 노래 부르는 것을 좋아합니다.\n" +
            "• 料理を作るのが上手です。\n" +
            "  → 요리를 만드는 것을 잘합니다.\n\n" +
            "の는 동사를 명사처럼 만들어 주는 역할."
        ),

        // --- ます형 관련 표현 ---
        new GrammarItem(
            "관련 표현",
            "～ましょう / ～ませんか",
            "권유·제안 표현",
            "• ～ましょう = 합시다 / 하자\n" +
            "  - 行きましょう。\n\n" +
            "• ～ましょうか = ~할까요? (제안)\n" +
            "  - 手伝いましょうか。\n\n" +
            "• ～ませんか = ~하지 않겠습니까? (정중 권유)\n" +
            "  - 一緒に行きませんか。"
        ),

        new GrammarItem(
            "관련 표현",
            "～すぎる / ～やすい / ～にくい",
            "과도함·난이도 표현",
            "형태: 모두 ます형 어간에 붙음\n\n" +
            "• ～すぎる = 너무 ~하다\n" +
            "  - 食べすぎる → 너무 먹다\n\n" +
            "• ～やすい = ~하기 쉽다\n" +
            "  - 読みやすい → 읽기 쉽다\n\n" +
            "• ～にくい = ~하기 어렵다\n" +
            "  - 分かりにくい → 이해하기 어렵다\n\n" +
            "주의: 기본형이 아니라 ます형 어간을 쓴다.\n" +
            "わかるやすい(✗) / わかりやすい(✓)"
        ),

        // --- 강독 ---
        new GrammarItem(
            "강독",
            "～と思います",
            "~라고 생각합니다 (의견·추측)",
            "형태: 보통체 + と思います\n\n" +
            "• 明日は雨が降ると思います。\n" +
            "  → 내일은 비가 올 거라고 생각합니다.\n\n" +
            "주의: です/ます가 아니라 보통체를 넣어야 한다.\n" +
            "  降りますと思います(✗)\n" +
            "  降ると思います(✓)"
        ),

        new GrammarItem(
            "강독",
            "～そうです (전문 vs 양태)",
            "전문: ~라고 합니다 / 양태: ~할 것 같다",
            "【전문】보통체 + そうです\n" +
            "• 明日は雨だそうです。 → 비라고 합니다.\n\n" +
            "【양태】ます형 어간 / い→ / な→ + そうです\n" +
            "• 降りそうです。 → 올 것 같습니다.\n" +
            "• おいしそうです。 → 맛있을 것 같습니다.\n\n" +
            "예외: いい → よさそう / ない → なさそう\n\n" +
            "핵심: 降るそうです(전문) vs 降りそうです(양태)"
        ),

        // --- 작문 ---
        new GrammarItem(
            "작문",
            "～とき",
            "~할 때 (시간 조건)",
            "• 동사 사전형 + とき = ~할 때\n" +
            "• 동사 た형 + とき = ~했을 때\n\n" +
            "• 日本に行くとき、カメラを買いました。\n" +
            "  → 일본에 갈 때 카메라를 샀습니다. (가기 전)\n" +
            "• 日本に行ったとき、富士山を見ました。\n" +
            "  → 일본에 갔을 때 후지산을 봤습니다. (도착 후)"
        ),

        new GrammarItem(
            "작문",
            "～たら / ～ば / ～と",
            "조건 표현 3종 비교",
            "【たら】た형 + ら = 개별 상황 (가장 범용)\n" +
            "• 雨が降ったら、行きません。\n\n" +
            "【ば】え단 + ば = 일반적 조건\n" +
            "• 安ければ買います。\n\n" +
            "【と】사전형 + と = 필연적 결과\n" +
            "• 春になると、桜が咲きます。\n\n" +
            "시험 팁: 헷갈리면 たら가 가장 무난!"
        ),

        new GrammarItem(
            "작문",
            "～のに / ～ために",
            "목적 표현 비교: ~하기 위해",
            "【～ために】사전형 + ために\n" +
            "• 日本語を勉強するために日本に来ました。\n" +
            "  → 일본어를 공부하기 위해 일본에 왔습니다.\n\n" +
            "【～のに】사전형 + のに\n" +
            "• この辞書は勉強するのに便利です。\n" +
            "  → 이 사전은 공부하는 데 편리합니다.\n\n" +
            "차이: ために = 의지적 목적 / のに = 용도·평가"
        ),

        // --- 문형 비교 ---
        new GrammarItem(
            "문형 비교",
            "だ vs で",
            "동사 て형의 で와, 명사/な형용사의 だ는 다른 것",
            "• 飲んでください 의 で = 동사의 て형 일부\n" +
            "• 学生だ / 静かだ 의 だ = 명사 / な형용사 서술형\n\n" +
            "• 飲むだ(✗) / 学生だ(✓)\n\n" +
            "모양이 비슷할 뿐, 문법 축이 완전히 다르다."
        ),

        new GrammarItem(
            "문형 비교",
            "보통체 vs 정중체",
            "友達 말투 vs です/ます 말투",
            "【정중체】行きます / 高いです / 静かです / 学生です\n" +
            "【보통체】行く / 高い / 静かだ / 学生だ\n\n" +
            "보통체를 쓰는 곳:\n" +
            "• 친한 사이 대화\n" +
            "• ～と思います, ～そうです 등의 절 안\n" +
            "• 일기, 메모 등 비격식 문장"
        ),

        new GrammarItem(
            "문형 비교",
            "수수 표현: あげる/もらう/くれる",
            "주다/받다의 방향에 따른 구분",
            "• あげる: (내가/누가) 남에게 주다\n" +
            "• もらう: (내가) 남에게서 받다\n" +
            "• くれる: (남이) 나에게 주다\n\n" +
            "동사 + て형과 결합:\n" +
            "• ～てあげる: ~해 주다 (내→남)\n" +
            "• ～てもらう: ~해 받다 (남→내)\n" +
            "• ～てくれる: ~해 주다 (남→내)"
        ),

        // --- 시험 정리 ---
        new GrammarItem(
            "시험 직전",
            "동사 변형은 언제 일어나는가",
            "무엇을 말하고 싶은가 기준으로 정리",
            "• 정중하게 → ます형 (食べます)\n" +
            "• 부정 → ない형 (食べない)\n" +
            "• 과거 → た형 (食べた)\n" +
            "• 연결 → て형 (食べて)\n" +
            "• 희망 → たい형 (食べたい)\n" +
            "• 가능 → 가능형 (食べられる)\n" +
            "• 의지·권유 → 의지형 (食べよう)\n" +
            "• 조건 → ば형/たら (食べれば/食べたら)\n\n" +
            "핵심: 형태를 위한 형태가 아니라, 기능에 따라 바뀐다."
        ),

        new GrammarItem(
            "시험 직전",
            "진짜 최소 암기 세트",
            "시험 직전에 돌려볼 문법 압축",
            "• は = 주제 / が = 주어·강조\n" +
            "• に = 도착점·시간 / で = 행동 장소\n" +
            "• い형용사는 い가 변함 / な형용사는 뒤가 변함\n" +
            "• ます형은 그룹 규칙 / て형은 어미 규칙\n" +
            "• きれい / 好き / 上手 특히 조심\n" +
            "• 行く → 行って / 行った 예외 암기\n" +
            "• ほしい = 물건 / たい = 행동\n" +
            "• ～てから = 한 후에\n" +
            "• ～なければなりません = 해야 한다\n" +
            "• ～たことがある = 경험\n" +
            "• ～たり～たりする = 나열\n" +
            "• と/ば/たら/なら = 조건 4종"
        ),

        new GrammarItem(
            "시험 직전",
            "암기 체크리스트",
            "1그룹 ない/ます/て/た형 한눈에",
            "• 1그룹 ない형: う단→あ단+ない (う는 わない)\n" +
            "• 1그룹 ます형: う단→い단+ます\n" +
            "• 1그룹 て형: うつる→って / むぶぬ→んで / く→いて / ぐ→いで / す→して\n" +
            "• 1그룹 た형: うつる→った / むぶぬ→んだ / く→いた / ぐ→いだ / す→した\n" +
            "• 2그룹: る를 떼고 ます/ない/て/た\n" +
            "• 3그룹: する→します/しない/して/した\n" +
            "        来る→来ます/来ない/来て/来た\n\n" +
            "• だ = 명사·な형용사 서술 / で = て형 일부 또는 な형용사 연결형"
        )
    };

    // ============================
    // 문법패턴 모드용 데이터 (강독 교재 Part 01~04)
    // 문법 모드와 완전 분리!
    // ============================
    private readonly List<PatternItem> _patternItems = new()
    {
        // --- Part 01 ---
        new PatternItem(
            "Part 01", "～ている",
            "~하고 있다 / ~해 있는 상태다",
            "동사 て형 + いる",
            "私は中華料理の店でアルバイトをしています。",
            "저는 중화요리 가게에서 아르바이트를 하고 있습니다.",
            "진행 표현의 기본형이다. する는 반드시 して, 来る는 来て로 바뀐다."
        ),
        new PatternItem(
            "Part 01", "～てから",
            "~하고 나서 / ~한 다음에",
            "동사 て형 + から",
            "私は大学を卒業してから、日本の会社に勤めました。",
            "저는 대학을 졸업하고 나서 일본 회사에 다녔습니다.",
            "단순 과거형 卒業した와 다르게, 뒤 행동과의 순서 관계를 드러낸다."
        ),
        new PatternItem(
            "Part 01", "～たい",
            "~하고 싶다",
            "동사 ます형 어간 + たい\n예) 行きます→行きたい / します→したい / 来ます→来たい(きたい)",
            "私はいつか、自分の家を持ちたいです。",
            "저는 언젠가 제 집을 갖고 싶습니다.",
            "ます를 떼고 바로 たい를 붙인다. なる는 なりたい가 되며, 명사 앞에는 に: 医者になりたい。"
        ),
        new PatternItem(
            "Part 01", "（N）になる",
            "~이 되다",
            "명사 + に + なる\n예) 医者になる / 春になる / 一年になる",
            "サッカー選手になるのが私の夢です。",
            "축구 선수가 되는 것이 제 꿈입니다.",
            "\"~이 되다\"는 が 아니라 に를 쓴다. ～のが와 결합하면 \"~하는 것이\"라는 명사문이 된다."
        ),

        // --- Part 02 ---
        new PatternItem(
            "Part 02", "～という N",
            "~라고 하는 / ~라는 N",
            "명사·문장 + という + 명사\n예) アナンさんという友だち / 何という名前",
            "私にはタイから来たアナンさんという友だちがいます。",
            "제게는 태국에서 온 아난이라는 친구가 있습니다.",
            "\"이름/소개/설명 붙이기\" 패턴으로 기억하면 편하다."
        ),
        new PatternItem(
            "Part 02", "～てくれる",
            "~해 주다 (남이 나에게)",
            "동사 て형 + くれる\n예) 紹介してくれる / 送ってくれる",
            "山田さんが私たちを駅まで送ってくれました。",
            "야마다 씨가 우리를 역까지 데려다주었습니다.",
            "주는 사람은 주어가 되고, 도움을 받는 사람(私に)은 생략되는 경우가 많다."
        ),
        new PatternItem(
            "Part 02", "～とき",
            "~할 때",
            "동사 기본형/た형 + とき\nい형용사 보통형 + とき\n명사 + のとき",
            "日本では部屋を借りるとき、連帯保証人が必要な場合が多いです。",
            "일본에서는 방을 빌릴 때 연대보증인이 필요한 경우가 많습니다.",
            "동사는 시점에 따라 기본형과 た형이 둘 다 가능. 명사는 のとき, な형용사는 なとき."
        ),
        new PatternItem(
            "Part 02", "～と思う",
            "~라고 생각하다",
            "보통형 + と思う\n예) 晴れると思う / おかしいと思う / 学生だと思う",
            "私はその話を聞いて、礼金は少しおかしいと思いました。",
            "저는 그 이야기를 듣고 사례금은 조금 이상하다고 생각했습니다.",
            "앞에는 보통형이 온다. な형용사·명사는 현재 긍정에서 だ를 쓰는 것이 원칙."
        ),

        // --- Part 03 ---
        new PatternItem(
            "Part 03", "～やすい",
            "~하기 쉽다 / ~하기 편하다",
            "동사 ます형 어간 + やすい\n예) 働きます→働きやすい / 見ます→見やすい",
            "店長がやさしくて、とても働きやすい職場です。",
            "점장이 친절해서 매우 일하기 편한 직장입니다.",
            "ます형 어간을 쓰므로 기본형 그대로 붙이지 않는다. わかる→わかりやすい."
        ),
        new PatternItem(
            "Part 03", "～かどうか",
            "~인지 어떤지 / ~인지 아닌지",
            "보통형 + かどうか\n예) 高いかどうか / やさしいかどうか",
            "時給が高いかどうかよりも、日本語を話す機会が多いことの方が大切です。",
            "시급이 높은지 어떤지보다 일본어를 말할 기회가 많은지가 더 중요합니다.",
            "뒤에 わかりません, 知りません, 確かめます, よりも 같은 표현이 자주 온다."
        ),
        new PatternItem(
            "Part 03", "～方がいい",
            "~하는 편이 좋다 / ~하지 않는 편이 좋다",
            "긍정: 동사 た형 + 方がいい\n부정: 동사 ない형 + 方がいい",
            "日本語を話す機会が多いアルバイトを選んだ方がいいと思います。",
            "일본어를 말할 기회가 많은 아르바이트를 고르는 편이 좋다고 생각합니다.",
            "긍정은 왜 과거형? → 문형 자체가 Vた方がいい로 굳어 있다."
        ),
        new PatternItem(
            "Part 03", "～前に",
            "~전에 / ~하기 전에",
            "동사 기본형 + 前に\n명사 + の前に",
            "アルバイトを始める前に、入国管理局で資格外活動許可証をもらいます。",
            "아르바이트를 시작하기 전에 입국관리국에서 자격외활동허가증을 받습니다.",
            "ます형이 아니라 기본형을 쓴다. 始める前に, 寝る前に처럼 사전형으로 붙이는 것이 핵심."
        ),

        // --- Part 04 ---
        new PatternItem(
            "Part 04", "～へ／～に 行く",
            "~에 ~하러 가다",
            "장소 + へ/に + 동사 ます형 어간 + に + 行く\n예) 銀行へ口座を開きに行く",
            "昨日、銀行へ口座を開きに行きました。",
            "어제 은행에 계좌를 만들러 갔습니다.",
            "목적 동사는 기본형이 아니라 ます형 어간을 쓴다. 開くに行く(✗) / 開きに行く(✓)."
        ),
        new PatternItem(
            "Part 04", "～てもらう",
            "~해 받다 / ~해 주다를 받다",
            "주는 사람 + に/から + 동사 て형 + もらう\n예) 友だちに教えてもらう",
            "私は友だちにATMの使い方を教えてもらいました。",
            "저는 친구에게 ATM 사용법을 배웠습니다.",
            "てくれる가 주는 사람 중심이라면, てもらう는 받는 사람 중심이다."
        ),
        new PatternItem(
            "Part 04", "～ために",
            "~하기 위해(서)",
            "동사 기본형 + ために\n명사 + のために",
            "私は将来自分の店を持つために、貯金しています。",
            "저는 장래에 제 가게를 갖기 위해 저축하고 있습니다.",
            "앞에는 기본형이 온다. たい형(희망)과 다르다: なりたい(희망) vs なるために(목적)."
        ),
        new PatternItem(
            "Part 04", "～からだ / ～からです",
            "~하기 때문이다",
            "보통형 + からだ / からです\n틀: ～のは、…からです",
            "私が日本に留学したのは、通訳になりたいからです。",
            "제가 일본에 유학한 것은 통역사가 되고 싶기 때문입니다.",
            "どうして/なぜ 질문에 ～からです로 끝내면 답안이 단정하고 안정적이다."
        )
    };

    private readonly Random _random = new();

    // ============================
    // 한자 모드 상태값들
    // ============================
    private WordItem? _currentWord;
    private int _currentIndex = -1;
    private bool _showFurigana = false;
    private bool _isSequentialMode = false;
    private bool _favoritesPanelVisible = false;
    private bool _kanjiListVisible = false;
    private int _randomSeenCount = 0;

    // ============================
    // 문법 모드 상태값들
    // ============================
    private GrammarItem? _currentGrammar;
    private int _currentGrammarIndex = -1;
    private bool _grammarListVisible = false;

    // ============================
    // 문법패턴 모드 상태값들
    // ============================
    private PatternItem? _currentPattern;
    private int _currentPatternIndex = -1;
    private bool _patternListVisible = false;

    public MainPage()
    {
        InitializeComponent();

        LoadWordFavorites();
        LoadGrammarFavorites();
        LoadPatternFavorites();

        ShowInitialWord();
        ShowInitialGrammar();
        ShowInitialPattern();

        RefreshFavoritesList();
        RefreshKanjiList();
        RefreshGrammarList();
        RefreshPatternList();

        ModePicker.SelectedIndex = 0;
        UpdateModeView();
    }

    // ============================
    // 공통
    // ============================

    private void OnModeChanged(object sender, EventArgs e)
    {
        UpdateModeView();
    }

    private void UpdateModeView()
    {
        int selected = ModePicker.SelectedIndex;
        KanjiModeView.IsVisible = selected == 0;
        GrammarModeView.IsVisible = selected == 1;
        PatternModeView.IsVisible = selected == 2;
    }

    private async void OnAboutClicked(object sender, EventArgs e)
    {
        await DisplayAlert(
            "앱 정보",
            $"일본어 암기 앱\n{CopyrightNotice}\n저작자: 유한대 게임콘텐츠과 박찬솔\n개인 학습용 앱",
            "확인");
    }

    // ============================
    // 한자 모드
    // ============================

    private void ShowInitialWord()
    {
        if (_words.Count == 0) return;
        _currentIndex = _random.Next(_words.Count);
        _currentWord = _words[_currentIndex];
        _randomSeenCount = 1;
        UpdateWordCard();
    }

    private void ShowWordAt(int index)
    {
        if (_words.Count == 0) return;
        if (index < 0) index = _words.Count - 1;
        else if (index >= _words.Count) index = 0;
        _currentIndex = index;
        _currentWord = _words[_currentIndex];
        UpdateWordCard();
    }

    private void ShowNextWord()
    {
        if (_words.Count == 0) return;

        if (_isSequentialMode)
        {
            _currentIndex = _currentIndex < 0 ? 0 : (_currentIndex + 1) % _words.Count;
        }
        else
        {
            int newIndex;
            if (_words.Count == 1) { newIndex = 0; }
            else { do { newIndex = _random.Next(_words.Count); } while (newIndex == _currentIndex); }
            _currentIndex = newIndex;
            _randomSeenCount++;
        }
        _currentWord = _words[_currentIndex];
        UpdateWordCard();
    }

    private void ShowPrevWord()
    {
        if (_words.Count == 0) return;

        if (_isSequentialMode)
        {
            _currentIndex = _currentIndex <= 0 ? _words.Count - 1 : _currentIndex - 1;
        }
        else
        {
            int newIndex;
            if (_words.Count == 1) { newIndex = 0; }
            else { do { newIndex = _random.Next(_words.Count); } while (newIndex == _currentIndex); }
            _currentIndex = newIndex;
        }
        _currentWord = _words[_currentIndex];
        UpdateWordCard();
    }

    private void UpdateWordCard()
    {
        if (_currentWord == null) return;
        KoreanLabel.Text = _currentWord.Korean;
        JapaneseLabel.Text = _currentWord.Japanese;
        FuriganaLabel.Text = _currentWord.Furigana;
        FuriganaLabel.IsVisible = _showFurigana;
        JapaneseLabel.IsVisible = false;
        FavoriteButton.Text = _currentWord.IsFavorite ? "★ 즐겨찾기 해제" : "☆ 즐겨찾기";
        UpdateWordProgressText();
    }

    private void UpdateWordProgressText()
    {
        if (_words.Count == 0) { ProgressLabel.Text = "진행: 0 / 0"; return; }
        ProgressLabel.Text = _isSequentialMode
            ? $"진행: {_currentIndex + 1} / {_words.Count}"
            : $"진행: 랜덤 모드 · {_randomSeenCount}개 봄";
    }

    private void RefreshFavoritesList()
    {
        var favorites = _words.Where(x => x.IsFavorite).ToList();
        FavoritesSummaryLabel.Text = $"즐겨찾기: {favorites.Count}개";
        EmptyFavoritesLabel.IsVisible = favorites.Count == 0;
        FavoritesCollectionView.IsVisible = favorites.Count > 0;
        FavoritesCollectionView.ItemsSource = favorites;
        FavoritesToggleButton.Text = _favoritesPanelVisible ? "즐겨찾기 목록 닫기" : "즐겨찾기 목록 보기";
    }

    private void RefreshKanjiList()
    {
        var rows = _words.Select((w, i) => new KanjiListRow
        {
            IndexDisplay = $"{i + 1}.",
            FavStar = w.IsFavorite ? "★" : "",
            Korean = w.Korean,
            Japanese = w.Japanese,
            Source = w,
            SourceIndex = i
        }).ToList();

        KanjiListSummaryLabel.Text = $"한자 목차: {_words.Count}개";
        KanjiListCollectionView.ItemsSource = rows;
        KanjiListToggleButton.Text = _kanjiListVisible ? "한자 목차 닫기" : "한자 목차 보기";
    }

    private void SaveWordFavorites()
    {
        var keys = _words.Where(x => x.IsFavorite).Select(x => x.Key).ToList();
        Preferences.Default.Set(WordFavoritesPreferenceKey, JsonSerializer.Serialize(keys));
    }

    private void LoadWordFavorites()
    {
        try
        {
            string json = Preferences.Default.Get(WordFavoritesPreferenceKey, "[]");
            var set = (JsonSerializer.Deserialize<List<string>>(json) ?? new()).ToHashSet();
            foreach (var w in _words) w.IsFavorite = set.Contains(w.Key);
        }
        catch { foreach (var w in _words) w.IsFavorite = false; }
    }

    // --- 한자 모드 이벤트 ---

    private void OnShowAnswerClicked(object sender, EventArgs e)
    {
        JapaneseLabel.IsVisible = !JapaneseLabel.IsVisible;
    }

    private void OnPrevClicked(object sender, EventArgs e) => ShowPrevWord();
    private void OnNextClicked(object sender, EventArgs e) => ShowNextWord();

    private void OnFuriganaToggled(object sender, ToggledEventArgs e)
    {
        _showFurigana = e.Value;
        FuriganaLabel.IsVisible = _showFurigana;
    }

    private void OnSequentialToggled(object sender, ToggledEventArgs e)
    {
        _isSequentialMode = e.Value;
        if (_currentWord != null) _currentIndex = _words.IndexOf(_currentWord);
        UpdateWordProgressText();
    }

    private void OnFavoriteClicked(object sender, EventArgs e)
    {
        if (_currentWord == null) return;
        _currentWord.IsFavorite = !_currentWord.IsFavorite;
        SaveWordFavorites();
        FavoriteButton.Text = _currentWord.IsFavorite ? "★ 즐겨찾기 해제" : "☆ 즐겨찾기";
        RefreshFavoritesList();
        RefreshKanjiList();
    }

    private void OnToggleFavoritesListClicked(object sender, EventArgs e)
    {
        _favoritesPanelVisible = !_favoritesPanelVisible;
        FavoritesPanel.IsVisible = _favoritesPanelVisible;
        if (_favoritesPanelVisible && _kanjiListVisible) { _kanjiListVisible = false; KanjiListPanel.IsVisible = false; RefreshKanjiList(); }
        RefreshFavoritesList();
    }

    private void OnToggleKanjiListClicked(object sender, EventArgs e)
    {
        _kanjiListVisible = !_kanjiListVisible;
        KanjiListPanel.IsVisible = _kanjiListVisible;
        if (_kanjiListVisible && _favoritesPanelVisible) { _favoritesPanelVisible = false; FavoritesPanel.IsVisible = false; RefreshFavoritesList(); }
        RefreshKanjiList();
    }

    private void OnFavoriteSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not WordItem sel) return;
        _currentWord = sel;
        _currentIndex = _words.IndexOf(sel);
        UpdateWordCard();
        if (sender is CollectionView cv) cv.SelectedItem = null;
    }

    private void OnKanjiListSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not KanjiListRow row) return;
        _currentWord = row.Source;
        _currentIndex = row.SourceIndex;
        UpdateWordCard();
        if (sender is CollectionView cv) cv.SelectedItem = null;
    }

    // ============================
    // 문법 모드
    // ============================

    private void ShowInitialGrammar()
    {
        if (_grammarItems.Count == 0) return;
        _currentGrammarIndex = 0;
        _currentGrammar = _grammarItems[0];
        UpdateGrammarCard();
    }

    private void ShowGrammarAt(int index)
    {
        if (_grammarItems.Count == 0) return;
        if (index < 0) index = _grammarItems.Count - 1;
        else if (index >= _grammarItems.Count) index = 0;
        _currentGrammarIndex = index;
        _currentGrammar = _grammarItems[index];
        UpdateGrammarCard();
    }

    private void UpdateGrammarCard()
    {
        if (_currentGrammar == null) return;
        GrammarCategoryLabel.Text = _currentGrammar.Category;
        GrammarTitleLabel.Text = _currentGrammar.Title;
        GrammarSummaryLabel.Text = _currentGrammar.Summary;
        GrammarContentLabel.Text = _currentGrammar.Content;
        GrammarFavoriteButton.Text = _currentGrammar.IsFavorite ? "★ 문법 즐겨찾기 해제" : "☆ 문법 즐겨찾기";
        int page = _currentGrammarIndex + 1, total = _grammarItems.Count;
        GrammarProgressLabel.Text = $"문법: {page} / {total}";
        GrammarProgressBar.Progress = (double)page / total;
        GrammarPageLabel.Text = $"{page} / {total}";
    }

    private void RefreshGrammarList()
    {
        var rows = _grammarItems.Select((x, i) => new GrammarListRow
        {
            IndexDisplay = $"{i + 1}.",
            TitleDisplay = x.IsFavorite ? $"★ {x.Title}" : x.Title,
            Subtitle = $"[{x.Category}] {x.Summary}",
            Source = x
        }).ToList();

        int fav = _grammarItems.Count(x => x.IsFavorite);
        GrammarListSummaryLabel.Text = $"문법 목록: {_grammarItems.Count}개 · 즐겨찾기 {fav}개";
        GrammarCollectionView.ItemsSource = rows;
        GrammarListToggleButton.Text = _grammarListVisible ? "문법 목록 닫기" : "문법 목록 보기";
    }

    private void SaveGrammarFavorites()
    {
        var keys = _grammarItems.Where(x => x.IsFavorite).Select(x => x.Key).ToList();
        Preferences.Default.Set(GrammarFavoritesPreferenceKey, JsonSerializer.Serialize(keys));
    }

    private void LoadGrammarFavorites()
    {
        try
        {
            string json = Preferences.Default.Get(GrammarFavoritesPreferenceKey, "[]");
            var set = (JsonSerializer.Deserialize<List<string>>(json) ?? new()).ToHashSet();
            foreach (var g in _grammarItems) g.IsFavorite = set.Contains(g.Key);
        }
        catch { foreach (var g in _grammarItems) g.IsFavorite = false; }
    }

    // --- 문법 이벤트 ---

    private void OnGrammarPrevClicked(object sender, EventArgs e) => ShowGrammarAt(_currentGrammarIndex - 1);
    private void OnGrammarNextClicked(object sender, EventArgs e) => ShowGrammarAt(_currentGrammarIndex + 1);

    private void OnGrammarFavoriteClicked(object sender, EventArgs e)
    {
        if (_currentGrammar == null) return;
        _currentGrammar.IsFavorite = !_currentGrammar.IsFavorite;
        SaveGrammarFavorites();
        UpdateGrammarCard();
        RefreshGrammarList();
    }

    private void OnToggleGrammarListClicked(object sender, EventArgs e)
    {
        _grammarListVisible = !_grammarListVisible;
        GrammarListPanel.IsVisible = _grammarListVisible;
        RefreshGrammarList();
    }

    private void OnGrammarSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not GrammarListRow row) return;
        _currentGrammar = row.Source;
        _currentGrammarIndex = _grammarItems.IndexOf(row.Source);
        UpdateGrammarCard();
        if (sender is CollectionView cv) cv.SelectedItem = null;
    }

    // ============================
    // 문법패턴 모드
    // ============================

    private void ShowInitialPattern()
    {
        if (_patternItems.Count == 0) return;
        _currentPatternIndex = 0;
        _currentPattern = _patternItems[0];
        UpdatePatternCard();
    }

    private void ShowPatternAt(int index)
    {
        if (_patternItems.Count == 0) return;
        if (index < 0) index = _patternItems.Count - 1;
        else if (index >= _patternItems.Count) index = 0;
        _currentPatternIndex = index;
        _currentPattern = _patternItems[index];
        UpdatePatternCard();
    }

    private void UpdatePatternCard()
    {
        if (_currentPattern == null) return;

        PatternPartLabel.Text = _currentPattern.Part;
        PatternNameLabel.Text = _currentPattern.Name;
        PatternMeaningLabel.Text = _currentPattern.Meaning;
        PatternConnectionLabel.Text = _currentPattern.Connection;
        PatternExampleLabel.Text = _currentPattern.Example;
        PatternTranslationLabel.Text = _currentPattern.Translation;
        PatternPointLabel.Text = _currentPattern.Point;

        PatternFavoriteButton.Text = _currentPattern.IsFavorite ? "★ 패턴 즐겨찾기 해제" : "☆ 패턴 즐겨찾기";

        int page = _currentPatternIndex + 1, total = _patternItems.Count;
        PatternProgressLabel.Text = $"패턴: {page} / {total}";
        PatternProgressBar.Progress = (double)page / total;
        PatternPageLabel.Text = $"{page} / {total}";
    }

    private void RefreshPatternList()
    {
        var rows = _patternItems.Select((x, i) => new PatternListRow
        {
            IndexDisplay = $"{i + 1}.",
            TitleDisplay = x.IsFavorite ? $"★ {x.Name}" : x.Name,
            Subtitle = $"[{x.Part}] {x.Meaning}",
            Source = x
        }).ToList();

        int fav = _patternItems.Count(x => x.IsFavorite);
        PatternListSummaryLabel.Text = $"패턴 목록: {_patternItems.Count}개 · 즐겨찾기 {fav}개";
        PatternCollectionView.ItemsSource = rows;
        PatternListToggleButton.Text = _patternListVisible ? "패턴 목록 닫기" : "패턴 목록 보기";
    }

    private void SavePatternFavorites()
    {
        var keys = _patternItems.Where(x => x.IsFavorite).Select(x => x.Key).ToList();
        Preferences.Default.Set(PatternFavoritesPreferenceKey, JsonSerializer.Serialize(keys));
    }

    private void LoadPatternFavorites()
    {
        try
        {
            string json = Preferences.Default.Get(PatternFavoritesPreferenceKey, "[]");
            var set = (JsonSerializer.Deserialize<List<string>>(json) ?? new()).ToHashSet();
            foreach (var p in _patternItems) p.IsFavorite = set.Contains(p.Key);
        }
        catch { foreach (var p in _patternItems) p.IsFavorite = false; }
    }

    // --- 패턴 이벤트 ---

    private void OnPatternPrevClicked(object sender, EventArgs e) => ShowPatternAt(_currentPatternIndex - 1);
    private void OnPatternNextClicked(object sender, EventArgs e) => ShowPatternAt(_currentPatternIndex + 1);

    private void OnPatternFavoriteClicked(object sender, EventArgs e)
    {
        if (_currentPattern == null) return;
        _currentPattern.IsFavorite = !_currentPattern.IsFavorite;
        SavePatternFavorites();
        UpdatePatternCard();
        RefreshPatternList();
    }

    private void OnTogglePatternListClicked(object sender, EventArgs e)
    {
        _patternListVisible = !_patternListVisible;
        PatternListPanel.IsVisible = _patternListVisible;
        RefreshPatternList();
    }

    private void OnPatternSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not PatternListRow row) return;
        _currentPattern = row.Source;
        _currentPatternIndex = _patternItems.IndexOf(row.Source);
        UpdatePatternCard();
        if (sender is CollectionView cv) cv.SelectedItem = null;
    }

    // ============================
    // 내부 클래스
    // ============================

    private class WordItem
    {
        public string Korean { get; set; }
        public string Japanese { get; set; }
        public string Furigana { get; set; }
        public bool IsFavorite { get; set; }
        public string Key => $"{Korean}|{Japanese}|{Furigana}";

        public WordItem(string korean, string japanese, string furigana)
        {
            Korean = korean; Japanese = japanese; Furigana = furigana; IsFavorite = false;
        }
    }

    private class GrammarItem
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public bool IsFavorite { get; set; }
        public string Key => $"{Category}|{Title}";

        public GrammarItem(string category, string title, string summary, string content)
        {
            Category = category; Title = title; Summary = summary; Content = content; IsFavorite = false;
        }
    }

    // 문법패턴 전용 데이터 클래스 (문법 모드와 완전 분리)
    private class PatternItem
    {
        public string Part { get; set; }        // Part 01~04
        public string Name { get; set; }        // 패턴명 (～ている 등)
        public string Meaning { get; set; }     // 의미
        public string Connection { get; set; }  // 접속 형태
        public string Example { get; set; }     // 예문 (일본어)
        public string Translation { get; set; } // 예문 해석
        public string Point { get; set; }       // 시험 포인트
        public bool IsFavorite { get; set; }
        public string Key => $"{Part}|{Name}";

        public PatternItem(string part, string name, string meaning,
            string connection, string example, string translation, string point)
        {
            Part = part; Name = name; Meaning = meaning;
            Connection = connection; Example = example;
            Translation = translation; Point = point;
            IsFavorite = false;
        }
    }

    private class GrammarListRow
    {
        public string IndexDisplay { get; set; } = "";
        public string TitleDisplay { get; set; } = "";
        public string Subtitle { get; set; } = "";
        public GrammarItem Source { get; set; } = null!;
    }

    private class KanjiListRow
    {
        public string IndexDisplay { get; set; } = "";
        public string FavStar { get; set; } = "";
        public string Korean { get; set; } = "";
        public string Japanese { get; set; } = "";
        public WordItem Source { get; set; } = null!;
        public int SourceIndex { get; set; }
    }

    private class PatternListRow
    {
        public string IndexDisplay { get; set; } = "";
        public string TitleDisplay { get; set; } = "";
        public string Subtitle { get; set; } = "";
        public PatternItem Source { get; set; } = null!;
    }
}

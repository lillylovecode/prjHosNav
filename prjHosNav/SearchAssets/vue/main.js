const app = Vue.createApp({
    data() {
        return {
            type: [
                "牙科", //0
                "眼科", //1
                "耳鼻喉科", //2
                "胸腔科", //3
                "一般消化科", //4
                "泌尿科", //5
                "泌尿、婦產科", //6
                "心臟外科、心臟內科", //7
                "骨科", //8
                "皮膚、外傷科", //9
                "家庭醫學科", //10
                "身心科", //11
                "老人醫學科、", //12
                "胃腸內科", //13
                "肝膽胰內科", //14
                "大腸直腸外科", //15
            ],
            nurseshow: true,
            nurse2show: true,
            h1isShow: true,
            isShow: false,
            idx: 0,
            totalAnswer: "",
            selectedAnswer: "",
            randomHosCount: "",
            randomHos: [
                {
                    name: "高雄醫學大學附設中和紀念醫院",
                    URL: "https://www.kmuh.org.tw/KMUHInterWeb/InterWeb/InnerPage/1001124050",
                },
                {
                    name: "國軍高雄總醫院",
                    URL: "https://reg.802.mnd.gov.tw/",
                },
                {
                    name: "榮民總醫院",
                    URL: "https://webreg.vghks.gov.tw/wps/portal/web/announce/!ut/p/b1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOKdfYMC_L3dDQ3cXR3NDDz9PAPMHS38DUxcTPS99KPSc_KTgErD9aPwKvYxhyowwAEcDfT9PPJzU_ULsoODLBwVFQHydxO9/dl4/d5/L2dBISEvZ0FBIS9nQSEh/",
                },
                {
                    name: "民生醫院",
                    URL: "https://www.kmsh.gov.tw/trenew/",
                },
                {
                    name: "大同醫院",
                    URL: "https://www.kmtth.org.tw/Web/KMTTHInterWeb/InterWeb/InnerPage/2020010690",
                },
                {
                    name: "阮綜合醫院",
                    URL: "https://register.yuanhosp.com.tw/register3/",
                },
                {
                    name: "長庚紀念醫院",
                    URL: "https://register.cgmh.org.tw/Register/8",
                },
            ],
            count: 8,
            questions: [
                {
                    srcimg:
                        "https://images.pexels.com/photos/112787/pexels-photo-112787.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
                    question: "請問您的年齡位於下列哪一段區域?",
                    answers: { a: "65歲以上", b: "18~64歲", c: "18歲以下" },
                    // 順序: "0",
                },
                {
                    srcimg:
                        "https://images.pexels.com/photos/7298867/pexels-photo-7298867.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
                    question: "哪個部位不舒服?",
                    answers: {
                        a: "頭頸",
                        b: "胸腹",
                        c: "生殖",
                        d: "心臟",
                        e: "四肢",
                        f: "其他",
                    },
                    // 順序: "1",
                },
                {
                    srcimg:
                        "https://images.pexels.com/photos/1576193/pexels-photo-1576193.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
                    question: "接近哪個部位呢?",
                    answers: {
                        a: "口腔",
                        b: "眼",
                        c: "耳",
                        d: "鼻",
                        e: "喉",
                    },
                    // 順序: "2",
                },
                {
                    srcimg:
                        "https://images.pexels.com/photos/5938368/pexels-photo-5938368.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
                    question: "請選擇感到不適的部位",
                    answers: {
                        a: "呼吸道不適",
                        b: "消化道不適",
                    },
                    // 順序: "3",
                },
                {
                    srcimg:
                        "https://images.pexels.com/photos/5938368/pexels-photo-5938368.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
                    question: "請問您的性別?",
                    answers: {
                        a: "男性",
                        b: "女性",
                    },
                    // 順序: "4",
                },
                {
                    srcimg:
                        "https://images.pexels.com/photos/7723388/pexels-photo-7723388.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
                    question: "是否傷及骨頭?",
                    answers: {
                        a: "是",
                        b: "否",
                    },
                    // 順序: "5",
                },
                {
                    srcimg:
                        "https://images.pexels.com/photos/6135040/pexels-photo-6135040.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
                    question: "請選擇感到不適的部位",
                    answers: {
                        a: "發燒感冒、其實我不是很清楚欸",
                        b: "心情鬱悶",
                    },
                    // 順序: "6",
                },
                {
                    srcimg:
                        "https://images.pexels.com/photos/6135040/pexels-photo-6135040.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
                    question: "請選擇腹部感到不適的部位 - 疼痛四象限",
                    answers: {
                        a: "肚子右上部位",
                        b: "肚子左上部位",
                        c: "肚子右下部位",
                        d: "肚子左下部位",
                    },
                    // 順序: "7",
                },
            ],
        };
    },
    methods: {
        showgsap() {
            this.isShow = !this.isShow;
            this.h1isShow = !this.h1isShow;
            this.nurseshow = !this.nurseshow;
            this.nurse2show = !this.nurse2show;
        },
        answered(e) {
            this.selectedAnswer = e.target.value;
            const old = this.idx.toString() + this.selectedAnswer;
            switch (old) {
                case "0a":
                    this.totalAnswer = this.type[12]; // "老人醫學科",
                    break;
                case "7a":
                    this.totalAnswer = this.type[13]; // "胃腸內科",
                    break;
                case "7b":
                    this.totalAnswer = this.type[14]; // "肝膽胰內科",
                    break;
                case "7c":
                    this.totalAnswer = this.type[4]; // "一般消化科",
                    break;
                case "7d":
                    this.totalAnswer = this.type[15]; // "大腸直腸外科",
                    break;

                default:
            }
            document.querySelectorAll("input").forEach((el) => (el.checked = false));
        },
        nextQuestion() {
            const status = this.idx.toString() + this.selectedAnswer;
            switch (status) {
                case "0c":
                    this.totalAnswer = "小兒科";
                    this.idx += 7;
                    break;
                case "1b":
                    this.idx += 2;
                    break;
                case "1c":
                    this.idx += 3;
                    break;
                case "1d":
                    this.totalAnswer = this.type[7]; //"心臟外科、心臟內科",
                    this.idx += 7;
                    break;
                case "1e":
                    this.idx += 4;
                    break;
                case "1f":
                    this.idx += 5;
                    break;
                case "2a":
                    this.totalAnswer = this.type[0]; // "牙科",
                    this.idx += 7;
                    break;
                case "2b":
                    this.totalAnswer = this.type[1]; // "眼科",
                    this.idx += 7;
                    break;
                case "2c":
                case "2d":
                case "2e":
                    this.totalAnswer = this.type[2]; // "耳鼻喉科",
                    this.idx += 7;
                    break;
                case "3a":
                    this.totalAnswer = this.type[3]; // "胸腔科",
                    this.idx += 7;
                    break;
                case "3b":
                    this.idx += 4;
                    break;
                case "4a":
                    this.totalAnswer = this.type[5]; // "泌尿科",
                    this.idx += 7;
                    break;
                case "4b":
                    this.totalAnswer = this.type[6]; // "泌尿、婦產科",
                    this.idx += 7;
                    break;
                case "5a":
                    this.totalAnswer = this.type[8]; // "骨科",
                    this.idx += 7;
                    break;
                case "5b":
                    this.totalAnswer = this.type[9]; // "皮膚、外傷科",
                    this.idx += 7;
                    break;
                case "6a":
                    this.totalAnswer = this.totalAnswer + this.type[10]; // "家庭醫學科",
                    this.idx += 7;
                    break;
                case "6b":
                    this.totalAnswer = this.totalAnswer + this.type[11]; // "身心",
                    this.idx += 7;
                    break;
                default:
                    this.idx++;
            }
            this.selectedAnswer = "";
            // document.querySelectorAll("input").forEach((el) => (el.checked = false));
        },
        showResults() {
            this.idx++;
        },
        resetQuiz() {
            this.idx = 0;
            this.selectedAnswer = "";
            this.correctAnswers = 0;
            this.wrongAnswers = 0;
            this.totalAnswer = "";
            this.ranhosMethod();
        },
        ranhosMethod() {
            this.randomHosCount = Math.round(Math.random() * 6);
        },
    },
    mounted() {
        this.ranhosMethod();
        const words = [
            "整形外科?",
            "胸腔食道外科?",
            "小兒外科?",
            "外傷及重症外科?",
            "一般醫學外科?",
            "胃腸內科?",
            "肝膽胰內科?",
            "大腸直腸外科?",
            "一般及消化系外科?",
            "過敏免疫風濕科?",
            "兒童眼科?",
        ];
        let cursor = gsap.timeline();
        cursor.from(".cursor", { opacity: 0, delay: 1.8 }).to(".cursor", {
            opacity: 0,
            ease: "power2.inOut",
            repeat: -1,
        });
        let masterTl = gsap.timeline({ repeat: -1 }).pause();
        let boxTl = gsap.timeline();
        boxTl
            .to(".box", {
                duration: 0,
                width: "17vw",
                delay: 0.5,
                ease: "power4.inOut",
            })
            .from(".hi", { duration: 1, y: "8vw", ease: "power3.out" })
            .to(".box", {
                duration: 1,
                height: "0vw",
                ease: "elastic.out",
                onComplete: () => masterTl.play(),
            })
            .to(".box", {
                duration: 2,
                autoAlpha: 0.7,
                yoyo: true,
                repeat: -1,
                ease: "rough({ template: none.out, strength:  1, points: 20, taper: 'none', randomize: true, clamp: false})",
            });
        words.forEach((word) => {
            let tl = gsap.timeline({ repeat: 1, yoyo: true, repeatDelay: 1 });
            tl.to(".text", { duration: 1, text: word });
            masterTl.add(tl);
        });
        const h2 = gsap.timeline({ defaults: { duration: 1 } });
        h2.from("h2.animh2", { opacity: 0, y: -50 });
        h2.from("button.animh3", { opacity: 0, y: -50 });
        gsap.from("img.nurse", { opacity: 0, duration: 1.5, x: -50 });
        gsap.from("img.nurse2", { opacity: 0, duration: 1.5, x: 50 });
    },
});

app.mount("#app");

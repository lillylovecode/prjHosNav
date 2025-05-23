USE [dbHospital]
GO
/****** Object:  Table [dbo].[tExamination]    Script Date: 2021/8/26 下午 01:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tExamination](
	[fEId] [int] IDENTITY(1,1) NOT NULL,
	[fEName] [nvarchar](50) NULL,
	[fENotice] [nvarchar](max) NULL,
 CONSTRAINT [PK_Examination] PRIMARY KEY CLUSTERED 
(
	[fEId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tHospital]    Script Date: 2021/8/26 下午 01:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tHospital](
	[hId] [nvarchar](50) NULL,
	[hName] [nvarchar](50) NULL,
	[hKeyword] [nvarchar](50) NULL,
	[hPhone] [nvarchar](50) NULL,
	[hAddress] [nvarchar](50) NULL,
	[hWebsite] [nvarchar](max) NULL,
	[hProgress] [nvarchar](max) NULL,
	[hOutpatient] [nvarchar](max) NULL,
	[hPhoto] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tMedicine]    Script Date: 2021/8/26 下午 01:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tMedicine](
	[fId] [int] IDENTITY(1,1) NOT NULL,
	[fChName] [nvarchar](max) NULL,
	[fEnName] [nvarchar](max) NULL,
	[fSymptoms] [nvarchar](max) NULL,
	[fCaution] [nvarchar](max) NULL,
	[fImagePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_tMedicine] PRIMARY KEY CLUSTERED 
(
	[fId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tMember]    Script Date: 2021/8/26 下午 01:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tMember](
	[MId] [int] IDENTITY(1,1) NOT NULL,
	[MName] [nvarchar](50) NULL,
	[MEmail] [nvarchar](50) NULL,
	[MPassword] [nvarchar](50) NULL,
	[MPhone] [nvarchar](50) NULL,
	[MGender] [nvarchar](50) NULL,
	[MAddress] [nvarchar](50) NULL,
	[MAuthority] [nvarchar](50) NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[MId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tMyMedicineBox]    Script Date: 2021/8/26 下午 01:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tMyMedicineBox](
	[fId] [int] IDENTITY(1,1) NOT NULL,
	[fChName] [nvarchar](max) NULL,
	[fImagePath] [nvarchar](max) NULL,
	[fDayOfUse] [nvarchar](max) NULL,
	[fQuantityUse] [nvarchar](max) NULL,
	[MId] [int] NULL,
 CONSTRAINT [PK_tMyMedicineBox] PRIMARY KEY CLUSTERED 
(
	[fId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tOutpatient]    Script Date: 2021/8/26 下午 01:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tOutpatient](
	[oid] [int] IDENTITY(1,1) NOT NULL,
	[outpatientName] [nvarchar](50) NULL,
	[doctor] [nvarchar](50) NULL,
	[photo] [nvarchar](50) NULL,
	[hId] [nvarchar](50) NULL,
 CONSTRAINT [PK_tOutpatient] PRIMARY KEY CLUSTERED 
(
	[oid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tReturn]    Script Date: 2021/8/26 下午 01:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tReturn](
	[RId] [int] IDENTITY(1,1) NOT NULL,
	[RType] [nvarchar](50) NULL,
	[RHospital] [nvarchar](50) NULL,
	[RDate] [nvarchar](50) NULL,
	[MId] [int] NULL,
 CONSTRAINT [PK_tReturn] PRIMARY KEY CLUSTERED 
(
	[RId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tSearch]    Script Date: 2021/8/26 下午 01:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tSearch](
	[SId] [int] IDENTITY(1,1) NOT NULL,
	[SType] [nvarchar](max) NULL,
	[SDisease] [nvarchar](max) NULL,
	[SSymptom] [nvarchar](max) NULL,
 CONSTRAINT [PK_Search] PRIMARY KEY CLUSTERED 
(
	[SId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tExamination] ON 

INSERT [dbo].[tExamination] ([fEId], [fEName], [fENotice]) VALUES (1, N'大腸內視鏡', N'(1)二天前開始配合低渣飲食，請見說明單張。
(2)瀉劑服用請見使用說明單張。
(3)檢查時需更換衣物，穿著本中心準備之檢查服。
(4)填妥檢查同意書帶來體檢中心。 (5)若有選擇無痛麻醉鏡檢，需有家屬陪同，請勿自行開車。')
INSERT [dbo].[tExamination] ([fEId], [fEName], [fENotice]) VALUES (2, N'胃鏡', N'(1)請空腹8小時，包括食物及水分。 (2)若有選擇無痛麻醉鏡檢，需有家屬陪同，請勿自行開車。')
INSERT [dbo].[tExamination] ([fEId], [fEName], [fENotice]) VALUES (3, N'抽血', N'抽血時請放鬆心情，完畢後請立即於抽血處棉球上按壓5分鐘(勿揉)，直至無出血；若周圍有瘀青腫脹疼痛、或有頭暈不適之情形，請立即告知現場護理人員。')
INSERT [dbo].[tExamination] ([fEId], [fEName], [fENotice]) VALUES (4, N'X光', N'懷孕者不宜照X光。胸部X光如衣物有金屬或鈕扣，需脫掉或更換，並除去項鍊及飾品')
INSERT [dbo].[tExamination] ([fEId], [fEName], [fENotice]) VALUES (5, N'超音波檢查', N'腹部及婦科超音波檢查，宜著上下分開衣服。')
INSERT [dbo].[tExamination] ([fEId], [fEName], [fENotice]) VALUES (6, N'正子攝影', N'(1)檢查前一晚及當日避免劇烈運動。
(2)糖尿病患者需告知，控制血糖150mg/dl以下。
(3)此項檢查時間約需3小時。
(4)當天如無法前來受檢，請務必提前二日告知並另安排受檢時間。')
INSERT [dbo].[tExamination] ([fEId], [fEName], [fENotice]) VALUES (7, N'冠狀動脈心臟電腦斷層攝影', N'(1)有心律不整者無法施作。
(2)心跳需控制在60次/分鐘以下，如心跳過快，放射科人員會給予服用藥物
降低心跳。
(3)本檢查務必需有家屬陪同。
(4)24小時以內勿食用刺激性食物及飲料，例如茶、咖啡…。
(5)如三個月內無血液腎功能報告，報到後需先抽血檢驗腎臟功能。')
INSERT [dbo].[tExamination] ([fEId], [fEName], [fENotice]) VALUES (8, N'腹部核磁共振', N'(1)請務必禁食、禁水8小時。')
SET IDENTITY_INSERT [dbo].[tExamination] OFF
GO
INSERT [dbo].[tHospital] ([hId], [hName], [hKeyword], [hPhone], [hAddress], [hWebsite], [hProgress], [hOutpatient], [hPhoto]) VALUES (N'h01', N'高雄醫學大學附設中和紀念醫院', N'心臟內科,心臟外科,骨科,泌尿科,肝膽胰,整形外科', N'+886-7-312-1101#5536,5507', N'高雄市三民區自由一路100號', N'https://www.kmuh.org.tw/KMUHInterWeb/InterWeb/Home', N'https://www.kmuh.org.tw/KMUHInterWeb/InterWeb/InnerPage/1001124053', N'https://www.kmuh.org.tw/KMUHInterWeb/InterWeb/InnerPage/1001124050', N'kmu.jpg')
INSERT [dbo].[tHospital] ([hId], [hName], [hKeyword], [hPhone], [hAddress], [hWebsite], [hProgress], [hOutpatient], [hPhoto]) VALUES (N'h02', N'國軍高雄總醫院', N'胸腔科,眼科,耳鼻喉科', N'+886-7-7496-751 #3', N'80284高雄市苓雅區中正一路2號', N'https://802.mnd.gov.tw/main.InitSessionState.do', N'https://802.mnd.gov.tw/ListP00220.ShowItemListState.do?StateEvent=InitEvent', N'https://reg.802.mnd.gov.tw/', N'高雄國軍.jpg')
INSERT [dbo].[tHospital] ([hId], [hName], [hKeyword], [hPhone], [hAddress], [hWebsite], [hProgress], [hOutpatient], [hPhoto]) VALUES (N'h03', N'榮民總醫院', N'心臟內科,心臟外科,骨科,泌尿科,肝膽胰,整形外科', N'+886-7-342-2121 #4904~4911', N'高雄市左營區大中一路386號', N'https://www.vghks.gov.tw/', N'https://webreg.vghks.gov.tw/wps/portal/web/realtimequery', N'https://webreg.vghks.gov.tw/wps/portal/web/announce/!ut/p/b1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOKdfYMC_L3dDQ3cXR3NDDz9PAPMHS38DUxcTPS99KPSc_KTgErD9aPwKvYxhyowwAEcDfT9PPJzU_ULsoODLBwVFQHydxO9/dl4/d5/L2dBISEvZ0FBIS9nQSEh/', N'榮總.jpg')
INSERT [dbo].[tHospital] ([hId], [hName], [hKeyword], [hPhone], [hAddress], [hWebsite], [hProgress], [hOutpatient], [hPhoto]) VALUES (N'h04', N'民生醫院', N'一般消化科,泌尿科,皮膚科', N'+886-7-7511131', N'高雄市苓雅區凱旋二路134號', N'https://kmsh.kcg.gov.tw/Default.aspx', N'https://www.kmsh.gov.tw/trenew/StepF1.aspx', N'https://www.kmsh.gov.tw/trenew/', N'民生.jpg')
INSERT [dbo].[tHospital] ([hId], [hName], [hKeyword], [hPhone], [hAddress], [hWebsite], [hProgress], [hOutpatient], [hPhoto]) VALUES (N'h05', N'大同醫院', N'泌尿科,婦產科', N'+886-7-291-1101', N'高雄市前金區中華三路68號', N'https://www.kmtth.org.tw/web/KMTTHInterWeb/InterWeb/Home', N'https://www.kmtth.org.tw/Web/KMTTHInterWeb/InterWeb/InnerPage/2020010691', N'https://www.kmtth.org.tw/Web/KMTTHInterWeb/InterWeb/InnerPage/2020010690', N'大同.jpg')
INSERT [dbo].[tHospital] ([hId], [hName], [hKeyword], [hPhone], [hAddress], [hWebsite], [hProgress], [hOutpatient], [hPhoto]) VALUES (N'h06', N'阮綜合醫院', N'老年醫學科,眼科,耳鼻喉科,胸腔科', N'+886-7-269-3228', N'高雄市苓雅區成功一路162號', N'http://www.yuanhosp.com.tw/front/bin/home.phtml', N'https://register.yuanhosp.com.tw/register3/webEmbedRegRoom.aspx?corpid=0001', N'https://register.yuanhosp.com.tw/register3/', N'阮綜合.jpg')
INSERT [dbo].[tHospital] ([hId], [hName], [hKeyword], [hPhone], [hAddress], [hWebsite], [hProgress], [hOutpatient], [hPhoto]) VALUES (N'h07', N'長庚紀念醫院', N'身心科,老人醫學科,胸腔科,一般消化科', N'+886-7-731-7123 #6150', N'高雄市鳥松區大埤路 123 號', N'https://www.cgmh.org.tw/tw', N'https://register.cgmh.org.tw/Progress/8', N'https://register.cgmh.org.tw/Register/8', N'高長.jpg')
GO
SET IDENTITY_INSERT [dbo].[tMedicine] ON 

INSERT [dbo].[tMedicine] ([fId], [fChName], [fEnName], [fSymptoms], [fCaution], [fImagePath]) VALUES (1, N'安立復錠', N'Abilify 15mg Tablet', N'思覺失調症、雙極性疾患之躁症發作及混合型發作', N'1.長期服用會引起錐體外症狀
2.可會誘發血糖上升，若有糖尿病者須嚴密監測血糖值。', N'1.jpg')
INSERT [dbo].[tMedicine] ([fId], [fChName], [fEnName], [fSymptoms], [fCaution], [fImagePath]) VALUES (2, N'痛立安長效膠囊', N'	Aceo Retard 90mg Capsule', N'風濕性關節炎、退化性關節炎(骨關節炎)、僵直性脊椎炎、痛風、肌肉炎、腱炎、腱鞘炎、滑囊炎。', N'1.如果出現眩暈，請勿駕駛車輛或操作危險器械，酒精會加強眩暈作用。
2.腸胃潰瘍病史、氣喘、慢性氣管阻塞、高血壓、心臟病、血液障礙、嚴重肝腎障礙患者之患者需小心使用。
3.服用本劑期間，癲癇症、帕金森氏病或精神病可能發病或惡化。', N'2.jpg')
INSERT [dbo].[tMedicine] ([fId], [fChName], [fEnName], [fSymptoms], [fCaution], [fImagePath]) VALUES (3, N'愛克痰發泡錠', N'Actein 600 mg Tab', N'減少呼吸道粘膜分泌的粘稠性、蓄意或偶發之 ACETAMINOPHEN中毒之解毒劑。', N'要仔細觀查氣喘病人在停止使用acetylcysteine，首先出現的支氣管痙攣的徵兆。如果需要的話，可吸入支氣管擴張劑。', N'3.jpg')
INSERT [dbo].[tMedicine] ([fId], [fChName], [fEnName], [fSymptoms], [fCaution], [fImagePath]) VALUES (4, N'愛口隆口內膏', N'Acolon 5gm Orabase', N'口腔糜爛或口腔炎、舌炎之潰瘍', N'1.孕婦應避免長期使用。
2.嬰幼兒若長期連續使用可能導致發育障礙。
3.使用後應暫時避免飲食。
4.本品勿使用於眼科。', N'4.jpg')
INSERT [dbo].[tMedicine] ([fId], [fChName], [fEnName], [fSymptoms], [fCaution], [fImagePath]) VALUES (5, N'抑血凝糖衣錠 10毫克', N'Acerine 10mg Sugar-Coated Tablet', N'末梢血管循環障礙。', N'1. 於急性出血或嚴重心跳徐緩或使用抗高血壓劑、抗凝血劑、血小板抑制劑之病人，應小心使用。 
2. 孕婦或可能懷孕之婦女最好不要使用。', N'5.jpg')
INSERT [dbo].[tMedicine] ([fId], [fChName], [fEnName], [fSymptoms], [fCaution], [fImagePath]) VALUES (6, N'撲菌特錠', N'Baktar 400mg Tablet', N'葡萄狀球菌、鏈鎖球菌、肺炎雙球菌、大腸菌、赤痢菌及綠膿菌引起之感染症', N'1.服藥時至少需用240毫升水吞服。
2.治療期間請飲用足量水以避免尿路或腎結石。
3.本藥可能引起光敏感，治療期間請防曬。
4.蠶豆症或曾對磺胺類sulfasalazine過敏者，建議不要使用本藥。
5.有下列任一病史者請先告知醫師：氣喘或過敏、肝或腎功能不良、甲狀腺功能障礙。', N'6.jpg')
INSERT [dbo].[tMedicine] ([fId], [fChName], [fEnName], [fSymptoms], [fCaution], [fImagePath]) VALUES (7, N'倍力舒錠', N'Benecol 50mg Tablet', N'麻痺性腸塞絞痛、迷走神經切斷手術後之胃緩及胃內貯留症、手術後及產後等之尿閉症、腹部膨滿。 　', N'空腹服用效果佳', N'7.jpg')
INSERT [dbo].[tMedicine] ([fId], [fChName], [fEnName], [fSymptoms], [fCaution], [fImagePath]) VALUES (8, N'倍美舒乳膏', N'Betamazole 15gm Cream', N'適用於下皮膚感染的局部治療：紅色毛癬菌、鬚瘡毛癬菌、絮狀表皮癬菌、大小芽胞菌所引起之足癬、股癬、頭癬。', N'1.避免接觸到眼睛 
2.如治療股癬或圓癬一週後或治療足癬二週後症狀若無改善，則停止使用 
3.治療皮膚患處，不應使用繃帶或其他東西包紮，將其閉塞 
4.使用於腹股溝時，病人應穿寬鬆的衣服，假如使用二星期後症狀仍然存在時，則應停止使用 
5.病人應避免感染源或再度感染 
6.藥物含有Corticosteroid，不應大量或長期用於懷孕病人 
7.假如有刺激性或過敏性發生時，即應停止使用，並作適當治療', N'8.jpg')
INSERT [dbo].[tMedicine] ([fId], [fChName], [fEnName], [fSymptoms], [fCaution], [fImagePath]) VALUES (9, N'益血康糖衣錠', N'Bloodfull S.C. Tablet', N'妊娠期、發育期、貧血、手術後及其他一般鐵質缺乏性貧血低血色素性貧血。', N'1.有潰瘍，結腸炎以及過敏病人和孕婦病人應小心使用。 
2.應避免食物：奶酪，雞蛋，酸奶，菠菜，茶，穀類食品。 
3.不要與制酸劑和鐵劑一起補充。', N'9.jpg')
INSERT [dbo].[tMedicine] ([fId], [fChName], [fEnName], [fSymptoms], [fCaution], [fImagePath]) VALUES (10, N'卡力舒錠', N'Carisoma 250mg Tablet', N'焦慮緊張症, 經常緊張, 肌炎, 椎間神經痛, 坐骨神經痛, 頸痛, 風濕性關節炎, 骨關節炎, 肌肉僵硬, 肌肉痛.', N'不可與酒精、催眠藥、opioids鎮痛劑或安神藥等中樞抑制劑併服，以免產品加成或中毒。嚴重腎功能不全者、紫質沉著症之病人禁用本藥。', N'10.jpg')
INSERT [dbo].[tMedicine] ([fId], [fChName], [fEnName], [fSymptoms], [fCaution], [fImagePath]) VALUES (11, N'治鼻敏錠', N'Chlorpheniramine 4mg Tablet', N'	
暫時緩解過敏性鼻炎、枯草熱所引起的相關症狀(流鼻涕、 打噴涕、眼睛及喉部搔癢)及過敏所引起的搔癢、皮膚發疹。', N'1.勿飲酒。 
2.服藥後，請勿開車。', N'11.jpg')
INSERT [dbo].[tMedicine] ([fId], [fChName], [fEnName], [fSymptoms], [fCaution], [fImagePath]) VALUES (12, N'替你憂-S 膜衣錠', N'Citao-S 10mg Tablet', N'憂鬱症之治療及預防復發。', N'若造成頭暈，請於睡前服藥', N'12.jpg')
INSERT [dbo].[tMedicine] ([fId], [fChName], [fEnName], [fSymptoms], [fCaution], [fImagePath]) VALUES (13, N'立安錠', N'Doxter 2mg Tablet', N'高血壓、良性前列腺肥大', N'1.服用本藥可能發生暈眩，應避免或小心開車及操作機械。 
2.由坐姿或臥姿起身時請徐緩，以免產生姿勢性低血壓。', N'13.jpg')
INSERT [dbo].[tMedicine] ([fId], [fChName], [fEnName], [fSymptoms], [fCaution], [fImagePath]) VALUES (14, N'癒吐寧錠', N'Emetrol 10mg Tablet', N'噁心、嘔吐、胃腸脹氣', N'1.當同時併用cimetidine時，可能需要調整劑量。 
2.因本藥具阻斷多巴胺之作用，所以可能發生乳漏。', N'14.jpg')
INSERT [dbo].[tMedicine] ([fId], [fChName], [fEnName], [fSymptoms], [fCaution], [fImagePath]) VALUES (15, N'褐黴素乳膏', N'Fusidic Acid 20mg/gm 5gm Cream', N'葡萄球菌、鏈球菌或其他對Fusidic Acid敏感的細菌的皮膚感染症。', N'對Fusidic Acid過敏禁用。', N'15.jpg')
SET IDENTITY_INSERT [dbo].[tMedicine] OFF
GO
SET IDENTITY_INSERT [dbo].[tMember] ON 

INSERT [dbo].[tMember] ([MId], [MName], [MEmail], [MPassword], [MPhone], [MGender], [MAddress], [MAuthority]) VALUES (1, N'kitty hello', N'kkk@fff.com', N'0000', N'091112222', N'女', N'高雄市', N'管理者')
INSERT [dbo].[tMember] ([MId], [MName], [MEmail], [MPassword], [MPhone], [MGender], [MAddress], [MAuthority]) VALUES (3, N'marry', N'jjj@cc.com', N'0000', N'0933111222', N'男', N'台北市', N'使用者')
INSERT [dbo].[tMember] ([MId], [MName], [MEmail], [MPassword], [MPhone], [MGender], [MAddress], [MAuthority]) VALUES (4, N'33', N'123@gmail.com', N'123', N'093215465', NULL, N'台南市', N'使用者')
INSERT [dbo].[tMember] ([MId], [MName], [MEmail], [MPassword], [MPhone], [MGender], [MAddress], [MAuthority]) VALUES (5, N'kk', N'iii@gmail.com', N'1234', N'07293847', N'女', N'高雄市', N'使用者')
INSERT [dbo].[tMember] ([MId], [MName], [MEmail], [MPassword], [MPhone], [MGender], [MAddress], [MAuthority]) VALUES (6, N'123', N'iii@gmail.com', N'1234', N'321', N'男', N'新北市', N'使用者')
INSERT [dbo].[tMember] ([MId], [MName], [MEmail], [MPassword], [MPhone], [MGender], [MAddress], [MAuthority]) VALUES (7, N'ppp', N'qqq@gmail.com', N'0000', N'0987654321', N'女', N'高雄市', N'使用者')
SET IDENTITY_INSERT [dbo].[tMember] OFF
GO
SET IDENTITY_INSERT [dbo].[tMyMedicineBox] ON 

INSERT [dbo].[tMyMedicineBox] ([fId], [fChName], [fImagePath], [fDayOfUse], [fQuantityUse], [MId]) VALUES (24, N'愛克痰發泡錠', N'3.jpg', N'午餐,飯前', N'1', 5)
INSERT [dbo].[tMyMedicineBox] ([fId], [fChName], [fImagePath], [fDayOfUse], [fQuantityUse], [MId]) VALUES (25, N'褐黴素乳膏', N'15.jpg', N'早餐,午餐,晚餐', NULL, 5)
INSERT [dbo].[tMyMedicineBox] ([fId], [fChName], [fImagePath], [fDayOfUse], [fQuantityUse], [MId]) VALUES (26, N'安立復錠', N'1.jpg', N' 晚餐,飯前', N'吃到死', 7)
INSERT [dbo].[tMyMedicineBox] ([fId], [fChName], [fImagePath], [fDayOfUse], [fQuantityUse], [MId]) VALUES (27, N'安立復錠', N'1.jpg', N'早餐,午餐,晚餐,飯前', N'1', 1)
SET IDENTITY_INSERT [dbo].[tMyMedicineBox] OFF
GO
SET IDENTITY_INSERT [dbo].[tOutpatient] ON 

INSERT [dbo].[tOutpatient] ([oid], [outpatientName], [doctor], [photo], [hId]) VALUES (13, N'整形外科', N'唐伯虎', N'13.jpg', N'h01')
INSERT [dbo].[tOutpatient] ([oid], [outpatientName], [doctor], [photo], [hId]) VALUES (14, N'胸腔食道外科', N'李憲斌', N'14.jpg', N'h01')
INSERT [dbo].[tOutpatient] ([oid], [outpatientName], [doctor], [photo], [hId]) VALUES (15, N'小兒外科', N'鐘育志

', N'15.jpg', N'h01')
INSERT [dbo].[tOutpatient] ([oid], [outpatientName], [doctor], [photo], [hId]) VALUES (16, N'外傷及重症外科', N'唐貞綾', N'16.jpg', N'h01')
INSERT [dbo].[tOutpatient] ([oid], [outpatientName], [doctor], [photo], [hId]) VALUES (17, N'一般醫學外科', N'郭功楷', N'17.jpg', N'h01')
INSERT [dbo].[tOutpatient] ([oid], [outpatientName], [doctor], [photo], [hId]) VALUES (18, N'胃腸內科', N'郭昭宏', N'18.jpg', N'h01')
INSERT [dbo].[tOutpatient] ([oid], [outpatientName], [doctor], [photo], [hId]) VALUES (19, N'肝膽胰內科', N'莊萬龍', N'19.jpg', N'h01')
INSERT [dbo].[tOutpatient] ([oid], [outpatientName], [doctor], [photo], [hId]) VALUES (20, N'大腸直腸外科', N'王照元', N'20.jpg', N'h01')
INSERT [dbo].[tOutpatient] ([oid], [outpatientName], [doctor], [photo], [hId]) VALUES (21, N'一般消化系外科', N'吳柏宣', N'21.jpg', N'h01')
INSERT [dbo].[tOutpatient] ([oid], [outpatientName], [doctor], [photo], [hId]) VALUES (22, N'過敏免疫風濕科', N'林育志', N'22.jpg', N'h01')
INSERT [dbo].[tOutpatient] ([oid], [outpatientName], [doctor], [photo], [hId]) VALUES (23, N'兒童眼科', N'林憲忠', N'23.jpg', N'h01')
INSERT [dbo].[tOutpatient] ([oid], [outpatientName], [doctor], [photo], [hId]) VALUES (36, N'整形外科', N'林大輸', N'13.jpg', N'h02')
INSERT [dbo].[tOutpatient] ([oid], [outpatientName], [doctor], [photo], [hId]) VALUES (37, N'胸腔食道外科', N'王大圈', N'14.jpg', N'h02')
INSERT [dbo].[tOutpatient] ([oid], [outpatientName], [doctor], [photo], [hId]) VALUES (38, N'小兒外科', N'卓大毅', N'15.jpg', N'h02')
INSERT [dbo].[tOutpatient] ([oid], [outpatientName], [doctor], [photo], [hId]) VALUES (39, N'外傷及重症外科', N'黃飛鴻', N'16.jpg', N'h02')
INSERT [dbo].[tOutpatient] ([oid], [outpatientName], [doctor], [photo], [hId]) VALUES (40, N'一般醫學外科', N'王仁凱', N'17.jpg', N'h02')
INSERT [dbo].[tOutpatient] ([oid], [outpatientName], [doctor], [photo], [hId]) VALUES (41, N'胃腸內科', N'蔡易軒', N'18.jpg', N'h02')
INSERT [dbo].[tOutpatient] ([oid], [outpatientName], [doctor], [photo], [hId]) VALUES (42, N'肝膽胰內科', N'周冠名', N'19.jpg', N'h02')
INSERT [dbo].[tOutpatient] ([oid], [outpatientName], [doctor], [photo], [hId]) VALUES (43, N'大腸直腸外科', N'王彩華', N'20.jpg', N'h02')
INSERT [dbo].[tOutpatient] ([oid], [outpatientName], [doctor], [photo], [hId]) VALUES (44, N'一般消化系外科', N'黃阿瑪', N'21.jpg', N'h02')
INSERT [dbo].[tOutpatient] ([oid], [outpatientName], [doctor], [photo], [hId]) VALUES (45, N'過敏免疫風濕科', N'貞太熙', N'22.jpg', N'h02')
INSERT [dbo].[tOutpatient] ([oid], [outpatientName], [doctor], [photo], [hId]) VALUES (46, N'兒童眼科', N'袁世凱', N'23.jpg', N'h02')
SET IDENTITY_INSERT [dbo].[tOutpatient] OFF
GO
SET IDENTITY_INSERT [dbo].[tReturn] ON 

INSERT [dbo].[tReturn] ([RId], [RType], [RHospital], [RDate], [MId]) VALUES (13, N'胃腸內科', N'榮民總醫院', N'2020-05-03', 1)
INSERT [dbo].[tReturn] ([RId], [RType], [RHospital], [RDate], [MId]) VALUES (15, N'整形外科', N'高雄醫學大學附設中和紀念醫院', N'2020-06-02', 1)
INSERT [dbo].[tReturn] ([RId], [RType], [RHospital], [RDate], [MId]) VALUES (16, N'一般消化科', N'民生醫院', N'2020-06-01', 1)
INSERT [dbo].[tReturn] ([RId], [RType], [RHospital], [RDate], [MId]) VALUES (17, N'身心科', N'長庚紀念醫院', N'2021-8-17', 5)
INSERT [dbo].[tReturn] ([RId], [RType], [RHospital], [RDate], [MId]) VALUES (18, N'老年醫學科', N'阮綜合醫院', N'2020-04-13', 5)
INSERT [dbo].[tReturn] ([RId], [RType], [RHospital], [RDate], [MId]) VALUES (19, N'內科', N'高醫', N'2021-11-02', 5)
INSERT [dbo].[tReturn] ([RId], [RType], [RHospital], [RDate], [MId]) VALUES (20, N'身心科', N'高醫', N'2021-08-30', 5)
INSERT [dbo].[tReturn] ([RId], [RType], [RHospital], [RDate], [MId]) VALUES (21, N'骨科', N'高雄總醫院', N'2021-09-07', 1)
SET IDENTITY_INSERT [dbo].[tReturn] OFF
GO
SET IDENTITY_INSERT [dbo].[tSearch] ON 

INSERT [dbo].[tSearch] ([SId], [SType], [SDisease], [SSymptom]) VALUES (1, N'整形外科', N'整容、重建、美容醫學、顯微外科、先天性頭頸部畸形、兔唇、顎裂、顱顏畸形及斜頸', N'身體外表四肢的功能喪失、外觀缺損、斷指、斷肢重接、顯微皮瓣及神經、血管接合手術、燒燙傷的治療及其疤痕處理、顏面部外傷及顏面骨骨折治療、雙眼皮、隆鼻、隆乳、抽脂、拉皮、磨皮')
INSERT [dbo].[tSearch] ([SId], [SType], [SDisease], [SSymptom]) VALUES (2, N'胸腔食道外科', N'肺癌、氣胸、膿胸、縱膈腔腫瘤、重症肌無力、胸腺瘤、手汗症、食道癌、食道憩室、食道弛緩、食道狹窄、胃食道逆流、肺氣腫、塵肺病、矽肺病、肺纖維化、細支氣管病變、支氣管擴張', N'習慣性打嗝、體重減輕、吞嚥困難、食物逆流、吞嚥疼痛、血痰')
INSERT [dbo].[tSearch] ([SId], [SType], [SDisease], [SSymptom]) VALUES (3, N'小兒外科', N'疝氣、肛門閉鎖、巨大結腸症、闌尾炎、腸套疊、腹部腫瘤 總膽管囊腫、膽道閉鎖', N'18歲(含)以下之外科疾病、新生兒手術、先天性或後天性肝膽異常、四肢外傷')
INSERT [dbo].[tSearch] ([SId], [SType], [SDisease], [SSymptom]) VALUES (4, N'外傷及重症外科', N'事故傷害、急診、急性腦中風、急性冠心症、重大外傷、高危險妊娠、外傷治療、外科急症、重症照護、急性闌尾炎、消化性潰瘍穿孔、急性憩室炎、急性膽囊炎、腹膜炎、呼吸衰竭、敗血性休克、多重器官衰竭', N'急診外傷、外科加護病房、車禍、燒燙傷、老年跌倒、胸腹部的鈍傷或穿刺傷、墜樓、四肢外傷')
INSERT [dbo].[tSearch] ([SId], [SType], [SDisease], [SSymptom]) VALUES (5, N'一般醫學外科', N'外傷、開刀手術、一般外科疾病、癌症、腦中風、輸液、骨折、石膏與副木固定、燒傷緊急處理、基本傷口縫合、氣管插管', N'外傷、開刀手術、癌症病患的營養照護、化學治療之服務')
INSERT [dbo].[tSearch] ([SId], [SType], [SDisease], [SSymptom]) VALUES (6, N'胃腸內科', N'消化性潰瘍及合併出血、逆流性食道炎、胃及十二指腸炎、內視鏡息肉切除', N'肝內腫瘤之檢查、消化性潰瘍及合併出血、內視鏡息肉切除、照胃鏡、乙狀結腸鏡、大腸鏡、腹部超音波及其導引之穿刺
')
INSERT [dbo].[tSearch] ([SId], [SType], [SDisease], [SSymptom]) VALUES (7, N'肝膽胰內科', N'病毒性肝炎、黃膽、肝內腫瘤之檢查、膽囊及膽管結石、胰臟炎及腫瘤', N'肝膽胰內科疾病、消化器超音波檢查、肝炎治療、肝癌治療')
INSERT [dbo].[tSearch] ([SId], [SType], [SDisease], [SSymptom]) VALUES (8, N'大腸直腸外科', N'大腸癌、直腸癌、肛門癌、感染或放射線導致的大腸炎、發炎性腸道病變、大腸直腸息肉症、下消化道出血、大腸直腸傷口、急性闌尾炎、肛門廔管、大便失禁、慢性便秘、直腸脫垂、大腸憩室症、肛門搔癢症、克隆氏疾病、腸阻塞、痔瘡、肛裂、疝氣', N'肛門周圍結節或化膿、大便出血、大便習慣改變、大便變細、長期性腹痛、大便頻繁、長期便秘、大便失禁、慢性貧血、肛門疼痛、肛門脫垂、腹脹、腹瀉')
INSERT [dbo].[tSearch] ([SId], [SType], [SDisease], [SSymptom]) VALUES (9, N'一般及消化系外科', N'皮膚及軟部組織腫瘤、甲狀腺、副甲狀腺腫瘤、藥物無法治瘉之甲狀腺功能亢進症、副甲狀腺功能亢進症、胃腸道腫瘤之切除、胃腸道阻塞、消化性潰瘍併發症、腹膜炎、肝膽結石之摘除、乳房腫瘤、腎臟移植', N'不明原因的腫塊、頸部腫塊、腹痛、腹脹、不明原因之體重減輕、進食困難、嘔吐、乳房皮膚或乳頭有凹陷、乳房內有腫塊、乳頭有分泌物、或乳房疼痛、便血、黑便或大便顏色變成灰白色、皮膚變黃伴隨有茶色尿、下肢血管曲張
 誤食異物')
INSERT [dbo].[tSearch] ([SId], [SType], [SDisease], [SSymptom]) VALUES (10, N'過敏免疫風濕科', N'全身性紅斑狼瘡、類風濕性關節炎、痛風關節炎、退化關節炎、硬皮症、皮肌炎、修格連氏乾燥症、纖維肌痛、混合結締組織疾病、僵直性脊椎炎、細菌性關節炎、血清陰性脊椎炎、氣喘病、過敏鼻炎、蕁麻疹、藥物疹、橋本氏甲狀腺炎、血管炎抗磷脂症候群、', N'臉部蝴蝶斑、皮膚紅疹、關節腫痛、全身浮腫、怕光、怕冷、口腔潰瘍、呼吸急促、胸痛、頭髮異常脫落、皮膚瘀青、發紺發燒、晨間脊椎僵硬、下背部疼痛、眼睛葡萄膜炎')
INSERT [dbo].[tSearch] ([SId], [SType], [SDisease], [SSymptom]) VALUES (11, N'兒童眼科', N'紅眼症、結膜炎、眼睛過敏、血管破裂、眼部創傷、眼瞼炎、視網膜剝離、葡萄膜炎', N'眼睛疼痛、近視、散光、眼睛發紅、眼部搔癢、眼部灼熱感、眼睛充血')
SET IDENTITY_INSERT [dbo].[tSearch] OFF
GO
ALTER TABLE [dbo].[tMyMedicineBox]  WITH CHECK ADD  CONSTRAINT [FK_tMyMedicineBox_tMember] FOREIGN KEY([MId])
REFERENCES [dbo].[tMember] ([MId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tMyMedicineBox] CHECK CONSTRAINT [FK_tMyMedicineBox_tMember]
GO

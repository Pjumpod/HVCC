Option Strict Off
Option Explicit On 

Module ActDefine

    Public Const DevX As Short = 1

    ''''CPU TYPE
    ''' QnACPU
    Public Const CPU_Q2ACPU As Short = &H11S ' Q2A
    Public Const CPU_Q2AS1CPU As Short = &H12S ' Q2AS1
    Public Const CPU_Q3ACPU As Short = &H13S ' Q3A
    Public Const CPU_Q4ACPU As Short = &H14S ' Q4A
    ''' QCPU Q
    Public Const CPU_Q02CPU As Short = &H22S ' Q02(H) Q
    Public Const CPU_Q06CPU As Short = &H23S ' Q06H   Q
    Public Const CPU_Q12CPU As Short = &H24S ' Q12H   Q
    Public Const CPU_Q25CPU As Short = &H25S ' Q25H   Q
    Public Const CPU_Q00JCPU As Short = &H30S ' Q00J   Q
    Public Const CPU_Q00CPU As Short = &H31S ' Q00    Q
    Public Const CPU_Q01CPU As Short = &H32S ' Q01    Q
    Public Const CPU_Q12PHCPU As Short = &H41S ' Q12PHCPU Q
    Public Const CPU_Q25PHCPU As Short = &H42S ' Q25PHCPU Q
    Public Const CPU_Q12PRHCPU As Short = &H43S ' Q12PRHCPU Q
    Public Const CPU_Q25PRHCPU As Short = &H44S ' Q25PRHCPU Q
    Public Const CPU_Q25SSCPU As Short = &H55S ' Q25SS
    Public Const CPU_Q03UDCPU As Short = &H70S ' Q03UDCPU  Q
    Public Const CPU_Q04UDHCPU As Short = &H71S ' Q04UDHCPU Q
    Public Const CPU_Q06UDHCPU As Short = &H72S ' Q06UDHCPU Q
    Public Const CPU_Q02UCPU As Short = &H83S ' Q02UCPU   Q
    Public Const CPU_Q03UDECPU As Short = &H90S ' Q03UDECPU   Q
    Public Const CPU_Q04UDEHCPU As Short = &H91S ' Q04UDEHCPU   Q
    Public Const CPU_Q06UDEHCPU As Short = &H92S ' Q06UDEHCPU   Q
    Public Const CPU_Q13UDHCPU As Short = &H73S ' Q13UDHCPU   Q
    Public Const CPU_Q13UDEHCPU As Short = &H93S ' Q13UDEHCPU   Q
    Public Const CPU_Q26UDHCPU As Short = &H74S ' Q26UDHCPU   Q
    Public Const CPU_Q26UDEHCPU As Short = &H94S ' Q26UDEHCPU   Q
    Public Const CPU_Q02PHCPU As Short = &H45S  ' Q02PH  Q
    Public Const CPU_Q06PHCPU As Short = &H46S  ' Q06PH  Q
    Public Const CPU_Q00UJCPU As Short = &H80   ' Q00UJCPU
    Public Const CPU_Q00UCPU As Short = &H81    ' Q00UCPU
    Public Const CPU_Q01UCPU As Short = &H82    ' Q01UCPU
    Public Const CPU_Q10UDHCPU As Short = &H75  ' Q10UDHCPU
    Public Const CPU_Q20UDHCPU As Short = &H76  ' Q20UDHCPU
    Public Const CPU_Q10UDEHCPU As Short = &H95 ' Q10UDEHCPU
    Public Const CPU_Q20UDEHCPU As Short = &H96 ' Q20UDEHCPU
    Public Const CPU_Q50UDEHCPU As Short = &H98 ' Q50UDEHCPU
    Public Const CPU_Q100UDEHCPU As Short = &H9A ' Q100UDEHCPU
    Public Const CPU_Q03UDVCPU As Short = &HD1 ' Q03UDVCPU
    Public Const CPU_Q04UDVCPU As Short = &HD2 ' Q04UDVCPU
    Public Const CPU_Q06UDVCPU As Short = &HD3 ' Q06UDVCPU
    Public Const CPU_Q13UDVCPU As Short = &HD4 ' Q13UDVCPU
    Public Const CPU_Q26UDVCPU As Short = &HD5 ' Q26UDVCPU
    ''' ACPU
    Public Const CPU_A0J2HCPU As Short = &H102S ' A0J2H
    Public Const CPU_A1FXCPU As Short = &H103S ' A1FX
    Public Const CPU_A1SCPU As Short = &H104S ' A1S,A1SJ
    Public Const CPU_A1SHCPU As Short = &H105S ' A1SH,A1SJH
    Public Const CPU_A1NCPU As Short = &H106S ' A1(N)
    Public Const CPU_A2CCPU As Short = &H107S ' A2C,A2CJ
    Public Const CPU_A2NCPU As Short = &H108S ' A2(N),A2S
    Public Const CPU_A2SHCPU As Short = &H109S ' A2SH
    Public Const CPU_A3NCPU As Short = &H10AS ' A3(N)
    Public Const CPU_A2ACPU As Short = &H10CS ' A2A
    Public Const CPU_A3ACPU As Short = &H10DS ' A3A
    Public Const CPU_A2UCPU As Short = &H10ES ' A2U,A2US
    Public Const CPU_A2USHS1CPU As Short = &H10FS ' A2USHS1
    Public Const CPU_A3UCPU As Short = &H110S ' A3U
    Public Const CPU_A4UCPU As Short = &H111S ' A4U
    ''' QCPU A
    Public Const CPU_Q02CPU_A As Short = &H141S ' Q02(H)
    Public Const CPU_Q06CPU_A As Short = &H142S ' Q06H
    ''' LCPU
    Public Const CPU_L02CPU As Short = &HA1S   ' L02CPU
    Public Const CPU_L26CPUBT As Short = &HA2S ' L26CPU-BT
    Public Const CPU_L02SCPU As Short = &HA3S  ' L02SCPU
    Public Const CPU_L26CPU As Short = &HA4S   ' L26CPU
    Public Const CPU_L06CPU As Short = &HA5S   ' L06CPU
    ''' C Controller
    Public Const CPU_Q12DC_V As Short = &H58S   ' Q12DCCPU-V
    Public Const CPU_Q24DHC_V As Short = &H59S  ' Q24DHCCPU-V
    ''' Q MOTION 	
    Public Const CPU_Q172CPU As Short = &H621S      ' Q172CPU
    Public Const CPU_Q173CPU As Short = &H622S      ' Q173CPU
    Public Const CPU_Q172HCPU As Short = &H621S     ' Q172HCPU
    Public Const CPU_Q173HCPU As Short = &H622S     ' Q173HCPU
    Public Const CPU_Q172DCPU As Short = &H625S     ' Q172DCPU
    Public Const CPU_Q173DCPU As Short = &H626S     ' Q173DCPU
    Public Const CPU_Q172DSCPU As Short = &H62AS    ' Q172DSCPU
    Public Const CPU_Q173DSCPU As Short = &H62BS    ' Q173DSCPU
    ''' QSCPU
    Public Const CPU_QS001CPU As Short = &H60S ' QS001
    ''' FXCPU
    Public Const CPU_FX0CPU As Short = &H201S ' FX0/FX0S
    Public Const CPU_FX0NCPU As Short = &H202S ' FX0N
    Public Const CPU_FX1CPU As Short = &H203S ' FX1
    Public Const CPU_FX2CPU As Short = &H204S ' FX2/FX2C
    Public Const CPU_FX2NCPU As Short = &H205S ' FX2N/FX2NC
    Public Const CPU_FX1SCPU As Short = &H206S ' FX1S
    Public Const CPU_FX1NCPU As Short = &H207S ' FX1N/FX1NC
    Public Const CPU_FX3UCCPU As Short = &H208S ' FX3U/FX3UC
    Public Const CPU_FX3GCPU As Short = &H209   ' FX3G/FX3GC
    ''' BOARD
    Public Const CPU_BOARD As Short = &H401S ' NETWORK BOARD
    ''' MOTION
    Public Const CPU_A171SHCPU As Short = &H601S ' A171SH
    Public Const CPU_A172SHCPU As Short = &H602S ' A172SH
    Public Const CPU_A273UHCPU As Short = &H603S ' A273UH
    Public Const CPU_A173UHCPU As Short = &H604S ' A173UH
    ''' GOT
    Public Const CPU_A900GOT As Short = &H701S ' A900GOT


    ''' PORT
    Public Const PORT_1 As Short = &H1S ' CommunicationPort1
    Public Const PORT_2 As Short = &H2S ' CommunicationPort2
    Public Const PORT_3 As Short = &H3S ' CommunicationPort3
    Public Const PORT_4 As Short = &H4S ' CommunicationPort4
    Public Const PORT_5 As Short = &H5S ' CommunicationPort5
    Public Const PORT_6 As Short = &H6S ' CommunicationPort6
    Public Const PORT_7 As Short = &H7S ' CommunicationPort7
    Public Const PORT_8 As Short = &H8S ' CommunicationPort8
    Public Const PORT_9 As Short = &H9S ' CommunicationPort9
    Public Const PORT_10 As Short = &HAS ' CommunicationPort10


    ''' BAUDRATE
    Public Const BAUDRATE_300 As Short = 300 ' 300bps
    Public Const BAUDRATE_600 As Short = 600 ' 600bps
    Public Const BAUDRATE_1200 As Short = 1200 ' 1200bps
    Public Const BAUDRATE_2400 As Short = 2400 ' 2400bps
    Public Const BAUDRATE_4800 As Short = 4800 ' 4800bps
    Public Const BAUDRATE_9600 As Short = 9600 ' 9600bps
    Public Const BAUDRATE_19200 As Short = 19200 ' 19200bps
    Public Const BAUDRATE_38400 As Integer = 38400 ' 38400bps
    Public Const BAUDRATE_57600 As Integer = 57600 ' 57600bps
    Public Const BAUDRATE_115200 As Integer = 115200 ' 115200bps


    ''' DATA BIT
    Public Const DATABIT_7 As Short = 7 ' DATA BIT 7
    Public Const DATABIT_8 As Short = 8 ' DATA BIT 8


    ''' PARITY
    Public Const NO_PARRITY As Short = 0 ' NO PARITY
    Public Const ODD_PARITY As Short = 1 ' ODD PARITY
    Public Const EVEN_PARITY As Short = 2 ' EVEN PARITY


    ''' STOP BITS
    Public Const STOPBIT_ONE As Short = 0 ' 1 STOP BIT
    Public Const STOPBIT_TWO As Short = 2 ' 2 STOP BIT


    ''' SERIAL CONTROL
    Public Const TRC_DTR As Short = &H1S ' DTR
    Public Const TRC_RTS As Short = &H2S ' RTS
    Public Const TRC_DTR_AND_RTS As Short = &H7S ' DTR and RTS
    Public Const TRC_DTR_OR_RTS As Short = &H8S ' DTR or RTS


    ''' SUM CHECK
    Public Const SUM_CHECK As Short = 1 ' Sum Check
    Public Const NO_SUM_CHECK As Short = 0 ' No Sum Check]

    ''' PACKET TYPE
    Public Const PACKET_ASCII As Short = &H2S ' PACKET TYPE ASCII
    Public Const PACKET_BINARY As Short = &H3S ' PACKET TYPE BINARY

    ''' CONNECT WAY
    Public Const TEL_AUTO_CONNECT As Short = &H0S ' AUTO LINE CONNECT
    Public Const TEL_AUTO_CALLBACK As Short = &H1S ' AUTO LINE CONNECT(CALLBACK FIXATION)
    Public Const TEL_AUTO_CALLBACK_NUMBER As Short = &H2S ' AUTO LINE CONNECT(CALLBACK NUMBER SPECIFICATION)
    Public Const TEL_CALLBACK As Short = &H3S ' CALLBACK CONNECT(FIXATION)
    Public Const TEL_CALLBACK_NUMBER As Short = &H4S ' CALLBACK CONNECT(NUMBER SPECIFICATION)
    Public Const TEL_CALLBACK_REQUEST As Short = &H5S ' CALLBACK REQUEST(FIXATION)
    Public Const TEL_CALLBACK_REQUEST_NUMBER As Short = &H6S ' CALLBACK REQUEST(NUMBER SPECIFICATION)
    Public Const TEL_CALLBACK_WAIT As Short = &H7S ' CALLBACK RECEPTION WAITING

    ''' LINE TYPE
    Public Const LINETYPE_PULSE As Short = &H0S ' PULSE
    Public Const LINETYPE_TONE As Short = &H1S ' TONE
    Public Const LINETYPE_ISDN As Short = &H2S ' ISDN

    ''' GOT TRANSPARENT PC IF
    Public Const GOT_PCIF_USB As Short = 1 ' USB
    Public Const GOT_PCIF_SERIAL As Short = 2 ' SERIAL
    Public Const GOT_PCIF_ETHERNET As Short = 3  ' ETHERNET

    ''' GOT TRANSPARENT PLC IF
    Public Const GOT_PLCIF_SERIAL_QCPUQ As Short = 1 ' SERIAL-QCPU Q
    Public Const GOT_PLCIF_SERIAL_QCPUA As Short = 2 ' SERIAL-QCPU A
    Public Const GOT_PLCIF_SERIAL_QNACPU As Short = 3 ' SERIAL-QnACPU
    Public Const GOT_PLCIF_SERIAL_ACPU As Short = 4 ' SERIAL-ACPU
    Public Const GOT_PLCIF_SERIAL_FXCPU As Short = 5 ' SERIAL-FXCPU
    Public Const GOT_PLCIF_SERIAL_LCPU As Short = 6 ' SERIAL-LCPU
    Public Const GOT_PLCIF_SERIAL_QJ71C24 As Short = 30 ' SERIAL-QJ71C24
    Public Const GOT_PLCIF_SERIAL_LJ71C24 As Short = 31 ' SERIAL-LJ71C24
    Public Const GOT_PLCIF_ETHERNET_QJ71E71 As Short = 50 ' ETHERNET-QJ71E71
    Public Const GOT_PLCIF_ETHERNET_CCIEFADP As Short = 60 ' ETHERNET-CC IE Field adapter
    Public Const GOT_PLCIF_ETHERNET_QCPU As Short = 70 ' ETHERNET-QCPU
    Public Const GOT_PLCIF_ETHERNET_LCPU As Short = 71 ' ETHERNET-LCPU
    Public Const GOT_PLCIF_BUS As Short = 90 ' BUS

    ''' ACTPROGTYPE UNITTYPE
    Public Const UNIT_QNCPU As Short = &H13S        ' QnCPU(Qnﾓｰﾄﾞ)RS232C直結 
    Public Const UNIT_FXCPU As Short = &HFS    ' FXCPU直結 
    Public Const UNIT_LNCPU As Short = &H50S  ' LnCPU RS232Cアダプタ接続
    Public Const UNIT_QNMOTION As Short = &H1CS	' QnﾓｰｼｮﾝRS232C直結
    Public Const UNIT_QJ71C24 As Short = &H19S	' Qn用C24ﾕﾆｯﾄ
    Public Const UNIT_FX485BD As Short = &H24S	' FXCPU計算機リンク(RS485接続)
    Public Const UNIT_LJ71C24 As Short = &H54S	' L用C24ﾕﾆｯﾄ直結
    Public Const UNIT_QJ71E71 As Short = &H1AS	' Qn用E71ﾕﾆｯﾄ
    Public Const UNIT_FXENET As Short = &H26S	' FX3U用Ethernetユニット
    Public Const UNIT_FXENET_ADP As Short = &H27S	' FX1N-ENET-ADP
    Public Const UNIT_QNETHER	 As Short = &H2CS	' QnCPU(Qnﾓｰﾄﾞ)Ether直結 IP指定通信
    Public Const UNIT_QNETHER_DIRECT As Short = &H2DS	' QnCPU(Qnﾓｰﾄﾞ)Ether直結 直結通信
    Public Const UNIT_LNETHER4 As Short = &H52S		' LnCPU Ethernetﾎﾟｰﾄ接続
    Public Const UNIT_LNETHER_DIRECT As Short = &H53S	' LnCPU Ethernetﾎﾟｰﾄ直結接続
    Public Const UNIT_NZ2GF_ETB	 As Short = &H59S	' NZ2GF-ETB(Ethernetアダプタ)接続
    Public Const UNIT_NZ2GF_ETB_DIRECT	 As Short = &H5AS	' NZ2GF-ETB(Ethernetアダプタ)直結接続
    Public Const UNIT_QNUSB	 As Short = &H16S	' QnCPU(Qnﾓｰﾄﾞ)USB直結 
    Public Const UNIT_LNUSB	 As Short = &H51S	' LnCPU USBﾎﾟｰﾄ直結
    Public Const UNIT_QNMOTIONUSB As Short = &H1DS	' QnﾓｰｼｮﾝUSB直結
    Public Const UNIT_G4QNCPU	 As Short = &H1BS	' AJ65BT-G4-S3ユニット直結(Qnアクセス)
    Public Const UNIT_CCLINKBOARD As Short = &H0CS	' CC-Linkﾎﾞｰﾄﾞ 
    Public Const UNIT_MNETHBOARD As Short = &H1ES    ' MNET/Hﾎﾞｰﾄﾞ接続
    Public Const UNIT_MNETGBOARD As Short = &H2BS	' CC-Link IE ｺﾝﾄﾛｰﾗﾈｯﾄﾜｰｸ ﾎﾞｰﾄﾞ接続
    Public Const UNIT_CCIEFBOARD As Short = &H2FS	' CC-Link IEフィールドボード
    Public Const UNIT_SIMULATOR	 As Short = &H0BS	' シミュレータ（GX Simulator）接続
    Public Const UNIT_SIMULATOR2 As Short = &H30S	' GX Simulator2
    Public Const UNIT_QBF As Short = &H1FS	' Qn用パソコンCPU
    Public Const UNIT_QSS As Short = &H20S	' Qn用SoftLogic
    Public Const UNIT_A900GOT As Short = &H21S	' GOT
    Public Const UNIT_GOT_QJ71E712 As Short = &H40S	' GOT1000 Ethernetトランスペアレント QJ71E71
    Public Const UNIT_GOT_QNETHER2 As Short = &H41S	' GOT1000 Ethernetトランスペアレント Ethernet内蔵Qn
    Public Const UNIT_GOT_LNETHER2 As Short = &H55S	' GOT1000ｼﾘｰｽﾞ経由LnCPU Ethernetﾎﾟｰﾄ接続
    Public Const UNIT_GOT_NZ2GF_ETB2 As Short = &H5BS	' GOT1000ｼﾘｰｽﾞ経由NZ2GF-ETB(Ethernetアダプタ)接続
    Public Const UNIT_GOTETHER_QNCPU2 As Short = &H56S	' GOT1000ｼﾘｰｽﾞEthernetﾎﾟｰﾄ経由QnCPU-RS422ﾎﾟｰﾄ接続
    Public Const UNIT_GOTETHER_QBUS2 As Short = &H58S	' GOT1000ｼﾘｰｽﾞEthernetﾎﾟｰﾄ経由Qﾊﾞｽ接続
    Public Const UNIT_GOTETHER_LNCPU2 As Short = &H57S	' GOT1000ｼﾘｰｽﾞEthernetﾎﾟｰﾄ経由LnCPU RS232Cアダプタ接続
    Public Const UNIT_FXETHER As Short = &H4AS	' EthernetADP接続(ハブ経由)FXCPU
    Public Const UNIT_FXETHER_DIRECT As Short = &H4BS	' EthernetADP接続(直結) FXCPU
    Public Const UNIT_GOTETHER_FXCPU As Short = &H60S	' Ethernet(GOTトランスペアレント)－FXCPU
    Public Const UNIT_GOT_FXETHER As Short = &H61S	' GOTトランスペアレント(PC(シリアル/USB)→GOT(Ethernet)→FX3U-ENET-ADP)
    Public Const UNIT_GOT_FXENET As Short = &H62S	' GOTトランスペアレント(PC(シリアル/USB)→GOT(Ethernet)→FX3U-ENET(-L))

    ''' ACTPROGTYPE PROTOCOLTYPE
    Public Const PROTOCOL_SERIAL As Short = &H04S	' Serialﾎﾟｰﾄ経由 
    Public Const PROTOCOL_USB As Short = &H0DS	' USBﾎﾟｰﾄ経由
    Public Const PROTOCOL_TCPIP As Short = &H05S	' TCP/IP経由 
    Public Const PROTOCOL_UDPIP As Short = &H08S	' UDP/IP経由 
    Public Const PROTOCOL_MNETH As Short = &H0FS	' Mnethﾎﾞｰﾄﾞ経由 
    Public Const PROTOCOL_MNETG	 As Short = &H14S	' Mnetgボード経由
    Public Const PROTOCOL_CCIEF	 As Short = &H15S	' CC-Link IEフィールドボード経由
    Public Const PROTOCOL_CCLINK As Short = &H07S	' CC-Link経由
    Public Const PROTOCOL_SERIALMODEM As Short = &H0ES	' ｼﾘｱﾙﾎﾟｰﾄ+ﾓﾃﾞﾑ経由 
    Public Const PROTOCOL_TEL As Short = &HAS  ' TEL経由 */
    Public Const PROTOCOL_QBF As Short = &H10S  ' Qn用パソコンCPU経由
    Public Const PROTOCOL_QSS As Short = &H11S  ' Qn用SoftLogic経由
    Public Const PROTOCOL_USBGOT As Short = &H13S   ' USBﾎﾟｰﾄ+GOT経由
    Public Const PROTOCOL_SHAREDMEMORY As Short = &H6S '共有ﾒﾓﾘ経由 

End Module

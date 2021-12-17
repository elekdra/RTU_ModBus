// -----------------------------------------------------------------------
// <copyright file="ParamIDDefs.cs" company="Ametek">
// Copyright (c) 2012 Ametek. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace WDGModbusLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Enumeration definition for
    /// parameter Identifiers
    /// </summary>
    public enum ParamIDDefs
    {
        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_OXYGEN = 1,

        /// <summary>
        /// Parameter for Combustibles
        /// </summary>
        PARID_COMB = 2,

        /// <summary>
        /// Parameter for Methane
        /// </summary>
        PARID_CH4 = 3,

        /// <summary>
        /// Parameter for System Alarm Mask
        /// </summary>
        PARID_SYSALARMMASK = 4,

        /// <summary>
        /// Parameter for Oxygen Cell Temperature
        /// </summary>
        PARID_CELLTEMP = 5,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_BOXTEMP = 6,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CELLMV = 7,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_TCMV = 8,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CJTEMP = 9,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_RTDRES = 10,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_COMBACTV = 11,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_COMBREFV = 12,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4ACTV = 13,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4REFV = 14,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CELLHDC = 15,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_BOXHDC = 16,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CELLTEMPSP = 17,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_BOXTEMPSP = 18,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CELLPBAND = 19,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CELLST = 20,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CELLIT = 21,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_BOXPBAND = 22,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_BOXST = 23,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_BOXIT = 24,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2IIR = 25,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CELLTEMPIIR = 26,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_BOXTEMPIIR = 27,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_COMBIIR = 28,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AT = 29,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_TCRATIO = 30,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2CALVAL = 31,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_COMBREFZEROV = 32,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_COMBACTZEROV = 33,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_COMBSENS = 34,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_MBBAUDRATE = 35,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_STATUSMASK = 36,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_PROCALARMMASK = 37,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CALGASDUR = 38,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_RECOVDUR = 39,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_RECOVTIMER = 40,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_OPTIONMASK = 41,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_COMMAND = 42,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMDRESP = 43,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2SPANGAS = 44,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2ZEROGAS = 45,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_COMBSPANGAS = 46,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4SPANGAS = 47,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_DATAVALID = 48,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AOUT1TRACK = 49,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AOUT1MODE = 50,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AOUT1FCN = 51,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AOUT1SPAN = 52,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AOUT1ZERO = 53,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AOUT1VALUE = 54,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AOUT2TRACK = 55,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AOUT2MODE = 56,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AOUT2FCN = 57,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AOUT2SPAN = 58,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AOUT2ZERO = 59,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AOUT2VALUE = 60,
        
        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AOUT3TRACK = 61,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AOUT3MODE = 62,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AOUT3FCN = 63,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AOUT3SPAN = 64,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AOUT3ZERO = 65,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AOUT3VALUE = 66,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_RELAYMASK = 67,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2CAL1 = 68,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2CAL2 = 69,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2CAL3 = 70,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2CAL4 = 71,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2CAL5 = 72,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2CAL6 = 73,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2CAL7 = 74,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2CAL8 = 75,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2CAL9 = 76,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2CAL10 = 77,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2CAL1TM = 78,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2CAL2TM = 79,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2CAL3TM = 80,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2CAL4TM = 81,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2CAL5TM = 82,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2CAL6TM = 83,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2CAL7TM = 84,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2CAL8TM = 85,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2CAL9TM = 86,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2CAL10TM = 87,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMBCAL1 = 88,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMBCAL2 = 89,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMBCAL3 = 90,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMBCAL4 = 91,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMBCAL5 = 92,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMBCAL6 = 93,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMBCAL7 = 94,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMBCAL8 = 95,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMBCAL9 = 96,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMBCAL10 = 97,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMBCAL1TM = 98,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMBCAL2TM = 99,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMBCAL3TM = 100,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMBCAL4TM = 101,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMBCAL5TM = 102,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMBCAL6TM = 103,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMBCAL7TM = 104,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMBCAL8TM = 105,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMBCAL9TM = 106,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMBCAL10TM = 107,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_STATE = 108,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_MBADDR = 109,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AD7794_CH1 = 110,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AD7794_CH2 = 111,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AD7794_CH3 = 112,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AD7794_CH4 = 113,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AD7794_CH5 = 114,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AD7794_CH6 = 115,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AD7785_CH1 = 116,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AD7785_CH2 = 117,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AD12S01_CH1 = 118,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AD12S01_CH2 = 119,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AIN_VOLTS = 120,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AOUT1_MEAS = 121,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_SIL_TC = 122,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_TESTSPAN = 123,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CINTVL = 124,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_FLOWTESTINT = 125,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_FlOWZERO = 126,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_FLOWSPAN = 127,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_FLOWVALUE = 128,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_FLOWTESTVAL = 129,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_ONTIME = 130,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_TOTUPTIME = 131,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CELLAGE = 132,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMBDETAGE = 133,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4DETAGE = 134,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CALMODE = 135,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CALSEQ = 136,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CALSTATE = 137,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_SILCELLMV = 138,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_DIGIN = 139,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_COMBRATIO = 140,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_DFLTCELLHDC = 141,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_DFLTBOXHDC = 142,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CELLDT = 143,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_BOXDT = 144,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2SPANDRIFT = 145,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_O2ZERODRIFT = 146,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_COMBSPANDRIFT = 147,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_COMBZERODRIFT = 148,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CALSTATUS = 149,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_RELAY3FUNC = 150,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_RELAY3HI = 151,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_RELAY3LO = 152,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_RELAY3ENRGZ = 153,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_RELAY4FUNC = 154,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_RELAY4HI = 155,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_RELAY4LO = 156,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_RELAY4ENRGZ = 157,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_RELAY5FUNC = 158,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_RELAY5HI = 159,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_RELAY5LO = 160,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_RELAY5ENRGZ = 161,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AC_ENABLE = 162,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AC_FREQ = 163,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AC_START = 164,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_FWVER = 165,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_SERIALNUM = 166,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_HWREV = 167,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CELLEOL = 168,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_TIME = 169,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_TIMESET = 170,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_NEXTCAL = 171,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4ZERO = 172,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4CNTSPERPCT = 173,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4RATIO = 174,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4SPANDRIFT = 175,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4ZERODRIFT = 176,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_EVENTMASK1 = 177,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_EVENTMASK2 = 178,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_WARNMASK = 179,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CALCCELLTMP = 180,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CELLRES = 181,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMBI = 182,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4I = 183,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CMBDETEOL = 184,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_PRESSURE = 185,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_SS_NAME = 186,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_SS_NAME2 = 187,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_SS_NAME3 = 188,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_SS_NAME4 = 189,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_SS_NAME5 = 190,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4CAL1 = 191,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4CAL2 = 192,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4CAL3 = 193,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4CAL4 = 194,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4CAL5 = 195,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4CAL6 = 196,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4CAL7 = 197,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4CAL8 = 198,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4CAL9 = 199,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4CAL10 = 200,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4CAL1TM = 201,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4CAL2TM = 202,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4CAL3TM = 203,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4CAL4TM = 204,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4CAL5TM = 205,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4CAL6TM = 206,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4CAL7TM = 207,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4CAL8TM = 208,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4CAL9TM = 209,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CH4CAL10TM = 210,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AOUT1SET = 211,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AOUT2SET = 212,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_AOUT3SET = 213,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_RLYMASKSET = 214,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_FLOWSPAN2 = 215,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_FLOWPCT = 216,

        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_CALSTATESTAT = 217,

        /// <summary>
        /// Parameter for V O2 span drift
        /// </summary>
        PARID_VO2SPANDRIFT = 218,

        /// <summary>
        /// Parameter for V O2 zero drift
        /// </summary>
    	PARID_VO2ZERODRIFT = 219,

        /// <summary>
        /// Parameter for V comb span drift
        /// </summary>
    	PARID_VCMBSPANDRIFT = 220,

        /// <summary>
        /// Parameter for V comb zero drift
        /// </summary>
    	PARID_VCMBZERODRIFT = 221,

        /// <summary>
        /// Parameter for V methane span drift
        /// </summary>
    	PARID_VCH4SPANDRIFT = 222,

        /// <summary>
        /// Parameter for V methane zero drift
        /// </summary>
    	PARID_VCH4ZERODRIFT = 223,

        /// <summary>
        /// Parameter for alarm fault
        /// </summary>
    	PARID_ALARM_FAULT = 224,
        /// <summary>
        /// Parameter for Oxygen
        /// </summary>
        PARID_SENS_MAX = 225,
    }
}

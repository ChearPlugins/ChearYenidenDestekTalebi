using System.Collections.Generic;
using System.Linq;

public class DataManager
{
    #region Lists
    static List<stringModel> stringData = new List<stringModel>();
    static List<longModel> longData = new List<longModel>();
    static List<booleanModel> booleanData = new List<booleanModel>();
    #endregion

    #region setData
    public static void SetData(ulong Steam64ID, string DataName, string Text)
    {
        if (stringData.Any(data => data.Steam64ID == Steam64ID))
            if (stringData.Any(data => data.Steam64ID == Steam64ID && data.DataName == DataName))
                stringData[stringData.IndexOf(stringData.Where(where => where.Steam64ID == Steam64ID && where.DataName == DataName).First())] = new stringModel(Steam64ID, DataName, Text);
            else
                stringData.Add(new stringModel(Steam64ID, DataName, Text));
        else
            stringData.Add(new stringModel(Steam64ID, DataName, Text));
    }

    public static void SetData(ulong Steam64ID, string DataName, long Number)
    {
        if (longData.Any(data => data.Steam64ID == Steam64ID))
            if (longData.Any(data => data.Steam64ID == Steam64ID && data.DataName == DataName))
                longData[longData.IndexOf(longData.Where(where => where.Steam64ID == Steam64ID && where.DataName == DataName).First())] = new longModel(Steam64ID, DataName, Number);
            else
                longData.Add(new longModel(Steam64ID, DataName, Number));
        else
            longData.Add(new longModel(Steam64ID, DataName, Number));
    }

    public static void SetData(ulong Steam64ID, string DataName, bool Bool)
    {
        if (booleanData.Any(data => data.Steam64ID == Steam64ID))
            if (booleanData.Any(data => data.Steam64ID == Steam64ID && data.DataName == DataName))
                booleanData[booleanData.IndexOf(booleanData.Where(where => where.Steam64ID == Steam64ID && where.DataName == DataName).First())] = new booleanModel(Steam64ID, DataName, Bool);
            else
                booleanData.Add(new booleanModel(Steam64ID, DataName, Bool));
        else
            booleanData.Add(new booleanModel(Steam64ID, DataName, Bool));

    }
    #endregion

    #region getData
    //public static string getDataText(ulong Steam64ID, string DataName) => stringData[stringData.FindIndex(data => data.Steam64ID == Steam64ID && data.DataName == DataName)].Text;
    //public static long getDataNumber(ulong Steam64ID, string DataName) => longData[longData.FindIndex(data => data.Steam64ID == Steam64ID && data.DataName == DataName)].Long;
    //public static bool getDataBool(ulong Steam64ID, string DataName) => booleanData[booleanData.FindIndex(data => data.Steam64ID == Steam64ID && data.DataName == DataName)].Boolean;

    public static object getData(ulong Steam64ID, string DataName, DataType Type)
    {
        if (Type == DataType.String)
            return stringData[stringData.FindIndex(data => data.Steam64ID == Steam64ID && data.DataName == DataName)].Text;

        if (Type == DataType.Integer)
            return longData[longData.FindIndex(data => data.Steam64ID == Steam64ID && data.DataName == DataName)].Long;

        if (Type == DataType.Boolean)
            return booleanData[booleanData.FindIndex(data => data.Steam64ID == Steam64ID && data.DataName == DataName)].Boolean;

        return null;
    }
    #endregion

    public static bool hasData(ulong Steam64ID, string DataName)
    {
        if (stringData.Any(data => data.Steam64ID == Steam64ID && data.DataName == DataName))
            return true;

        else if (longData.Any(data => data.Steam64ID == Steam64ID && data.DataName == DataName))
            return true;

        else if (booleanData.Any(data => data.Steam64ID == Steam64ID && data.DataName == DataName))
            return true;

        return false;
    }

    //#region Enums
    //public enum DataType
    //{
    //    String,
    //    Integer,
    //    Boolean
    //}
    //#endregion

    #region Models
    public class stringModel
    {
        public ulong Steam64ID { get; set; }
        public string DataName { get; set; }
        public string Text { get; set; }

        public stringModel(ulong steam64id, string dataname, string text)
        {
            Steam64ID = steam64id;
            DataName = dataname;
            Text = text;
        }
    }

    public class longModel
    {
        public ulong Steam64ID { get; set; }
        public string DataName { get; set; }
        public long Long { get; set; }

        public longModel(ulong steam64id, string dataname, long getLong)
        {
            Steam64ID = steam64id;
            DataName = dataname;
            Long = getLong;
        }
    }

    public class booleanModel
    {
        public ulong Steam64ID { get; set; }
        public string DataName { get; set; }
        public bool Boolean { get; set; }

        public booleanModel(ulong steam64id, string dataname, bool boolean)
        {
            Steam64ID = steam64id;
            DataName = dataname;
            Boolean = boolean;
        }
    }

    #endregion
}


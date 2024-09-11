
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;
using SimpleJSON;


namespace cfg
{
public sealed partial class L10nGame : Luban.BeanBase
{
    public L10nGame(JSONNode _buf) 
    {
        { if(!_buf["l10n_key"].IsString) { throw new SerializationException(); }  L10nKey = _buf["l10n_key"]; }
        { if(!_buf["cn"].IsString) { throw new SerializationException(); }  Cn = _buf["cn"]; }
        { if(!_buf["cn_traditional"].IsString) { throw new SerializationException(); }  CnTraditional = _buf["cn_traditional"]; }
        { if(!_buf["en"].IsString) { throw new SerializationException(); }  En = _buf["en"]; }
    }

    public static L10nGame DeserializeL10nGame(JSONNode _buf)
    {
        return new L10nGame(_buf);
    }

    /// <summary>
    /// 语言key
    /// </summary>
    public readonly string L10nKey;
    /// <summary>
    /// 中文
    /// </summary>
    public readonly string Cn;
    /// <summary>
    /// 繁体中文
    /// </summary>
    public readonly string CnTraditional;
    /// <summary>
    /// 英文
    /// </summary>
    public readonly string En;
   
    public const int __ID__ = 1325605109;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
        
        
        
        
    }

    public override string ToString()
    {
        return "{ "
        + "l10nKey:" + L10nKey + ","
        + "cn:" + Cn + ","
        + "cnTraditional:" + CnTraditional + ","
        + "en:" + En + ","
        + "}";
    }
}

}

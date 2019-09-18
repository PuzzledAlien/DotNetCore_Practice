public class Hex
{
    /// <summary>
    /// 字节数组转换为Hex字符串
    /// </summary>
    /// <param name="data"></param>
    /// <param name="toLowerCase"></param>
    /// <returns></returns>
    public static string ByteArrayToHexString(byte[] data, bool toLowerCase = true)
    {
        var hex = BitConverter.ToString(data).Replace("-", string.Empty);
        return toLowerCase ? hex.ToLower() : hex.ToUpper();
    }
}
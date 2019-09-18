public class DigestUtils
{
    /// <summary>
    /// SHA256 转换为 Hex字符串
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string Sha256Hex(string data)
    {
        var bytes = Encoding.UTF8.GetBytes(data);
        using (var sha256 = SHA256.Create())
        {
            var hash = sha256.ComputeHash(bytes);
            return Hex.ByteArrayToHexString(hash);
        }
    }

    /// <summary>
    /// SHA256 转换为 Hex字符串
    /// </summary>
    /// <param name="data"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static string Sha256Hex(string data, Encoding encoding)
    {
        var bytes = encoding.GetBytes(data);
        using (var sha256 = SHA256.Create())
        {
            var hash = sha256.ComputeHash(bytes);
            return Hex.ByteArrayToHexString();
        }
    }

    /// <summary>
    /// SHA256 转换为 Hex字符串
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string Sha256Hex(byte[] bytes)
    {
        using (var sha256 = SHA256.Create())
        {
            var hash = sha256.ComputeHash(bytes);
            return Hex.ByteArrayToHexString();
        }
    }
}
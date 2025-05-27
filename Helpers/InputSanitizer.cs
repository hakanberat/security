using System.Text.RegularExpressions;

public static class InputSanitizer
{
    public static string SanitizeInput(string input)
    {
        // HTML karakterlerini encode et (XSS'ye karşı)
        string encoded = System.Net.WebUtility.HtmlEncode(input);

        // Tehlikeli karakterleri temizle (SQL Injection'a karşı)
        return Regex.Replace(encoded, @"[^\w@\.-]", "");
    }
}

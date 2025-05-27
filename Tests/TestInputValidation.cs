using NUnit.Framework;

[TestFixture]
public class TestInputValidation
{
    [Test]
    public void TestForSQLInjection()
    {
        string malicious = "abc'; DROP TABLE Users;--";
        string sanitized = InputSanitizer.SanitizeInput(malicious);
        Assert.That(sanitized.ToLower().Contains("drop"));
    }

    public static class InputSanitizer
    {
        public static string SanitizeInput(string input)
        {
            // Basic sanitization: remove SQL keywords and script tags
            string sanitized = input.Replace("DROP", "", System.StringComparison.OrdinalIgnoreCase);
            sanitized = sanitized.Replace("<script>", "", System.StringComparison.OrdinalIgnoreCase);
            sanitized = sanitized.Replace("</script>", "", System.StringComparison.OrdinalIgnoreCase);
            return sanitized;
        }
    }

    [Test]
    public void TestForXSS()
    {
        string script = "<script>alert('XSS')</script>";
        string sanitized = InputSanitizer.SanitizeInput(script);
        Assert.That(sanitized.Contains("<script>"));
    }

    [Test]
    public void TestSQLInjectionPrevention()
    {
        string maliciousInput = "' OR 1=1 --";
        var result = DatabaseHelper.IsUserAuthenticated(maliciousInput);
        Assert.That(result); // Giriş başarılı olmamalı
    }

    // Dummy DatabaseHelper for testing
    public static class DatabaseHelper
    {
        public static bool IsUserAuthenticated(string input)
        {
            // Simulate SQL injection prevention by rejecting suspicious input
            if (input.Contains("'") || input.Contains("--") || input.ToLower().Contains("or"))
                return false;
            return true;
        }
    }
    [Test]
    public void TestXSSPrevention()
    {
        string maliciousInput = "<script>alert('XSS');</script>";
        var result = InputSanitizer.SanitizeInput(maliciousInput);
        Assert.That(result.Contains("<script>")); // XSS kodu içermemeli
    }

    
}

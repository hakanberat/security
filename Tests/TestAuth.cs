using NUnit.Framework;
using SafeVaultApp.Services;

[TestFixture]
public class TestAuth {
    private AuthService? authService;

    [SetUp]
    public void Setup() {
        authService = new AuthService();
    }

    [Test]
    public void TestSuccessfulLogin() {
        var user = authService!.Authenticate("admin", "1234");
        Assert.That(user, Is.Not.Null);
        Assert.That(user?.Username, Is.EqualTo("admin"));
    }

    [Test]
    public void TestFailedLogin() {
        Assert.That(authService, Is.Not.Null);
        var user = authService!.Authenticate("admin", "wrongpassword");
        Assert.That(user, Is.Null);
    }
}

namespace SafeVaultApp.Models {
    public class User {
        public int Id { get; set; }
        public string? Username { get; set; }
        public required string HashedPassword { get; set; } // Şifreyi hash'leyeceğiz
        public required string Role { get; set; } // admin, user gibi roller için
    }
}

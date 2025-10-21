using System;
using System.Security.Cryptography;
using System.Text;

namespace InventorSignatureAddIn
{
    /// <summary>
    /// 处理数字签名的生成和验证
    /// </summary>
    public class SignatureManager
    {
        private readonly string _密钥 = "Inventor-签名-2021-安全密钥-V1";

        /// <summary>
        /// 为提供的数据生成数字签名
        /// </summary>
        public string GenerateSignature(string 数据, string 签名者, DateTime 时间戳)
        {
            if (string.IsNullOrEmpty(数据))
                throw new ArgumentException("数据不能为空", nameof(数据));
            
            if (string.IsNullOrEmpty(签名者))
                throw new ArgumentException("签名者不能为空", nameof(签名者));

            // 组合签名数据
            string 组合字符串 = $"{数据}|{签名者}|{时间戳:yyyy-MM-dd HH:mm:ss}|{_密钥}";
            
            // 使用HMAC-SHA256算法生成签名
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_密钥)))
            {
                byte[] 哈希值 = hmac.ComputeHash(Encoding.UTF8.GetBytes(组合字符串));
                return Convert.ToBase64String(哈希值);
            }
        }

        /// <summary>
        /// 验证数字签名
        /// </summary>
        public bool VerifySignature(string 数据, string 签名者, DateTime 时间戳, string 存储的签名)
        {
            try
            {
                if (string.IsNullOrEmpty(存储的签名))
                    return false;

                // 重新计算签名进行比较
                string 计算的签名 = GenerateSignature(数据, 签名者, 时间戳);
                return string.Equals(计算的签名, 存储的签名, StringComparison.Ordinal);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 用户身份认证
        /// </summary>
        public bool AuthenticateUser(string 用户名, string 密码)
        {
            // 在生产环境中，这里应该连接安全的用户数据库
            var 有效用户 = new[]
            {
                new { 用户名 = "admin", 密码 = "admin123" },
                new { 用户名 = "engineer", 密码 = "engineer2024" },
                new { 用户名 = "reviewer", 密码 = "review123" },
                new { 用户名 = "设计师", 密码 = "design123" }
            };

            // 检查用户名和密码是否匹配
            return Array.Exists(有效用户, 用户 => 
                用户.用户名 == 用户名 && 用户.密码 == 密码);
        }
    }
}

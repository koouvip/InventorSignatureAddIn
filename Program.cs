
using System;
using System.Windows.Forms;

namespace InventorSignatureAddIn
{
    /// <summary>
    /// Inventor 签名插件主入口点
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 测试入口点，用于验证编译
        /// </summary>
        public static void Main()
        {
            // 启用视觉样式
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Console.WriteLine("=== Inventor 电子签名插件 ===");
            Console.WriteLine("编译测试 - 编译成功！");
            
            // 测试签名功能
            测试签名功能();
            
            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }

        private static void 测试签名功能()
        {
            try
            {
                var 管理器 = new SignatureManager();
                
                // 测试数据
                string 测试数据 = "工程图签名测试";
                string 签名者 = "测试工程师";
                DateTime 时间戳 = DateTime.Now;
                
                // 生成签名
                string 签名 = 管理器.GenerateSignature(测试数据, 签名者, 时间戳);
                Console.WriteLine($"✓ 签名生成成功: {签名.Substring(0, 20)}...");
                
                // 验证签名
                bool 验证结果 = 管理器.VerifySignature(测试数据, 签名者, 时间戳, 签名);
                Console.WriteLine($"✓ 签名验证结果: {验证结果}");
                
                // 测试用户认证
                bool 认证结果 = 管理器.AuthenticateUser("admin", "admin123");
                Console.WriteLine($"✓ 用户认证测试: {认证结果}");
                
                MessageBox.Show("Inventor 电子签名插件\n编译成功！", 
                              "测试完成", 
                              MessageBoxButtons.OK, 
                              MessageBoxIcon.Information);
            }
            catch (Exception 异常)
            {
                Console.WriteLine($"✗ 测试过程中出错: {异常.Message}");
                MessageBox.Show($"测试失败: {异常.Message}", "错误", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Inventor 插件激活入口点
        /// </summary>
        public void Activate(object inventor应用)
        {
            MessageBox.Show("Inventor 电子签名插件已激活！", 
                          "插件加载", 
                          MessageBoxButtons.OK, 
                          MessageBoxIcon.Information);
        }
    }
}

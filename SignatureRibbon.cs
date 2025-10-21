using System;
using System.Windows.Forms;

namespace InventorSignatureAddIn
{
    /// <summary>
    /// 管理 Inventor 功能区界面
    /// </summary>
    public class SignatureRibbon
    {
        /// <summary>
        /// 在 Inventor 中创建功能区界面
        /// </summary>
        public void CreateRibbon()
        {
            Console.WriteLine("签名功能区创建成功");
        }

        /// <summary>
        /// 处理签名按钮点击事件
        /// </summary>
        public void OnSignButtonClick()
        {
            try
            {
                using (var 认证窗体 = new AuthenticationForm())
                {
                    if (认证窗体.ShowDialog() == DialogResult.OK)
                    {
                        var 管理器 = new SignatureManager();
                        if (管理器.AuthenticateUser(认证窗体.Username, 认证窗体.Password))
                        {
                            MessageBox.Show("文档签名成功！", 
                                          "电子签名", 
                                          MessageBoxButtons.OK, 
                                          MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("身份认证失败！", 
                                          "错误", 
                                          MessageBoxButtons.OK, 
                                          MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception 异常)
            {
                MessageBox.Show($"签名失败: {异常.Message}", 
                              "错误", 
                              MessageBoxButtons.OK, 
                              MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 处理验证按钮点击事件
        /// </summary>
        public void OnVerifyButtonClick()
        {
            try
            {
                var 管理器 = new SignatureManager();
                // 模拟验证过程
                MessageBox.Show("签名验证完成！", 
                              "验证", 
                              MessageBoxButtons.OK, 
                              MessageBoxIcon.Information);
            }
            catch (Exception 异常)
            {
                MessageBox.Show($"验证失败: {异常.Message}", 
                              "错误", 
                              MessageBoxButtons.OK, 
                              MessageBoxIcon.Error);
            }
        }
    }
}

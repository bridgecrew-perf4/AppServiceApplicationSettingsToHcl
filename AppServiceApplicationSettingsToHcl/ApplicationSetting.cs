namespace AppServiceApplicationSettingsToHcl
{
    /// <summary>
    /// AppServiceのアプリケーション設定
    /// </summary>
    public class ApplicationSetting
    {
        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 値
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// デプロイスロットの設定
        /// </summary>
        public bool SlotSetting { get; set; }
    }
}

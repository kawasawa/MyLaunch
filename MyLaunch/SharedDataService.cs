﻿using MyBase;
using MyBase.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MyLaunch
{
    /// <summary>
    /// アプリケーション全体で共有される情報の保管庫を表します。
    /// </summary>
    public sealed class SharedDataStore
    {
        private readonly ILoggerFacade _logger;
        private readonly IProductInfo _productInfo;
        private readonly Process _process;

        public IEnumerable<string> CommandLineArgs { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<string> CachedDirectories { get; set; } = Enumerable.Empty<string>();

        public string Identifier => $"__{this._productInfo.Company}:{this._productInfo.Product}:{this._productInfo.Version}__";
        public string LogDirectoryPath => Path.Combine(this._productInfo.Local, "log");
        public string TempDirectoryPath => Path.Combine(this._productInfo.Temporary, this._process.StartTime.ToString("yyyyMMddHHmmssfff"));

        /// <summary>
        /// このクラスの新しいインスタンスを生成します。
        /// </summary>
        /// <param name="logger">ロガー</param>
        /// <param name="productInfo">プロダクト情報</param>
        /// <param name="process">プロセス情報</param>
        public SharedDataStore(ILoggerFacade logger, IProductInfo productInfo, Process process)
        {
            this._logger = logger;
            this._productInfo = productInfo;
            this._process = process;
        }

        /// <summary>
        /// このプロセスで使用する一時フォルダを生成する。
        /// </summary>
        public void CreateTempDirectory()
        {
            // フォルダを作成し、隠し属性を付与する
            var info = new DirectoryInfo(this.TempDirectoryPath);
            info.Create();
            info.Attributes |= FileAttributes.Hidden;

            this._logger.Debug($"一時フォルダを作成し、隠し属性を付与しました。: Path={this.TempDirectoryPath}");
        }
    }
}

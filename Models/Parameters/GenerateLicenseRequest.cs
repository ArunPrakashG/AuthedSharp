using System;
using System.Collections.Generic;
using System.Text;

namespace AuthedSharp.Models.Parameters {
	public struct GenerateLicenseRequest {
		public readonly string AppSecret;
		public readonly string LicensePrefix;
		public readonly int Level;
		public readonly int Time;
		public readonly int Amount;
		public readonly string ApplicationSession;

		public GenerateLicenseRequest(string _appSecret, string _licensePrefix, int _level, int _time, int _amount, string _session) {
			AppSecret = _appSecret;
			LicensePrefix = _licensePrefix;
			Level = _level;
			Time = _time;
			Amount = _amount;
			ApplicationSession = _session;
		}
	}
}

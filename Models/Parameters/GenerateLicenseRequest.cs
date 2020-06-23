namespace AuthedSharp.Models.Parameters {
	public struct GenerateLicenseRequest {
		public readonly string AppSecret;
		public readonly string LicensePrefix;
		public readonly int Level;
		public readonly int Time;
		public readonly int Amount;
		public readonly string ApplicationSession;

		/// <summary>
		/// ctor for Generate license request.
		/// </summary>
		/// <param name="_appSecret">The application secret.</param>
		/// <param name="_licensePrefix">The license prefix.</param>
		/// <param name="_level">The level of license.</param>
		/// <param name="_time">The time until the license is expired.</param>
		/// <param name="_amount">The amount of licenses to generate.</param>
		/// <param name="_appSession">The application session.</param>
		public GenerateLicenseRequest(string _appSecret, string _licensePrefix, int _level, int _time, int _amount, string _appSession) {
			AppSecret = _appSecret;
			LicensePrefix = _licensePrefix;
			Level = _level;
			Time = _time;
			Amount = _amount;
			ApplicationSession = _appSession;
		}
	}
}

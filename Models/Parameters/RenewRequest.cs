namespace AuthedSharp.Models.Parameters {
	public struct RenewRequest {
		public readonly string Email;
		public readonly string LicenseCode;
		public readonly string ApplicationSession;

		/// <summary>
		/// ctor
		/// </summary>
		/// <param name="_email">The email address.</param>
		/// <param name="_licenseCode">The license code.</param>
		/// <param name="_appSession">The application session.</param>
		public RenewRequest(string _email, string _licenseCode, string _appSession) {
			Email = _email;
			LicenseCode = _licenseCode;
			ApplicationSession = _appSession;
		}
	}
}

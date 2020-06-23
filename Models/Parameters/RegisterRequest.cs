using System;
using System.Collections.Generic;
using System.Text;

namespace AuthedSharp.Models.Parameters {
	public struct RegisterRequest {
		public readonly string Email;
		public readonly string Password;
		public readonly string LicenseCode;
		public readonly string ApplicationSession;

		/// <summary>
		/// ctor
		/// </summary>
		/// <param name="_email">The email address.</param>
		/// <param name="_password">The password.</param>
		/// <param name="_licenseCode">The license code.</param>
		/// <param name="_appSession">The application session.</param>
		public RegisterRequest(string _email, string _password, string _licenseCode, string _appSession) {
			Email = _email;
			Password = _password;
			LicenseCode = _licenseCode;
			ApplicationSession = _appSession;
		}
	}
}

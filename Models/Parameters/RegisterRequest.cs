using System;
using System.Collections.Generic;
using System.Text;

namespace AuthedSharp.Models.Parameters {
	public struct RegisterRequest {
		public readonly string Email;
		public readonly string Password;
		public readonly string LicenseCode;

		public RegisterRequest(string _email, string _password, string _licenseCode) {
			Email = _email;
			Password = _password;
			LicenseCode = _licenseCode;
		}
	}
}

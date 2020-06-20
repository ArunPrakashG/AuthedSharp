using System;
using System.Collections.Generic;
using System.Text;

namespace AuthedSharp.Models.Parameters {
	public struct RenewRequest {
		public readonly string Email;
		public readonly string LicenseCode;
		public readonly string ApplicationSession;

		public RenewRequest(string _email, string _licenseCode, string _session) {
			Email = _email;
			LicenseCode = _licenseCode;
			ApplicationSession = _session;
		}
	}
}

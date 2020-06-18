using System;
using System.Collections.Generic;
using System.Text;

namespace AuthedSharp.Models.Parameters {
	public struct LoginRequest {
		public readonly string Email;
		public readonly string Password;

		public LoginRequest(string _email, string _password) {
			Email = _email;
			Password = _password;
		}
	}
}

using System;

namespace AuthedSharp.Models.Parameters {
	public struct VerifyRequest {
		public readonly string ApplicationID;
		public readonly string AccessToken;

		/// <summary>
		/// Verifies an application.
		/// </summary>
		/// <param name="_applicationID">The application id.</param>
		/// <param name="_accessToken">The application access token.</param>
		public VerifyRequest(string _applicationID, string _accessToken) {
			ApplicationID = _applicationID ?? throw new ArgumentNullException(nameof(_applicationID));
			AccessToken = _accessToken ?? throw new ArgumentNullException(nameof(_applicationID));
		}
	}
}

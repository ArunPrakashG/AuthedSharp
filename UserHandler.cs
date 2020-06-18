using AuthedSharp.Models.Parameters;
using AuthedSharp.Models.Responses.UserResponses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AuthedSharp {
	public sealed class UserHandler {
		private readonly Requester Requester;

		internal UserHandler(Requester _requester) => Requester = _requester;

		public async Task<LoginResponse> LoginAsync(LoginRequest request) {
			if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password)) {
				throw new ArgumentNullException(nameof(request));
			}

			using (HttpRequestMessage requestMsg = new HttpRequestMessage(HttpMethod.Post, "login")) {
				requestMsg.Content = new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{ "email", request.Email },
					{ "password", request.Password }
				});

				return await Requester.InternalRequestAsObject<LoginResponse>(requestMsg, 1).ConfigureAwait(false);
			}
		}

		public async Task<RegisterResponse> RegisterAsync(RegisterRequest request) {
			if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password) || string.IsNullOrEmpty(request.LicenseCode)) {
				throw new ArgumentNullException(nameof(request));
			}

			using (HttpRequestMessage requestMsg = new HttpRequestMessage(HttpMethod.Post, "register")) {
				requestMsg.Content = new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{ "email", request.Email },
					{ "password", request.Password },
					{ "licenseCode", request.LicenseCode }
				});

				return await Requester.InternalRequestAsObject<RegisterResponse>(requestMsg, 1).ConfigureAwait(false);
			}
		}
	}
}

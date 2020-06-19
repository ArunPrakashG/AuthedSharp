using AuthedSharp.Models.Parameters;
using AuthedSharp.Models.Responses.UserResponses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuthedSharp {
	public sealed class UserHandler {
		private readonly Requester Requester;
		private readonly bool SaveSession;

		internal UserHandler(Requester _requester, bool _saveSession) {
			Requester = _requester;
			SaveSession = _saveSession;
		}

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

				requestMsg.Headers.Add("session", request.Session);
				return await Requester.InternalRequestAsObject<RegisterResponse>(requestMsg, 1).ConfigureAwait(false);
			}
		}

		public async Task<RenewResponse> RenewAsync(RenewRequest request) {
			if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.LicenseCode)) {
				throw new ArgumentNullException(nameof(request));
			}

			using (HttpRequestMessage requestMsg = new HttpRequestMessage(HttpMethod.Post, "renew")) {
				requestMsg.Content = new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{ "email", request.Email },
					{ "licenseCode", request.LicenseCode }
				});

				requestMsg.Headers.Add("session", request.Session);
				return await Requester.InternalRequestAsObject<RenewResponse>(requestMsg, 1).ConfigureAwait(false);
			}
		}

		public async Task<GrandMembershipResponse> GrandMembershipAsync(GrandMembershipRequest request) {
			if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.MembershipID)) {
				throw new ArgumentNullException(nameof(request));
			}

			using (HttpRequestMessage requestMsg = new HttpRequestMessage(HttpMethod.Post, "user/membership")) {
				requestMsg.Content = new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{ "email", request.Email },
					{ "membershipId", request.MembershipID }
				});

				requestMsg.Headers.Add("session", request.Session);
				return await Requester.InternalRequestAsObject<GrandMembershipResponse>(requestMsg, 1).ConfigureAwait(false);
			}
		}

		public async Task<UpdateUserResponse> UpdateUserAsync(UpdateUserFieldRequest request) {
			if (string.IsNullOrEmpty(request.Session) || string.IsNullOrEmpty(request.UserSession)) {
				throw new ArgumentNullException(nameof(request));
			}

			using (HttpRequestMessage requestMsg = new HttpRequestMessage(HttpMethod.Post, "users/set")) {
				requestMsg.Content = new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{ "userSession", request.UserSession },
					{ "field", request.Field.ToString() },
					{ "value", request.FieldValue }
				});

				requestMsg.Headers.Add("session", request.Session);
				return await Requester.InternalRequestAsObject<UpdateUserResponse>(requestMsg, 1).ConfigureAwait(false);
			}
		}

		public async Task<RenewSessionResponse> RenewUserSessionAsync(RenewUserSessionRequest request) {
			if (string.IsNullOrEmpty(request.Session) || string.IsNullOrEmpty(request.UserSession)) {
				throw new ArgumentNullException(nameof(request));
			}

			using (HttpRequestMessage requestMsg = new HttpRequestMessage(HttpMethod.Post, "session")) {
				requestMsg.Content = new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{ "userSession", request.UserSession }
				});

				requestMsg.Headers.Add("session", request.Session);
				return await Requester.InternalRequestAsObject<RenewSessionResponse>(requestMsg, 1).ConfigureAwait(false);
			}
		}

		public async Task<GetUserResponse> GetUserAsync(GetUserRequest request) {
			if (string.IsNullOrEmpty(request.Session) || string.IsNullOrEmpty(request.UserSession)) {
				throw new ArgumentNullException(nameof(request));
			}

			using (HttpRequestMessage requestMsg = new HttpRequestMessage(HttpMethod.Post, "user")) {
				requestMsg.Content = new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{ "userSession", request.UserSession }
				});

				requestMsg.Headers.Add("session", request.Session);
				return await Requester.InternalRequestAsObject<GetUserResponse>(requestMsg, 1).ConfigureAwait(false);
			}
		}
	}
}

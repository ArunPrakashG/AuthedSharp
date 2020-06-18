using AuthedSharp.Models.Parameters;
using AuthedSharp.Models.Responses.AppResponses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuthedSharp {
	public sealed class ApplicationHandler {
		private readonly Requester Requester;

		internal ApplicationHandler(Requester _requester) => Requester = _requester;

		public async Task<VerifyResponse> VerifyAsync(VerifyRequest request) {
			if (string.IsNullOrEmpty(request.AccessToken) || string.IsNullOrEmpty(request.ApplicationID)) {
				throw new ArgumentNullException(nameof(request));
			}

			using (HttpRequestMessage requestMsg = new HttpRequestMessage(HttpMethod.Post, $"verify/{request.ApplicationID}")) {
				requestMsg.Content = new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{ "access", request.AccessToken }
				});

				return await Requester.InternalRequestAsObject<VerifyResponse>(requestMsg, 1).ConfigureAwait(false);
			}
		}

		public async Task<UpdateApplicationResponse> UpdateApplicationValuesAsync(UpdateAppRequest request) {
			if (string.IsNullOrEmpty(request.AppSecret) || string.IsNullOrEmpty(request.CurrentSession)) {
				throw new ArgumentNullException(nameof(request));
			}

			using (HttpRequestMessage requestMsg = new HttpRequestMessage(HttpMethod.Post, $"set/{request.FieldInfo.Field}")) {
				requestMsg.Content = new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{ "secret", request.AppSecret },
					{ "value", request.FieldInfo.Value.ToString() }
				});

				requestMsg.Headers.Add("Session", request.CurrentSession);

				return await Requester.InternalRequestAsObject<UpdateApplicationResponse>(requestMsg, 1).ConfigureAwait(false);
			}
		}

		public async Task<GenerateLicenseResponse> GenerateLicenseAsync(GenerateLicenseRequest request) {
			if (string.IsNullOrEmpty(request.AppSecret) || string.IsNullOrEmpty(request.Session)) {
				throw new ArgumentNullException(nameof(request));
			}

			using (HttpRequestMessage requestMsg = new HttpRequestMessage(HttpMethod.Post, $"generate/license")) {
				requestMsg.Content = new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{ "secret", request.AppSecret },
					{ "prefix", request.LicensePrefix },
					{ "level", request.Level.ToString() },
					{ "time", request.Time.ToString() },
					{ "amount", request.Amount.ToString() }
				});

				requestMsg.Headers.Add("Session", request.Session);
				return await Requester.InternalRequestAsObject<GenerateLicenseResponse>(requestMsg, 1).ConfigureAwait(false);
			}
		}

		public async Task<GenerateMembershipResponse> GenerateLicenseAsync(GenerateMembershipRequest request) {
			if (string.IsNullOrEmpty(request.AppSecret) || string.IsNullOrEmpty(request.Session)) {
				throw new ArgumentNullException(nameof(request));
			}

			using (HttpRequestMessage requestMsg = new HttpRequestMessage(HttpMethod.Post, $"generate/membership")) {
				requestMsg.Content = new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{ "secret", request.AppSecret },
					{ "name", request.Name },
					{ "level", request.Level.ToString() },
					{ "time", request.Time.ToString() }
				});

				requestMsg.Headers.Add("Session", request.Session);
				return await Requester.InternalRequestAsObject<GenerateMembershipResponse>(requestMsg, 1).ConfigureAwait(false);
			}
		}
	}
}

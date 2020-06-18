using AuthedSharp.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AuthedSharp {
	internal sealed class Requester : IDisposable {
		private const string BASE_ADDRESS = "https://api.authed.io/app/";
		private const int MAX_TRIES = 3;
		private static readonly SemaphoreSlim Sync = new SemaphoreSlim(1, 1);
		private readonly int DELAY_BETWEEN_REQUESTS = 5;
		private readonly int DELAY_BETWEEN_FAILED_REQUESTS = 10;
		private readonly HttpClientHandler ClientHandler;
		private readonly HttpClient Client;

		internal Requester(HttpClientHandler? _clientHandler, IWebProxy? _proxy) {
			ClientHandler = _clientHandler ?? new HttpClientHandler() {
				AllowAutoRedirect = false,
				Proxy = _proxy,
				UseProxy = _proxy != null				
			};

			Client = new HttpClient(ClientHandler, false) {
				BaseAddress = new Uri(BASE_ADDRESS),
				Timeout = TimeSpan.FromSeconds(30)
			};
		}

		internal Requester() {
			ClientHandler = new HttpClientHandler() {
				AllowAutoRedirect = false
			};

			Client = new HttpClient(ClientHandler, false) {
				BaseAddress = new Uri(BASE_ADDRESS),
				Timeout = TimeSpan.FromSeconds(30)
			};
		}

		/// <summary>
		/// Sends a <see cref="HttpRequestMessage"/> request and returns result object.
		/// </summary>
		/// <param name="request">The <see cref="HttpRequestMessage"/> request instance.</param>
		/// <param name="maxTries">The maximum number of tries before the request is considered as a fail.</param>
		/// <typeparam name="T">The type of result object, used to deserialize the result json.</typeparam>
		/// <returns>The result object.</returns>
		public async Task<T> InternalRequestAsObject<T>(
			HttpRequestMessage request, int maxTries = MAX_TRIES) {
			if (request == null) {
				return default;
			}

			bool success = false;
			for (int i = 0; i < maxTries; i++) {
				try {
					using (HttpResponseMessage response = await ExecuteRequest(async () => await Client.SendAsync(request).ConfigureAwait(false)).ConfigureAwait(false)) {
						if (!response.IsSuccessStatusCode) {
							continue;
						}

						using (HttpContent responseContent = response.Content) {
							string jsonContent = await responseContent.ReadAsStringAsync().ConfigureAwait(false);

							if (string.IsNullOrEmpty(jsonContent)) {
								continue;
							}

							success = true;
							return JsonConvert.DeserializeObject<T>(jsonContent);
						}
					}
				}
				catch (Exception) {
					success = false;
					continue;
				}
				finally {
					if (!success) {
						await Task.Delay(TimeSpan.FromSeconds(DELAY_BETWEEN_FAILED_REQUESTS)).ConfigureAwait(false);
					}
				}
			}

			if (!success) {
				throw new InternalRequestFailedException();
			}

			return default;
		}

		/// <summary>
		/// Send a generic HTTP request to the specified url with the specified method and headers.
		/// </summary>
		/// <param name="method">the <see cref="HttpMethod"/> to use for the request.</param>
		/// <param name="requestUrl">The URL the send the request to.</param>
		/// <param name="data">headers which should be appended to the request, if any.</param>
		/// <param name="maxTries">The maximum number of tries before the request is considered as a fail.</param>
		/// <typeparam name="T">The type of result object, used to deserialize the result json.</typeparam>
		/// <returns>The result object.</returns>
		public async Task<T> InternalRequestAsObject<T>(
			HttpMethod method, string requestUrl, Dictionary<string, string> data, int maxTries = MAX_TRIES) {
			if (string.IsNullOrEmpty(requestUrl)) {
				return default;
			}

			bool success = false;
			for (int i = 0; i < maxTries; i++) {
				try {
					using (HttpRequestMessage request = new HttpRequestMessage(method, requestUrl)) {
						foreach (var pair in data) {
							request.Headers.Add(pair.Key, pair.Value);
						}

						using (HttpResponseMessage response = await ExecuteRequest(async () => await Client.SendAsync(request).ConfigureAwait(false)).ConfigureAwait(false)) {
							if (!response.IsSuccessStatusCode) {
								continue;
							}

							using (HttpContent responseContent = response.Content) {
								string jsonContent = await responseContent.ReadAsStringAsync().ConfigureAwait(false);

								if (string.IsNullOrEmpty(jsonContent)) {
									continue;
								}

								success = true;
								return JsonConvert.DeserializeObject<T>(jsonContent);
							}
						}
					}
				}
				catch (Exception e) {
					success = false;
					continue;
				}
				finally {
					if (!success) {
						await Task.Delay(TimeSpan.FromSeconds(DELAY_BETWEEN_FAILED_REQUESTS)).ConfigureAwait(false);
					}
				}
			}

			if (!success) {
				throw new InternalRequestFailedException();
			}

			return default;
		}

		/// <summary>
		/// Send a generic, unparsed, JSON serializable object as an HTTP request to the specified url with the specified method and headers.
		/// </summary>
		/// <param name="requestJsonContent">the JSON serializable object of the request.</param>
		/// <param name="method">the <see cref="HttpMethod"/> to use for the request.</param>
		/// <param name="requestUrl">The URL the send the request to.</param>
		/// <param name="data">headers which should be appended to the request, if any.</param>
		/// <param name="maxTries">The maximum number of tries before the request is considered as a fail.</param>
		/// <typeparam name="TRequestType">the type of request object.</typeparam>
		/// <typeparam name="UResponseType">the type of response object.</typeparam>
		/// <returns>the result, Deserialized as <see cref="UResponseType"/> type.</returns>
		public async Task<UResponseType> InternalRequestAsObject<TRequestType, UResponseType>(
			TRequestType requestJsonContent, HttpMethod method, string requestUrl, Dictionary<string, string> data, int maxTries = MAX_TRIES) {
			if (string.IsNullOrEmpty(requestUrl) || requestJsonContent == null) {
				return default;
			}

			bool success = false;
			for (int i = 0; i < maxTries; i++) {
				try {
					using (HttpRequestMessage request = new HttpRequestMessage(method, requestUrl)) {
						foreach (var pair in data) {
							request.Headers.Add(pair.Key, pair.Value);
						}

						request.Content = new StringContent(JsonConvert.SerializeObject(requestJsonContent));

						using (HttpResponseMessage response = await ExecuteRequest(async () => await Client.SendAsync(request).ConfigureAwait(false)).ConfigureAwait(false)) {
							if (!response.IsSuccessStatusCode) {
								continue;
							}

							using (HttpContent responseContent = response.Content) {
								string jsonContent = await responseContent.ReadAsStringAsync().ConfigureAwait(false);

								if (string.IsNullOrEmpty(jsonContent)) {
									continue;
								}

								success = true;
								return JsonConvert.DeserializeObject<UResponseType>(jsonContent);
							}
						}
					}
				}
				catch (Exception e) {
					success = false;
					continue;
				}
				finally {
					if (!success) {
						await Task.Delay(TimeSpan.FromSeconds(DELAY_BETWEEN_FAILED_REQUESTS)).ConfigureAwait(false);
					}
				}
			}

			if (!success) {
				throw new InternalRequestFailedException();
			}

			return default;
		}

		/// <summary>
		/// A wrapper for all internal requests.
		/// <para>Requests are rate limited through this function().</para>
		/// </summary>
		/// <param name="function">the request function()</param>
		/// <typeparam name="T">the type of the response of the request.</typeparam>
		/// <returns>the result</returns>
		private async Task<T> ExecuteRequest<T>(Func<Task<T>> function) {
			if (function == null) {
				return default;
			}

			await Sync.WaitAsync().ConfigureAwait(false);

			try {
				return await function().ConfigureAwait(false);
			}
			finally {
				await Task.Delay(TimeSpan.FromSeconds(DELAY_BETWEEN_REQUESTS));
				Sync.Release();
			}
		}

		/// <summary>
		/// Disposes clients used internally.
		/// </summary>
		public void Dispose() {
			ClientHandler?.Dispose();
			Client?.Dispose();
		}
	}
}

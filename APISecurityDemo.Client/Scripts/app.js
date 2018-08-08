$(function () {

	var baseUrl = 'https://localhost:44312';
	var accessToken = "";

	var showResponse = function (obj) {
		$("#output").text(JSON.stringify(obj, null, 4));
	};

	var saveAccessToken = function (data) {
		accessToken = data.access_token;
	};

	var login = function () {
		var url = baseUrl + "/token";
		var loginForm = $("#userData").serializeArray();
		var data = {};
		data.grant_type = "password";

		$.each(loginForm, function (i, v) {
			data[v.name] = v.value;
		});

		console.log(data);

		$.ajax({
			url: url,
			type: 'POST',
			dataType: 'json',
			contentType: "application/x-www-form-urlencoded; charset=utf-8",
			data: data,
		})
			.done(saveAccessToken)
			.fail(error)
			.always(showResponse);

		return false;
	};

	var getHeaders = function () {
		if (accessToken) {
			return {
				"Authorization": "Bearer " + accessToken
			}
		}
	};

	var getData = function () {
		var url = baseUrl + "/api/bike";

		var headers = getHeaders();

		$.ajax(url, {
			method: "GET",
			headers: headers
		})
			.done(success)
			.fail(error)
			.always(showResponse);

		return false;
	};

	var success = function (data) {
		console.log(data);
	};

	var error = function (xhr) {
		console.log(xhr);
	};

	// Eventhandler
	$("#login").on("click", login);
	$("#getData").on("click", getData);
});
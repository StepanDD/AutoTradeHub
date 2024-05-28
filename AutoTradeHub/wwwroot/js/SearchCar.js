function updateModelList() {
	if (getSelectedMarka() == -1) {
		removeAllOptions("selectModel");
		removeAllOptions("selectGeneration");
		return;
	}
	$.ajax({
		type: "GET",

		url: "https://localhost:44395/Car/GetModelsByMarka?markaId=" + getSelectedMarka(),
		dataType: "json",
		success: function (result) {
			let models = result["value"];
			var selector = document.getElementById("selectModel");
			selector.disabled = false;
			removeAll(selector);
			let optionList = selector.options;
			let options = models;
			options.forEach(option =>
				optionList.add(
					new Option(option.name, option.id, false)
				)
			);
			optionList.add(
				new Option("Любая", -1, true, true)
			)
			selectOptionModel();
			updateGenerationList();
		},
		error: function (req, status, error) {
			console.log(status);
		}
	})
}

function removeAllOptions(selectorId) {
	var selector = document.getElementById(selectorId);
	selector.disabled = true;
	removeAll(selector);
}

function getSelectedMarka() {
	var selectedValue = document.getElementById("selectMarka").value;
	return selectedValue;
}

function updateGenerationList() {
	if (getSelectedModel() == -1) {
		removeAllOptions("selectGeneration");
		return;
	}
	$.ajax({
		type: "GET",

		url: "https://localhost:44395/Car/GetGenerationsByModel?modelId=" + getSelectedModel(),
		dataType: "json",
		success: function (result) {
			let generations = result["value"];
			var selector = document.getElementById("selectGeneration");
			selector.disabled = false;
			removeAll(selector);
			let optionList = selector.options;
			let options = generations;
			options.forEach(option =>
				optionList.add(
					new Option(option.name, option.id, false)
				)
			);
			optionList.add(
				new Option("Любое", -1, true, true)
			)
			selectOptionGeneration();
		},
		error: function (req, status, error) {
			console.log(status);
		}
	})
}

function getSelectedModel() {
	var selectedValue = document.getElementById("selectModel").value;
	return selectedValue;
}

function removeAll(selectBox) {
	while (selectBox.options.length > 0) {
		selectBox.remove(0);
	}
}

function saveSelectedModel() {
	var selector = document.getElementById("selectModel");
	const modelId = selector.value;
	sessionStorage.setItem("selectedModelId", modelId)
}
function saveSelectedGeneration() {
	var selector = document.getElementById("selectGeneration");
	const generationId = selector.value;
	sessionStorage.setItem("selectedGenerationId", generationId)
}

window.onload = function () {
	var marka = getSelectedMarka();
	if (marka != -1) {
		updateModelList();
	}
}

function selectOptionModel() {
	const modelId = sessionStorage.getItem("selectedModelId");
	if (modelId != null) {
		var selector = document.getElementById("selectModel");
		selector.value = modelId;
	}
}
function selectOptionGeneration() {
	const generationId = sessionStorage.getItem("selectedGenerationId");
	if (generationId != null) {
		var selector = document.getElementById("selectGeneration");
		selector.value = generationId;
	}
}

function aaa() {
	alert("aaa");
}

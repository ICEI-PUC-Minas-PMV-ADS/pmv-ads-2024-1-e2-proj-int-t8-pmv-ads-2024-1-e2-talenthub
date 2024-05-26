// @ts-nocheck

$(document).ready(function () {
  $("body").tooltip({ selector: "[data-toggle=tooltip]" });

  var urlParams = new URLSearchParams(window.location.search);
  var searchTerm = urlParams.get("searchTerm");
  if (searchTerm) {
    $('input[name="searchTerm"]').val(searchTerm);
    $(".search-btn").prop("disabled", false);
  } else {
    $(".search-btn").prop("disabled", true);
  }

  $('input[name="searchTerm"]').on("input", function () {
    if ($(this).val().trim() === "") {
      $(".search-btn").prop("disabled", true);
    } else {
      $(".search-btn").prop("disabled", false);
    }
  });
});

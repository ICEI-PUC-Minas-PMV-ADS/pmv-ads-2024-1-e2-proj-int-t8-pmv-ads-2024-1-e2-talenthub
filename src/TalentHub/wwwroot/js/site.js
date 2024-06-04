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

  $("#editNoteModal").on("show.bs.modal", function (event) {
    var button = $(event.relatedTarget);
    var noteId = button.data("id");
    var noteText = button.data("text");

    var modal = $(this);
    modal.find(".modal-body #noteId").val(noteId);
    modal.find(".modal-body #noteText").val(noteText);
  });

  $("#confirmDeleteModal").on("show.bs.modal", function (event) {
    var button = $(event.relatedTarget);
    var noteId = button.data("id");

    var modal = $(this);
    modal.find("#deleteNoteId").val(noteId);
  });
  
  $("#confirmDeleteProjectModal").on("show.bs.modal", function (event) {
    var button = $(event.relatedTarget);
    var projectId = button.data("id");

    var modal = $(this);
    modal.find("#deleteProjectId").val(projectId);
  });
});

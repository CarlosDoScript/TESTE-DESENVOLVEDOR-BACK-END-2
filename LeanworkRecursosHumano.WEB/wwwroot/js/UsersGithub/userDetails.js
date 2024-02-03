$(document).ready(function () {
    loadRecords(1);

    $(document).on('click', '.pagination li a', function () {
        var currentPage = $(this).attr('data-page');
        displayRecords(currentPage);
    });

    $(document).on('input', '#records-filter', function () {
        var filter = $(this).val().toLowerCase();
        recordsFilter(filter);
    });
});

var userRepos = [];
var recordsPerPage = 10;

function loadRecords() {
    let filter = $("#records-filter").val();
    let userNameLogin = $("#userLogin").text()

    $.ajax({
        url: '/UsersGithub/GetReposByLoginName',
        type: 'GET',
        data: { userLogin:userNameLogin },
        success: function (response) {
            userRepos = response;
            displayRecords(1);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.error('Erro ao carregar repositorios:', textStatus, errorThrown);
        }
    });
}

function displayRecords(currentPage) {
    var startIndex = (currentPage - 1) * recordsPerPage;
    var endIndex = startIndex + recordsPerPage;

    $("#usersRepos-table-body").empty();
    $("#pagination-container").empty();
    userRepos.slice(startIndex, Math.min(endIndex, userRepos.length)).forEach(function (userRepo) {
        var line = "<tr>";
        line += "<td>" + userRepo.id + "</td>";
        line += "<td>" + userRepo.name + "</td>";
        line += "<td><a target='_blank' href='" + userRepo.html_url + "'" + userRepo.html_url + "' data-id=" + userRepo.id + " title='Visitar repositorio'>" + userRepo.html_url + "</a></td>";
        line += "</tr>";

        $("#usersRepos-table-body").append(line);
    });

    updatePagination(currentPage, userRepos.length);
}

function recordsFilter(filter) {
    var filteredUserRepos = userRepos.filter(function (userRepo) {
        return userRepo.name.toLowerCase().includes(filter);
    });

    displayFilteredRecords(filteredUserRepos, 1);
}

function displayFilteredRecords(filteredUserRepos, currentPage) {
    var startIndex = (currentPage - 1) * recordsPerPage;
    var endIndex = startIndex + recordsPerPage;

    $("#usersRepos-table-body").empty();

    filteredUserRepos.slice(startIndex, Math.min(endIndex, filteredUserRepos.length)).forEach(function (userRepos) {
        var line = "<tr>";
        line += "<td>" + userRepo.id + "</td>";
        line += "<td>" + userRepo.name + "</td>";
        line += "<td><a target='_blank' href='" + userRepo.html_url + "'" + userRepo.html_url + "' data-id=" + userRepo.id + " title='Visitar repositorio'>" + userRepo.html_url + "</a></td>";
        line += "</tr>";

        $("#usersRepos-table-body").append(line);
    });

    updatePagination(currentPage, filteredUserRepos.length);
}

function updatePagination(currentPage, totalRecords) {
    const totalPages = Math.ceil(totalRecords / recordsPerPage);

    $("#pagination-container").empty();

    for (var i = 1; i <= totalPages; i++) {
        var listItem = $("<li class='page-item'><a href='#/' class='page-link' href='#' data-page='" + i + "'>" + i + "</a></li>");
        $("#pagination-container").append(listItem);
    }

    $('.spinner-border').remove();

    $("#pagination-container li a[data-page='" + currentPage + "']").parent().addClass("active");
}

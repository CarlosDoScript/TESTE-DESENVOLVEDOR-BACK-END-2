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

var users = [];
var recordsPerPage = 10;

function loadRecords() {
    let filter = $("#records-filter").val();

    $.ajax({
        url: '/GithubUsuarios/GetUsers',
        type: 'GET',
        data: { filter: filter },
        success: function (response) {
            users = response;
            displayRecords(1);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.error('Erro ao carregar usuários:', textStatus, errorThrown);
        }
    });
}

function displayRecords(currentPage) {
    var startIndex = (currentPage - 1) * recordsPerPage;
    var endIndex = startIndex + recordsPerPage;

    $("#users-table-body").empty();
    $("#pagination-container").empty();

    users.slice(startIndex, Math.min(endIndex, users.length)).forEach(function (user) {
        var line = "<tr>";
        line += "<td title='" + user.id + "' >" + user.id + "</td>";
        line += "<td  title='" + user.login + "' >" + user.login + "</td>";
        console.log(user.id)
        line += "<td><a href='/GithubUsuarios/Details/" + parseInt(user.id) + "' data-id=" + user.id + " title='Detalhes do usuário'><i class='fas fa-eye'></i></a></td>";
        line += "</tr>";

        $("#users-table-body").append(line);
    });

    updatePagination(currentPage, users.length);
}

function recordsFilter(filter) {
    var filteredUsers = users.filter(function (user) {
        return user.login.toLowerCase().includes(filter);
    });

    displayFilteredRecords(filteredUsers, 1);
}

function displayFilteredRecords(filteredUsers, currentPage) {
    var startIndex = (currentPage - 1) * recordsPerPage;
    var endIndex = startIndex + recordsPerPage;

    $("#users-table-body").empty();

    filteredUsers.slice(startIndex, Math.min(endIndex, filteredUsers.length)).forEach(function (user) {
        var line = "<tr>";
        line += "<td>" + user.id + "</td>";
        line += "<td>" + user.login + "</td>";
        line += "<td><a href='/GithubUsuarios/Details/" + parseInt(user.id) + "' data-id=" + user.id + " title='Detalhes do usuário'><i class='fas fa-eye'></i></a></td>";
        line += "</tr>";

        $("#users-table-body").append(line);
    });

    updatePagination(currentPage, filteredUsers.length);
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

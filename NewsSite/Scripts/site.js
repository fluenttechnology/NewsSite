/* Toggle between adding and removing the "responsive" class to topnav when the user clicks on the icon */
function responsiveNavbar() {
    var x = document.getElementById("myTopnav");
    if (x.className === "topnav") {
        x.className += " responsive";
    } else {
        x.className = "topnav";
    }
}

function clickPagination(clicked_id) {
    var newPage = document.getElementById("paginationBar");
    var x = document.getElementsByClassName("activePagination");
    if (x.length > 0) {
        x[0].classList.remove("activePagination");
    }
    var y = document.getElementById(clicked_id);
    newPage.value = y.textContent;
    y.className += "activePagination";

    var xhr = new XMLHttpRequest();

    xhr.open('GET', "http://localhost:58322/", true);
    xhr.send();
}

function clickMinusPagination() {
    var newPage = document.getElementById("paginationBar");
    var x = document.getElementsByClassName("activePagination");
    var oldPageNumber = x[0].textContent;

    if (oldPageNumber > 1) {
        x[0].classList.remove("activePagination");
        var newPageNumber = parseInt(oldPageNumber) - 1;
        var id = "pagination" + newPageNumber;
        var y = document.getElementById(id);
        y.className += "activePagination";
        newPage.value = y.textContent;
    }
}

function clickPlusPagination() {
    var newPage = document.getElementById("paginationBar");
    var x = document.getElementsByClassName("activePagination");
    var oldPageNumber = x[0].textContent;

    if (oldPageNumber < 6) {
        x[0].classList.remove("activePagination");
        var newPageNumber = parseInt(oldPageNumber) + 1;
        var id = "pagination" + newPageNumber;
        var y = document.getElementById(id);
        y.className += "activePagination";
        newPage.value = y.textContent;
    }
}
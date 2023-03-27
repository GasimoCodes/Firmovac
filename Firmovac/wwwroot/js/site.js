// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//All checkboxes are checked when the first checkbox is checked
function toggle(source) {
    checkboxes = document.getElementsByName('foo');
    for (var i = 0, n = checkboxes.length; i < n; i++) {
        checkboxes[i].checked = source.checked;
    }
}

// Získání checkboxů v tabulce
var checkboxes = document.querySelectorAll('#searchTB input[type=checkbox]');
// Získání elementu pro zobrazení názvů firem v modálním okně
var selectedRows = document.querySelector('#selectedRows');
// Pole pro uložení ID firem
var ids = [];
// Funkce pro zobrazení názvů firem v modálním okně
function showSelectedRows() {
    var names = [];
    // Projdeme všechny checkboxy a pokud jsou zaškrtnuté, uložíme název firmy
    checkboxes.forEach(function (checkbox) {
        if (checkbox.checked) {
            var name = checkbox.closest('tr').querySelector('.firm-name').textContent;
            var id = parseInt(checkbox.closest('tr').querySelector('.firm-name').id);
            names.push(name);
            ids.push(id);
        }
    });
    // Zobrazíme názvy firem v modálním okně
    const selectedRows = document.querySelector('#selectedRows');
    // Odstraníme všechny děti elementu selectedRows
    while (selectedRows.firstChild) {
        selectedRows.removeChild(selectedRows.firstChild);
    }
    // Pokud jsou nějaké vybrané řádky, zobrazíme je jako tagy
    if (names.length > 0) {
        for (let i = 0; i < names.length; i++) {
            const tag = document.createElement('span');
            tag.classList.add('badge', 'rounded-pill', 'bg-dark', 'p-3', 'm-1');
            tag.textContent = names[i];
            selectedRows.appendChild(tag);
        }
    }
}

//AJAX pro POST smazání firem
function postDeleteFirm() {
    const xhttp = new XMLHttpRequest();
    const idsData = JSON.stringify(ids);
    console.log(idsData);
    xhttp.open("POST", "/", true);
    xhttp.setRequestHeader("Content-type", "application/json");
    if (ids.length > 0) {
        xhttp.send(idsData);
    }
    ids.length = 0;
}

//AJAX POST ID firms
function postIdFirm() {
    checkboxes.forEach(function (checkbox) {
        if (checkbox.checked) {
            var id = parseInt(checkbox.closest('tr').querySelector('.firm-name').id);
            ids.push(id);
        }
    });
    const xhttp = new XMLHttpRequest();
    const idsData = JSON.stringify(ids);
    console.log(idsData);
    xhttp.open("POST", "/", true);
    xhttp.setRequestHeader("Content-type", "application/json");
    if (ids.length > 0) {
        xhttp.send(idsData);
    }
    ids.length = 0;
}
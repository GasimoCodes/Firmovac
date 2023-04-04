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

//AJAX POST ID firms
function postIdFirm(arg) {
    var firmyIds = [];

    checkboxes.forEach(function (checkbox) {
        if (checkbox.checked) {
            var firmId = parseInt(checkbox.closest('tr').querySelector('.firm-name').id);
            firmyIds.push(firmId);
        }
    });
    var data = {
        listPrintFirm: firmyIds,
        command: arg
    }
    console.log(data.listPrintFirm);

    fetch('/', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)

    }).then((response) => {
        if (arg == 1) {
            location.reload();
            return;
        }
            
            
        return response.blob();

    }).then(blob => {
        const url = URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = url;
        a.download = 'data.csv';
        document.body.appendChild(a);
        a.click();
        a.remove();
        URL.revokeObjectURL(url);
    })
        .catch(error => {
            console.error('There was a problem with the fetch operation:', error);
        });

    console.log(data);
    firmyIds.length = 0;

}

function addContact() {
    // najděte poslední kontakt v rámci accordionu a zjistěte jeho id
    const lastContact = document.querySelector('#accordionCard .accordion:last-child');
    const lastContactId = parseInt(lastContact.getAttribute('id').match(/\d+/g));

    // vytvořte nový kontakt
    const newContactId = lastContactId + 1;
    const newContact = `
    <div class="accordion mt-1 w-100" id="accord_contact_${newContactId}">
      <div class="accordion-item rounded-4 shadow-sm p-1">
        <button class="own-p-tag px-3 accordion-button rounded-3 btn bg-transparent shadow-none" type="button" data-bs-toggle="collapse" data-bs-target="#accord_contactItem_${newContactId}" aria-expanded="false" aria-controls="collapseOne">
          <div class="flex-row align-items-center d-inline-flex">
            <a id="deleteContact_${newContactId}" class="btn">
              <i class="bi bi-x-lg"></i>
            </a>
            Kontakt
          </div>
        </button>
        <div id="accord_contactItem_${newContactId}" class="accordion-collapse rounded-4 collapse p-3" aria-labelledby="headingOne" data-bs-parent="#accord_contact_${newContactId}">
          <input name="Kontakty[${newContactId}].Id" type="hidden" value="0">
          <label for="kontaktMail">Name</label>
          <input name="Kontakty[${newContactId}].Name" type="text" class="form-control" id="kontakt_x_mail" placeholder="Název">
          <label for="kontaktMail">Email</label>
          <input name="Kontakty[${newContactId}].Email" type="email" class="form-control" id="kontakt_x_mail" placeholder="Email">
          <label for="kontaktMail">Tel</label>
          <input name="Kontakty[${newContactId}].Phone" type="tel" class="form-control" id="kontakt_x_mail" placeholder="Tel">
        </div>
      </div>
    </div>
  `;

    // přidejte nový kontakt do accordionu
    const accordionCard = document.querySelector('#accordionCard');
    accordionCard.innerHTML += newContact;
}

const addContactBtn = document.getElementById("addContactBtn");
addContactBtn.addEventListener("click", addContact);
const hamBurger = document.querySelector(".toggle-btn");

hamBurger.addEventListener("click", function () {
  document.querySelector("#sidebar").classList.toggle("expand");
});

let dealerToDeleteId = null; 

async function loadDealers() {
    try {
        const response = await fetch("https://localhost:7033/api/Dealersh");

        if (response.ok) {
            const dealers = await response.json();
            let tableBody = document.querySelector("#dealersTable tbody");

            tableBody.innerHTML = "";

            dealers.forEach((dealer) => {
                let row = `
                    <tr>
                        <th scope="row">${dealer.idDealersh}</th>
                        <td>${dealer.name}</td>
                        <td>${dealer.address}</td>
                        <td>${dealer.email}</td>
                        <td>${dealer.phone}</td>
                        <td>
                            <button class="btn btn-warning btn-sm edit-btn" 
                            data-id="${dealer.idDealersh}" 
                            data-name="${dealer.name}"
                            data-location="${dealer.address}"
                            data-city="${dealer.city}"
                            data-region="${dealer.region}"
                            data-cep="${dealer.postalCode}"
                            data-email="${dealer.email}"
                            data-phone=${dealer.phone}"
                            >
                                <i class="lni lni-pencil-alt"></i>
                            </button>
                            <button class="btn btn-danger btn-sm delete-btn" data-id="${dealer.idDealersh}">
                                <i class="lni lni-trash-can"></i>
                            </button>
                        </td>
                    </tr>
                `;
                tableBody.innerHTML += row; 
            });

            document.querySelectorAll('.delete-btn').forEach(button => {
                button.addEventListener('click', function() {
                    const dealerId = this.getAttribute('data-id');
                    const dealerName = this.getAttribute('data-name');
            
                    dealerToDeleteId = dealerId;
            
                    document.getElementById('deleteDealerName').textContent = dealerName;
            
                    let deleteModal = new bootstrap.Modal(document.getElementById('deleteModal'));
                    deleteModal.show();
                });
            });

            document.querySelectorAll('.edit-btn').forEach(button => {
                button.addEventListener('click', function() {
                    const dealerId = this.getAttribute('data-id');
           
                    document.getElementById('editName').value = this.getAttribute('data-name');
                    document.getElementById('editLocation').value = this.getAttribute('data-location');
                    document.getElementById('editCity').value = this.getAttribute('data-city');
                    document.getElementById('editRegion').value = this.getAttribute('data-region');
                    document.getElementById('editPostalCode').value = this.getAttribute('data-cep');
                    document.getElementById('editEmail').value = this.getAttribute('data-email');
                    document.getElementById('editPhone').value = this.getAttribute('data-phone');



                    document.getElementById('editForm').setAttribute('data-id', dealerId);

                    let editModal = new bootstrap.Modal(document.getElementById('editModal'));
                    editModal.show();
                });
            });

            await loadUserInfo();

        } else {
            alert("Erro ao buscar os dados da API.");
        }
    } catch (error) {
        console.error("Erro ao fazer a requisição:", error);
    }
}
document.getElementById('editForm').addEventListener('submit', async function(event) {
    event.preventDefault(); 
    debugger
    const dealerId = this.getAttribute('data-id');

    const updatedDealer = {
        name: document.getElementById('editName').value,
        location: document.getElementById('editLocation').value,
        city: document.getElementById('editCity').value,

    };

    try {
        const response = await fetch(`https://localhost:7033/api/Dealersh/${dealerId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(updatedDealer) 
        });

        if (response.ok) {
            alert('Concessionária atualizada com sucesso!');

            loadDealers();
            
            let editModal = bootstrap.Modal.getInstance(document.getElementById('editModal'));
            editModal.hide();
        } else {
            alert('Erro ao atualizar a concessionária.');
        }
    } catch (error) {
        console.error('Erro na requisição:', error);
        alert('Ocorreu um erro ao tentar salvar as mudanças.');
    }
});
document.getElementById('addForm').addEventListener('submit', async function(event) {
    event.preventDefault();
    const newDealer = {
        name: document.getElementById('addName').value,
        address: document.getElementById('addLocation').value,
        city: document.getElementById('addCity').value,
        region: document.getElementById('addRegion').value,
        postalCode: document.getElementById('addPostalCode').value,
        email: document.getElementById('addEmail').value,
        phone: document.getElementById('addPhone').value,
        maximumCapacityVehicles: document.getElementById('addMaxCapacityVehicles').value
    };

    try {
        const response = await fetch("https://localhost:7033/api/Dealersh", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newDealer)
        });

        if (response.ok) {
            alert('Concessionária adicionada com sucesso!');
            loadDealers();

            let addModal = bootstrap.Modal.getInstance(document.getElementById('addModal'));
            addModal.hide();
            document.getElementById('addForm').reset();
        } else {
            alert('Erro ao adicionar a concessionária.');
        }
    } catch (error) {
        console.error('Erro na requisição:', error);
        alert('Ocorreu um erro ao tentar adicionar a concessionária.');
    }
});
document.getElementById('confirmDeleteBtn').addEventListener('click', async function() {
    if (dealerToDeleteId) {
        try {
            const response = await fetch(`https://localhost:7033/api/Dealersh/${dealerToDeleteId}`, {
                method: 'DELETE'
            });

            if (response.ok) {
                alert('Concessionária excluída com sucesso!');

                let deleteModal = bootstrap.Modal.getInstance(document.getElementById('deleteModal'));
                deleteModal.hide();

                loadDealers();
            } else {
                alert('Erro ao excluir a concessionária.');
            }
        } catch (error) {
            console.error('Erro na requisição:', error);
            alert('Ocorreu um erro ao tentar excluir a concessionária.');
        }
    }
});

function loadUserInfo() {
    const userInfo = localStorage.getItem('userInfo');
    if (userInfo) {
        const userData = JSON.parse(userInfo);
        const userInfoDiv = document.getElementById('user-info'); 
        userInfoDiv.innerHTML = `<p style="margin: 0; font-size: 15px">${userData.name}</p> <p style="margin-bottom:3px; font-size: 10px">${userData.userRole}</p>`;
    } else {
        console.error('Nenhuma informação de usuário encontrada.');
    }
  }

document.addEventListener("DOMContentLoaded", loadDealers);

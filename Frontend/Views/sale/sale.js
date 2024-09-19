const hamBurger = document.querySelector(".toggle-btn");

hamBurger.addEventListener("click", function () {
  document.querySelector("#sidebar").classList.toggle("expand");
});

let saleToDeleteId = null; 

async function loadSale() {
    try {
      debugger
        const response = await fetch("https://localhost:7033/api/Sale");

        if (response.ok) {
            const sales = await response.json();
            let tableBody = document.querySelector("#SaleTable tbody");

            tableBody.innerHTML = "";

            sales.forEach((sale) => {
                let row = `
                    <tr>
                        <th scope="row">${sale.idSale}</th>
                        <td>${sale.dataSale}</td>
                        <td>${sale.salePrice}</td>
                        <td>${sale.saleProtocol}</td>
                        <td>
                            <button class="btn btn-warning btn-sm edit-btn" 
                            data-id="${sale.idSale}" 
                            data-dataSale="${sale.dataSale}"
                            data-salePrice="${sale.salePrice}"
                            data-saleProtocol=${sale.saleProtocol}"
                            >
                                <i class="lni lni-pencil-alt"></i>
                            </button>
                            <button class="btn btn-danger btn-sm delete-btn" data-id="${sale.idSale}">
                                <i class="lni lni-trash-can"></i>
                            </button>
                        </td>
                    </tr>
                `;
                tableBody.innerHTML += row; 
            });

            document.querySelectorAll('.delete-btn').forEach(button => {
                button.addEventListener('click', function() {
                    const saleId = this.getAttribute('data-id');
                    const saleName = this.getAttribute('data-name');
            
                    saleToDeleteId = saleId;
            
                    document.getElementById('deleteSaleName').textContent = saleName;
            
                    let deleteModal = new bootstrap.Modal(document.getElementById('deleteModal'));
                    deleteModal.show();
                });
            });

            document.querySelectorAll('.edit-btn').forEach(button => {
                button.addEventListener('click', function() {
                    const saleId = this.getAttribute('data-id');
           
                    document.getElementById('editSalePrice').value = this.getAttribute('data-salePrice');
                    document.getElementById('editSaleDate').value = this.getAttribute('data-salePrice');
                   
                    document.getElementById('editForm').setAttribute('data-id', saleId);

                    let editModal = new bootstrap.Modal(document.getElementById('editModal'));
                    editModal.show();
                });
            });

            await loadDealersh();
            await loadVehicles();
            await loadClients();  
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
    const saleId = this.getAttribute('data-id');

    const updatedSale = {
        name: document.getElementById('editName').value,
        country: document.getElementById('editCountry').value,
        yearFoundation: parseInt(document.getElementById('editYearFoundation').value),
        webSite: document.getElementById('editWebsite').value,
    };

    try {
        const response = await fetch(`https://localhost:7033/api/Fabricator/${saleId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(updatedSale) 
        });

        if (response.ok) {
            alert('Venda atualizada com sucesso!');

            loadSale();
            
            let editModal = bootstrap.Modal.getInstance(document.getElementById('editModal'));
            editModal.hide();
        } else {
            alert('Erro ao atualizar o Venda.');
        }
    } catch (error) {
        console.error('Erro na requisição:', error);
        alert('Ocorreu um erro ao tentar salvar as mudanças.');
    }
});
document.getElementById('addForm').addEventListener('submit', async function(event) {
    event.preventDefault();
    const newSale = {
        idDealersh: parseInt(document.getElementById('dealershSelect').value),
        idVehicle: parseInt(document.getElementById('vehicleSelect').value),
        idClient: parseInt(document.getElementById('clientSelect').value),
        dataSale: document.getElementById('addSaleDate').value,
        salePrice: parseFloat(document.getElementById('addSalePrice').value)
    };
    try {
        const response = await fetch("https://localhost:7033/api/Sale", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newSale)
        });
        if (response.ok) {
            alert('Venda adicionado com sucesso!');
            loadSale();

            let addModal = bootstrap.Modal.getInstance(document.getElementById('addModal'));
            addModal.hide();
            document.getElementById('addForm').reset();
        } else {
            alert('Erro ao adicionar a venda.');
        }
    } catch (error) {
        console.error('Erro na requisição:', error);
        alert('Ocorreu um erro ao tentar adicionar a venda.');
    }
});
document.getElementById('confirmDeleteBtn').addEventListener('click', async function() {
    if (saleToDeleteId) {
        try {
            const response = await fetch(`https://localhost:7033/api/Sale/${saleToDeleteId}`, {
                method: 'DELETE'
            });

            if (response.ok) {
                alert('Venda excluída com sucesso!');

                let deleteModal = bootstrap.Modal.getInstance(document.getElementById('deleteModal'));
                deleteModal.hide();

                loadSale();
            } else {
                alert('Erro ao excluir a venda.');
            }
        } catch (error) {
            console.error('Erro na requisição:', error);
            alert('Ocorreu um erro ao tentar excluir o fabricante.');
        }
    }
});

// Carregar dados de Dealersh
const loadDealersh = async () => {
    try {
        const response = await fetch("https://localhost:7033/api/Dealersh");
        if (response.ok) {
            const dealershList = await response.json();
            let dealershSelect = document.getElementById('dealershSelect');
            dealershList.forEach(dealer => {
                let option = document.createElement('option');
                option.value = dealer.idDealersh;
                option.textContent = dealer.name;
                dealershSelect.appendChild(option);
            });
        }
    } catch (error) {
        console.error("Erro ao carregar Concessionárias:", error);
    }
};
 // Carregar dados de Vehicle
 const loadVehicles = async () => {
    try {
        const response = await fetch("https://localhost:7033/api/Vehicle");
        if (response.ok) {
            const vehicleList = await response.json();
            let vehicleSelect = document.getElementById('vehicleSelect');
            vehicleList.forEach(vehicle => {
                let option = document.createElement('option');
                option.value = vehicle.idVehicle;
                option.textContent = vehicle.vehicleModel; 
                vehicleSelect.appendChild(option);
            });
        }
    } catch (error) {
        console.error("Erro ao carregar Veículos:", error);
    }
};
// Carregar dados de Client
const loadClients = async () => {
    try {
        const response = await fetch("https://localhost:7033/api/Client");
        if (response.ok) {
            const clientList = await response.json();
            let clientSelect = document.getElementById('clientSelect');
            clientList.forEach(client => {
                let option = document.createElement('option');
                option.value = client.idClient;
                option.textContent = client.name;
                clientSelect.appendChild(option);
            });
        }
    } catch (error) {
        console.error("Erro ao carregar Clientes:", error);
    }
};

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
  

document.addEventListener("DOMContentLoaded", loadSale);
const hamBurger = document.querySelector(".toggle-btn");

hamBurger.addEventListener("click", function () {
  document.querySelector("#sidebar").classList.toggle("expand");
});

let fabricatorToDeleteId = null; 

async function loadFabricator() {
    try {
      debugger
        const response = await fetch("https://localhost:7033/api/Fabricator");

        if (response.ok) {
            const fabricators = await response.json();
            let tableBody = document.querySelector("#fabricatorTable tbody");

            tableBody.innerHTML = "";

            fabricators.forEach((fabricator) => {
                let row = `
                    <tr>
                        <th scope="row">${fabricator.idFabricator}</th>
                        <td>${fabricator.name}</td>
                        <td>${fabricator.country}</td>
                        <td>${fabricator.yearFoundation}</td>
                        <td>${fabricator.webSite}</td>
                        <td>
                            <button class="btn btn-warning btn-sm edit-btn" 
                            data-id="${fabricator.idFabricator}" 
                            data-name="${fabricator.name}"
                            data-country="${fabricator.country}"
                            data-yearFoundation=${fabricator.yearFoundation}"
                            data-website="${fabricator.webSite}"
                            >
                                <i class="lni lni-pencil-alt"></i>
                            </button>
                            <button class="btn btn-danger btn-sm delete-btn" data-id="${fabricator.idFabricator}">
                                <i class="lni lni-trash-can"></i>
                            </button>
                        </td>
                    </tr>
                `;
                tableBody.innerHTML += row; 
            });

            document.querySelectorAll('.delete-btn').forEach(button => {
                button.addEventListener('click', function() {
                    const fabricatorId = this.getAttribute('data-id');
                    const fabricatorName = this.getAttribute('data-name');
            
                    fabricatorToDeleteId = fabricatorId;
            
                    document.getElementById('deleteFabricatorName').textContent = fabricatorName;
            
                    let deleteModal = new bootstrap.Modal(document.getElementById('deleteModal'));
                    deleteModal.show();
                });
            });

            document.querySelectorAll('.edit-btn').forEach(button => {
                button.addEventListener('click', function() {
                    const fabricatorId = this.getAttribute('data-id');
           
                    document.getElementById('editName').value = this.getAttribute('data-name');
                    document.getElementById('editCountry').value = this.getAttribute('data-country');
                    document.getElementById('editYearFoundation').value = this.getAttribute('data-yearFoundation');
                    document.getElementById('editWebsite').value = this.getAttribute('data-website');

                    document.getElementById('editForm').setAttribute('data-id', fabricatorId);

                    let editModal = new bootstrap.Modal(document.getElementById('editModal'));
                    editModal.show();
                });
            });

            await loadUserInfo();
            loadExpandMenu();

        } else {
            alert("Erro ao buscar os dados da API.");
        }
    } catch (error) {
        console.error("Erro ao fazer a requisição:", error);
    }
}

document.getElementById('editForm').addEventListener('submit', async function(event) {
    event.preventDefault(); 
    const fabricatorId = this.getAttribute('data-id');

    const updatedFabricator = {
        name: document.getElementById('editName').value,
        country: document.getElementById('editCountry').value,
        yearFoundation: parseInt(document.getElementById('editYearFoundation').value),
        webSite: document.getElementById('editWebsite').value,
    };

    try {
        const response = await fetch(`https://localhost:7033/api/Fabricator/${fabricatorId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(updatedFabricator) 
        });

        if (response.ok) {
            alert('Fabricante atualizada com sucesso!');

            loadFabricator();
            
            let editModal = bootstrap.Modal.getInstance(document.getElementById('editModal'));
            editModal.hide();
        } else {
            alert('Erro ao atualizar o fabricante.');
        }
    } catch (error) {
        console.error('Erro na requisição:', error);
        alert('Ocorreu um erro ao tentar salvar as mudanças.');
    }
});
document.getElementById('addForm').addEventListener('submit', async function(event) {
    event.preventDefault();
    debugger
    const newFabricator = {
        name: document.getElementById('addName').value,
        country: document.getElementById('addCountry').value,
        yearFoundation: parseInt(document.getElementById('addYearFoundation').value),
        webSite: document.getElementById('addWebsite').value,
    };

    try {
        const response = await fetch("https://localhost:7033/api/Fabricator", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newFabricator)
        });

        if (response.ok) {
            alert('Fabricante adicionado com sucesso!');
            loadFabricator();

            let addModal = bootstrap.Modal.getInstance(document.getElementById('addModal'));
            addModal.hide();
            document.getElementById('addForm').reset();
        } else {
            alert('Erro ao adicionar o fabricante.');
        }
    } catch (error) {
        console.error('Erro na requisição:', error);
        alert('Ocorreu um erro ao tentar adicionar o fabricante.');
    }
});
document.getElementById('confirmDeleteBtn').addEventListener('click', async function() {
    if (fabricatorToDeleteId) {
        try {
            const response = await fetch(`https://localhost:7033/api/Fabricator/${fabricatorToDeleteId}`, {
                method: 'DELETE'
            });

            if (response.ok) {
                alert('Cliente excluído com sucesso!');

                let deleteModal = bootstrap.Modal.getInstance(document.getElementById('deleteModal'));
                deleteModal.hide();

                loadFabricator();
            } else {
                alert('Erro ao excluir o fabricante.');
            }
        } catch (error) {
            console.error('Erro na requisição:', error);
            alert('Ocorreu um erro ao tentar excluir o fabricante.');
        }
    }
});

function loadUserInfo() {
    const userInfo = localStorage.getItem('userInfo');
    if (userInfo) {
        const userData = JSON.parse(userInfo);
        const userInfoDiv = document.getElementById('user-info'); 
        userInfoDiv.innerHTML = `<p style="margin: 0; font-size: 15px">${userData.name}</p> <p style="margin-bottom:3px; font-size: 10px">${userData.userRole}</p>`;


        if (userData.userRole.toLowerCase() !== 'administrador') {
            let userNavItem = document.querySelector('.sidebar-item a[href="../user/index.html"]');
            let fabricatorNavItem = document.querySelector('.sidebar-item a[href="../Fabricator/index.html"]');
            if (userNavItem) {
                userNavItem.parentElement.style.display = 'none'; 
            }
            if(fabricatorNavItem){
                fabricatorNavItem.parentElement.style.display = 'none'; 
            }
         }
     
    } else {
        console.error('Nenhuma informação de usuário encontrada.');
    }
}

function loadExpandMenu(){
    var sidebar = document.getElementById('sidebar');
    if (sidebar) {
        sidebar.classList.add('expand');  
    }
}

document.addEventListener("DOMContentLoaded", loadFabricator);
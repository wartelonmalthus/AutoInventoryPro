const hamBurger = document.querySelector(".toggle-btn");

hamBurger.addEventListener("click", function () {
  document.querySelector("#sidebar").classList.toggle("expand");
});

let userToDeleteId = null; 

async function loadUser() {
    try {
        const response = await fetch("https://localhost:7033/api/User");
        if (response.ok) {
            const users = await response.json();
            let tableBody = document.querySelector("#userTable tbody");

            tableBody.innerHTML = "";

            users.forEach((user) => {
                let row = `
                    <tr>
                        <th scope="row">${user.idUser}</th>
                        <td>${user.name}</td>
                        <td>${user.email}</td>
                        <td>${user.userRole}</td>
                        <td>
                            <button class="btn btn-warning btn-sm edit-btn" 
                            data-id="${user.idUser}" 
                            data-name="${user.name}"
                            data-email="${user.email}"
                            data-userRole="${user.userRole}"
                            >
                                <i class="lni lni-pencil-alt"></i>
                            </button>
                            <button class="btn btn-danger btn-sm delete-btn" data-id="${user.idUser}">
                                <i class="lni lni-trash-can"></i>
                            </button>
                        </td>
                    </tr>
                `;
                tableBody.innerHTML += row; 
            });

            document.querySelectorAll('.delete-btn').forEach(button => {
                button.addEventListener('click', function() {
                    const userId = this.getAttribute('data-id');
                    const userName = this.getAttribute('data-name');
            
                    userToDeleteId = userId;
            
                    document.getElementById('deleteUserName').textContent = userName;
            
                    let deleteModal = new bootstrap.Modal(document.getElementById('deleteModal'));
                    deleteModal.show();
                });
            });

            document.querySelectorAll('.edit-btn').forEach(button => {
                button.addEventListener('click', function() {
                    const userId = this.getAttribute('data-id');
                    const userRole = this.getAttribute('data-userRole');
                    let accessLevelEnum;
                    
                    switch (userRole) {
                        case "Administrador":
                            accessLevelEnum = 0;
                            break;
                        case "Vendedor":
                            accessLevelEnum = 1;
                            break;
                        case "Gerente":
                            accessLevelEnum = 2;
                            break;
                        default:
                            accessLevelEnum = null;
                    }
           
                    document.getElementById('editName').value = this.getAttribute('data-name');
                    document.getElementById('editEmail').value = this.getAttribute('data-email');
                    document.getElementById('editAccessLevel').value = accessLevelEnum;

                    document.getElementById('editForm').setAttribute('data-id', userId);

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
    const userId = this.getAttribute('data-id');

    const updatedUser = {
        name: document.getElementById('editName').value,
        email: document.getElementById('editEmail').value,
        userRole: parseInt(document.getElementById('editAccessLevel').value),
    };
    try {
        const response = await fetch(`https://localhost:7033/api/User/${userId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(updatedUser) 
        });

        if (response.ok) {
            alert('Usuário atualizado com sucesso!');

            loadUser();
            
            let editModal = bootstrap.Modal.getInstance(document.getElementById('editModal'));
            editModal.hide();
        } else {
            alert('Erro ao atualizar o usuário.');
        }
    } catch (error) {
        console.error('Erro na requisição:', error);
        alert('Ocorreu um erro ao tentar salvar as mudanças.');
    }
});
document.getElementById('addForm').addEventListener('submit', async function(event) {
    event.preventDefault();
    const newUser = {
        name: document.getElementById('addName').value,
        password: document.getElementById('addPassword').value,
        email: document.getElementById('addCountry').value,
        userRole: parseInt(document.getElementById('addAccessLevel').value)
    };

    try {
        const response = await fetch("https://localhost:7033/api/User", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newUser)
        });

        if (response.ok) {
            alert('Usuário adicionado com sucesso!');
            loadUser();

            let addModal = bootstrap.Modal.getInstance(document.getElementById('addModal'));
            addModal.hide();
            document.getElementById('addForm').reset();
        } else {
            alert('Erro ao adicionar o usuário.');
        }
    } catch (error) {
        console.error('Erro na requisição:', error);
        alert('Ocorreu um erro ao tentar adicionar o usuário.');
    }
});
document.getElementById('confirmDeleteBtn').addEventListener('click', async function() {
    if (userToDeleteId) {
        try {
            const response = await fetch(`https://localhost:7033/api/User/${userToDeleteId}`, {
                method: 'DELETE'
            });

            if (response.ok) {
                alert('Cliente excluído com sucesso!');

                let deleteModal = bootstrap.Modal.getInstance(document.getElementById('deleteModal'));
                deleteModal.hide();

                loadUser();
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
    } else {
        console.error('Nenhuma informação de usuário encontrada.');
    }
  }

document.addEventListener("DOMContentLoaded", loadUser);
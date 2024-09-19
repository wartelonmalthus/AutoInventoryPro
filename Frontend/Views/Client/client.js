const hamBurger = document.querySelector(".toggle-btn");

hamBurger.addEventListener("click", function () {
  document.querySelector("#sidebar").classList.toggle("expand");
});

let clientToDeleteId = null; 

async function loadClient() {
    try {
        const response = await fetch("https://localhost:7033/api/Client");

        if (response.ok) {
            const clients = await response.json();
            let tableBody = document.querySelector("#clientTable tbody");

            tableBody.innerHTML = "";

            clients.forEach((client) => {
                let row = `
                    <tr>
                        <th scope="row">${client.idClient}</th>
                        <td>${client.name}</td>
                        <td>${client.cpf}</td>
                        <td>${client.phone}</td>
                        <td>
                            <button class="btn btn-warning btn-sm edit-btn" 
                            data-id="${client.idClient}" 
                            data-name="${client.name}"
                            data-cpf="${client.cpf}"
                            data-phone=${client.phone}"
                            >
                                <i class="lni lni-pencil-alt"></i>
                            </button>
                            <button class="btn btn-danger btn-sm delete-btn" data-id="${client.idClient}">
                                <i class="lni lni-trash-can"></i>
                            </button>
                        </td>
                    </tr>
                `;
                tableBody.innerHTML += row; 
            });

            document.querySelectorAll('.delete-btn').forEach(button => {
                button.addEventListener('click', function() {
                    const clientId = this.getAttribute('data-id');
                    const clientName = this.getAttribute('data-name');
            
                    clientToDeleteId = clientId;
            
                    document.getElementById('deleteClientName').textContent = clientName;
            
                    let deleteModal = new bootstrap.Modal(document.getElementById('deleteModal'));
                    deleteModal.show();
                });
            });

            document.querySelectorAll('.edit-btn').forEach(button => {
                button.addEventListener('click', function() {
                    const clientId = this.getAttribute('data-id');
           
                    document.getElementById('editName').value = this.getAttribute('data-name');
                    document.getElementById('editCpf').value = this.getAttribute('data-cpf');
                    document.getElementById('editTelefone').value = this.getAttribute('data-phone');

                    document.getElementById('editForm').setAttribute('data-id', clientId);

                    let editModal = new bootstrap.Modal(document.getElementById('editModal'));
                    editModal.show();
                });
            });

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
    const clientId = this.getAttribute('data-id');

    const updatedClient = {
        name: document.getElementById('editName').value,
        cpf: document.getElementById('editCpf').value,
        phone: document.getElementById('editTelefone').value,
    };

    try {
        const response = await fetch(`https://localhost:7033/api/Client/${clientId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(updatedClient) 
        });

        if (response.ok) {
            alert('Cliente atualizada com sucesso!');

            loadClient();
            
            let editModal = bootstrap.Modal.getInstance(document.getElementById('editModal'));
            editModal.hide();
        } else {
            alert('Erro ao atualizar o cliente.');
        }
    } catch (error) {
        console.error('Erro na requisição:', error);
        alert('Ocorreu um erro ao tentar salvar as mudanças.');
    }
});
document.getElementById('addForm').addEventListener('submit', async function(event) {
    event.preventDefault();
    debugger
    const newCliente = {
        name: document.getElementById('addName').value,
        cpf: document.getElementById('addCpf').value,
        phone: document.getElementById('addPhone').value,

    };

    try {
        const response = await fetch("https://localhost:7033/api/Client", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newCliente)
        });

        if (response.ok) {
            alert('Concessionária adicionada com sucesso!');
            loadClient();

            let addModal = bootstrap.Modal.getInstance(document.getElementById('addModal'));
            addModal.hide();
            document.getElementById('addForm').reset();
        } else {
            alert('Erro ao adicionar o cliente.');
        }
    } catch (error) {
        console.error('Erro na requisição:', error);
        alert('Ocorreu um erro ao tentar adicionar o cliente.');
    }
});

document.getElementById('confirmDeleteBtn').addEventListener('click', async function() {
    if (clientToDeleteId) {
        try {
            const response = await fetch(`https://localhost:7033/api/Client/${clientToDeleteId}`, {
                method: 'DELETE'
            });

            if (response.ok) {
                alert('Cliente excluído com sucesso!');

                let deleteModal = bootstrap.Modal.getInstance(document.getElementById('deleteModal'));
                deleteModal.hide();

                loadClient();
            } else {
                alert('Erro ao excluir o cliente.');
            }
        } catch (error) {
            console.error('Erro na requisição:', error);
            alert('Ocorreu um erro ao tentar excluir o cliente.');
        }
    }
});


document.addEventListener("DOMContentLoaded", loadClient);
const hamBurger = document.querySelector(".toggle-btn");

hamBurger.addEventListener("click", function () {
  document.querySelector("#sidebar").classList.toggle("expand");
});

let vechicleToDeleteId = null; 

async function loadVehicle() {
    try {
        const response = await fetch("https://localhost:7033/api/Vehicle");
        if (response.ok) {
            const vehicles = await response.json();
            let tableBody = document.querySelector("#vehicleTable tbody");

            tableBody.innerHTML = "";

            vehicles.forEach((vehicle) => {
                let row = `
                    <tr>
                        <th scope="row">${vehicle.idVehicle}</th>
                        <td>${vehicle.vehicleModel}</td>
                        <td>${vehicle.yearManufacture}</td>
                        <td>${vehicle.price}</td>
                        <td>${vehicle.vehicleType}</td>
                        <td>${vehicle.description}</td>
                        <td>
                            <button class="btn btn-warning btn-sm edit-btn" 
                            data-id="${vehicle.idVehicle}" 
                            data-model="${vehicle.vehicleModel}"
                            data-yearManufacture="${vehicle.yearManufacture}"
                            data-price="${vehicle.price}"
                            data-type="${vehicle.vehicleType}"
                            data-description="${vehicle.description}"
                            >
                                <i class="lni lni-pencil-alt"></i>
                            </button>
                            <button class="btn btn-danger btn-sm delete-btn" data-id="${vehicle.idVehicle}">
                                <i class="lni lni-trash-can"></i>
                            </button>
                        </td>
                    </tr>
                `;
                tableBody.innerHTML += row; 
            });

            document.querySelectorAll('.delete-btn').forEach(button => {
                button.addEventListener('click', function() {
                    const vehicleId = this.getAttribute('data-id');
                    const vechicleModel = this.getAttribute('data-model');
            
                    vechicleToDeleteId = vehicleId;
            
                    document.getElementById('deleteVehicleName').textContent = vechicleModel;
            
                    let deleteModal = new bootstrap.Modal(document.getElementById('deleteModal'));
                    deleteModal.show();
                });
            });

            document.querySelectorAll('.edit-btn').forEach(button => {
                button.addEventListener('click', function() {
                     debugger
                    const vehicleId = this.getAttribute('data-id');
                    const vechicleType = this.getAttribute('data-type');
                    let vehicleTypeNow;
                    switch (vechicleType) {
                        case "Carro":
                          vehicleTypeNow = 0;
                            break;
                        case "Moto":
                          vehicleTypeNow = 1;
                            break;
                        case "Caminhão":
                          vehicleTypeNow = 2;
                            break;
                        default:
                          vehicleTypeNow = null;
                    }
           
                    document.getElementById('editModel').value = this.getAttribute('data-model');
                    document.getElementById('editYearManufacture').value = this.getAttribute('data-yearManufacture');
                    document.getElementById('editPrice').value = this.getAttribute('data-price');
                    document.getElementById('editType').value = vehicleTypeNow;
                    document.getElementById('editTextarea').value = this.getAttribute('data-description');


                    document.getElementById('editForm').setAttribute('data-id', vehicleId);

                    let editModal = new bootstrap.Modal(document.getElementById('editModal'));
                    editModal.show();
                });
            });

            await loadFabricators();
            await loadUserInfo();

        } else {
            alert("Erro ao buscar os dados da API.");
        }
    } catch (error) {
        console.error("Erro ao fazer a requisição:", error);
    }
}

document.getElementById('editForm').addEventListener('submit', async function(event) {
  debugger;
    event.preventDefault(); 
    const vechicleId = this.getAttribute('data-id');

    const updatedVehicle = {
        vehicleModel: document.getElementById('editModel').value,
        yearManufacture: parseInt(document.getElementById('editYearManufacture').value),
        userRole: parseInt(document.getElementById('editAccessLevel').value),
        price: parseInt(document.getElementById('editPrice').value),
        idFabricator: parseInt(document.getElementById('fabricatorSelect').value),
        vehicleType: parseInt(document.getElementById('editType').value),
        description: document.getElementById('editTextarea').value,
    };
    try {
        const response = await fetch(`https://localhost:7033/api/Vehicle/${vechicleId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(updatedVehicle) 
        });

        if (response.ok) {
            alert('Veículo atualizado com sucesso!');

            loadVehicle();
            
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
    const newVehicle = {
        vehicleModel: document.getElementById('addModel').value,
        yearManufacture: parseInt(document.getElementById('addYearManufacture').value),
        price: parseInt(document.getElementById('addPrice').value),
        idFabricator: parseInt(document.getElementById('fabricatorSelect').value),
        vehicleType: parseInt(document.getElementById('addType').value),
        description: document.getElementById('addTextarea').value,
    };

    try {
        const response = await fetch("https://localhost:7033/api/Vehicle", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newVehicle)
        });

        if (response.ok) {
            alert('Veículo adicionado com sucesso!');
            loadVehicle();

            let addModal = bootstrap.Modal.getInstance(document.getElementById('addModal'));
            addModal.hide();
            document.getElementById('addForm').reset();
        } else {
            alert('Erro ao adicionar o veículo.');
        }
    } catch (error) {
        console.error('Erro na requisição:', error);
        alert('Ocorreu um erro ao tentar adicionar o usuário.');
    }
});
document.getElementById('confirmDeleteBtn').addEventListener('click', async function() {
    if (vechicleToDeleteId) {
        try {
            const response = await fetch(`https://localhost:7033/api/Vehicle/${userToDeleteId}`, {
                method: 'DELETE'
            });

            if (response.ok) {
                alert('veículo excluído com sucesso!');

                let deleteModal = bootstrap.Modal.getInstance(document.getElementById('deleteModal'));
                deleteModal.hide();

                loadUser();
            } else {
                alert('Erro ao excluir o veículo.');
            }
        } catch (error) {
            console.error('Erro na requisição:', error);
            alert('Ocorreu um erro ao tentar excluir o veículo.');
        }
    }
});
const loadFabricators = async () => {
  try {
      const response = await fetch("https://localhost:7033/api/Fabricator");
      if (response.ok) {
          const fabricatorList = await response.json();
          let fabricatorSelect = document.getElementById('fabricatorSelect');
          fabricatorList.forEach(fabricator => {
              let option = document.createElement('option');
              option.value = fabricator.idFabricator;
              option.textContent = fabricator.name;
              fabricatorSelect.appendChild(option);
          });
      } else {
          console.error("Falha ao buscar fabricadores:", response.status);
      }
  } catch (error) {
      console.error("Erro ao carregar Fabricadores:", error);
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

document.addEventListener("DOMContentLoaded", loadVehicle);
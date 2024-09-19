let email = document.querySelector("#EmailInput");
let senha = document.querySelector("#PasswordInput");
let form  = document.querySelector("#loginForm");

form.addEventListener('submit', async function(event) {
    event.preventDefault(); 
    let data = {
        email: email.value,
        password: senha.value
    };
    try {
        const response = await fetch("https://localhost:7033/api/Auth", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (response.status === 200) {
            let responseData = await response.json(); 
            console.log(responseData);
            localStorage.setItem('userInfo', JSON.stringify(responseData)); 
            window.location.href = 'Views/Dealersh/index.html';
        } else{
            alert("Ocorreu um erro ao tentar fazer o login.");
        }
    } catch (error) {
        console.error("Erro na requisição:", error);
        alert("Ocorreu um erro ao tentar fazer o login.");
    }
});

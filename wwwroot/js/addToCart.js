async function addToCart(produsId) {
    try {
        let response = await fetch('/Account/IsAuthenticated', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            },
        });
        console.log(response);
        let data = await response.json();

        if (!data.isAuthenticated) {
            let confirmation = confirm('Trebuie să fiți autentificat pentru a adăuga produse în coș. Apăsați OK pentru a merge la pagina de autentificare.');

            if (confirmation) {
                window.location.href = '/Identity/Account/Login';
            }
            return;
        }
        else {
            await fetch('/ViewProduse/AddToCart', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ id: produsId })
            });
            alert('Produs adaugat in cos.');
            window.location.href = '/CosCumparaturi/Index';
        }
        
    } catch (error) {
        console.error('Error:', error);
        alert('A apărut o eroare. Încercați din nou.');
    }
}

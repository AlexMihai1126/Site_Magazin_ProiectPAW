async function addToCart(produsId) {
    try {
        await fetch('/Telefoane/AddToCart', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ id: produsId })
        });
        alert('Produs adaugat in cos.');
        window.location.href = '/CosCumparaturi/Index';
    } catch (error) {
        console.error('Error:', error);
        alert('A apărut o eroare. Încercați din nou.');
    }
}

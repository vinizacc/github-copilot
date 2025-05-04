// Function to validate credit card number using Luhn algorithm
function validateCreditCardNumber(cardNumber) {
    const regex = new RegExp("^[0-9]{14,16}$");
    if (!regex.test(cardNumber)) return false;

    let sum = 0;
    let shouldDouble = false;
    for (let i = cardNumber.length - 1; i >= 0; i--) {
        let intVal = parseInt(cardNumber[i]);
        if (shouldDouble) {
            intVal *= 2;
            if (intVal > 9) {
                intVal = 1 + (intVal % 10);
            }
        }
        sum += intVal;
        shouldDouble = !shouldDouble;
    }
    return (sum % 10) === 0;
}

// Function to determine the card issuer (Bandeira)
function getCardIssuer(cardNumber) {
    const cardPatterns = {
        visa: /^4[0-9]{12}(?:[0-9]{3})?$/,
        visa16: /^4[0-9]{15}$/, // New pattern for Visa with 16 digits
        mastercard: /^5[1-5][0-9]{14}$/,
        amex: /^3[47][0-9]{13}$/,
        discover: /^6(?:011|5[0-9]{2})[0-9]{12}$/,
        elo: /^(506|636|438|431|457|627)[0-9]{13,16}$/, // Updated pattern for Elo
        hipercard: /^(6062)[0-9]{10,17}$/, // Pattern for Hipercard
        dinersclub: /^3(0|6|8|9)[0-9]{12,14}$/, // Updated pattern for Diners Club
        enroute: /^2(014|149)[0-9]{11}$/, // Pattern for Enroute
        jcb: /^(?:2131|1800|35\d{3})\d{11}$/, // Pattern for JCB
        voyager: /^86[3-9][0-9]{12}$/, // Pattern for Voyager
        aura: /^50[0-9]{14,17}$/, // Pattern for Aura
        // Add more patterns as needed
    };

    for (const [issuer, pattern] of Object.entries(cardPatterns)) {
        if (pattern.test(cardNumber)) {
            return issuer;
        }
    }
    return 'unknown';
}

// Example usage
const cardNumber = "5047525051203529"; // Replace with actual card number
if (validateCreditCardNumber(cardNumber)) {
    const issuer = getCardIssuer(cardNumber);
    console.log(`Card is valid. Issuer: ${issuer}`);
} else {
    console.log("Card is invalid.");
}
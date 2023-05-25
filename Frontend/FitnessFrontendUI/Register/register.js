// Autofill the form fields
var form = document.getElementById("registerform");
form.username.value = "Gica";
form.email.value = "gica@example.com";
form.password.value = "secretpassword";

function handleFormSubmit(event) {
    event.preventDefault();

    // Perform form submission actions

    // Redirect to the main page after successful form submission
    window.location.href = "../index.html";

    return false;
  }